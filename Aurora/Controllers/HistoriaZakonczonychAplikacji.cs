using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aurora.Models;
using Aurora.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Aurora.Enums;


namespace Aurora.Controllers
{
    public class HistoriaZakonczonychAplikacji : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HistoriaZakonczonychAplikacji(DataDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var aplikacje = _context.AplikacjeRekrutacyjne
/*                .Where(e => e.Status == Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaSukcesem) || e.Status == Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaNiepowodzeniem) || e.Status == Convert.ToInt32(RodzajStatusuAplikacji.Odrzucona))
*/                .Include(e => e.Kandydat)
/*                .Where(e => e.Kandydat.ID == 2)
*/                .Include(e => e.KierunekStudiow)
                .Include(e => e.TuraRekrutacji)
                    .ThenInclude(e => e.Opinie)
/*                .Where(e => e.TuraRekrutacji.DataZakonczenia < DateTime.Now.Date)*/
                .ToList();
            return View(aplikacje);
        }


        public IActionResult Opinia(int kandydatID, int turaRekrutacjiID)
        {

            var opinia = new Opinia()
            {

                KandydatID = kandydatID,
                TuraRekrutacjiID = turaRekrutacjiID

            };

            return View(opinia);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Opinia([Bind("Id,KandydatID,TuraRekrutacjiID,Tresc")] Opinia opinia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opinia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opinia);
        }
    }
}
