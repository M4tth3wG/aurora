using Aurora.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.ViewModels
{
    [NotMapped]
    public class WyliczWspolczynnikViewModel
    {
        public int KierunekID {  get; set; }
        public string NazwaKierunku{  get; set; }

        public Dictionary<string, int?> wynikiMaturalne {  get; set; }

        public WyliczWspolczynnikViewModel() {
            wynikiMaturalne = new Dictionary<string, int?>()
            {
                {"MatPodst", null},
                {"MatRoz", null},
                {"PolPodst", null},
                {"PolRoz", null},
                {"ObcPodst", null},
                {"ObcRoz", null},
                {"FizPodst", null},
                {"FizRoz", null},
                {"ChePodst", null},
                {"CheRoz", null},
                {"GeoPodst", null},
                {"GeoRoz", null},
                {"BioPodst", null},
                {"BioRoz", null},
                {"InfoPodst", null},
                {"InfoRoz", null},
                {"EgzRys", null}
            };
        }

        public WyliczWspolczynnikViewModel(KierunekStudiow kierunek): this()
        {
            NazwaKierunku = kierunek.NazwaKierunku;
            KierunekID = kierunek.ID;
        }  
        
        public WyliczWspolczynnikViewModel(int id, string nazwaKierunku): this()
        {
            NazwaKierunku = nazwaKierunku;
            KierunekID = id;
        }
    }
}
