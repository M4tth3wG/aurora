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
        public string Tresc { get; set; }


        public Opinia()
        {

        }
    }
}
