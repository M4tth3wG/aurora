using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using System.Collections.Generic;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class AiR1Stopien : StrategiaWspolRekrut

    {
        public double WyliczPunkty(List<SkladowaWspRekrut> skladowe)
        {
            if (!UtilsRR.HasPassedMatura(skladowe, new List<PrzedmiotMaturalny>() { PrzedmiotMaturalny.Fizyka })) return 0.0;

            var punktyMatematyka = UtilsRR.GetPoints(skladowe, RodzajSkladowejWspRekrut.M, PrzedmiotMaturalny.Matematyka);
            var punktyFizyka = UtilsRR.GetPoints(skladowe, RodzajSkladowejWspRekrut.PD, PrzedmiotMaturalny.Fizyka);
            var punktyJezykObcy = UtilsRR.GetPoints(skladowe, RodzajSkladowejWspRekrut.JO, PrzedmiotMaturalny.JezykObcy);
            var punktyJezykPolski = UtilsRR.GetPoints2(skladowe, RodzajSkladowejWspRekrut.JP, PrzedmiotMaturalny.JezykPolski);

            return punktyMatematyka + punktyFizyka + 0.1 * punktyJezykObcy + 0.1 * punktyJezykPolski;
        }
    }
}
