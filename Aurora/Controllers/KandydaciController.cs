using Aurora.Data;
using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
using Aurora.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private readonly UserManager<IdentityUser> _userManager;

        public KandydaciController(DataDbContext context, IWebHostEnvironment hostEnvironment, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(KandydaciIndexViewModel model)
        {

            //var serializedModel = TempData["PreviousModel"] as string;

            //if (!string.IsNullOrEmpty(serializedModel))
            //{
            //    model = JsonConvert.DeserializeObject<KandydaciIndexViewModel>(serializedModel);
            //}

            var aplikacje = new List<AplikacjaRekrutacyjna> { };

            if (!model.CzyDowolnyWydzial)
            {
                aplikacje = GetAktualneAplikacje();

                aplikacje = aplikacje.Where(a => a.KierunekStudiow.Wydzial == Convert.ToInt32(model.FilterWydzial)).ToList();

                int liczbaAplikacjiPrzedFiltrowaniemBezWydzialu = aplikacje.Count;

                if (!string.IsNullOrEmpty(model.SearchFilter)) aplikacje = aplikacje.Where(a => a.KierunekStudiow.NazwaKierunku.Contains(model.SearchFilter)).ToList();

                if (!string.IsNullOrEmpty(model.FilterPoziom) && model.FilterPoziom != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.PoziomStudiow == Convert.ToInt32(model.FilterPoziom)).ToList();

                if (!string.IsNullOrEmpty(model.FilterForma) && model.FilterForma != "dowolna") aplikacje = aplikacje.Where(a => a.KierunekStudiow.FormaStudiow == Convert.ToInt32(model.FilterForma)).ToList();

                if (!string.IsNullOrEmpty(model.FilterJezyk) && model.FilterJezyk != "dowolny") aplikacje = aplikacje.Where(a => a.KierunekStudiow.JezykWykladowy == Convert.ToInt32(model.FilterJezyk)).ToList();

                if (!string.IsNullOrEmpty(model.FilterMiejsce) && model.FilterMiejsce != "dowolne") aplikacje = aplikacje.Where(a => a.KierunekStudiow.MiejsceStudiow == Convert.ToInt32(model.FilterMiejsce)).ToList();

                aplikacje = aplikacje.OrderByDescending(a => a.WspolczynnikRekrutacyjny.Wartosc).ToList();


                if (aplikacje.Count == 0)
                {
                    if (liczbaAplikacjiPrzedFiltrowaniemBezWydzialu == 0)
                    {
                        ViewBag.NoResultMessage = "W aktualnej turze rekrutacji nie ma aplikacji na wybranym wydziale.";
                    }

                    else
                    {
                        ViewBag.PopUpMessage = "Nie znaleziono pasujących wyników do podanych kryteriów wyszukiwania.";
                        ViewBag.NoResultMessage = "W aktualnej turze rekrutacji nie ma aplikacji spełniające wymagania.";

                    }

                }

            }

            model.FilterAplikacje = aplikacje;

            ViewBag.PopUpMessage = model.PostMessage;

            //TempData["PreviousModel"] = JsonConvert.SerializeObject(model);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(KandydaciIndexViewModel model, int operationCode, int applicationId)
        {

            //var serializedModel = TempData["PreviousModel"] as string;

            //if (!string.IsNullOrEmpty(serializedModel))
            //{
            //    model = JsonConvert.DeserializeObject<KandydaciIndexViewModel>(serializedModel);
            //}

            var aplikacja = await _context.AplikacjeRekrutacyjne.Include(a => a.KierunekStudiow).Where(a => a.ID == applicationId).FirstOrDefaultAsync();

            if (aplikacja == null) return NotFound();

            var tura = await _context.TuryRekrutacji.FindAsync(aplikacja.TuraRekrutacjiID);

            if (tura == null) return NotFound();

            if (operationCode == 1)
            {
                model.PostMessage = await PrzypiszKandydata(aplikacja, tura);
            }
            else if (operationCode == 2)
            {
                model.PostMessage = await OdrzucKandydata(aplikacja);
            }

            //TempData["PreviousModel"] = JsonConvert.SerializeObject(model);

            return RedirectToAction(nameof(Index),  model);

        }

        private async Task<string> PrzypiszKandydata(AplikacjaRekrutacyjna aplikacja,TuraRekrutacji tura)
        {
            if (tura.DostepneMiejsca > 0)
            {
                ++tura.LiczbaZajetychMiejsc;

                _context.TuryRekrutacji.Update(tura);

                _context.KandydaciTuryRekrutacji.Add(new KandydatTuraRekrutacji(aplikacja.KandydatID, tura.ID));

                aplikacja.Status = Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaSukcesem);

                _context.AplikacjeRekrutacyjne.Update(aplikacja);

                await _context.SaveChangesAsync();

                var kandydat = await _context.Kandydaci.FindAsync(aplikacja.KandydatID);

                return $"Kandydat {kandydat.Imie} {kandydat.Nazwisko} został pomyślnie przypisany do kierunku {aplikacja.KierunekStudiow.NazwaKierunku}.";
            }
            return $"Brak wolnych miejsc na kierunku {aplikacja.KierunekStudiow.NazwaKierunku}";

        }

        private async Task<string> OdrzucKandydata(AplikacjaRekrutacyjna aplikacja)
        {
            aplikacja.Status = Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaNiepowodzeniem);
            _context.AplikacjeRekrutacyjne.Update(aplikacja);
            //await _context.SaveChangesAsync();
            var kandydat = await _context.Kandydaci.FindAsync(aplikacja.KandydatID);
            return $"Kandydat {kandydat.Imie} {kandydat.Nazwisko} został pomyślnie przypisany do kierunku {aplikacja.KierunekStudiow.NazwaKierunku}.";
        }

        public async Task<IActionResult> WyslijWiadomosc(int aplikacjaId, string PostMessage = "") 
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne.Include(a => a.KierunekStudiow)
                                                                 .Include(a => a.Kandydat)
                                                                 .Where(a => a.ID == aplikacjaId)
                                                                 .FirstOrDefaultAsync();

            if (aplikacja == null) return NotFound();

            if (!string.IsNullOrEmpty(PostMessage)) ViewBag.Message = PostMessage;


            (ViewBag.ImiePracownika, ViewBag.NazwiskoPracownika, ViewBag.IDPracownika) = await GetDanePracownika();

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
                await _context.SaveChangesAsync();

                PopUpMessage = $"Wiadomość do {kandydat.Imie} {kandydat.Nazwisko} została pomyślnie wysłana.";
            }

            return RedirectToAction("WyslijWiadomosc", new { aplikacjaId, PostMessage = PopUpMessage });
        }


        public async Task<(string, string, int)> GetDanePracownika()
        {

            var user = await _userManager.GetUserAsync(User);
            var pracownik = _context.PracownicyDziekanatu.FirstOrDefault(p => p.AdresEmail == user.Email);
            return (pracownik.Imie, pracownik.Nazwisko, pracownik.ID);
        }   




        private List<AplikacjaRekrutacyjna> GetAktualneAplikacje()
        {
            return _context.AplikacjeRekrutacyjne.Include(a => a.TuraRekrutacji)
                                                 .Include(a => a.Kandydat)
                                                 .Include(a => a.KierunekStudiow)
                                                 .Include(a => a.WspolczynnikRekrutacyjny)
                                                    .ThenInclude(w => w.skladowe)
                                                 .Where(a => a.Status == Convert.ToInt32(RodzajStatusuAplikacji.OczekujeNaRozpatrzenie) &&
                                                             a.DataZlozenia <= a.TuraRekrutacji.TerminZakonczeniaPrzyjmowaniaAplikacji &&
                                                             a.DataZlozenia >= a.TuraRekrutacji.DataOtwarcia &&
                                                             (a.TuraRekrutacji.StatusTury == Convert.ToInt32(RodzajStatusuTury.zamknieta) ||
                                                             a.TuraRekrutacji.StatusTury == Convert.ToInt32(RodzajStatusuTury.otwarta))
                                                 ).ToList(); ;
        }

        


        
    }
}
