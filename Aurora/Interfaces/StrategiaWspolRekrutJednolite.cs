using Aurora.Enums;
using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrutJednolite: StrategiaWspolRekrut1Stopien
    {
        public abstract override double WyliczPunkty(List<SkladowaWspRekrut> skladowe);

        public StrategiaWspolRekrutJednolite(List<PrzedmiotMaturalny> przedmiotyMaturalne): base(przedmiotyMaturalne)
        {
            
        }
    }
}
