using Aurora.Models;
using Aurora.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Utils
{
    public static class UtilsRR
    {
        private static readonly int P = Convert.ToInt32(RodzajSkladowejWspRekrut.P);
        private static readonly int R = Convert.ToInt32(RodzajSkladowejWspRekrut.R);
        private static readonly int E = Convert.ToInt32(RodzajSkladowejWspRekrut.E);

        public static double GetMaxPointsCombination(double P, double R) 
        {
            var values = new List<double> { P, P + 1.5 * R, 2.5 * R };
            return values.Max();
        }
        
        public static double GetMaxPointsCombination2(double P, double R) 
        {
            if (P > R) return P;
            return R;
        }

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
                return GetMaxPointsCombination2(PPoints, RPoints);
            }
            return searchComponent.LiczbaPunktow;
        }

        public static bool HasPassedMatura(List<SkladowaWspRekrut> components, List<PrzedmiotMaturalny> maturaSubjects) 
        {
            var mathComponents = components.Where(c => c.PrzedmiotMaturalny == Convert.ToInt32(PrzedmiotMaturalny.Matematyka)).ToList();

            if (mathComponents.Count == 0) return false;            
            
            var polishComponents = components.Where(c => c.PrzedmiotMaturalny == Convert.ToInt32(PrzedmiotMaturalny.JezykPolski)).ToList();

            if (polishComponents.Count == 0) return false;            
            
            var foreignComponents = components.Where(c => c.PrzedmiotMaturalny == Convert.ToInt32(PrzedmiotMaturalny.JezykObcy)).ToList();

            if (foreignComponents.Count == 0) return false;

            foreach(var subject in maturaSubjects)
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
    }
}
