using Aurora.Enums;
using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrut1Stopien: StrategiaWspolRekrut
    {
        public List<PrzedmiotMaturalny> przedmiotyMaturalne { get; }

        public StrategiaWspolRekrut1Stopien(List<PrzedmiotMaturalny> przedmiotyMaturalne)
        {
            this.przedmiotyMaturalne = przedmiotyMaturalne;
        }
        
        public StrategiaWspolRekrut1Stopien()
        {
            this.przedmiotyMaturalne = new () 
            {
                PrzedmiotMaturalny.JezykPolski,
                PrzedmiotMaturalny.Matematyka,
                PrzedmiotMaturalny.JezykObcy,
                PrzedmiotMaturalny.Fizyka,
            };
        }

        public abstract override double WyliczPunkty(List<SkladowaWspRekrut> skladowe);
    }
}
