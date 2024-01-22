﻿using Aurora.Enums;
using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrut1Stopien: IStrategiaWspolRekrut
    {
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
        public abstract bool HasRequiredValues(List<SkladowaWspRekrut> skladowe);
    }
}
