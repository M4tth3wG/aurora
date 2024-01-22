using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class StrategiaLekarski: Standard1Stopien
    {
        public StrategiaLekarski(List<PrzedmiotMaturalny> przedmiotyMaturalne = null) : base(Consts.defaultExtraMaturaSubjectsMed)
        {
        }

        public override double GetMedBiologyPoints(List<SkladowaWspRekrut> skladowe)
        {
            return skladowe.FirstOrDefault(c => c.RodzajSkladowejWspRekrut == Convert.ToInt32(RodzajSkladowejWspRekrut.B)
            || (c.RodzajSkladowejWspRekrut == Convert.ToInt32(RodzajSkladowejWspRekrut.R) && c.PrzedmiotMaturalny == Convert.ToInt32(PrzedmiotMaturalny.Biologia)))?.PrzedmiotMaturalny ?? 0.0;
        }

    }
}
