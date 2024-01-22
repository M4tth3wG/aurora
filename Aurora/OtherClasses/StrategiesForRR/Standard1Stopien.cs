using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.Models;
using Aurora.Utils;
using Aurora.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.OtherClasses.StrategiesForRR
{
    public class Standard1Stopien : StrategiaWspolRekrut1Stopien

    {

        public Standard1Stopien(List<PrzedmiotMaturalny> przedmiotyMaturalne = null) : base(Consts.defaultExtraMaturaSubjects.Union(przedmiotyMaturalne ?? new() { }).ToList())
        {

        }

        public override double GetAverageGradePoints(List<SkladowaWspRekrut> skladowe)
        {
            return 0.0;
        }

        public override double GetBasicPoints(List<SkladowaWspRekrut> skladowe)
        {
            var(punktyMatematyka, punktyJezykObcy, punktyJezykPolski) = UtilsRR.GetBasicPoints(skladowe);
            return punktyMatematyka + 0.1 * punktyJezykObcy + 0.1 * punktyJezykPolski;
        }

        public override double GetDPoints(List<SkladowaWspRekrut> skladowe)
        {
            return 0.0;
        }

        public override double GetExamPoints(List<SkladowaWspRekrut> skladowe)
        {
            return 0.0;
        }

        public override double GetExtraSubjectPoints(List<SkladowaWspRekrut> skladowe)
        {
            return UtilsRR.GetPointsPD(skladowe, przedmiotyMaturalneDodatkowe);
        }

        public override double GetMedBiologyPoints(List<SkladowaWspRekrut> skladowe)
        {
            return 0.0;
        }

        public override double GetODPoints(List<SkladowaWspRekrut> skladowe)
        {
            return 0.0;
        }

        public override bool HasRequiredValues(List<SkladowaWspRekrut> skladowe)
        {
            return UtilsRR.HasPassedMatura(skladowe, przedmiotyMaturalneDodatkowe);
        }
    }
}
