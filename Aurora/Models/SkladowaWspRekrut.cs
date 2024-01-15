using Aurora.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class SkladowaWspRekrut
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Liczba punktów")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Value must be greater than or equal to 0.0")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double LiczbaPunktow;

        public SkladowaWspRekrut()
        {
        }

        public SkladowaWspRekrut(int iD, double liczbaPunktow, int wspolczynnikRekrutacyjnyID, int? przedmiotMaturalnyID, int rodzajSkladowejWspRekrutID)
        {
            ID = iD;
            LiczbaPunktow = liczbaPunktow;
            WspolczynnikRekrutacyjnyID = wspolczynnikRekrutacyjnyID;
            PrzedmiotMaturalny = przedmiotMaturalnyID;
            RodzajSkladowejWspRekrut = rodzajSkladowejWspRekrutID;
        }

        public SkladowaWspRekrut(int iD, double liczbaPunktow, int wspolczynnikRekrutacyjnyID, PrzedmiotMaturalny? przedmiotMaturalny, RodzajSkladowejWspRekrut rodzajSkladowejWspRekrut)
        {
            ID = iD;
            LiczbaPunktow = liczbaPunktow;
            WspolczynnikRekrutacyjnyID = wspolczynnikRekrutacyjnyID;
            if (przedmiotMaturalny != null)
                PrzedmiotMaturalny = Convert.ToInt32(przedmiotMaturalny);
            else
                PrzedmiotMaturalny = null;
            RodzajSkladowejWspRekrut = Convert.ToInt32(rodzajSkladowejWspRekrut);
        }

        [Required]
        [Display(Name = "Współczynnik rekrutacyjny")]
        public int WspolczynnikRekrutacyjnyID { get; set; }

        [AllowNull]
        [Display(Name = "Współczynnik rekrutacyjny")]
        public virtual WspolczynnikRekrutacyjny WspolczynnikRekrutacyjny { get; set; }


        [AllowNull]
        [Display(Name = "Przedmiot maturalny")]
        public int? PrzedmiotMaturalny { get; set; }

        [Required]
        public int RodzajSkladowejWspRekrut { get; set; }

    
    }
}