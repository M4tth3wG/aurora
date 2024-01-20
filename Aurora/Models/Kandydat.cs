using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    [Index(nameof(PESEL), IsUnique = true)] // ???
    public class Kandydat
    {
        public Kandydat()
        {
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public int AdresID { get; set; }

        [AllowNull]
        public virtual Adres Adres { get; set; }

        [Required]
        [StringLength(11)]
        public string PESEL { get; set; }

        [Required]
        [MaxLength(255)]
        public string Imie {  get; set; }

        [Required]
        [MaxLength(255)]
        public string Nazwisko { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(255)]
        public string AdresEmail { get; set; }


        public ICollection<Opinia> Opinie { get; set; }

        public ICollection<KandydatKierunekStudiow> ListaUlubionychKierunkow { get; set; }

        public ICollection<KandydatUlubionyKierunekStudiow> WybraneKierunki { get; set; }
        
        public ICollection<Egzamin> Egzaminy { get; set; }

        public ICollection<OplataRekrutacyjna> Oplaty { get; set; }

        public ICollection<Wiadomosc> wiadomosci { get; set; }


        public Kandydat(int iD, int adresID, string pESEL, string imie, string nazwisko, string adresEmail)
        {
            ID = iD;
            AdresID = adresID;
            PESEL = pESEL;
            Imie = imie;
            Nazwisko = nazwisko;
            AdresEmail = adresEmail;
        }
    }
}
