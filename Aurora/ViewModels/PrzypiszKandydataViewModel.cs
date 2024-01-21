using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.ViewModels
{
    [NotMapped]
    public class PrzypiszKandydataViewModel
    {

        public string FilterPoziom { get; set; }
        public string FilterForma { get; set; }
        public string FilterJezyk { get; set; }
        public string FilterWydzial { get; set; }
        public string FilterMiejsce { get; set; }

        public string SearchFilter { get; set; }

        public readonly IEnumerable<SelectListItem> poziomyStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<PoziomStudiow>();
        public readonly IEnumerable<SelectListItem> formyStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<FormaStudiow>();
        public readonly IEnumerable<SelectListItem> jezykiStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<Jezyk>();
        public readonly IEnumerable<SelectListItem> wydzialy = EnumUtils.GetWartosciEnumaJakoSelectList<NazwaWydzialu>();
        public readonly IEnumerable<SelectListItem> miejscaStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<MiejsceStudiow>();

        public List<AplikacjaRekrutacyjna> FilterAplikacje { get; set; }

        public Kandydat Kandydat { get; set; }
    }
}
