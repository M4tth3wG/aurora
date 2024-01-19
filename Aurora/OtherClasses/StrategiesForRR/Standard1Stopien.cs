using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using Aurora.ViewModels;
using System.Collections.Generic;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class Standard1Stopien : StrategiaWspolRekrut1Stopien

    {
        protected List<PrzedmiotMaturalny> przedmiotyMaturalne { get; }

        public Standard1Stopien(List<PrzedmiotMaturalny> przedmiotyMaturalne)
        {
            this.przedmiotyMaturalne = przedmiotyMaturalne;
        }

        public double WyliczPunkty(List<SkladowaWspRekrut> skladowe)
        {
            if (!UtilsRR.HasPassedMatura(skladowe, przedmiotyMaturalne)) return 0.0;

            var punktyPD = UtilsRR.GetPointsPD(skladowe, przedmiotyMaturalne);
            var (punktyMatematyka, punktyJezykObcy, punktyJezykPolski) = UtilsRR.GetBasicPoints(skladowe);

            return UtilsRR.WyliczPunktyKlasycznie(punktyMatematyka, punktyPD, punktyJezykObcy, punktyJezykPolski);
        }

    }
}
