﻿using Aurora.Interfaces;
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


        //tymaczsowo public
        [NotMapped]
        public StrategiaWspolRekrut strategia { get; set; }

        public double Wartosc 
        {
            get
            {
                if (strategia == null) { return -1.0; }
                return strategia.WyliczPunkty(skladowe.ToList());
            }
        }

        [Required]
        [Display(Name = "Aplikacja rekrutacyjna")]
        public int AplikacjaRekrutacyjnaID { get; set; }

        [AllowNull]
        [Display(Name = "Aplikacja rekrutacyjna")]
        public virtual AplikacjaRekrutacyjna AplikacjaRekrutacyjna { get; set; }
        
        [AllowNull]
        [Display(Name = "Egzamin")]
        public virtual Egzamin egzamin { get; set; }

        public ICollection<SkladowaWspRekrut> skladowe { get; set; }

        public WspolczynnikRekrutacyjny()
        {
        }
        public WspolczynnikRekrutacyjny(int iD, int aplikacjaRekrutacyjnaID, KierunekStudiow kierunek)
        {
            ID = iD;
            AplikacjaRekrutacyjnaID = aplikacjaRekrutacyjnaID;
            strategia = UtilsRR.GetStrategiaDlaKierunku(kierunek);
        }

        public WspolczynnikRekrutacyjny(int iD, StrategiaWspolRekrut strategia, int aplikacjaRekrutacyjnaID)
        {
            ID = iD;
            this.strategia = strategia;
            AplikacjaRekrutacyjnaID = aplikacjaRekrutacyjnaID;
        }
    }
}