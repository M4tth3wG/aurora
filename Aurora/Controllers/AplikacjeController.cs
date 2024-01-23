using Aurora.Data;
using Aurora.Enums;
using Aurora.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Aurora.Controllers
{
    [Authorize(Roles = "Kandydat")]
    public class AplikacjeController : Controller
    {
        private readonly DataDbContext _context;

        public AplikacjeController(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kandydatEmail = HttpContext.User.Identity.Name;     

            var aplikacje = await _context.AplikacjeRekrutacyjne
                .Include(a => a.KierunekStudiow)
                .Include(a => a.Kandydat)
                .Where(a => a.Kandydat.AdresEmail.Equals(kandydatEmail))
                .Include(a => a.TuraRekrutacji)
                .Where(a =>
                    a.TuraRekrutacji.StatusTury != (int)Enums.RodzajStatusuTury.anulowana
                    &&
                    a.TuraRekrutacji.StatusTury != (int)Enums.RodzajStatusuTury.zakonczona
                )
                .ToListAsync();

            if (!aplikacje.Any())
            {
                return View("BrakAplikacji");
            }


            return View(aplikacje);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne
                .Where(a => a.ID == id)
                .Include(a => a.Kandydat)
                .Include(a => a.EgzaminyWstepne)
                .Include(a => a.OplataRekrutacyjna)
                .Include(a => a.KierunekStudiow)
                    .ThenInclude(k => k.DostepneEgzaminyWstepne)
                        .ThenInclude(d => d.Dziedzina)
                .Include(a => a.WspolczynnikRekrutacyjny)
                    .ThenInclude(w => w.skladowe)
                .Include(a => a.TuraRekrutacji)
                .Include(a => a.Dokumenty)
                    .ThenInclude(d => d.Dokument)
                .FirstAsync();

            if (!CzyKandydatZalogowany(aplikacja.Kandydat))
            {
                return BadRequest();
            }

            return View(aplikacja);
        }

        public async Task<IActionResult> AnulujAplikacje(int id)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne
                .Where(a => a.ID == id)
                .Include (a => a.Kandydat)
                .Include(a => a.EgzaminyWstepne)
                .Include(a => a.OplataRekrutacyjna)
                .Include(a => a.KierunekStudiow)
                    .ThenInclude(k => k.DostepneEgzaminyWstepne)
                        .ThenInclude(d => d.Dziedzina)
                .Include(a => a.WspolczynnikRekrutacyjny)
                    .ThenInclude(w => w.skladowe)
                .Include(a => a.TuraRekrutacji)
                .Include(a => a.Dokumenty)
                    .ThenInclude(d => d.Dokument)
                .FirstAsync();

            if (!CzyKandydatZalogowany(aplikacja.Kandydat))
            {
                return BadRequest();
            }

            int status = aplikacja.Status;

            // TODO jakie warunki
            if (
                status != (int)RodzajStatusuAplikacji.Anulowana
                &&
                status != (int)RodzajStatusuAplikacji.ZakonczonaNiepowodzeniem
                &&
                status != (int)RodzajStatusuAplikacji.ZakonczonaSukcesem
                &&
                aplikacja.TuraRekrutacji.StatusTury != (int)RodzajStatusuTury.anulowana
                &&
                aplikacja.TuraRekrutacji.StatusTury != (int)RodzajStatusuTury.zakonczona
            )
            {
                ViewBag.PopUpMessage = "Czy na pewno chcesz anulować aplikację?";
            }

            return View("Details", aplikacja);
        }

        public async Task<IActionResult> AnulujAplikacjePotwierdz(int id)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne
                                    .Where(a => a.ID == id)
                                    .Include(a => a.Kandydat)
                                    .FirstAsync();

            if (!CzyKandydatZalogowany(aplikacja.Kandydat))
            {
                return BadRequest();
            }

            aplikacja.Status = (int)RodzajStatusuAplikacji.Anulowana;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> ZapiszNaEgzaminy(int id)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne
                .Where(a => a.ID == id)
                .Include(a => a.Kandydat)
                .Include(a => a.EgzaminyWstepne)
                .Include(a => a.KierunekStudiow)
                    .ThenInclude(k => k.DostepneEgzaminyWstepne)
                        .ThenInclude(d => d.Dziedzina)
                .FirstAsync();

            if (!CzyKandydatZalogowany(aplikacja.Kandydat))
            {
                return BadRequest();
            }

            var dostepneEgzaminy = aplikacja.KierunekStudiow.DostepneEgzaminyWstepne
                                        .Select(e => e.Dziedzina)
                                        .Except(
                                            aplikacja.EgzaminyWstepne
                                        );
                                        

            ViewBag.AplikacjaID = aplikacja.ID;
            ViewBag.PopUpMessage = TempData["PopUpMessage"];

            if (dostepneEgzaminy.Any())
            {
                return View(dostepneEgzaminy);
            }

            return View("BrakEgzaminow");
        }

        public async Task<IActionResult> ZapisNaEgzaminyPotwierdz(int id, int aplikacjaID)
        {
            var aplikacja = await _context.AplikacjeRekrutacyjne
                .Where(a => a.ID == aplikacjaID)
                .Include(a => a.Kandydat)
                .Include(a => a.EgzaminyWstepne)
                .Include(a => a.KierunekStudiow)
                    .ThenInclude(k => k.DostepneEgzaminyWstepne)
                        .ThenInclude(d => d.Dziedzina)
                .FirstAsync();

            var egzamin = aplikacja.KierunekStudiow
                                    .DostepneEgzaminyWstepne
                                    .Where(e => e.DziedzinaID == id)
                                    .Select(d => d.Dziedzina)
                                    .FirstOrDefault();

            if (!CzyKandydatZalogowany(aplikacja.Kandydat) || egzamin == null)
            {
                return BadRequest();
            }

            aplikacja.EgzaminyWstepne.Add(egzamin);
            await _context.SaveChangesAsync();

            TempData["PopUpMessage"] = "Pomyślnie zapisano na egzamin.";

            return RedirectToAction(nameof(ZapiszNaEgzaminy), new { aplikacja.ID });
        }

        public bool CzyKandydatZalogowany(Kandydat kandydat)
        {
            var kandydatEmail = HttpContext.User.Identity.Name;

            return kandydat.AdresEmail.Equals(kandydatEmail);
        }
    }
}
