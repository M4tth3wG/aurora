using Aurora.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Aurora.Models
{
    public class WspolczynnikRekrutacyjny
    {
        [Key]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [NotMapped]
        private StrategiaWspolRekrut strategia { get; set; }

        public double Wartosc 
        {
            get
            {
                return strategia.WyliczPunkty(skladowe.ToList());
            }
        }

        [Required]
        [Display(Name = "Aplikacja rekrutacyjna")]
        public int AplikacjaRekrutacyjnaID { get; set; }

        [AllowNull]
        [Display(Name = "Aplikacja rekrutacyjna")]
        public virtual AplikacjaRekrutacyjna AplikacjaRekrutacyjna { get; set; }

        public ICollection<SkladowaWspRekrut> skladowe { get; set; }

        public WspolczynnikRekrutacyjny()
        {
        }

        public WspolczynnikRekrutacyjny(string iD, int aplikacjaRekrutacyjnaID, ICollection<SkladowaWspRekrut> skladowe)
        {
            ID = iD;
            AplikacjaRekrutacyjnaID = aplikacjaRekrutacyjnaID;
            this.skladowe = skladowe;
        }

        public WspolczynnikRekrutacyjny(string iD, StrategiaWspolRekrut strategia, int aplikacjaRekrutacyjnaID, ICollection<SkladowaWspRekrut> skladowe)
        {
            ID = iD;
            this.strategia = strategia;
            AplikacjaRekrutacyjnaID = aplikacjaRekrutacyjnaID;
            this.skladowe = skladowe;
        }
    }
}