using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class AplikacjaRekrutacyjnaDokument
    {
        public AplikacjaRekrutacyjnaDokument()
        {
        }

        [Required]
        [Key, Column(Order = 0)]
        public int DokumentID { get; set; }
        [AllowNull]
        public virtual Dokument Dokument { get; set; }

        [Required]
        [Key, Column(Order = 1)]

        public int AplikacjaRekrutacyjnaID { get; set; }

        [AllowNull]
        public virtual AplikacjaRekrutacyjna AplikacjaRekrutacyjna { get; set; }

        public AplikacjaRekrutacyjnaDokument(int dokumentID, int aplikacjaRekrutacyjnaID)
        {
            DokumentID = dokumentID;
            AplikacjaRekrutacyjnaID = aplikacjaRekrutacyjnaID;
        }

    }
}
