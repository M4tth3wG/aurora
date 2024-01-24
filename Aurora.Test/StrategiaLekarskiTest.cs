using Aurora.Enums;
using Aurora.Models;
using Aurora.OtherClasses.StrategiesForRR;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Aurora.Test
{
    public class StrategiaLekarskiTest
    {

        private StrategiaLekarski strategia = new();

        public static IEnumerable<object[]> TestDataContainsAppropriateComponent() 
        {
            yield return new object[] { new List<SkladowaWspRekrut> {
                new() {
                    LiczbaPunktow = 188.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.B
                },

                new() {
                    LiczbaPunktow = 76.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Matematyka,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.M
                },

                new() {
                    LiczbaPunktow = 94.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.P
                },
            }, 188.0};
            
            yield return new object[] { new List<SkladowaWspRekrut> {
                new() {
                    LiczbaPunktow = 188.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Matematyka,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.M
                },

                new() {
                    LiczbaPunktow = 76.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Matematyka,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.M
                },

                new() {
                    LiczbaPunktow = 94.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.R
                }
            }, 235.0};
        }

        public static IEnumerable<object[]> TestDataContainsInappropriateComponent()
        {
            yield return new object[] { new List<SkladowaWspRekrut> {
                new() {
                    LiczbaPunktow = 213.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.PD
                },

                new() {
                    LiczbaPunktow = 76.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.P
                },

                new() {
                    LiczbaPunktow = 94.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.D
                }
            }};

            yield return new object[] { new List<SkladowaWspRekrut> {
                new() {
                    LiczbaPunktow = 1.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.JezykPolski,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.B
                },

                new() {
                    LiczbaPunktow = 49.0,
                    PrzedmiotMaturalny = (int)PrzedmiotMaturalny.Biologia,
                    RodzajSkladowejWspRekrut = (int)RodzajSkladowejWspRekrut.M
                }
            }};
        }

        [Theory]
        [MemberData(nameof(TestDataContainsAppropriateComponent))]
        public void GetMedBiologyPoints_ContainsAppropriateComponent_ReturnsPoints(List<SkladowaWspRekrut> skladowe, double expectedPoints)
        {
            var result = strategia.GetMedBiologyPoints(skladowe);

            Assert.Equal(expectedPoints, result, 5);
        }

        [Theory]
        [MemberData(nameof(TestDataContainsInappropriateComponent))]
        public void GetMedBiologyPoints_ContainsInAppropriateComponent_ReturnsZeros(List<SkladowaWspRekrut> skladowe)
        {
            var result = strategia.GetMedBiologyPoints(skladowe);

            Assert.Equal(0.0, result, 5);
        }

    }
}
