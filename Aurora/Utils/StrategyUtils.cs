using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.OtherClasses.StrategiesForRR;

namespace Aurora.Utils
{
    public static class StrategyUtils
    {

        public static IStrategiaWspolRekrut ConvertIDToStrategy(int id)
        {
            return id switch
            {
                0 => new Strategia1StopienStandard(),
                1 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Geografia }),
                2 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Chemia }),
                3 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Biologia }),
                4 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Informatyka }),
                5 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Informatyka, PrzedmiotMaturalny.Geografia }),
                6 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Chemia, PrzedmiotMaturalny.Geografia }),
                7 => new Strategia1StopienStandard(new() { PrzedmiotMaturalny.Chemia, PrzedmiotMaturalny.Biologia }),
                8 => new StrategiaArchitektura(),
                9 => new StrategiaLekarski(),
                _ => throw new System.Exception($"Unknown strategy ID: {id}!")
            };
        }
    }
}
