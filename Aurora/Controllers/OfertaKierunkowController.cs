using Aurora.Data;
using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aurora.Controllers
{
    public class OfertaKierunkowController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ISession _session;

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
               kierunki = kierunki.Where(a => a.NazwaKierunku.Contains(searchFilter)).ToList();
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








    }
}
