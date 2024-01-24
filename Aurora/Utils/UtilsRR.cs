using Aurora.Models;
using Aurora.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Aurora.Interfaces;
using Aurora.OtherClasses.StrategiesForRR;
using Aurora.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Aurora.Utils
{
    public static class UtilsRR
    {
        private static readonly int P = Convert.ToInt32(RodzajSkladowejWspRekrut.P);
        private static readonly int R = Convert.ToInt32(RodzajSkladowejWspRekrut.R);
        private static readonly int E = Convert.ToInt32(RodzajSkladowejWspRekrut.E);

        public static double GetMax(params double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("No numbers to compare.");
            }
            return numbers.ToList().Max();
        }
        
        public static double GetMin(params double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("No numbers to compare.");
            }
            return numbers.ToList().Min();
        }

        public static double GetMaxPointsCombination(double P, double R)
        {
            return GetMax(P, P + 1.5 * R, 2.5 * R);
        }

        // P, P + 1.5 * R, 2.5 * R
        public static double GetPoints(List<SkladowaWspRekrut> components, RodzajSkladowejWspRekrut comp, PrzedmiotMaturalny subject)
        {
            var compInt = Convert.ToInt32(comp);
            var searchComponent = components.Where(c => c.RodzajSkladowejWspRekrut == compInt).FirstOrDefault();
            if (searchComponent == null)
            {
                var subjectInt = Convert.ToInt32(subject);
                var subjectComponents = components.Where(s => s.PrzedmiotMaturalny == subjectInt);
                var PPoints = subjectComponents.Where(s => s.RodzajSkladowejWspRekrut == P).FirstOrDefault()?.LiczbaPunktow ?? 0.0;
                var RPoints = subjectComponents.Where(s => s.RodzajSkladowejWspRekrut == R).FirstOrDefault()?.LiczbaPunktow ?? 0.0;
                return GetMaxPointsCombination(PPoints, RPoints);
            }
            return searchComponent.LiczbaPunktow;

        }


        // P, R
        public static double GetPoints2(List<SkladowaWspRekrut> components, RodzajSkladowejWspRekrut comp, PrzedmiotMaturalny subject)
        {
            var compInt = Convert.ToInt32(comp);
            var searchComponent = components.Where(c => c.RodzajSkladowejWspRekrut == compInt).FirstOrDefault();
            if (searchComponent == null)
            {
                var subjectInt = Convert.ToInt32(subject);
                var subjectComponents = components.Where(s => s.PrzedmiotMaturalny == subjectInt);
                var PPoints = subjectComponents.Where(s => s.RodzajSkladowejWspRekrut == P).FirstOrDefault()?.LiczbaPunktow ?? 0.0;
                var RPoints = subjectComponents.Where(s => s.RodzajSkladowejWspRekrut == R).FirstOrDefault()?.LiczbaPunktow ?? 0.0;
                var newComp = new SkladowaWspRekrut()
                {
                    LiczbaPunktow = GetMax(PPoints, RPoints),
                    RodzajSkladowejWspRekrut = Convert.ToInt32(comp),
                    PrzedmiotMaturalny = subjectInt,
                };
                components.Add(newComp);
                return GetMax(PPoints, RPoints);
            }
            return searchComponent.LiczbaPunktow;
        }

        public static double GetPointsPD(List<SkladowaWspRekrut> skladowe, List<PrzedmiotMaturalny> extras)
        {
            double PD = 0.0;
            foreach (var subject in extras)
            {
                var currentPoints = GetPoints(skladowe, RodzajSkladowejWspRekrut.PD, subject);
                PD = GetMax(PD, currentPoints);
            }
            return PD;
        }

        public static (double, double, double) GetBasicPoints(List<SkladowaWspRekrut> skladowe)
        {
            var punktyMatematyka = GetPoints(skladowe, RodzajSkladowejWspRekrut.M, PrzedmiotMaturalny.Matematyka);
            var punktyJezykObcy = GetPoints(skladowe, RodzajSkladowejWspRekrut.JO, PrzedmiotMaturalny.JezykObcy);
            var punktyJezykPolski = GetPoints2(skladowe, RodzajSkladowejWspRekrut.JP, PrzedmiotMaturalny.JezykPolski);
            return (punktyMatematyka, punktyJezykObcy, punktyJezykPolski);
        }


        public static List<SkladowaWspRekrut> ConvertModelToComponents(WyliczWspolczynnikViewModel model)
        {
            List<SkladowaWspRekrut> result = new() { };
            foreach (var (type, subject, key) in Consts.RRFormValuesConverterList)
            {
                if (model.wynikiMaturalne[key] != null)
                {
                    result.Add(
                        new SkladowaWspRekrut
                        {
                            LiczbaPunktow = (double) model.wynikiMaturalne[key],
                            RodzajSkladowejWspRekrut = Convert.ToInt32(type),
                            PrzedmiotMaturalny = Convert.ToInt32(subject)
                        }
                    );
                }
            }
            if (model.wynikiMaturalne["EgzRys"] != null)
            {
                result.Add(
                new SkladowaWspRekrut
                {
                        LiczbaPunktow = (double) model.wynikiMaturalne["EgzRys"],
                        RodzajSkladowejWspRekrut = E
                    }
                );
            }
            return result;
        }

    }
}
