using Aurora.Controllers;
using Aurora.Data;
using Aurora.Enums;
using Aurora.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aurora.Test
{
    public class AplikacjeControllerTest
    {

        static readonly List<Kandydat> kandydaci = new List<Kandydat>()
        {
            new Kandydat()
            {
                ID = 1,
                AdresEmail = "test1@test"
            },
            new Kandydat()
            {
                ID = 2,
                AdresEmail = "test2@test"
            },
            new Kandydat()
            {
                ID = 3,
                AdresEmail = "test3@test"
            },
            new Kandydat()
            {
                ID = 4,
                AdresEmail = "test4@test"
            }
        };

        [Theory, MemberData(nameof(AplikacjeDane))]
        public void IndexTest(Kandydat kandydat, string expectedViewName)
        {
            // Arrange

            var httpContextMock = new Mock<HttpContext>();

            httpContextMock.Setup(
                x => x.User.Identity.Name
                ).Returns(kandydat.AdresEmail);

            var dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
               .UseInMemoryDatabase(databaseName: "bazaAplikacjeTest")
               .Options;

            using (var dbContext = new DataDbContext(dbContextOptions))
            {
                if (!dbContext.Kandydaci.Any())
                {
                    PrepareDb(dbContext);
                }

                var controller = new AplikacjeController(dbContext);

                controller.ControllerContext = new ControllerContext();

                controller.ControllerContext.HttpContext = httpContextMock.Object;


                // Act
                var result = controller.Index().Result;
                


                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);

                Assert.Equal(expectedViewName, viewResult.ViewName);
            }

        }

        public static IEnumerable<object[]> AplikacjeDane()
        {

            return new List<object[]>
            {
                new object[] { kandydaci[0], "BrakAplikacji" },
                new object[] { kandydaci[1], "BrakAplikacji" },
                new object[] { kandydaci[2], null },
                new object[] { kandydaci[3], null }
            };
        }

        private void PrepareDb(DataDbContext dbContext)
        {
            var aplikacje = new List<AplikacjaRekrutacyjna>() {
                    new AplikacjaRekrutacyjna() {
                        ID = 1,
                        TuraRekrutacjiID = 2,
                        KierunekStudiowID = 1,
                        KandydatID = 2,
                        Status = (int)RodzajStatusuAplikacji.OczekujeNaRozpatrzenie

                    },
                    new AplikacjaRekrutacyjna() {
                        ID = 2,
                        TuraRekrutacjiID = 4,
                        KierunekStudiowID = 1,
                        KandydatID = 2,
                        Status = (int)RodzajStatusuAplikacji.ZakonczonaSukcesem

                    },
                    new AplikacjaRekrutacyjna() {
                        ID = 3,
                        TuraRekrutacjiID = 1,
                        KierunekStudiowID = 1,
                        KandydatID = 3,
                        Status = (int)RodzajStatusuAplikacji.OczekujeNaRozpatrzenie

                    },
                    new AplikacjaRekrutacyjna() {
                        ID = 4,
                        TuraRekrutacjiID = 3,
                        KierunekStudiowID = 1,
                        KandydatID = 4,
                        Status = (int)RodzajStatusuAplikacji.ZakonczonaSukcesem

                    }
                };

            aplikacje.ForEach(a => dbContext.AplikacjeRekrutacyjne.Add(a));

            var tury = new List<TuraRekrutacji>() {
                    new TuraRekrutacji() {
                        ID = 1,
                        KierunekStudiowID = 1,
                        StatusTury = (int)RodzajStatusuTury.otwarta
                    },
                    new TuraRekrutacji() {
                        ID = 2,
                        KierunekStudiowID = 1,
                        StatusTury = (int)RodzajStatusuTury.zakonczona
                    },
                    new TuraRekrutacji() {
                        ID = 3,
                        KierunekStudiowID = 1,
                        StatusTury = (int)RodzajStatusuTury.zamknieta
                    },
                    new TuraRekrutacji() {
                        ID = 4,
                        KierunekStudiowID = 1,
                        StatusTury = (int)RodzajStatusuTury.anulowana
                    }
                };

            tury.ForEach(t => dbContext.TuryRekrutacji.Add(t));

            kandydaci.ForEach(k => dbContext.Kandydaci.Add(k));

            dbContext.KierunkiStudiow.Add(new KierunekStudiow()
            {
                ID = 1
            });

            dbContext.SaveChanges();
        }
    }
}
