﻿using Aurora.Enums;
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
        public int KierunekStudiowID { get; set; }

        [AllowNull]
        public virtual KierunekStudiow KierunekStudiow { get; set; }

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
        [AllowNull]
        public WspolczynnikRekrutacyjny WspolczynnikRekrutacyjny { get; set; } 
        
        [Required]
        public int KandydatID { get; set; }

        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        public AplikacjaRekrutacyjna(int iD, int kierunekStudiowID, int turaRekrutacjiID, int oplataRekrutacyjnaID, DateTime dataZlozenia, int status, int kandydatID)
        {
            ID = iD;
            KierunekStudiowID = kierunekStudiowID;
            TuraRekrutacjiID = turaRekrutacjiID;
            OplataRekrutacyjnaID = oplataRekrutacyjnaID;
            DataZlozenia = dataZlozenia;
            Status = status;
            KandydatID = kandydatID;
        }

        public AplikacjaRekrutacyjna()
        {
        }
    }
}
