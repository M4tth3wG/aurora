using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class WiadomoscKandydat
    {
        public WiadomoscKandydat()
        {
        }

        [Required]
        [Key, Column(Order = 0)]
        public int KandydatID { get; set; }

        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        [Required]
        [Key, Column(Order = 1)]

        public int WiadomoscID { get; set; }

        [AllowNull]
        public virtual Wiadomosc Wiadomosc { get; set; }

        public WiadomoscKandydat(int kandydatID, int wiadomoscID)
        {
            KandydatID = kandydatID;
            WiadomoscID = wiadomoscID;
        }
    }
}
