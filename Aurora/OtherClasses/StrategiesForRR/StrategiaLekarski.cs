using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class StrategiaLekarski: Strategia1StopienStandard
    {
        public StrategiaLekarski(List<PrzedmiotMaturalny> przedmiotyMaturalne = null) : base(Consts.defaultExtraMaturaSubjectsMed)
        {
        }
        
        public override double GetMedBiologyPoints(List<SkladowaWspRekrut> skladowe)
        {
            var cmpBio = skladowe.FirstOrDefault(c => c.RodzajSkladowejWspRekrut == Convert.ToInt32(RodzajSkladowejWspRekrut.B) && c.PrzedmiotMaturalny == Convert.ToInt32(PrzedmiotMaturalny.Biologia));
            if (cmpBio != null) return cmpBio.LiczbaPunktow;
            return skladowe.FirstOrDefault(c => c.RodzajSkladowejWspRekrut == Convert.ToInt32(RodzajSkladowejWspRekrut.R) && c.PrzedmiotMaturalny == Convert.ToInt32(PrzedmiotMaturalny.Biologia))?.LiczbaPunktow * 2.5 ?? 0.0;
        }

    }
}
