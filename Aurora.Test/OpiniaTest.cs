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
    public class OpiniaTest
    {


        //Sprawdzanie czy inny uzytkownik może wejsc do szczegolow mojej aplikacji
        [Theory]
        [InlineData(2, 1, null)]
        [InlineData(1, 1, "BadRequestResult")]
        public void OpiniaTestErrorWhenOpiniaWasAdded(int kandydatID, int turaID, string resultView)
        {
            // Arrange

            var dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
                .UseInMemoryDatabase(databaseName: "AuroraDB")
                .Options;

            using (var dbContext = new DataDbContext(dbContextOptions))
            {
                if (dbContext.Opinia.Count() == 0)
                {
                    PrepareDB(dbContext);
                }


                var controller = new HistoriaZakonczonychAplikacjiController(dbContext, null);


                // Act
                var result = controller.Opinia(kandydatID, turaID);


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

            dbContext.Opinia.Add(new Opinia()
            {
                KandydatID = 1,
                TuraRekrutacjiID = 1,
                IntuicyjnoscSystemu = 5,
                InformowanieOStatusie = 5
            });


            dbContext.AplikacjeRekrutacyjne.Add(new AplikacjaRekrutacyjna()
            {
                KandydatID = 1,
                TuraRekrutacjiID = 1,
            }
            );

            dbContext.AplikacjeRekrutacyjne.Add(new AplikacjaRekrutacyjna()
            {
                KandydatID = 2,
                TuraRekrutacjiID = 1,
            });

            dbContext.TuryRekrutacji.Add(new TuraRekrutacji()
            {
                ID = 1,
                StatusTury = 4
            });



            dbContext.SaveChanges();
        }
    }
}
