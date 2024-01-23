using Aurora.Interfaces;
using Aurora.Utils;
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
        public int ID { get; set; }

        public double Wartosc 
        {
            get
            {
                return AplikacjaRekrutacyjna.KierunekStudiow.Strategia?.GetTotalPoints(skladowe.ToList()) ?? -1.0;
            }
        }

        [Required]
        [Display(Name = "Aplikacja rekrutacyjna")]
        public int AplikacjaRekrutacyjnaID { get; set; }

        [AllowNull]
        [Display(Name = "Aplikacja rekrutacyjna")]
        public virtual AplikacjaRekrutacyjna AplikacjaRekrutacyjna { get; set; }

        [AllowNull]
        public int? EgzaminID { get; set; }

        [AllowNull]
        [Display(Name = "Egzamin")]
        public virtual Egzamin Egzamin { get; set; }

        public ICollection<SkladowaWspRekrut> skladowe { get; set; }

        public WspolczynnikRekrutacyjny()
        {
        }

        public WspolczynnikRekrutacyjny(int iD, int aplikacjaRekrutacyjnaID, int? egzaminID = null)
        {
            ID = iD;
            AplikacjaRekrutacyjnaID = aplikacjaRekrutacyjnaID;
            EgzaminID = egzaminID;
        }
    }
}