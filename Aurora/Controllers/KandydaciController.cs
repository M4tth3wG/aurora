using Aurora.Data;
using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
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
        private readonly ISession _session;

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
                kandydaci = kandydaci.Where(k => CzyKandydatPasuje(k.Imie, k.Nazwisko, searchFilter)).ToList();
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

        
        public async Task<IActionResult> PrzypiszKandydata(int? id, string searchFilter = "",
            string filterPoziom = "dowolny", string filterForma = "dowolna", string filterJezyk = "dowolny",
            string filterWydzial = "dowolny", string filterMiejsce = "dowolne", string PostMessage = "")
        { 
            var kandydat = await _context.Kandydaci.FindAsync(id);
            if (kandydat != null)
            {
                var aplikacje = GetAktualneAplikacje(id);

                ViewBag.searchFilter = searchFilter;
                ViewBag.Imie = kandydat.Imie;
                ViewBag.Nazwisko = kandydat.Nazwisko;
                ViewBag.ID = kandydat.ID;

                int liczbaAplikacjiPrzedFiltrowaniem = aplikacje.Count;

                if (!string.IsNullOrEmpty(searchFilter)) 
                { 
                    aplikacje = aplikacje.Where(a => a.KierunekStudiow.NazwaKierunku.Contains(searchFilter)).ToList();
                }

                ViewBag.FilterOptionsPoziom = EnumUtils.GetWartosciEnumaJakoSelectList<PoziomStudiow>();
                TempData["FilterPoziom"] = filterPoziom;
                if (!string.IsNullOrEmpty(filterPoziom) && filterPoziom != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.PoziomStudiow == Convert.ToInt32(filterPoziom)).ToList();
                ViewBag.SelectedFilterPoziom = filterPoziom;

                ViewBag.FilterOptionsForma = EnumUtils.GetWartosciEnumaJakoSelectList<FormaStudiow>();
                TempData["FilterForma"] = filterForma;
                if (!string.IsNullOrEmpty(filterForma) && filterForma != "dowolna") aplikacje = aplikacje.Where(a => a.KierunekStudiow.FormaStudiow == Convert.ToInt32(filterForma)).ToList();
                ViewBag.SelectedFilterForma = filterForma;

                ViewBag.FilterOptionsJezyk = EnumUtils.GetWartosciEnumaJakoSelectList<Jezyk>();
                TempData["FilterJezyk"] = filterJezyk;
                if (!string.IsNullOrEmpty(filterJezyk) && filterJezyk != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.JezykWykladowy == Convert.ToInt32(filterJezyk)).ToList();
                ViewBag.SelectedFilterJezyk = filterJezyk;

                ViewBag.FilterOptionsWydzial = EnumUtils.GetWartosciEnumaJakoSelectList<NazwaWydzialu>();
                TempData["FilterWydzial"] = filterWydzial;
                if (!string.IsNullOrEmpty(filterWydzial) && filterWydzial != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.Wydzial == Convert.ToInt32(filterWydzial)).ToList();
                ViewBag.SelectedFilterWydzial = filterWydzial;

                ViewBag.FilterOptionsMiejsce = EnumUtils.GetWartosciEnumaJakoSelectList<MiejsceStudiow>();
                TempData["FilterMiejsce"] = filterMiejsce;
                if (!string.IsNullOrEmpty(filterMiejsce) && filterMiejsce != "dowolne") aplikacje = aplikacje.Where(a => a.KierunekStudiow.MiejsceStudiow == Convert.ToInt32(filterMiejsce)).ToList();
                ViewBag.SelectedFilterMiejsce = filterMiejsce;

                ViewBag.PopUpMessage = PostMessage;

                if (aplikacje.Count == 0) {
                    if (liczbaAplikacjiPrzedFiltrowaniem != 0)
                    {
                        ViewBag.PopUpMessage = "Nie znaleziono pasujących wyników do podanych kryteriów wyszukiwania.";
                    }
                    ViewBag.NoResultMessage = $"Kandydat {kandydat.Imie} {kandydat.Nazwisko} nie posiada w aktualnej turze rekrutacji aplikacji spełniające podane kryteria wyszukiwania.";

                }

                return View(aplikacje);
            }
            return View("Error");
        }


        [HttpPost]
        public async Task<IActionResult> PrzypiszKandydata(int id, string searchFilter,
            string filterPoziom, string filterForma, string filterJezyk,
            string filterWydzial, string filterMiejsce)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.Include(a => a.KierunekStudiow).Where(a => a.ID == id).FirstOrDefaultAsync();
            if (aplikacja == null) return View("Error");

            var tura = await _context.TuryRekrutacji.FindAsync(aplikacja.TuraRekrutacjiID);

            if (tura == null)
            {
                return View("Error");
            }

            string PostMessage = "";

            if (tura.DostepneMiejsca > 0)
            {
                ++tura.LiczbaZajetychMiejsc;

                _context.TuryRekrutacji.Update(tura);

                aplikacja.Status = Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaSukcesem);

                _context.AplikacjeRekrutacyjne.Update(aplikacja);

                var kandydat = await _context.Kandydaci.FindAsync(aplikacja.KandydatID);

                if (kandydat == null) return View("Error");

                PostMessage = $"Kandydat {kandydat.Imie} {kandydat.Nazwisko} został pomyślnie przypisany do kierunku {aplikacja.KierunekStudiow.NazwaKierunku}.";

                //await _context.SaveChangesAsync();
                
            }
            else 
            {
                PostMessage = $"Brak wolnych miejsc na kierunku {aplikacja.KierunekStudiow.NazwaKierunku}";
            }



            return RedirectToAction("PrzypiszKandydata", new {
                aplikacja.KandydatID, searchFilter, filterPoziom, filterForma, filterJezyk, filterWydzial, filterMiejsce, PostMessage

            });
         }

        public async Task<IActionResult> WyslijWiadomosc(int id, string PostMessage = "") 
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.Include(a => a.KierunekStudiow)
                                                                 .Include(a => a.Kandydat)
                                                                 .Where(a => a.ID == id)
                                                                 .FirstOrDefaultAsync();

            if (aplikacja == null) return View("Error");

            if (!string.IsNullOrEmpty(PostMessage)) ViewBag.Message = PostMessage;


            (ViewBag.ImieUsera, ViewBag.NazwiskoUsera, ViewBag.IDUsera) = UserUtils.GetDanePracownika(_context);

            return View(aplikacja);
        }

        [HttpPost]
        public async Task<IActionResult> WyslijWiadomosc(int aplikacjaId, int pracownikId, string tresc)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.FindAsync(aplikacjaId);

            if (aplikacja == null) return View("Error");

            var kandydat = await _context.Kandydaci.FindAsync(aplikacja.KandydatID);

            if (kandydat == null) return View("Error");

            string Message;

            if (string.IsNullOrEmpty(tresc))
            {

                Message = $"Wiadomość do {kandydat.Imie} {kandydat.Nazwisko} nie została wysłana - wiadomość jest pusta.";
            }
            else
            {
                Wiadomosc wiadomosc = new Wiadomosc
                {
                    KandydatID = aplikacja.KandydatID,
                    PracownikDziekanatuID = pracownikId,
                    Tresc = tresc
                };
                _context.Wiadomosci.Add(wiadomosc);
                //await _context.SaveChangesAsync();

                Message = $"Wiadomość do {kandydat.Imie} {kandydat.Nazwisko} została pomyślnie wysłana.";
            }

            return RedirectToAction("WyslijWiadomosc", new { aplikacjaId, PostMessage = Message });
        }


        private bool CzyKandydatPasuje(string Imie, string Nazwisko, string SearchText) 
        {
            //return string.Equals(Nazwisko, SearchText, StringComparison.OrdinalIgnoreCase) ||
            //       string.Equals(Imie, SearchText, StringComparison.OrdinalIgnoreCase) ||
            //       string.Equals($"{Nazwisko} {Imie}", SearchText, StringComparison.OrdinalIgnoreCase);
            var imieMalaLitera = Imie.ToLower();
            var nazwiskoMalaLitera = Nazwisko.ToLower();
            var SearchTextMalaLitera = SearchText.ToLower();
            var polaczoneNazwiskoIImie = $"{nazwiskoMalaLitera} {imieMalaLitera}";

            return imieMalaLitera.Contains(SearchTextMalaLitera) ||
                   nazwiskoMalaLitera.Contains(SearchTextMalaLitera) ||
                   polaczoneNazwiskoIImie.Contains(SearchTextMalaLitera);
                    
        }
        



        private List<AplikacjaRekrutacyjna> GetAktualneAplikacje(int? id)
        { 
            return _context.AplikacjeRekrutacyjne.Include(a => a.TuraRekrutacji)
                                                 .Include(a => a.Kandydat)
                                                 .Include(a => a.KierunekStudiow)
                                                 .Where(a => a.KandydatID == id &&
                                                            a.Status == Convert.ToInt32(RodzajStatusuAplikacji.OczekujeNaRozpatrzenie) &&
                                                            (a.TuraRekrutacji.StatusTury == Convert.ToInt32(RodzajStatusuTury.zamknieta) ||
                                                            a.TuraRekrutacji.StatusTury == Convert.ToInt32(RodzajStatusuTury.otwarta))
                                                 )
                                                 .ToList();
        }

        


        
    }
}
