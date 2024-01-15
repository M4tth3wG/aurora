using System.ComponentModel.DataAnnotations;

namespace Aurora.Models
{
    public class Adres
    {

        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Ulica { get; set; }

        [Required]
        [MaxLength(255)]
        public string NumerBudynku { get; set; }

        [Required]
        [MaxLength(255)]
        public string KodPocztowy {  get; set; }

        [Required]
        [MaxLength(255)]
        public string Miejscowosc {  get; set; }

        public Adres()
        {
        }

        public Adres(int iD, string ulica, string numerBudynku, string kodPocztowy, string miejscowosc)
        {
            ID = iD;
            Ulica = ulica;
            NumerBudynku = numerBudynku;
            KodPocztowy = kodPocztowy;
            Miejscowosc = miejscowosc;
        }
    }
}
