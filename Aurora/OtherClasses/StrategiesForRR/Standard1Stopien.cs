using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using Aurora.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class Standard1Stopien : StrategiaWspolRekrut1Stopien

    {

        public Standard1Stopien(List<PrzedmiotMaturalny> przedmiotyMaturalne = null) : base(Consts.defaultMaturaSubjects.Union(przedmiotyMaturalne ?? new() { }).ToList())
        {

        }

        public override double WyliczPunkty(List<SkladowaWspRekrut> skladowe)
        {
            if (!UtilsRR.HasPassedMatura(skladowe, przedmiotyMaturalne)) return 0.0;

            var punktyPD = UtilsRR.GetPointsPD(skladowe, przedmiotyMaturalne);
            var (punktyMatematyka, punktyJezykObcy, punktyJezykPolski) = UtilsRR.GetBasicPoints(skladowe);

            return UtilsRR.GetMin(UtilsRR.WyliczPunktyKlasycznie(punktyMatematyka, punktyPD, punktyJezykObcy, punktyJezykPolski), Consts.DEFAULT_RR_MAX_VALUE);
        }

    }
}
