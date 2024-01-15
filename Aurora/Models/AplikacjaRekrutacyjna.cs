using Aurora.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class AplikacjaRekrutacyjna
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int TuraRekrutacjiID { get; set; }

        [AllowNull]
        public virtual TuraRekrutacji TuraRekrutacji{  get; set; }

        [Required]
        public int OplataRekrutacyjnaID { get; set; }

        [AllowNull]
        public OplataRekrutacyjna OplataRekrutacyjna { get; set; }

        [Required]
        public DateTime DataZlozenia { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int WspolczynnikRekrutacyjnyID { get; set; }

        [AllowNull]
        public virtual WspolczynnikRekrutacyjny WspolczynnikRekrutacyjny { get; set; } 
        
        [Required]
        public int KandydatID { get; set; }

        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        public AplikacjaRekrutacyjna(int iD, int turaRekrutacjiID, int oplataRekrutacyjnaID, DateTime dataZlozenia, int status, int wspolczynnikRekrutacyjnyID, int kandydatID)
        {
            ID = iD;
            TuraRekrutacjiID = turaRekrutacjiID;
            OplataRekrutacyjnaID = oplataRekrutacyjnaID;
            DataZlozenia = dataZlozenia;
            Status = status;
            WspolczynnikRekrutacyjnyID = wspolczynnikRekrutacyjnyID;
            KandydatID = kandydatID;
        }
        public AplikacjaRekrutacyjna(int iD, int turaRekrutacjiID, int oplataRekrutacyjnaID, DateTime dataZlozenia, RodzajStatusuAplikacji status, int wspolczynnikRekrutacyjnyID, int kandydatID)
        {
            ID = iD;
            TuraRekrutacjiID = turaRekrutacjiID;
            OplataRekrutacyjnaID = oplataRekrutacyjnaID;
            DataZlozenia = dataZlozenia;
            Status = Convert.ToInt32(status);
            WspolczynnikRekrutacyjnyID = wspolczynnikRekrutacyjnyID;
            KandydatID = kandydatID;
        }

        public AplikacjaRekrutacyjna()
        {
        }
    }
}
