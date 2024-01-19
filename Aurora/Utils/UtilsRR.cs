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


        private static readonly List<string> kierunkiBiologiaMatura = new()
        {
            "inżynieria biomedyczna",
            "gospodarka o obiegu zamkniętym i ochrona klimatu"
        };

        private static readonly List<string> kierunkiChemiaMatura = new()
        {
           "biotechnologia",
           "chemia i analityka przemysłowa",
           "chemia i inżynieria materiałów",
           "gospodarka o obiegu zamkniętym i ochrona klimatu",
           "górnictwo i geologia",
           "inżynieria biomedyczna",
           "inżynieria chemiczna i procesowa",
           "inżynieria surowców mineralnych",
           "technologia chemiczna"
        };

        private static readonly List<string> kierunkiGeografiaMatura = new()
        {
            "geodezja i kartografia",
            "geoenergetyka",
            "geoinformatyka",
            "górnictwo i geologia",
            "inżynieria surowców mineralnych"
        };

        private static readonly List<string> kierunkiInformatykaMatura = new()
         {
            "cyberbezpieczeństwo",
            "geodezja i kartografia",
            "geoenergetyka",
            "geoinformatyka",
            "informatyczne systemy automatyki",
            "informatyka algorytmiczna",
            "informatyka stosowana",
            "informatyka techniczna",
            "inżynieria systemów",
            "inżynieria zarządzania",
            "matematyka",
            "matematyka stosowana",
            "teleinformatyka",
            "telekomunikacja",
            "zarządzanie"
        };

        public static double GetMax(params double[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Brak liczb do porównania");
            }
            return numbers.ToList().Max();
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

        // P, P + 1.5 * R, 2.5 * R
        public static double GetPoints(Dictionary<string, int?> results, string keyP, string keyR)
        {
            var P = results[keyP] ?? 0.0;
            var R = results[keyR] ?? 0.0;
            return GetMax(P, P + 1.5 * R, 2.5 * R);
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
        public static double GetPointsPD(WyliczWspolczynnikViewModel model, List<(string, string)> keys)
        {
            double PD = 0.0;
            foreach (var (keyP, keyR) in keys)
            {
                var currentPoints = GetPoints(model.wynikiMaturalne, keyP, keyR);
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

        public static bool HasPassedMatura(List<SkladowaWspRekrut> components, List<PrzedmiotMaturalny> maturaSubjects)
        {
            foreach (var subject in maturaSubjects)
            {
                var subjectComponents = components.Where(c => c.PrzedmiotMaturalny == Convert.ToInt32(subject)).ToList();
                if (subjectComponents.Count == 0) return false;
            }

            return true;
        }

        public static double GetExamPoints(List<SkladowaWspRekrut> components)
        {
            var examComponent = components.Where(c => c.RodzajSkladowejWspRekrut == E).FirstOrDefault();
            if (examComponent != null) return examComponent.LiczbaPunktow;
            return 0.0;
        }

        public static double WyliczPunktyKlasycznie(double punktyMatematyka, double punktyPD, double punktyJezykObcy, double punktyJezykPolski)
        {
            return punktyMatematyka + punktyPD + 0.1 * punktyJezykObcy + 0.1 * punktyJezykPolski;
        }




        public static StrategiaWspolRekrut GetStrategiaDlaKierunku(KierunekStudiow kierunek)
        {
            var poziom = EnumUtils.ConvertIDToType<PoziomStudiow>(kierunek.PoziomStudiow);
            switch (poziom)
            {
                case PoziomStudiow.drugiegoStopnia:
                    return GetStrategiaDlaKierunku2Stopien(kierunek);

                case PoziomStudiow.jednoliteMagisterskie:
                    return GetStrategiaDlaKierunkuJednolite(kierunek);

                case PoziomStudiow.pierwszegoStopniaLicencjackie:
                case PoziomStudiow.pierwszegoStopniaInzynierskie:
                    return GetStrategiaDlaKierunku1Stopien(kierunek);

                default:
                    return null;

            }

        }


        private static StrategiaWspolRekrut1Stopien GetStrategiaDlaKierunku1Stopien(KierunekStudiow kierunek)
        {
            var maturaSubjectList = new List<PrzedmiotMaturalny> { PrzedmiotMaturalny.Fizyka };
            var kierunekNameLowerCase = kierunek.NazwaKierunku.ToLower().Trim();
            if (kierunkiBiologiaMatura.Contains(kierunekNameLowerCase)) maturaSubjectList.Add(PrzedmiotMaturalny.Biologia);
            if (kierunkiChemiaMatura.Contains(kierunekNameLowerCase)) maturaSubjectList.Add(PrzedmiotMaturalny.Chemia);
            if (kierunkiGeografiaMatura.Contains(kierunekNameLowerCase)) maturaSubjectList.Add(PrzedmiotMaturalny.Geografia);
            if (kierunkiInformatykaMatura.Contains(kierunekNameLowerCase)) maturaSubjectList.Add(PrzedmiotMaturalny.Informatyka);
            return new Standard1Stopien(maturaSubjectList);
        }

        private static StrategiaWspolRekrut2Stopien GetStrategiaDlaKierunku2Stopien(KierunekStudiow kierunek)
        {
            return default;
        }

        private static StrategiaWspolRekrutJednolite GetStrategiaDlaKierunkuJednolite(KierunekStudiow kierunek)
        {
            return kierunek.NazwaKierunku.ToLower() switch
            {
                "lekarski" => new StrategiaLekarski(),
                "architektura" => new StrategiaArchitektura(),
                _ => default
            };
        }


        static List<(RodzajSkladowejWspRekrut, PrzedmiotMaturalny, string)> x = new() {
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Matematyka, "MatPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Matematyka, "MatRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.JezykPolski, "PolPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.JezykPolski, "PolRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.JezykObcy, "ObcPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.JezykObcy, "ObcRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Fizyka, "FizPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Fizyka, "FizRoz"), 
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Chemia, "ChePodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Chemia, "CheRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Geografia, "GeoPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Geografia, "GeoRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Biologia, "BioPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Biologia, "BioRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Informatyka, "InfoPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Informatyka, "InfoRoz"),
        };

        public static List<SkladowaWspRekrut> ConvertFormPointsToComponents(WyliczWspolczynnikViewModel model)
        {
            List<SkladowaWspRekrut> result = new() { };
            foreach (var (type, subject, key) in x)
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
                        RodzajSkladowejWspRekrut = Convert.ToInt32(RodzajSkladowejWspRekrut.E)
                    }
                );
            }
            return result;
        }
    }
}
