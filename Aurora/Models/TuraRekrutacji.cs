using Aurora.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class TuraRekrutacji
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int KierunekStudiowID { get; set; }

        [AllowNull]
        public virtual KierunekStudiow KierunekStudiow { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        [Required]
        public DateTime DataOtwarcia { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        [Required]
        public DateTime TerminZakonczeniaPrzyjmowaniaAplikacji { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DataZakonczenia { get; set; }

        [Required]
        public int LiczbaZajetychMiejsc { get; set; }

        [Required]
        public int LimitPrzyjec { get; set; }

        [Required]
        public int DostepneMiejsca 
        {
            get 
            {
                return LimitPrzyjec - LiczbaZajetychMiejsc;
            }
        }

        [Required]
        public double MinimalnyProgPunktowy {  get; set; }

        [Required]
        public int StatusTury { get; set; }

        [Required]
        public int RodzajRekrutacji { get; set; }

        public ICollection<DziedzinaEgzaminuWstepnego> DostepneEgzaminyWstepne { get; set; }

        public ICollection<Opinia> Opinie { get; set; }

        public ICollection<AplikacjaRekrutacyjna> aplikacje { get; set; }

        public ICollection<Egzamin> egzaminy { get; set; }

        public ICollection<DokumentTura> Dokumenty { get; set; }


        public TuraRekrutacji(int iD, int kierunekStudiowID, DateTime dataOtwarcia, DateTime terminZakonczeniaPrzyjmowaniaAplikacji, DateTime dataZakonczenia, int liczbaZajetychMiejsc, int limitPrzyjec, double minimalnyProgPunktowy, int statusTuryID, int rodzajRekrutacjiID)
        {
            ID = iD;
            KierunekStudiowID = kierunekStudiowID;
            DataOtwarcia = dataOtwarcia;
            TerminZakonczeniaPrzyjmowaniaAplikacji = terminZakonczeniaPrzyjmowaniaAplikacji;
            DataZakonczenia = dataZakonczenia;
            LiczbaZajetychMiejsc = liczbaZajetychMiejsc;
            LimitPrzyjec = limitPrzyjec;
            MinimalnyProgPunktowy = minimalnyProgPunktowy;
            StatusTury = statusTuryID;
            RodzajRekrutacji = rodzajRekrutacjiID;
        }
        public TuraRekrutacji(int iD, int kierunekStudiowID, DateTime dataOtwarcia, DateTime terminZakonczeniaPrzyjmowaniaAplikacji, DateTime dataZakonczenia, int liczbaZajetychMiejsc, int limitPrzyjec, double minimalnyProgPunktowy, RodzajStatusuTury statusTury, RodzajRekrutacji rodzajRekrutacji)
        {
            ID = iD;
            KierunekStudiowID = kierunekStudiowID;
            DataOtwarcia = dataOtwarcia;
            TerminZakonczeniaPrzyjmowaniaAplikacji = terminZakonczeniaPrzyjmowaniaAplikacji;
            DataZakonczenia = dataZakonczenia;
            LiczbaZajetychMiejsc = liczbaZajetychMiejsc;
            LimitPrzyjec = limitPrzyjec;
            MinimalnyProgPunktowy = minimalnyProgPunktowy;
            StatusTury = Convert.ToInt32(statusTury);
            RodzajRekrutacji = Convert.ToInt32(rodzajRekrutacji);
        }

        public TuraRekrutacji() { }

    }
}
