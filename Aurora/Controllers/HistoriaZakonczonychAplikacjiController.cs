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
using Aurora.Utils;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;


namespace Aurora.Controllers
{
    [Authorize(Roles="Kandydat")]
    public class HistoriaZakonczonychAplikacjiController : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HistoriaZakonczonychAplikacjiController(DataDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var aplikacje = await _context.AplikacjeRekrutacyjne
                .Where(e => e.Status == Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaSukcesem) || e.Status == Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaNiepowodzeniem) || e.Status == Convert.ToInt32(RodzajStatusuAplikacji.Odrzucona))
                .Include(e => e.Kandydat)
                .Where(e => e.Kandydat.AdresEmail == HttpContext.User.Identity.Name)
                .Include(e => e.KierunekStudiow)
                .Include(e => e.TuraRekrutacji)
                    .ThenInclude(e => e.Opinie)
                .Where(e => e.TuraRekrutacji.DataZakonczenia < DateTime.Now.Date)
                .ToListAsync();
            return View(aplikacje);
        }


        public IActionResult Opinia(int kandydatID, int turaRekrutacjiID)
        {

            var tura = _context.AplikacjeRekrutacyjne
                .Where(e => e.TuraRekrutacjiID == turaRekrutacjiID)
                .Where(e => e.KandydatID == kandydatID)
                .Include(e => e.TuraRekrutacji)
                .Where(e => e.TuraRekrutacji.StatusTury == 4)
                .ToList();

            var opinie = _context.Opinia
                .Where(e => e.TuraRekrutacjiID == turaRekrutacjiID)
                .Where(e => e.KandydatID == kandydatID)
                .ToList();

            if (tura.Count != 1 || opinie.Count != 0)
            {
                return BadRequest();
            }

            var opinia = new Opinia()
            {

                KandydatID = kandydatID,
                TuraRekrutacjiID = turaRekrutacjiID

            };

            return View(opinia);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Opinia([Bind("Id,KandydatID,TuraRekrutacjiID,Tresc,JakoscPomocy,IntuicyjnoscSystemu,InformowanieOStatusie")] Opinia opinia)
        {

            if (ModelState.IsValid)
            {
                ViewBag.PopUpMessage = "Pomyślnie dodano opinie";
                _context.Add(opinia);
                await _context.SaveChangesAsync();
                return View(opinia);
            }


            return View(opinia);
        }





        public IActionResult Szczegoly(int kandydatID,int turaRekrutacjiID)
        {

            var aplikacja = _context.AplikacjeRekrutacyjne
                .Where(e => e.TuraRekrutacjiID == turaRekrutacjiID)
                .Where(e => e.KandydatID == kandydatID)
                .Include(e => e.Kandydat)
                    .ThenInclude(e => e.Adres)
                .Include(e => e.Kandydat.Adres)
                .Include(e => e.KierunekStudiow)
                .Include(e => e.TuraRekrutacji)
                    .ThenInclude(e => e.Opinie)
                .Include(e => e.Dokumenty)
                    .ThenInclude(e => e.Dokument)
                .Include(e => e.WspolczynnikRekrutacyjny)
                .Include(e => e.OplataRekrutacyjna)
                .ToList();

            if (aplikacja.Count() == 0)
            {

                return BadRequest();
            }

            var wszyskieAplikacjeWTurze = _context.AplikacjeRekrutacyjne
                .Where(e => e.TuraRekrutacjiID == turaRekrutacjiID)
                .Include(e => e.KierunekStudiow)
                .Include(e => e.WspolczynnikRekrutacyjny)
                    .ThenInclude(e => e.skladowe)
                        .ThenInclude(e => e.Egzamin)
                /*                .OrderBy(e => e.WspolczynnikRekrutacyjny)*/
                .ToList();

            /*            wszyskieAplikacjeWTurze = wszyskieAplikacjeWTurze.OrderBy(p => p.WspolczynnikRekrutacyjny.Wartosc).ToList();
            */
            int i = 0;

            foreach (var aplikacje in wszyskieAplikacjeWTurze)
            {
                i++;

/*                aplikacje.WspolczynnikRekrutacyjny.strategia = UtilsRR.GetStrategiaDlaKierunku(aplikacje.KierunekStudiow);*/

                if (aplikacje.ID == aplikacja.FirstOrDefault().ID)
                {
                    @ViewBag.ZajeteMiejsce = i;
                }
                if (aplikacje.Status == Convert.ToInt32(RodzajStatusuAplikacji.ZakonczonaSukcesem))
                {
/*                    @ViewBag.MinimalnaIloscPunktow = aplikacje.WspolczynnikRekrutacyjny.Wartosc;*/

                }

            }


            @ViewBag.IloscOsobAplikujących = i;

            return View(aplikacja.FirstOrDefault());
        }
    }
}
