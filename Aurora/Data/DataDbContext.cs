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

            KierunekStudiow kierunek1 = new KierunekStudiow(
                1, 1, 0.0, 1500.0, 0, 0, "Architektura", 0, 0, "Architektura dla ambitnych"
            );

            KierunekStudiow kierunek2 = new KierunekStudiow(
                2, 1, 0.0, 1250.0, 0, 0, "Automatyka i Robotyka", 0, 10, "AiR dla wymagających"
            );

            builder.Entity<KierunekStudiow>().HasData(
                kierunek1,
                kierunek2
            );

            TuraRekrutacji tura1 = new TuraRekrutacji(
                1, 1, new DateTime(2024, 1, 1), new DateTime(2024, 2, 1), new DateTime(2024, 2, 15), 0, 50, 300.0, 2, 2
            );
            
            TuraRekrutacji tura2 = new TuraRekrutacji(
                2, 2, new DateTime(2024, 1, 1), new DateTime(2024, 2, 1), new DateTime(2024, 2, 15), 0, 150, 225.0, 2, 2
            );

            builder.Entity<TuraRekrutacji>().HasData(
                tura1,
                tura2
            );

            OplataRekrutacyjna oplata1 = new OplataRekrutacyjna(
                1, 2, 80.0
            );
            OplataRekrutacyjna oplata2 = new OplataRekrutacyjna(
                2, 2, 80.0
            );

            builder.Entity<OplataRekrutacyjna>().HasData(
                oplata1,
                oplata2
            );

            AplikacjaRekrutacyjna aplikacja1 = new AplikacjaRekrutacyjna(
                1, 1, 1, 1, new DateTime(2024, 1, 15), 8, 2   
            );

            AplikacjaRekrutacyjna aplikacja2 = new AplikacjaRekrutacyjna(
                2, 2, 1, 2, new DateTime(2024, 1, 15), 8, 2   
            );

            builder.Entity<AplikacjaRekrutacyjna>().HasData(
                aplikacja1,
                aplikacja2
            );

            WspolczynnikRekrutacyjny wspolczynnik1 = new WspolczynnikRekrutacyjny(
                1, new Architektura1Stopien(), 1    
            );            
            
            WspolczynnikRekrutacyjny wspolczynnik2 = new WspolczynnikRekrutacyjny(
                2, new AiR1Stopien(), 2    
            );

            builder.Entity<WspolczynnikRekrutacyjny>().HasData(
                wspolczynnik1,
                wspolczynnik2
            );

            SkladowaWspRekrut skladowa1 = new SkladowaWspRekrut(1, 70, 1, 0, 1, null);
            SkladowaWspRekrut skladowa2 = new SkladowaWspRekrut(2, 70, 1, 3, 1, null);
            SkladowaWspRekrut skladowa3 = new SkladowaWspRekrut(3, 70, 1, 1, 1, null);
            SkladowaWspRekrut skladowa4 = new SkladowaWspRekrut(4, 70, 1, 1, 0, null);
            SkladowaWspRekrut skladowa5 = new SkladowaWspRekrut(5, 70, 1, 2, 0, null);
            SkladowaWspRekrut skladowa6 = new SkladowaWspRekrut(6, 70, 1, 2, 1, null);
            SkladowaWspRekrut skladowa7 = new SkladowaWspRekrut(7, 250, 1, null, 2, null);

            SkladowaWspRekrut skladowa8 = new SkladowaWspRekrut(8, 70, 2, 0, 1, null);
            SkladowaWspRekrut skladowa9 = new SkladowaWspRekrut(9, 70, 2, 3, 1, null);
            SkladowaWspRekrut skladowa10 = new SkladowaWspRekrut(10, 70, 2, 1, 1, null);
            SkladowaWspRekrut skladowa11 = new SkladowaWspRekrut(11, 70, 2, 1, 0 , null);
            SkladowaWspRekrut skladowa12 = new SkladowaWspRekrut(12, 70, 2, 2, 0, null);
            SkladowaWspRekrut skladowa13 = new SkladowaWspRekrut(13, 70, 2, 2, 1, null);
            SkladowaWspRekrut skladowa14 = new SkladowaWspRekrut(14, 250, 2, null, 2, null);

            builder.Entity<SkladowaWspRekrut>().HasData(
                skladowa1, skladowa2, skladowa3, skladowa4, 
                skladowa5, skladowa6, skladowa7, skladowa8, skladowa9, 
                skladowa10, skladowa11, skladowa12, skladowa13, skladowa14
            );

            PracownikDziekanatu pracownik1 = new PracownikDziekanatu(
                 1, "Natalia", "Kowalczyk", 0
            );   
            
            PracownikDziekanatu pracownik2 = new PracownikDziekanatu(
                 2, "Jakub", "Nowak", 10
            );

            builder.Entity<PracownikDziekanatu>().HasData(
                pracownik1,
                pracownik2
            );


        }
    }
}
