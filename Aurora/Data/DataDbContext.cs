using Aurora.Enums;
using Aurora.Models;
using Aurora.OtherClasses.StrategiesForRR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Aurora.Data
{
    public class DataDbContext: IdentityDbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) 
        {
        }

        public DbSet<KierunekStudiow> KierunkiStudiow { get; set; }

        public DbSet<TuraRekrutacji> TuryRekrutacji { get; set; }

        public DbSet<AplikacjaRekrutacyjna> AplikacjeRekrutacyjne { get; set; }

        public DbSet<Egzamin> Egzaminy { get; set; }

        public DbSet<Adres> Adresy { get; set; }

        public DbSet<Kandydat> Kandydaci { get; set; }

        public DbSet<KandydatTuraRekrutacji> KandydaciTuryRekrutacji { get; set; }

        public DbSet<OplataRekrutacyjna> OplatyRekrutacyjne { get; set; }

        public DbSet<SkladowaWspRekrut> SkladoweWspRekrut { get; set; }

        public DbSet<WspolczynnikRekrutacyjny> WspolczynnikiRekrutacyjne { get; set; }

        public DbSet<PracownikDziekanatu> PracownicyDziekanatu { get; set; }

        public DbSet<Wiadomosc> Wiadomosci { get; set; }

        public DbSet<Opinia> Opinia { get; set; }

        public DbSet<Dokument> Dokument { get; set; }

        public DbSet<AplikacjaRekrutacyjnaDokument> AplikacjaRekrutacyjnaDokument { get; set; }

        public DbSet<DziedzinaEgzaminuWstepnego> DziedzinaEgzaminuWstepnego { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
