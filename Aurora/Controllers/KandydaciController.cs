using Aurora.Data;
using Aurora.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            if (!string.IsNullOrEmpty(searchFilter))
            {
                kandydaci = kandydaci.Where(k => czyDaneOsoboweSąPodobne(k.Imie, k.Nazwisko, searchFilter)).ToList();
            }

            ViewBag.SearchFilter = searchFilter;

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

        public async Task<IActionResult> PrzypiszKandydata(int? id)
        { 
            var kandydat = await _context.Kandydaci.FindAsync(id);
            if (kandydat != null)
            {
                return View(kandydat);
            }
            return View("Error");
        }

        private bool czyDaneOsoboweSąPodobne(string Imie, string Nazwisko, string SearchText) 
        {
            return string.Equals(Nazwisko, SearchText, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(Imie, SearchText, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals($"{Nazwisko} {Imie}", SearchText, StringComparison.OrdinalIgnoreCase);
        }
        


        
    }
}
