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


namespace Aurora.Controllers
{
    public class HistoriaZakoncoznychAplikacji : Controller
    {
        private readonly DataDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HistoriaZakoncoznychAplikacji(DataDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var aplikacje = _context.AplikacjeRekrutacyjne
                .Where(e => e.Status == 5 || e.Status == 6)
                .Include(e => e.Kandydat)
/*                .Where(e => e.Kandydat.ID == 2)
*/                .Include(e => e.KierunekStudiow)
                .ToList();
            return View(aplikacje);
        }


        public IActionResult Opinia()
        {
            var aplikacje = _context.AplikacjeRekrutacyjne
                .Where(e => e.Status == 5 || e.Status == 6)
                .Include(e => e.Kandydat)
/*                .Where(e => e.Kandydat.ID == 2)
*/                .Include(e => e.KierunekStudiow)
                .ToList();
            return View(aplikacje);
        }
    }
}
