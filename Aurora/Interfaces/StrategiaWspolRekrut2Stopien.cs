using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public interface StrategiaWspolRekrut2Stopien: StrategiaWspolRekrut
    {
        new double WyliczPunkty(List<SkladowaWspRekrut> skladowe);
    }
}
