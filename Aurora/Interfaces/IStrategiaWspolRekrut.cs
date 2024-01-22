using Aurora.Models;
using Aurora.ViewModels;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public interface IStrategiaWspolRekrut
    {
        public double WyliczPunkty(List<SkladowaWspRekrut> skladowe)
        {
            if (HasRequiredValues(skladowe)) return GetBasicPoints(skladowe) + GetExtraSubjectPoints(skladowe) + GetMedBiologyPoints(skladowe) +
                GetDPoints(skladowe) + GetAverageGradePoints(skladowe) + GetODPoints(skladowe) + GetExamPoints(skladowe);

            return 0.0;
        }

        public abstract double GetBasicPoints(List<SkladowaWspRekrut> skladowe);

        public abstract double GetExtraSubjectPoints(List<SkladowaWspRekrut> skladowe);

        public abstract double GetMedBiologyPoints(List<SkladowaWspRekrut> skladowe);

        public abstract double GetDPoints(List<SkladowaWspRekrut> skladowe);

        public abstract double GetAverageGradePoints(List<SkladowaWspRekrut> skladowe);

        public abstract double GetODPoints(List<SkladowaWspRekrut> skladowe);
        
        public abstract double GetExamPoints(List<SkladowaWspRekrut> skladowe);

        public abstract bool HasRequiredValues(List<SkladowaWspRekrut> skladowe);


    }
}