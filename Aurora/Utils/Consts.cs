using Aurora.Enums;
using System.Collections.Generic;

namespace Aurora.Utils
{
    public static class Consts
    {

        public readonly static List<PrzedmiotMaturalny> defaultMaturaSubjects = new() { PrzedmiotMaturalny.Matematyka, PrzedmiotMaturalny.JezykPolski, PrzedmiotMaturalny.JezykObcy, PrzedmiotMaturalny.Fizyka } ;
        public readonly static List<PrzedmiotMaturalny> defaultMaturaSubjectsMed = new() { PrzedmiotMaturalny.Biologia,PrzedmiotMaturalny.Fizyka, PrzedmiotMaturalny.Matematyka, PrzedmiotMaturalny.JezykPolski, PrzedmiotMaturalny.JezykObcy } ;
        
        
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

        public const double DEFAULT_RR_MAX_VALUE = 535.0;
        public const double ARCHITECTURE_DEFAULT_RR_MAX_VALUE = 1195.0;
    }
}
