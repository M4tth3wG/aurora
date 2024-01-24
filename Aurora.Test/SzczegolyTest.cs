using Aurora.Controllers;
using Aurora.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;
using Aurora.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Linq;
using System.Data;

namespace Aurora.Test
{
    public class SzczegolyTest
    {
       

        //Sprawdzanie czy inny uzytkownik mo¿e wejsc do szczegolow mojej aplikacji
        [Theory]
        [InlineData(2, 1, "BadRequestResult")]
        [InlineData(1,1, null)]
        public void SzczegolyErrorTestList(int kandydatID, int turaID, string resultView)
        {
            // Arrange

            var dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
                .UseInMemoryDatabase(databaseName: "SzczegolyTest")
                .Options;

            using (var dbContext = new DataDbContext(dbContextOptions))
            {
                if(dbContext.Kandydaci.Count() == 0)
                {
                    PrepareDB(dbContext);
                }


                var controller = new HistoriaZakonczonychAplikacjiController(dbContext, null);


                // Act
                var result = controller.Szczegoly(kandydatID, turaID);


                // Assert
                if (resultView == null)
                {
                    var viewResult = Assert.IsType<ViewResult>(result);
                    Assert.Equal(resultView, viewResult.ViewName);
                }
                else
                {
                    Assert.IsType<BadRequestResult>(result);
                }

            }
        }



        private void PrepareDB(DataDbContext dbContext)
        {


            dbContext.KierunkiStudiow.Add( new KierunekStudiow(
                1, 1, 0.0, 1500.0, 2, 0, "Architektura", 0, 0, "Architektura dla ambitnych", 0
            ));
            dbContext.Adresy.Add(new Adres(1, "Aleje Jerozolimskie", "123", "00-001", "Warszawa"));
            dbContext.AplikacjeRekrutacyjne.Add(new AplikacjaRekrutacyjna(1, 1, 1, 1, new DateTime(2023, 1, 15), 4, 1));
            dbContext.Kandydaci.Add(new Kandydat(1, 1, "12345678901", "Jan", "Kowalski", "jan.kowalski@example.com"));
            dbContext.TuryRekrutacji.Add(new TuraRekrutacji(
                1, 1, new DateTime(2024, 1, 1), new DateTime(2023, 2, 1), new DateTime(2023, 2, 15), 50, 50, 300.0, 4, 2
            ));
            dbContext.OplatyRekrutacyjne.Add(new OplataRekrutacyjna(
                1, 1, 80.0
            ));
            dbContext.WspolczynnikiRekrutacyjne.Add(new WspolczynnikRekrutacyjny(
                1, 1
            ));

            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(1, 70, 1, 0, 1, null));
            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(2, 70, 1, 3, 1, null));
            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(3, 70, 1, 1, 1, null));
            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(4, 70, 1, 1, 0, null));
            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(5, 70, 1, 2, 0, null));
            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(6, 70, 1, 2, 1, null));
            dbContext.SkladoweWspRekrut.Add(new SkladowaWspRekrut(7, 70, 1, 0, 0, null));

            dbContext.SaveChanges();
        }
    }
}
