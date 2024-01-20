using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class StrategiaLekarski: StrategiaWspolRekrutJednolite
    {
        public StrategiaLekarski(List<PrzedmiotMaturalny> przedmiotyMaturalne = null) : base(Consts.defaultMaturaSubjectsMed)
        {
        }

        public override double WyliczPunkty(List<SkladowaWspRekrut> skladowe)
        {
            if (!HasPassedMatura(skladowe)) return 0.0;

            var punktyFizyka = UtilsRR.GetPoints(skladowe, RodzajSkladowejWspRekrut.PD, PrzedmiotMaturalny.Fizyka);
            var punktyBiologia = GetBiologyPoints(skladowe);
            var (punktyMatematyka, punktyJezykObcy, punktyJezykPolski) = UtilsRR.GetBasicPoints(skladowe);
            if (punktyFizyka == 0 && punktyMatematyka == 0) 
            {
                punktyJezykObcy = 0;
                punktyJezykPolski = 0;
                punktyBiologia = 0;
            }

            return UtilsRR.GetMin(WyliczPunkty(punktyMatematyka, punktyFizyka, punktyBiologia, punktyJezykObcy, punktyJezykPolski), Consts.DEFAULT_RR_MAX_VALUE);
        }

        public double WyliczPunkty(double punktyMatematyka, double punktyFizyka, double punktyBiologia, double punktyJezykObcy, double punktyJezykPolski)
        {
            return punktyMatematyka + punktyBiologia + punktyFizyka + 0.1 * punktyJezykObcy + 0.1 * punktyJezykPolski;
        }

        public bool HasPassedMatura(List<SkladowaWspRekrut> components)
        {
            if (!UtilsRR.HasPassedMatura(components, Consts.defaultMaturaSubjects)) return false;

            return UtilsRR.HasPassedMatura(components, new() { PrzedmiotMaturalny.Biologia }) || UtilsRR.HasPassedMatura(components, new() { PrzedmiotMaturalny.Fizyka });
        }
        public static double GetBiologyPoints(List<SkladowaWspRekrut> components)
        {
            var compInt = Convert.ToInt32(RodzajSkladowejWspRekrut.B);
            var searchComponent = components.Where(c => c.RodzajSkladowejWspRekrut == compInt).FirstOrDefault();
            if (searchComponent == null)
            {
                var compIntR = Convert.ToInt32(RodzajSkladowejWspRekrut.R);
                var subjectInt = Convert.ToInt32(PrzedmiotMaturalny.Biologia);
                var subjectComponents = components.Where(s => s.PrzedmiotMaturalny == subjectInt);
                return subjectComponents.Where(s => s.RodzajSkladowejWspRekrut == compIntR).FirstOrDefault()?.LiczbaPunktow ?? 0.0;
            }
            return searchComponent.LiczbaPunktow;

        }


    }
}
