using Aurora.Models;
using Aurora.ViewModels;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public interface StrategiaWspolRekrut
    {
        double WyliczPunkty(List<SkladowaWspRekrut> skladowe);

    }
}
