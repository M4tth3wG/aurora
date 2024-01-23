using Aurora.Models;
using Aurora.OtherClasses.StrategiesForRR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Aurora.Enums;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace Aurora.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<DokumentTura>()
                .HasKey(k => new { k.DokumentID, k.TuraRekrutacjiID });

            builder.Entity<KandydatTuraRekrutacji>()
                .HasKey(k => new { k.KandydatID, k.TuraRekrutacjiID });

            builder.Entity<KandydatKierunekStudiow>()
                .HasKey(k => new { k.KandydatID, k.KierunekStudiowID });

            builder.Entity<AplikacjaRekrutacyjnaDokument>()
                .HasKey(k => new { k.DokumentID, k.AplikacjaRekrutacyjnaID });

            builder.Entity<KandydatUlubionyKierunekStudiow>()
                .HasKey(k => new { k.KandydatID, k.UlubionyKierunekStudiowID });

            builder.Entity<DziedzinaEgzaminuWstepnegoKierunekStudiow>()
                .HasKey(k => new { k.DziedzinaID, k.KierunekStudiowID });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            Adres adres1 = new Adres(1, "Aleje Jerozolimskie", "123", "00-001", "Warszawa");
            Adres adres2 = new Adres(2, "Rynek Główny", "45", "30-062", "Kraków");
            Adres adres3 = new Adres(3, "Długi Targ", "8", "80-830", "Gdańsk");
            Adres adres4 = new Adres(4, "Plac Grunwaldzki", "4", "50-384", "Wrocław");
            Adres adres5 = new Adres(5, "Mickiewicza", "67", "20-230", "Lublin");
            Adres adres6 = new Adres(6, "Wita Stwosza", "15", "40-042", "Katowice");


            builder.Entity<Adres>().HasData(
                adres1,
                adres2,
                adres3,
                adres4,
                adres5,
                adres6
            );

            Kandydat kandydat1 = new Kandydat(1, adres2.ID, "12345678901", "Jan", "Kowalski", "jan.kowalski@example.com");
            Kandydat kandydat2 = new Kandydat(2, adres3.ID, "98765432109", "Anna", "Nowak", "anna.nowak@example.com");
            Kandydat kandydat3 = new Kandydat(3, adres1.ID, "55511133344", "Piotr", "Zalewski", "piotr.zalewski@example.com");
            Kandydat kandydat4 = new Kandydat(4, adres4.ID, "66677733212", "Adam", "Kowalski", "adam.kowalski@example.com");
            Kandydat kandydat5 = new Kandydat(5, adres5.ID, "12345678902", "Karolina", "Nowak", "karolina.nowak@example.com");
            Kandydat kandydat6 = new Kandydat(6, adres6.ID, "98765432103", "Marek", "Lis", "marek.lis@example.com");


            builder.Entity<Kandydat>().HasData(
                kandydat1,
                kandydat2,
                kandydat3,
                kandydat4,
                kandydat5,
                kandydat6
            );

            var dziedzinyEgzaminuWstepnego = new List<DziedzinaEgzaminuWstepnego>()
            {
                new DziedzinaEgzaminuWstepnego()
                {
                    ID = 1,
                    Dziedzina = "Matematyka"
                },
                new DziedzinaEgzaminuWstepnego()
                {
                    ID = 2,
                    Dziedzina = "Fizyka"
                },
                new DziedzinaEgzaminuWstepnego()
                {
                    ID = 3,
                    Dziedzina = "Chemia"
                },
                new DziedzinaEgzaminuWstepnego()
                {
                    ID = 4,
                    Dziedzina = "Biologia"
                },
                new DziedzinaEgzaminuWstepnego()
                {
                    ID = 5,
                    Dziedzina = "Język angielski"
                }
            };

            builder.Entity<DziedzinaEgzaminuWstepnego>().HasData(dziedzinyEgzaminuWstepnego);

            KierunekStudiow kierunek1 = new KierunekStudiow(
                1, 1, 0.0, 1500.0, 2, 0, "Architektura", 0, 0, "Architektura dla ambitnych", RodzajStrategii.StrategiaArchitektura
            );

            KierunekStudiow kierunek2 = new KierunekStudiow(
                2, 1, 0.0, 1250.0, 3, 0, "Automatyka i Robotyka", 0, 10, "AiR dla wymagających", RodzajStrategii.Strategia1StopienStandard
            );

            builder.Entity<KierunekStudiow>().HasData(
            kierunek1,
            kierunek2
            );

            var egzaminyKierunki = new List<DziedzinaEgzaminuWstepnegoKierunekStudiow>() {
                new DziedzinaEgzaminuWstepnegoKierunekStudiow
                {
                    DziedzinaID = 1,
                    KierunekStudiowID = 2
                },
                new DziedzinaEgzaminuWstepnegoKierunekStudiow
                {
                    DziedzinaID = 2,
                    KierunekStudiowID = 2
                },
                new DziedzinaEgzaminuWstepnegoKierunekStudiow
                {
                    DziedzinaID = 5,
                    KierunekStudiowID = 2
                }
            };

            builder.Entity<DziedzinaEgzaminuWstepnegoKierunekStudiow>()
                .HasData(egzaminyKierunki);

            TuraRekrutacji tura1 = new TuraRekrutacji(
                1, 1, new DateTime(2024, 1, 1), new DateTime(2024, 2, 1), new DateTime(2024, 2, 15), 0, 50, 300.0, 2, 2
            );

            TuraRekrutacji tura2 = new TuraRekrutacji(
                2, 2, new DateTime(2024, 1, 1), new DateTime(2024, 2, 1), new DateTime(2024, 2, 15), 0, 150, 225.0, 2, 2
            );

            TuraRekrutacji tura3 = new TuraRekrutacji(
                3, 2, new DateTime(2023, 1, 1), new DateTime(2023, 2, 1), new DateTime(2023, 2, 15), 3, 3, 225.0, 4, 2
            );

            builder.Entity<TuraRekrutacji>().HasData(
                tura1,
                tura2,
                tura3
            );

            OplataRekrutacyjna oplata1 = new OplataRekrutacyjna(
                1, 2, 80.0
            );
            OplataRekrutacyjna oplata2 = new OplataRekrutacyjna(
                2, 2, 80.0
            );
            OplataRekrutacyjna oplata3 = new OplataRekrutacyjna(
                3, 1, 80.0
            );
            OplataRekrutacyjna oplata4 = new OplataRekrutacyjna(
                4, 2, 80.0
            );
            OplataRekrutacyjna oplata5 = new OplataRekrutacyjna(
                5, 3, 80.0
             );
            OplataRekrutacyjna oplata6 = new OplataRekrutacyjna(
                6, 4, 80.0
            );
            OplataRekrutacyjna oplata7 = new OplataRekrutacyjna(
                7, 5, 80.0
            );
            OplataRekrutacyjna oplata8 = new OplataRekrutacyjna(
                8, 6, 80.0
            );



            builder.Entity<OplataRekrutacyjna>().HasData(
                oplata1,
                oplata2,
                oplata3,
                oplata4,
                oplata5,
                oplata6,
                oplata7,
                oplata8
            );

            AplikacjaRekrutacyjna aplikacja1 = new AplikacjaRekrutacyjna(
                1, 1, 1, 1, new DateTime(2024, 1, 15), 8, 2
            );

            AplikacjaRekrutacyjna aplikacja2 = new AplikacjaRekrutacyjna(
                2, 2, 2, 2, new DateTime(2024, 1, 15), 8, 2
            );

            AplikacjaRekrutacyjna aplikacja3 = new AplikacjaRekrutacyjna(
                3, 2, 3, 3, new DateTime(2023, 1, 10), 5, 1
            );

            AplikacjaRekrutacyjna aplikacja4 = new AplikacjaRekrutacyjna(
                4, 2, 3, 4, new DateTime(2023, 1, 11), 5, 2
            );

            AplikacjaRekrutacyjna aplikacja5 = new AplikacjaRekrutacyjna(
                5, 2, 3, 5, new DateTime(2023, 1, 12), 6, 3
            );

            AplikacjaRekrutacyjna aplikacja6 = new AplikacjaRekrutacyjna(
                6, 2, 3, 6, new DateTime(2023, 1, 13), 6, 4
            );

            AplikacjaRekrutacyjna aplikacja7 = new AplikacjaRekrutacyjna(
                7, 2, 3, 7, new DateTime(2023, 1, 14), 5, 5
            );

            AplikacjaRekrutacyjna aplikacja8 = new AplikacjaRekrutacyjna(
                8, 2, 3, 8, new DateTime(2023, 1, 15), 6, 6
            );

            builder.Entity<AplikacjaRekrutacyjna>().HasData(
                aplikacja1,
                aplikacja2,
                aplikacja3,
                aplikacja4,
                aplikacja5,
                aplikacja6,
                aplikacja7,
                aplikacja8
            );

            WspolczynnikRekrutacyjny wspolczynnik1 = new WspolczynnikRekrutacyjny(
                1, 1
            );

            WspolczynnikRekrutacyjny wspolczynnik2 = new WspolczynnikRekrutacyjny(
                2, 2
            );

            WspolczynnikRekrutacyjny wspolczynnik3 = new WspolczynnikRekrutacyjny(
                3, 3
            );

            WspolczynnikRekrutacyjny wspolczynnik4 = new WspolczynnikRekrutacyjny(
                4, 4
            );

            WspolczynnikRekrutacyjny wspolczynnik5 = new WspolczynnikRekrutacyjny(
                5, 5
            );

            WspolczynnikRekrutacyjny wspolczynnik6 = new WspolczynnikRekrutacyjny(
                6, 6
            );

            WspolczynnikRekrutacyjny wspolczynnik7 = new WspolczynnikRekrutacyjny(
                7, 7
            );

            WspolczynnikRekrutacyjny wspolczynnik8 = new WspolczynnikRekrutacyjny(
                8, 8
            );


            builder.Entity<WspolczynnikRekrutacyjny>().HasData(
                wspolczynnik1,
                wspolczynnik2,
                wspolczynnik3,
                wspolczynnik4,
                wspolczynnik5,
                wspolczynnik6,
                wspolczynnik7,
                wspolczynnik8
            );

            SkladowaWspRekrut skladowa1 = new SkladowaWspRekrut(1, 70, 1, 0, 1, null);
            SkladowaWspRekrut skladowa57 = new SkladowaWspRekrut(57, 70, 1, 0, 0, null); // add basic math
            SkladowaWspRekrut skladowa2 = new SkladowaWspRekrut(2, 70, 1, 3, 1, null);
            SkladowaWspRekrut skladowa3 = new SkladowaWspRekrut(3, 70, 1, 1, 1, null);
            SkladowaWspRekrut skladowa4 = new SkladowaWspRekrut(4, 70, 1, 1, 0, null);
            SkladowaWspRekrut skladowa5 = new SkladowaWspRekrut(5, 70, 1, 2, 0, null);
            SkladowaWspRekrut skladowa6 = new SkladowaWspRekrut(6, 70, 1, 2, 1, null);
            SkladowaWspRekrut skladowa7 = new SkladowaWspRekrut(7, 250, 1, null, 2, null);

            SkladowaWspRekrut skladowa8 = new SkladowaWspRekrut(8, 70, 2, 0, 1, null);
            SkladowaWspRekrut skladowa9 = new SkladowaWspRekrut(9, 70, 2, 3, 1, null);
            SkladowaWspRekrut skladowa10 = new SkladowaWspRekrut(10, 70, 2, 1, 1, null);
            SkladowaWspRekrut skladowa11 = new SkladowaWspRekrut(11, 70, 2, 1, 0, null);
            SkladowaWspRekrut skladowa12 = new SkladowaWspRekrut(12, 70, 2, 2, 0, null);
            SkladowaWspRekrut skladowa13 = new SkladowaWspRekrut(13, 70, 2, 2, 1, null);
            SkladowaWspRekrut skladowa14 = new SkladowaWspRekrut(14, 70, 2, 0, 0, null);

            SkladowaWspRekrut skladowa15 = new SkladowaWspRekrut(15, 70, 3, 0, 1, null);
            SkladowaWspRekrut skladowa16 = new SkladowaWspRekrut(16, 70, 3, 3, 1, null);
            SkladowaWspRekrut skladowa17 = new SkladowaWspRekrut(17, 70, 3, 1, 1, null);
            SkladowaWspRekrut skladowa18 = new SkladowaWspRekrut(18, 70, 3, 1, 0, null);
            SkladowaWspRekrut skladowa19 = new SkladowaWspRekrut(19, 70, 3, 2, 0, null);
            SkladowaWspRekrut skladowa20 = new SkladowaWspRekrut(20, 70, 3, 2, 1, null);
            SkladowaWspRekrut skladowa21 = new SkladowaWspRekrut(21, 70, 3, 0, 0, null);

            SkladowaWspRekrut skladowa22 = new SkladowaWspRekrut(22, 60, 4, 0, 1, null);
            SkladowaWspRekrut skladowa23 = new SkladowaWspRekrut(23, 70, 4, 3, 1, null);
            SkladowaWspRekrut skladowa24 = new SkladowaWspRekrut(24, 70, 4, 1, 1, null);
            SkladowaWspRekrut skladowa25 = new SkladowaWspRekrut(25, 70, 4, 1, 0, null);
            SkladowaWspRekrut skladowa26 = new SkladowaWspRekrut(26, 70, 4, 2, 0, null);
            SkladowaWspRekrut skladowa27 = new SkladowaWspRekrut(27, 70, 4, 2, 1, null);
            SkladowaWspRekrut skladowa28 = new SkladowaWspRekrut(28, 70, 4, 0, 0, null);

            SkladowaWspRekrut skladowa29 = new SkladowaWspRekrut(29, 50, 5, 0, 1, null);
            SkladowaWspRekrut skladowa30 = new SkladowaWspRekrut(30, 70, 5, 3, 1, null);
            SkladowaWspRekrut skladowa31 = new SkladowaWspRekrut(31, 70, 5, 1, 1, null);
            SkladowaWspRekrut skladowa32 = new SkladowaWspRekrut(32, 70, 5, 1, 0, null);
            SkladowaWspRekrut skladowa33 = new SkladowaWspRekrut(33, 70, 5, 2, 0, null);
            SkladowaWspRekrut skladowa34 = new SkladowaWspRekrut(34, 70, 5, 2, 1, null);
            SkladowaWspRekrut skladowa35 = new SkladowaWspRekrut(35, 70, 5, 0, 0, null);

            SkladowaWspRekrut skladowa36 = new SkladowaWspRekrut(36, 40, 6, 0, 1, null);
            SkladowaWspRekrut skladowa37 = new SkladowaWspRekrut(37, 70, 6, 3, 1, null);
            SkladowaWspRekrut skladowa38 = new SkladowaWspRekrut(38, 70, 6, 1, 1, null);
            SkladowaWspRekrut skladowa39 = new SkladowaWspRekrut(39, 70, 6, 1, 0, null);
            SkladowaWspRekrut skladowa40 = new SkladowaWspRekrut(40, 70, 6, 2, 0, null);
            SkladowaWspRekrut skladowa41 = new SkladowaWspRekrut(41, 70, 6, 2, 1, null);
            SkladowaWspRekrut skladowa42 = new SkladowaWspRekrut(42, 70, 6, 0, 0, null);

            SkladowaWspRekrut skladowa43 = new SkladowaWspRekrut(43, 70, 7, 0, 1, null);
            SkladowaWspRekrut skladowa44 = new SkladowaWspRekrut(44, 65, 7, 3, 1, null);
            SkladowaWspRekrut skladowa45 = new SkladowaWspRekrut(45, 70, 7, 1, 1, null);
            SkladowaWspRekrut skladowa46 = new SkladowaWspRekrut(46, 70, 7, 1, 0, null);
            SkladowaWspRekrut skladowa47 = new SkladowaWspRekrut(47, 70, 7, 2, 0, null);
            SkladowaWspRekrut skladowa48 = new SkladowaWspRekrut(48, 70, 7, 2, 1, null);
            SkladowaWspRekrut skladowa49 = new SkladowaWspRekrut(49, 70, 7, 0, 0, null);

            SkladowaWspRekrut skladowa50 = new SkladowaWspRekrut(50, 70, 8, 0, 1, null);
            SkladowaWspRekrut skladowa51 = new SkladowaWspRekrut(51, 55, 8, 3, 1, null);
            SkladowaWspRekrut skladowa52 = new SkladowaWspRekrut(52, 70, 8, 1, 1, null);
            SkladowaWspRekrut skladowa53 = new SkladowaWspRekrut(53, 70, 8, 1, 0, null);
            SkladowaWspRekrut skladowa54 = new SkladowaWspRekrut(54, 70, 8, 2, 0, null);
            SkladowaWspRekrut skladowa55 = new SkladowaWspRekrut(55, 70, 8, 2, 1, null);
            SkladowaWspRekrut skladowa56 = new SkladowaWspRekrut(56, 70, 8, 0, 0, null);




            builder.Entity<SkladowaWspRekrut>().HasData(
                skladowa1, skladowa2, skladowa3, skladowa4,
                skladowa5, skladowa6, skladowa7, skladowa8, skladowa9,
                skladowa10, skladowa11, skladowa12, skladowa13, skladowa14,
                skladowa15, skladowa16, skladowa17, skladowa18, skladowa19,
                skladowa20, skladowa21, skladowa22, skladowa23, skladowa24,
                skladowa25, skladowa26, skladowa27, skladowa28, skladowa29,
                skladowa30, skladowa31, skladowa32, skladowa33, skladowa34,
                skladowa35, skladowa36, skladowa37, skladowa38, skladowa39,
                skladowa40, skladowa41, skladowa42, skladowa43, skladowa44,
                skladowa45, skladowa46, skladowa47, skladowa48, skladowa49,
                skladowa50, skladowa51, skladowa52, skladowa53, skladowa54,
                skladowa55, skladowa56, skladowa57
            );

            var pracownicy = new List<PracownikDziekanatu>()
            {
                new PracownikDziekanatu() {
                    ID = 1,
                    Imie = "Natalia",
                    Nazwisko = "Kowalczyk",
                    Wydzial = 0,
                    AdresEmail = "natalia.kowalczyk@pwr.edu.pl",
                },
                new PracownikDziekanatu() {
                    ID = 2,
                    Imie = "Jakub",
                    Nazwisko = "Nowak",
                    Wydzial = 10,
                    AdresEmail = "jakub.nowak@pwr.edu.pl",
                }
            };

            builder.Entity<PracownikDziekanatu>().HasData(pracownicy);

            Dokument dokuemnt1 = new Dokument(
                 1, 1
            );

            Dokument dokuemnt2 = new Dokument(
                 2, 1
            );

            Dokument dokuemnt3 = new Dokument(
                 3, 1
            );

            Dokument dokuemnt4 = new Dokument(
                 4, 1
            );

            Dokument dokuemnt5 = new Dokument(
                 5, 1
            );

            Dokument dokuemnt6 = new Dokument(
                 6, 1
            );

            Dokument dokuemnt7 = new Dokument(
                 7, 1
            );

            Dokument dokuemnt8 = new Dokument(
                 8, 1
            );

            builder.Entity<Dokument>().HasData(
                dokuemnt1,
                dokuemnt2,
                dokuemnt3,
                dokuemnt4,
                dokuemnt5,
                dokuemnt6,
                dokuemnt7,
                dokuemnt8
            );


            DokumentTura dokumentTura1 = new DokumentTura(
                1, 1
            );

            DokumentTura dokumentTura2 = new DokumentTura(
                2, 2
            );

            DokumentTura dokumentTura3 = new DokumentTura(
                3, 3
            );

            DokumentTura dokumentTura4 = new DokumentTura(
                4, 3
            );

            DokumentTura dokumentTura5 = new DokumentTura(
                5, 3
            );

            DokumentTura dokumentTura6 = new DokumentTura(
                6, 3
            );

            DokumentTura dokumentTura7 = new DokumentTura(
                7, 3
            );

            DokumentTura dokumentTura8 = new DokumentTura(
                8, 3
            );



            builder.Entity<DokumentTura>().HasData(
                dokumentTura1,
                dokumentTura2,
                dokumentTura3,
                dokumentTura4,
                dokumentTura5,
                dokumentTura6,
                dokumentTura7,
                dokumentTura8
            );



            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument1 = new AplikacjaRekrutacyjnaDokument(
                1, 1
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument2 = new AplikacjaRekrutacyjnaDokument(
                2, 2
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument3 = new AplikacjaRekrutacyjnaDokument(
                3, 3
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument4 = new AplikacjaRekrutacyjnaDokument(
                4, 4
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument5 = new AplikacjaRekrutacyjnaDokument(
                5, 5
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument6 = new AplikacjaRekrutacyjnaDokument(
                6, 6
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument7 = new AplikacjaRekrutacyjnaDokument(
                7, 7
            );

            AplikacjaRekrutacyjnaDokument aplikacjaRekrutacyjnaDokument8 = new AplikacjaRekrutacyjnaDokument(
                8, 8
            );



            builder.Entity<AplikacjaRekrutacyjnaDokument>().HasData(
                aplikacjaRekrutacyjnaDokument1,
                aplikacjaRekrutacyjnaDokument2,
                aplikacjaRekrutacyjnaDokument3,
                aplikacjaRekrutacyjnaDokument4,
                aplikacjaRekrutacyjnaDokument5,
                aplikacjaRekrutacyjnaDokument6,
                aplikacjaRekrutacyjnaDokument7,
                aplikacjaRekrutacyjnaDokument8
            );
        }
    }
}
