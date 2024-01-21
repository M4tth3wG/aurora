using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class OplataRekrutacyjna
    {
        public OplataRekrutacyjna()
        {
        }

        [Key]
        [Required]
        [DisplayName("Numer")]
        public int ID { get; set; }

        [Required]
        public int KandydatID { get; set; }

        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Kwota { get; set; }

        public OplataRekrutacyjna(int iD, int kandydatID, double kwota)
        {
            ID = iD;
            KandydatID = kandydatID;
            Kwota = kwota;
        }
    }
}
