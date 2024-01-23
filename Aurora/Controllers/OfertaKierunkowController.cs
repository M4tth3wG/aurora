using Aurora.Data;
using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.OtherClasses.StrategiesForRR;
using Aurora.Utils;
using Aurora.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aurora.Controllers
{
    public class OfertaKierunkowController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public OfertaKierunkowController(DataDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(string searchFilter = "",
                   string filterPoziom = "dowolny", string filterForma = "dowolna", string filterJezyk = "dowolny",
                   string filterWydzial = "dowolny", string filterMiejsce = "dowolne", string PostMessage = "")
        {

            var kierunki = await _context.KierunkiStudiow.ToListAsync();

            ViewBag.searchFilter = searchFilter;

            int liczbaKierunkowPrzedFiltrowaniem = kierunki.Count;

            if (!string.IsNullOrEmpty(searchFilter))
            {
                kierunki = kierunki.Where(a => StringUtils.IsSubstring(a.NazwaKierunku, searchFilter)).ToList();
            }

            ViewBag.FilterOptionsPoziom = EnumUtils.GetWartosciEnumaJakoSelectList<PoziomStudiow>();
            TempData["FilterPoziom"] = filterPoziom;
            if (!string.IsNullOrEmpty(filterPoziom) && filterPoziom != "dowolny") kierunki = kierunki.Where(a => a.PoziomStudiow == Convert.ToInt32(filterPoziom)).ToList();
            ViewBag.SelectedFilterPoziom = filterPoziom;

            ViewBag.FilterOptionsForma = EnumUtils.GetWartosciEnumaJakoSelectList<FormaStudiow>();
            TempData["FilterForma"] = filterForma;
            if (!string.IsNullOrEmpty(filterForma) && filterForma != "dowolna") kierunki = kierunki.Where(a => a.FormaStudiow == Convert.ToInt32(filterForma)).ToList();
            ViewBag.SelectedFilterForma = filterForma;

            ViewBag.FilterOptionsJezyk = EnumUtils.GetWartosciEnumaJakoSelectList<Jezyk>();
            TempData["FilterJezyk"] = filterJezyk;
            if (!string.IsNullOrEmpty(filterJezyk) && filterJezyk != "dowolny") kierunki = kierunki.Where(a => a.JezykWykladowy == Convert.ToInt32(filterJezyk)).ToList();
            ViewBag.SelectedFilterJezyk = filterJezyk;

            ViewBag.FilterOptionsWydzial = EnumUtils.GetWartosciEnumaJakoSelectList<NazwaWydzialu>();
            TempData["FilterWydzial"] = filterWydzial;
            if (!string.IsNullOrEmpty(filterWydzial) && filterWydzial != "dowolny") kierunki = kierunki.Where(a => a.Wydzial == Convert.ToInt32(filterWydzial)).ToList();
            ViewBag.SelectedFilterWydzial = filterWydzial;

            ViewBag.FilterOptionsMiejsce = EnumUtils.GetWartosciEnumaJakoSelectList<MiejsceStudiow>();
            TempData["FilterMiejsce"] = filterMiejsce;
            if (!string.IsNullOrEmpty(filterMiejsce) && filterMiejsce != "dowolne") kierunki = kierunki.Where(a => a.MiejsceStudiow == Convert.ToInt32(filterMiejsce)).ToList();
            ViewBag.SelectedFilterMiejsce = filterMiejsce;

            ViewBag.PopUpMessage = PostMessage;

            if (kierunki.Count == 0 && liczbaKierunkowPrzedFiltrowaniem != 0)
            {
                ViewBag.PopUpMessage = "Nie znaleziono pasujących wyników do podanych kryteriów wyszukiwania.";
            }

            return View(kierunki);

        }

        [HttpGet]
        public async Task<IActionResult> WyliczWspolczynnik(int id)
        {
            var kierunek = await _context.KierunkiStudiow.FindAsync(id);
            if (kierunek == null)
            {
                return View("Error");
            }

            return View(new WyliczWspolczynnikViewModel(kierunek));
        }

        [HttpPost]
        public async Task<IActionResult> WyliczWspolczynnik(WyliczWspolczynnikViewModel model)
        {

            if (model == null) return View("Error");

            var kierunek = await _context.KierunkiStudiow.FindAsync(model.KierunekID);

            if (kierunek == null) return NotFound();

            var strategia = kierunek.Strategia;

            var skladowe = UtilsRR.ConvertModelToComponents(model);

            var listaBrakujacychPrzedmiotow = strategia.GetMissingSubjects(skladowe);

            var czyWprowadzonoEgzaminZRysunku = model.wynikiMaturalne["EgzRys"] != null;

            if (listaBrakujacychPrzedmiotow.Count > 0) ViewBag.PopUpMessage = $"Brak podanego przynajmniej jednego wyniku dla przedmiotu {StringUtils.ConvertListToTupleFormat(listaBrakujacychPrzedmiotow)}.";

            else if (strategia is StrategiaArchitektura && !czyWprowadzonoEgzaminZRysunku) ViewBag.PopUpMessage = "Brak podanego wyniku dla egzaminu z rysunku.";

            else ViewBag.WartoscWR = strategia.GetTotalPoints(skladowe);

            return View(model);
        }




        // Obsluga funkconalnosci pracownika dziekanatu: Mateusz Gazda

        [Authorize(Roles ="PracownikDziekanatu")]
        public IActionResult IndexPracownik()
        {
            return View();
        }

        [Authorize(Roles = "PracownikDziekanatu")]
        public IActionResult DodajNowyKierunekStudiow()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PracownikDziekanatu")]
        public IActionResult DodajNowyKierunekStudiow(KierunekStudiowKluczViewModel klucz)
        {

            if (ModelState.IsValid)
            {
                KierunekStudiow kierunek = new KierunekStudiow()
                {
                    NazwaKierunku = klucz.NazwaKierunku,
                    JezykWykladowy = (int)klucz.JezykWykladowy,
                    MiejsceStudiow = (int)klucz.MiejsceStudiow,
                    FormaStudiow = (int)klucz.FormaStudiow,
                    PoziomStudiow = (int)klucz.PoziomStudiow
                };

                if (CzyKluczKierunkuUnikalny(kierunek))
                {
                    return RedirectToAction(nameof(DodajNowyKierunekStudiowSzczegoly), kierunek);
                }

                return RedirectToAction(nameof(ZduplikowanyKierunek), klucz);
            }
            
            return View(klucz);
        }

        public IActionResult ZduplikowanyKierunek(KierunekStudiowKluczViewModel klucz)
        {
            ViewBag.PopUpMessage = "Istnieje już kierunek o podanych danych.";
            return View("DodajNowyKierunekStudiow", klucz);
        }

        [Authorize(Roles = "PracownikDziekanatu")]
        public IActionResult DodajNowyKierunekStudiowSzczegoly(KierunekStudiow kierunek)
        {
            return View(kierunek);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PracownikDziekanatu")]
        public async Task<IActionResult> DodajNowyKierunekStudiowSzczegolyPost(KierunekStudiow kierunek)
        {
            if (!ModelState.IsValid)
            {
                return View("DodajNowyKierunekStudiowSzczegoly", kierunek);
            }

            _context.Add(kierunek);
            await _context.SaveChangesAsync();

            ViewBag.PopUpMessage = "Pomyślnie dodano nowy kierunek studiów.";

            return View("DodajNowyKierunekStudiowSzczegoly", kierunek);
        }

        private bool CzyKluczKierunkuUnikalny(KierunekStudiow klucz)
        {
            var kierunki = _context.KierunkiStudiow.ToList();

            return !kierunki.Any(k => 
            
                    k.NazwaKierunku.ToLower().Trim()
                        .Equals(klucz.NazwaKierunku.ToLower().Trim()) 
                    &&
                    k.JezykWykladowy == klucz.JezykWykladowy
                    &&
                    k.FormaStudiow == klucz.FormaStudiow
                    &&
                    k.MiejsceStudiow == klucz.MiejsceStudiow
                    &&
                    k.PoziomStudiow == klucz.PoziomStudiow
            );
        }

    }
}
