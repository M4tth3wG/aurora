using Aurora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Aurora.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Aurora.Controllers;
using Aurora.Data;
using Microsoft.EntityFrameworkCore;

namespace Aurora.Test
{

    public class OfertaKierunkowTest
    {

        // Mateusz Gazda

        [Theory, MemberData(nameof(KierunkiDane))]
        public void CzyKluczKierunkuUnikalny_Test(KierunekStudiow kierunek, bool unikalny)
        {
            // Arrange

            var dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
                .UseInMemoryDatabase(databaseName: "bazaOfertaKierunkowTest")
                .Options;

            using (var dbContext = new DataDbContext(dbContextOptions))
            {
                var daneDoBazy = new List<KierunekStudiow>() { 
                    new KierunekStudiow() {
                        NazwaKierunku = "Architektura",
                        JezykWykladowy = (int)Jezyk.polski,
                        FormaStudiow = (int)FormaStudiow.stacjonarne,
                        MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                        PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
                    },
                    new KierunekStudiow() {
                        NazwaKierunku = "Automatyka i Robotyka",
                        JezykWykladowy = (int)Jezyk.angielski,
                        FormaStudiow = (int)FormaStudiow.niestacjonarne,
                        MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                        PoziomStudiow = (int)PoziomStudiow.pierwszegoStopniaInzynierskie
                    }
                };

                daneDoBazy.ForEach(k => dbContext.KierunkiStudiow.Add(k));

                dbContext.SaveChanges();


                var controller = new OfertaKierunkowController(dbContext, null);


                // Act
                var result = controller.CzyKluczKierunkuUnikalny(kierunek);


                // Assert
                
                Assert.Equal(unikalny, result);
            }
        }

        public static IEnumerable<object[]> KierunkiDane()
        {
            KierunekStudiow kierunek_1 = new KierunekStudiow()
            {
                NazwaKierunku = "Architektura",
                JezykWykladowy = (int)Jezyk.polski,
                FormaStudiow = (int)FormaStudiow.stacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
            };

            KierunekStudiow kierunek_2 = new KierunekStudiow()
            {
                NazwaKierunku = " Architektura  ",
                JezykWykladowy = (int)Jezyk.polski,
                FormaStudiow = (int)FormaStudiow.stacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
            };

            KierunekStudiow kierunek_3 = new KierunekStudiow()
            {
                NazwaKierunku = "architektura",
                JezykWykladowy = (int)Jezyk.polski,
                FormaStudiow = (int)FormaStudiow.stacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
            };

            KierunekStudiow kierunek_4 = new KierunekStudiow()
            {
                NazwaKierunku = "Architektura",
                JezykWykladowy = (int)Jezyk.angielski,
                FormaStudiow = (int)FormaStudiow.stacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
            };

            KierunekStudiow kierunek_5 = new KierunekStudiow()
            {
                NazwaKierunku = "Architektura",
                JezykWykladowy = (int)Jezyk.polski,
                FormaStudiow = (int)FormaStudiow.niestacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
            };

            KierunekStudiow kierunek_6 = new KierunekStudiow()
            {
                NazwaKierunku = "Architektura",
                JezykWykladowy = (int)Jezyk.polski,
                FormaStudiow = (int)FormaStudiow.niestacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Legnica,
                PoziomStudiow = (int)PoziomStudiow.jednoliteMagisterskie
            };

            KierunekStudiow kierunek_7 = new KierunekStudiow()
            {
                NazwaKierunku = "Architektura",
                JezykWykladowy = (int)Jezyk.polski,
                FormaStudiow = (int)FormaStudiow.stacjonarne,
                MiejsceStudiow = (int)MiejsceStudiow.Wroclaw,
                PoziomStudiow = (int)PoziomStudiow.pierwszegoStopniaLicencjackie
            };

            return new List<object[]>
            {
                new object[] { kierunek_1, false },
                new object[] { kierunek_2, false },
                new object[] { kierunek_3, false },
                new object[] { kierunek_4, true },
                new object[] { kierunek_5, true },
                new object[] { kierunek_6, true },
                new object[] { kierunek_7, true }
            };
        }
        
    }
}
