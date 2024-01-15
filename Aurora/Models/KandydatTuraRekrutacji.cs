using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class KandydatTuraRekrutacji
    {
        public KandydatTuraRekrutacji()
        {
        }

        [Required]
        [Key, Column(Order = 0)]
        public int KandydatID { get; set; }
        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        [Required]
        [Key, Column(Order = 1)]

        public int TuraRekrutacjiID { get; set; }

        [AllowNull]
        public virtual TuraRekrutacji TuraRekrutacji { get; set; }

        public KandydatTuraRekrutacji(int kandydatID, int turaRekrutacjiID)
        {
            KandydatID = kandydatID;
            TuraRekrutacjiID = turaRekrutacjiID;
        }
    }
}
