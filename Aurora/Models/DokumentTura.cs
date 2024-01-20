using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class DokumentTura
    {
        public DokumentTura()
        {
        }

        [Required]
        [Key, Column(Order = 0)]
        public int DokumentID { get; set; }
        [AllowNull]
        public virtual Dokument Dokument { get; set; }

        [Required]
        [Key, Column(Order = 1)]

        public int TuraRekrutacjiID { get; set; }

        [AllowNull]
        public virtual TuraRekrutacji TuraRekrutacji { get; set; }

        public DokumentTura(int dokumentID, int turaRekrutacjiID)
        {
            DokumentID = dokumentID;
            TuraRekrutacjiID = turaRekrutacjiID;
        }

    }
}
