using Aurora.Data;
using Aurora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Aurora.Controllers
{
    public class AplikacjeController : Controller
    {
        private readonly DataDbContext _context;

        public AplikacjeController(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // TODO aplikacje dla zalogowanego kandydata

            var aplikacje = _context.AplikacjeRekrutacyjne
                .Include(a => a.KierunekStudiow)
                .Include(a => a.Kandydat)
                .Where(a => true) /*dodac wyszukiwanie po emailu zalogowanego kanydata*/
                .Include(a => a.TuraRekrutacji)
                .Where(a =>
                    a.TuraRekrutacji.StatusTury != (int)Enums.RodzajStatusuTury.anulowana
                    &&
                    a.TuraRekrutacji.StatusTury != (int)Enums.RodzajStatusuTury.zakonczona
                )
                .ToListAsync();


            return View(await aplikacje);
        }

        public async Task<IActionResult> Details(int id)
        {
            // TODO zabezpieczyć przed przeglądaniem nie swoich aplikacji

            var aplikacja = _context.AplikacjeRekrutacyjne
                .Where(a => a.ID == id)
                .Include(a => a.OplataRekrutacyjna)
                .Include(a => a.KierunekStudiow)
                .Include(a => a.WspolczynnikRekrutacyjny)
                .Include(a => a.Dokumenty) /*jakie to dokumenty*/
                .FirstAsync();

            // potrzebne jeszcze egazminy dostepne i na ktore zapisany

            return View(await aplikacja);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AnulujAplikacje(int id) { 
        
            
        }*/
    }
}
