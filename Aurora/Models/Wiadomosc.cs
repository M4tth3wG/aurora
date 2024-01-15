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

        //[Required]
        //public int PracownikDziekanatuID { get; set; }

        //public virtual PracownikDziekanatu pracownikDziekanatu { get; set; }

        [Required]
        [MaxLength(255)]
        public string Tresc {  get; set; }

        public Wiadomosc(int iD, string tresc)
        {
            ID = iD;
            Tresc = tresc;
        }
    }
}
