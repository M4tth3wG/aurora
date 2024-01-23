using Aurora.Enums;
using System.Collections.Generic;

namespace Aurora.Utils
{
    public static class Consts
    {

        public readonly static List<PrzedmiotMaturalny> defaultMaturaSubjects = new() { PrzedmiotMaturalny.Matematyka, PrzedmiotMaturalny.JezykPolski, PrzedmiotMaturalny.JezykObcy };
        public readonly static List<PrzedmiotMaturalny> defaultExtraMaturaSubjects = new() { PrzedmiotMaturalny.Fizyka };
        public readonly static List<PrzedmiotMaturalny> defaultExtraMaturaSubjectsMed = new() { PrzedmiotMaturalny.Biologia, PrzedmiotMaturalny.Fizyka };


        public readonly static Dictionary<PrzedmiotMaturalny, (string, string)> SubjectFormKeys = new()
        {
            { PrzedmiotMaturalny.JezykPolski, ("PolPodst", "PolRoz" ) },
            { PrzedmiotMaturalny.Matematyka, ("MatPodst", "MatRoz" ) },
            { PrzedmiotMaturalny.JezykObcy, ("ObcPodst", "ObcRoz" ) },
            { PrzedmiotMaturalny.Fizyka, ("FizPodst", "FizRoz" ) },
            { PrzedmiotMaturalny.Chemia, ("ChePodst", "CheRoz" ) },
            { PrzedmiotMaturalny.Biologia, ("BioPodst", "BioRoz" ) },
            { PrzedmiotMaturalny.Geografia, ("GeoPodst", "GeoRoz" ) },
            { PrzedmiotMaturalny.Informatyka, ("InfoPodst", "InfoRoz" ) }
        };

        public readonly static Dictionary<PrzedmiotMaturalny, List<RodzajSkladowejWspRekrut>> basicMaturaSubjectDict = new()
        {
            { PrzedmiotMaturalny.JezykPolski, new () {RodzajSkladowejWspRekrut.P, RodzajSkladowejWspRekrut.JP } },
            { PrzedmiotMaturalny.JezykObcy, new () {RodzajSkladowejWspRekrut.P, RodzajSkladowejWspRekrut.JO } },
            { PrzedmiotMaturalny.Matematyka, new () {RodzajSkladowejWspRekrut.P, RodzajSkladowejWspRekrut.M} }
        };
        

       public static List<(RodzajSkladowejWspRekrut, PrzedmiotMaturalny, string)> RRFormValuesConverterList = new() {
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Matematyka, "MatPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Matematyka, "MatRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.JezykPolski, "PolPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.JezykPolski, "PolRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.JezykObcy, "ObcPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.JezykObcy, "ObcRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Fizyka, "FizPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Fizyka, "FizRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Chemia, "ChePodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Chemia, "CheRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Geografia, "GeoPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Geografia, "GeoRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Biologia, "BioPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Biologia, "BioRoz"),
            (RodzajSkladowejWspRekrut.P, PrzedmiotMaturalny.Informatyka, "InfoPodst"),
            (RodzajSkladowejWspRekrut.R, PrzedmiotMaturalny.Informatyka, "InfoRoz"),
        };

        public const double DEFAULT_RR_MAX_VALUE = 535.0;
        public const double ARCHITECTURE_DEFAULT_RR_MAX_VALUE = 1195.0;
    }
}
