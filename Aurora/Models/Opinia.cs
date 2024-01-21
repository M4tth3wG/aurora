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

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Długość pola Treści powinna być od 10 do 500 znaków.")]

        public string Tresc { get; set; }


        public Opinia()
        {

        }
    }
}
