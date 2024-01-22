using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrut2Stopien : IStrategiaWspolRekrut
    {
        public abstract double GetAverageGradePoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetBasicPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetDPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetExamPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetExtraSubjectPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetMedBiologyPoints(List<SkladowaWspRekrut> skladowe);
        public abstract double GetODPoints(List<SkladowaWspRekrut> skladowe);
        public abstract bool HasRequiredValues(List<SkladowaWspRekrut> skladowe);
    }
}
