using Aurora.Data;
using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.OtherClasses.StrategiesForRR;
using Aurora.Utils;
using Aurora.ViewModels;
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
            if (kierunek == null)
            {
                return View("Error");
            }

            var strategia = UtilsRR.GetStrategiaDlaKierunku(kierunek);

            var (listaBrakujacychPrzedmiotow, czyWprowadzonoEgzaminZRysunku) = CzyWprowadzonoWszystkiePotrzebneWartosci(strategia, model);
            if (listaBrakujacychPrzedmiotow.Count > 0)
            {
                ViewBag.PopUpMessage = $"Brak podanego przynajmniej jednego wyniku dla przedmiotu {StringUtils.ConvertListToTupleFormat(listaBrakujacychPrzedmiotow)}.";
            }
            else if (strategia is StrategiaArchitektura && !czyWprowadzonoEgzaminZRysunku)
            {
                ViewBag.PopUpMessage = "Brak podanego wyniku dla egzaminu z rysunku.";
            }
            else 
            {
                ViewBag.WartoscWR = ObliczPunktyWspolczynnika(strategia, model);
            }

            return View(model); 
        }


        private (List<string>, bool) CzyWprowadzonoWszystkiePotrzebneWartosci(StrategiaWspolRekrut strategia, WyliczWspolczynnikViewModel model)
        {
            return strategia switch
            {
                StrategiaWspolRekrut1Stopien st1 => CzyWprowadzonoWszystkiePotrzebneWartosciStopien1(st1, model),
                _ => default,
            };
        }


        private (List<string>, bool) CzyWprowadzonoWszystkiePotrzebneWartosciStopien1(StrategiaWspolRekrut1Stopien strategia, WyliczWspolczynnikViewModel model)
        {
            var brakujacePrzedmioty = new List<string>();
            var czyWprowadzonoEgzamin = true;

            foreach(var subject in strategia.przedmiotyMaturalne)
            {
                var (keyP, keyR) = Consts.SubjectFormKeys[subject];
                if (model.wynikiMaturalne[keyP] == null && model.wynikiMaturalne[keyR] == null) brakujacePrzedmioty.Add(EnumUtils.GetDescription<PrzedmiotMaturalny>(subject));
            }

            if (model.wynikiMaturalne["EgzRys"] == null) czyWprowadzonoEgzamin = false;
           
            return (brakujacePrzedmioty, czyWprowadzonoEgzamin);
        }

        private double? ObliczPunktyWspolczynnika(StrategiaWspolRekrut strategia, WyliczWspolczynnikViewModel model)
        {
            if (strategia == null || model == null) return null;
            var components = UtilsRR.ConvertFormPointsToComponents(model);
            return strategia.WyliczPunkty(components);
        }








    }
}
