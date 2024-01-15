using Aurora.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<KandydatTuraRekrutacji>()
                .HasKey(k => new { k.KandydatID, k.TuraRekrutacjiID });            
            
            builder.Entity<KandydatKierunekStudiow>()
                .HasKey(k => new { k.KandydatID, k.KierunekStudiowID });            
            
            builder.Entity<KandydatUlubionyKierunekStudiow>()
                .HasKey(k => new { k.KandydatID, k.UlubionyKierunekStudiowID });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            Adres adres1 = new Adres(1, "Aleje Jerozolimskie", "123", "00-001", "Warszawa");
            Adres adres2 = new Adres(2, "Rynek Główny", "45", "30-062", "Kraków");
            Adres adres3 = new Adres(3, "Długi Targ", "8", "80-830", "Gdańsk");
            Adres adres4 = new Adres(4, "Plac Grunwaldzki", "4", "50-384", "Wrocław");

            builder.Entity<Adres>().HasData(
                adres1,
                adres2,
                adres3,
                adres4
            );

            Kandydat kandydat1 = new Kandydat(1, adres2.ID, "12345678901", "Jan", "Kowalski", "jan.kowalski@example.com");
            Kandydat kandydat2 = new Kandydat(2, adres3.ID, "98765432109", "Anna", "Nowak", "anna.nowak@example.com");
            Kandydat kandydat3 = new Kandydat(3, adres1.ID, "55511133344", "Piotr", "Zalewski", "piotr.zalewski@example.com");
            Kandydat kandydat4 = new Kandydat(4, adres4.ID, "66677733212", "Adam", "Kowalski", "adam.kowalski@example.com");

            builder.Entity<Kandydat>().HasData(
                kandydat1,
                kandydat2,
                kandydat3,
                kandydat4
            );


        }
    }
}
