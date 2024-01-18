using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class PracownikDziekanatu
    {
        public PracownikDziekanatu()
        {
        }

        [Key]
        public int ID { get; set; }

        //[AllowNull]
        //public int OfertaID { get; set; }

        //[AllowNull]
        //public virtual Oferta oferta { get; set; }

        [Required]
        [MaxLength(255)]
        public string Imie { get; set; } 
        
        [Required]
        [MaxLength(255)]
        public string Nazwisko { get; set; }

        [Required]
        public int Wydzial {  get; set; }

        public PracownikDziekanatu(int iD, string imie, string nazwisko, int wydzial)
        {
            ID = iD;
            Imie = imie;
            Nazwisko = nazwisko;
            Wydzial = wydzial;
        }
    }
}
