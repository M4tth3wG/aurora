using Aurora.Models;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public interface StrategiaWspolRekrutJednolite: StrategiaWspolRekrut
    {
        new double WyliczPunkty(List<SkladowaWspRekrut> skladowe);
    }
}
