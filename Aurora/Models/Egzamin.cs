using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class Egzamin
    {
        [Key]
        public int ID { get; set; }

        [AllowNull]
        public int? TuraRekrutacjiID { get; set; }

        [AllowNull]
        public virtual TuraRekrutacji TuraRekrutacji { get; set; }

        [Required]
        public int KandydatID { get; set; }

        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }


        [Required]
        [MaxLength(255)]
        public string Organ { get; set; }

        [Required]
        [MaxLength(255)]
        public string Ocena { get; set; }

        [AllowNull]
        public double? LiczbaPunktow { get; set; }

        [AllowNull]
        public double? MaksymalnaLiczbaPunktow { get; set; }

        [AllowNull]
        public double? WynikProcentowy
        {
            get
            {
                if (LiczbaPunktow != null && MaksymalnaLiczbaPunktow != null)
                    return LiczbaPunktow / MaksymalnaLiczbaPunktow;
                return null;
            }
            set
            {

            }
        }

        [Required]
        public int SkladowaWspRekrutID { get; set; }

        [AllowNull]
        public virtual SkladowaWspRekrut SkladowaWspRekrut { get; set; }

        [AllowNull]
        [MaxLength(255)]
        public string? Dziedzina { get; set; }


        [AllowNull]
        [MaxLength(255)]
        public string? Przedmiot {  get; set; }

        [AllowNull]
        [MaxLength(255)]
        public string? Forma { get; set; }


        [AllowNull]
        [MaxLength(255)]
        public string? Poziom { get; set; }


        [AllowNull]
        [MaxLength(255)]
        public string? ZawodNauczany {  get; set; }


        [AllowNull]
        [MaxLength(255)]
        public string? Kod { get; set; }


        [AllowNull]
        [MaxLength(255)]
        public string? Kwalifikacje { get; set; }

        public Egzamin() { }

        protected Egzamin(int iD, int? turaRekrutacjiID, int kandydatID, string organ, string ocena, double? liczbaPunktow, double? maksymalnaLiczbaPunktow, int skladowaWspRekrutID, string dziedzina, string przedmiot, string forma, string poziom, string zawodNauczany, string kod, string kwalifikacje)
        {
            ID = iD;
            TuraRekrutacjiID = turaRekrutacjiID;
            KandydatID = kandydatID;
            Organ = organ;
            Ocena = ocena;
            LiczbaPunktow = liczbaPunktow;
            MaksymalnaLiczbaPunktow = maksymalnaLiczbaPunktow;
            SkladowaWspRekrutID = skladowaWspRekrutID;
            Dziedzina = dziedzina;
            Przedmiot = przedmiot;
            Forma = forma;
            Poziom = poziom;
            ZawodNauczany = zawodNauczany;
            Kod = kod;
            Kwalifikacje = kwalifikacje;
        }
    }
}
