using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Aurora.Models
{
    public class Wiadomosc
    {
        public Wiadomosc()
        {
        }

        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public int PracownikDziekanatuID { get; set; }

        public virtual PracownikDziekanatu pracownikDziekanatu { get; set; }

        [Required]
        public int KandydatID { get; set; }

        public virtual Kandydat kandydat { get; set; }

        [Required]
        [MaxLength(255)]
        public string Tresc {  get; set; }

        public Wiadomosc(int iD, int pracownikDziekanatuID, int kandydatID, string tresc)
        {
            ID = iD;
            PracownikDziekanatuID = pracownikDziekanatuID;
            KandydatID = kandydatID;
            Tresc = tresc;
        }
    }
}
