using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrut2Stopien: StrategiaWspolRekrut
    {
        public abstract override double WyliczPunkty(List<SkladowaWspRekrut> skladowe);
    }
}
