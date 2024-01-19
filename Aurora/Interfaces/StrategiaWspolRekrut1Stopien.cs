using Aurora.Enums;
using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public interface StrategiaWspolRekrut1Stopien: StrategiaWspolRekrut
    {
        new double WyliczPunkty(List<SkladowaWspRekrut> skladowe);
    }
}
