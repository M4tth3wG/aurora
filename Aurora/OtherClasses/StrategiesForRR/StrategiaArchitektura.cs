using Aurora.Data;
using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class StrategiaArchitektura : Standard1Stopien

    {
        public StrategiaArchitektura(List<PrzedmiotMaturalny> przedmiotyMaturalne = null): base(Consts.defaultMaturaSubjects)
        {
        }

        public override double GetExamPoints(List<SkladowaWspRekrut> skladowe)
        {
            return skladowe.FirstOrDefault(c => c.RodzajSkladowejWspRekrut == Convert.ToInt32(RodzajSkladowejWspRekrut.E))?.LiczbaPunktow ?? 0.0;
        }
    }
}
