using System.ComponentModel;

namespace Aurora.Enums
{
    public enum RodzajStrategii
    {
        [Description("fizyka")]
        Strategia1StopienStandard,

        [Description("fizyka / geografia")]
        Strategia1StopienGeo,

        [Description("fizyka / chemia")]
        Strategia1StopienChem,

        [Description("fizyka / biologia")]
        Strategia1StopienBio,

        [Description("fizyka / informatyka")]
        Strategia1StopienInfo,

        [Description("fizyka / informatyka / geografia")]
        Strategia1StopienInfoGeo,

        [Description("fizyka / chemia / geografia")]
        Strategia1StopienGeoChem,

        [Description("fizyka / biologia / chemia")]
        Strategia1StopienBioChem,

        [Description("fizyka / egzamin z rysunku")]
        StrategiaArchitektura,

        [Description("fizyka i biologia")]
        StrategiaLekarski,
    }
}
