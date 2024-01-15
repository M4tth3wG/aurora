using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public interface StrategiaWspolRekrut
    {
        double WyliczPunkty(List<SkladowaWspRekrut> skladowe);
    }
}
