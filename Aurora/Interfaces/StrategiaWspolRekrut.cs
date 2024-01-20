using Aurora.Models;
using Aurora.ViewModels;
using System.Collections.Generic;

namespace Aurora.Interfaces
{
    public abstract class StrategiaWspolRekrut
    {
        public abstract double WyliczPunkty(List<SkladowaWspRekrut> skladowe);

    }
}
