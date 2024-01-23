using Aurora.Data;
using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
using Aurora.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aurora.Controllers
{
    public class KandydaciController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public KandydaciController(DataDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(string searchFilter, string sortOption = "ID")
        {
            var kandydaci = _context.Kandydaci.ToList();

            if (!string.IsNullOrEmpty(searchFilter))
            {
                kandydaci = kandydaci.Where(k => StringUtils.CzyKandydatPasuje(k.Imie, k.Nazwisko, searchFilter)).ToList();
            }

            switch (sortOption)
            {
                case "NazwiskoAsc":
                    kandydaci = kandydaci.OrderBy(k => $"{k.Nazwisko} {k.Imie}").ToList();
                    break;
                case "NazwiskoDesc":
                    kandydaci = kandydaci.OrderByDescending(k => $"{k.Nazwisko} {k.Imie}").ToList();
                    break;
                default:
                    kandydaci = kandydaci.OrderBy(k => k.ID).ToList();
                    break;
            }

            ViewBag.SortOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "Domyślnie", Value = "ID" },
                new SelectListItem { Text = "Alfabetycznie (rosnąco)", Value = "NazwiskoAsc" },
                new SelectListItem { Text = "Alfabetycznie (malejąco)", Value = "NazwiskoDesc" }
            };

            ViewBag.SelectedSortOption = sortOption;

            ViewBag.SearchFilter = searchFilter;
            TempData["SortOption"] = sortOption;

            return View(kandydaci);
        }

        
        public async Task<IActionResult> PrzypiszKandydata(int? id, PrzypiszKandydataViewModel model, string PostMessage = "")

        {
            if (id == null) return NotFound();

            var kandydat = await _context.Kandydaci.FindAsync(id);

            if (kandydat == null) return NotFound();

            if (model == null) model = new PrzypiszKandydataViewModel();

            var aplikacje = GetAktualneAplikacje(id);

            model.Kandydat = kandydat;

            int liczbaAplikacjiPrzedFiltrowaniem = aplikacje.Count;

            if (!string.IsNullOrEmpty(model.SearchFilter)) aplikacje = aplikacje.Where(a => a.KierunekStudiow.NazwaKierunku.Contains(model.SearchFilter)).ToList();

            if (!string.IsNullOrEmpty(model.FilterPoziom) && model.FilterPoziom != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.PoziomStudiow == Convert.ToInt32(model.FilterPoziom)).ToList();

            if (!string.IsNullOrEmpty(model.FilterForma) && model.FilterForma != "dowolna") aplikacje = aplikacje.Where(a => a.KierunekStudiow.FormaStudiow == Convert.ToInt32(model.FilterForma)).ToList();

            if (!string.IsNullOrEmpty(model.FilterJezyk) && model.FilterJezyk != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.JezykWykladowy == Convert.ToInt32(model.FilterJezyk)).ToList();

            if (!string.IsNullOrEmpty(model.FilterWydzial) && model.FilterWydzial != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.Wydzial == Convert.ToInt32(model.FilterWydzial)).ToList();

            if (!string.IsNullOrEmpty(model.FilterMiejsce) && model.FilterMiejsce != "dowolne") aplikacje = aplikacje.Where(a => a.KierunekStudiow.MiejsceStudiow == Convert.ToInt32(model.FilterMiejsce)).ToList();

            ViewBag.PopUpMessage = PostMessage;
            model.FilterAplikacje = aplikacje;

            if (aplikacje.Count == 0) {
                if (liczbaAplikacjiPrzedFiltrowaniem != 0)
                {
                    ViewBag.PopUpMessage = "Nie znaleziono pasujących wyników do podanych kryteriów wyszukiwania.";
                }

                // czy zrobić osobne komunikaty dla przypadku gdy kandydat nie ma żadnych aplikacji
                // oraz dla przypadku gdy nie ma aplikacji, które nie spełniają kryteriów wyszukiwania

                ViewBag.NoResultMessage = $"Kandydat {kandydat.Imie} {kandydat.Nazwisko} nie posiada w aktualnej turze rekrutacji aplikacji spełniające podane kryteria wyszukiwania.";

            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> PrzypiszKandydata(int id)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.Include(a => a.KierunekStudiow).Where(a => a.ID == id).FirstOrDefaultAsync();
            if (aplikacja == null) return NotFound();

            var tura = await _context.TuryRekrutacji.FindAsync(aplikacja.TuraRekrutacjiID);

            if (tura == null) return NotFound();

            string PostMessage = "";

            if (tura.DostepneMiejsca > 0)
            {
                ++tura.LiczbaZajetychMiejsc;

                _context.TuryRekrutacji.Update(tura);

                _context.KandydaciTuryRekrutacji.Add(new KandydatTuraRekrutacji(aplikacja.KandydatID, tura.ID));

                aplikacja.Status = Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaSukcesem);

                _context.AplikacjeRekrutacyjne.Update(aplikacja);

                //await _context.SaveChangesAsync();

                var kandydat = await _context.Kandydaci.FindAsync(aplikacja.KandydatID);

                PostMessage = $"Kandydat {kandydat.Imie} {kandydat.Nazwisko} został pomyślnie przypisany do kierunku {aplikacja.KierunekStudiow.NazwaKierunku}.";
            }
            else 
            {
                PostMessage = $"Brak wolnych miejsc na kierunku {aplikacja.KierunekStudiow.NazwaKierunku}";
            }


            return RedirectToAction("PrzypiszKandydata", new {
                aplikacja.KandydatID,
                PostMessage

            });
         }

        public async Task<IActionResult> WyslijWiadomosc(int id, string PostMessage = "") 
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.Include(a => a.KierunekStudiow)
                                                                 .Include(a => a.Kandydat)
                                                                 .Where(a => a.ID == id)
                                                                 .FirstOrDefaultAsync();

            if (aplikacja == null) return NotFound();

            if (!string.IsNullOrEmpty(PostMessage)) ViewBag.Message = PostMessage;


            (ViewBag.ImieUsera, ViewBag.NazwiskoUsera, ViewBag.IDUsera) = UserUtils.GetDanePracownika(_context);

            return View(aplikacja);
        }

        [HttpPost]
        public async Task<IActionResult> WyslijWiadomosc(int aplikacjaId, int pracownikId, string content)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.FindAsync(aplikacjaId);

            if (aplikacja == null) return NotFound();

            var kandydat = await _context.Kandydaci.FindAsync(aplikacja.KandydatID);

            if (kandydat == null) return NotFound();

            string PopUpMessage;

            if (string.IsNullOrEmpty(content))
            {

                PopUpMessage = $"Wiadomość do {kandydat.Imie} {kandydat.Nazwisko} nie została wysłana - wiadomość jest pusta.";
            }
            else
            {
                Wiadomosc wiadomosc = new Wiadomosc
                {
                    KandydatID = aplikacja.KandydatID,
                    PracownikDziekanatuID = pracownikId,
                    Tresc = content
                };
                _context.Wiadomosci.Add(wiadomosc);
                //await _context.SaveChangesAsync();

                PopUpMessage = $"Wiadomość do {kandydat.Imie} {kandydat.Nazwisko} została pomyślnie wysłana.";
            }

            return RedirectToAction("WyslijWiadomosc", new { aplikacjaId, PostMessage = PopUpMessage });
        }



        



        private List<AplikacjaRekrutacyjna> GetAktualneAplikacje(int? id)
        { 
            return _context.AplikacjeRekrutacyjne.Include(a => a.TuraRekrutacji)
                                                 .Include(a => a.Kandydat)
                                                 .Include(a => a.KierunekStudiow)
                                                 .Where(a => a.KandydatID == id &&
                                                            a.Status == Convert.ToInt32(RodzajStatusuAplikacji.OczekujeNaRozpatrzenie) &&
                                                            a.DataZlozenia <= a.TuraRekrutacji.TerminZakonczeniaPrzyjmowaniaAplikacji &&
                                                            a.DataZlozenia >= a.TuraRekrutacji.DataOtwarcia &&
                                                            (a.TuraRekrutacji.StatusTury == Convert.ToInt32(RodzajStatusuTury.zamknieta) ||
                                                            a.TuraRekrutacji.StatusTury == Convert.ToInt32(RodzajStatusuTury.otwarta))
                                                 )
                                                 .ToList();
        }

        


        
    }
}
