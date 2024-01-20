using Aurora.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aurora.Models
{
    public class Dokument
    {

        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int RodzajDokumentu { get; set; }

        public ICollection<DokumentTura> Tury { get; set; }


        public Dokument(int iD, int rodzajDokumentu)
        {
            ID = iD;
            RodzajDokumentu = rodzajDokumentu;
        }
    }
}
