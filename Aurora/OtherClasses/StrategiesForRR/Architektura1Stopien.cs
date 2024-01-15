using Aurora.Data;
using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class Architektura1Stopien : StrategiaWspolRekrut

    {
        public double WyliczPunkty(List<SkladowaWspRekrut> skladowe)
        {
            if (!UtilsRR.HasPassedMatura(skladowe, new List<PrzedmiotMaturalny>() { PrzedmiotMaturalny.Fizyka })) return 0.0;

            var punktyMatematyka = UtilsRR.GetPoints(skladowe, PrzedmiotMaturalny.Matematyka);
            var punktyFizyka = UtilsRR.GetPoints(skladowe, PrzedmiotMaturalny.Fizyka);
            var punktyJezykObcy = UtilsRR.GetPoints(skladowe, PrzedmiotMaturalny.JezykObcy);
            var punktyJezykPolski= UtilsRR.GetPoints2(skladowe, PrzedmiotMaturalny.JezykPolski);
            var punktyEgzamin = UtilsRR.GetExamPoints(skladowe);
               
            return punktyMatematyka + punktyFizyka + 0.1 * punktyJezykObcy + 0.1 * punktyJezykPolski + punktyEgzamin;
        }
    }
}
