using System.ComponentModel;

namespace Aurora.Enums
{
    public enum PrzedmiotMaturalny
    {
        Matematyka,
        [Description("Język obcy")]
        JezykObcy,
        [Description("Język Polski")]
        JezykPolski,
        Fizyka,
        Chemia,
        Geografia,
        Biologia,
        Informatyka
    }
}
