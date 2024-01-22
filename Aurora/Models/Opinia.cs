using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class Opinia
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public int KandydatID { get; set; }

        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }


        [Required]
        public int TuraRekrutacjiID { get; set; }

        [AllowNull]
        public virtual TuraRekrutacji TuraRekrutacji { get; set; }

        [AllowNull]
        [DisplayName("Informacje dodatkowe")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Długość pola Treści powinna być od 10 do 500 znaków.")]
        public string Tresc { get; set; }

        [Required(ErrorMessage = "Podanie opinii o intuicyjności systemu jest wymagane")]
        [DisplayName("Intuicyjność systemu rekrutacyjnego")]
        [Range(1, 5,ErrorMessage = "Podanie opinii o intuicyjności systemu jest wymagane")]
        public int IntuicyjnoscSystemu {  get; set; }

        [Required(ErrorMessage = "Podanie opinii o informowaniu o statusie przez system jest wymagane")]
        [DisplayName("Informowanie o statusie przez system")]
        [Range(1,5,ErrorMessage = "Podanie opinii o informowaniu o statusie przez system jest wymagane")]
        public int InformowanieOStatusie { get; set; }

        [AllowNull]
        [DisplayName("Jakość pomocy")]
        [Range(1, 5)]
        public int? JakoscPomocy { get; set; }

        public Opinia()
        {

        }
    }
}
