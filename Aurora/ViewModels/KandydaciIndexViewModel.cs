using Aurora.Enums;
using Aurora.Models;
using Aurora.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Aurora.ViewModels
{
    public class KandydaciIndexViewModel
    {
        public string FilterPoziom { get; set; }
        public string FilterForma { get; set; }
        public string FilterJezyk { get; set; }
        public string FilterWydzial { get; set; } = NazwaWydzialu.None.ToString();
        public string FilterMiejsce { get; set; }

        public string SearchFilter { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public readonly IEnumerable<SelectListItem> poziomyStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<PoziomStudiow>();
        [JsonIgnore]
        [IgnoreDataMember]
        public readonly IEnumerable<SelectListItem> formyStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<FormaStudiow>();
        [JsonIgnore]
        [IgnoreDataMember]
        public readonly IEnumerable<SelectListItem> jezykiStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<Jezyk>();
        //public readonly IEnumerable<SelectListItem> wydzialy = EnumUtils.GetWartosciEnumaJakoSelectList<NazwaWydzialu>();
        [JsonIgnore]
        [IgnoreDataMember]
        public readonly IEnumerable<SelectListItem> wydzialy = EnumUtils.GetEnumSelectList<NazwaWydzialu>();
        [JsonIgnore]
        [IgnoreDataMember]
        public readonly IEnumerable<SelectListItem> miejscaStudiow = EnumUtils.GetWartosciEnumaJakoSelectList<MiejsceStudiow>();

        [JsonIgnore]
        [IgnoreDataMember]
        public List<AplikacjaRekrutacyjna> FilterAplikacje { get; set; }

        public string PostMessage { get; set; } = "";

        public bool CzyDowolnyWydzial => FilterWydzial == NazwaWydzialu.None.ToString() || FilterWydzial == ((int)NazwaWydzialu.None).ToString();
    }
}
