using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
using Aurora.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrut1Stopien: IStrategiaWspolRekrut
    {
        private readonly static RodzajSkladowejWspRekrut P = RodzajSkladowejWspRekrut.P;
        private readonly static RodzajSkladowejWspRekrut R = RodzajSkladowejWspRekrut.R;
        private readonly static RodzajSkladowejWspRekrut PD = RodzajSkladowejWspRekrut.PD;

        public List<PrzedmiotMaturalny> przedmiotyMaturalneDodatkowe { get; }

        public StrategiaWspolRekrut1Stopien(List<PrzedmiotMaturalny> przedmiotyMaturalne)
        {
            this.przedmiotyMaturalneDodatkowe = przedmiotyMaturalne;
        }
        
        public StrategiaWspolRekrut1Stopien()
        {
            this.przedmiotyMaturalneDodatkowe = new () 
            {
                PrzedmiotMaturalny.Fizyka,
            };
        }

        public abstract double GetBasicPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetExtraSubjectPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetMedBiologyPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetDPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetAverageGradePoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetODPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetExamPoints(List<SkladowaWspRekrut> skladowe);
        public bool HasRequiredValues(List<SkladowaWspRekrut> skladowe)
        { 
            return !GetMissingSubjects(skladowe).Any();
        }
        public List<string> GetMissingSubjects(List<SkladowaWspRekrut> skladowe)
        {
            var missingSubjects = new List<string>();

            foreach(var (subject, types) in Consts.basicMaturaSubjectDict)
            {
                var cmp = skladowe.FirstOrDefault(s => IsComponentValid(s, subject, types));
                if (cmp == null) missingSubjects.Add(EnumUtils.GetDescription(subject));
            }

            foreach (var subject in przedmiotyMaturalneDodatkowe)
            {
                var cmp = skladowe.FirstOrDefault(s => IsComponentValid(s, subject, new() { P, R, PD }));
                if (cmp == null) missingSubjects.Add(EnumUtils.GetDescription(subject));
            }

            return missingSubjects;
        }

        public static bool IsComponentValid(SkladowaWspRekrut cmp, PrzedmiotMaturalny subject, List<RodzajSkladowejWspRekrut> types)
        {
            return cmp.PrzedmiotMaturalny == (int)subject && types.Contains(EnumUtils.ConvertIDToType<RodzajSkladowejWspRekrut>(cmp.RodzajSkladowejWspRekrut));
        }
    }
}
