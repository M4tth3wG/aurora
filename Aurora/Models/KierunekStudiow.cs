using Aurora.Enums;
using Aurora.Interfaces;
using Aurora.OtherClasses.StrategiesForRR;
using Aurora.Utils;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    [Serializable]
    public class KierunekStudiow
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Język Wykładowy")]
        [Required]
        public int JezykWykladowy { get; set; }

        [NotMapped]
        private int _StrategiaID;        
        
        [NotMapped]
        private IStrategiaWspolRekrut _Strategia;

        [Required]
        [Display(Name = "Strategia wyliczania współczynnika rekrutacyjnego")]
        public int StrategiaID {
            get { return _StrategiaID; }
            set
            {
                if (Enum.IsDefined(typeof(RodzajStrategii), value))
                {
                    _StrategiaID = value;
                    _Strategia = StrategyUtils.ConvertIDToStrategy(value);
                }
            }

        }

        [NotMapped]
        public IStrategiaWspolRekrut Strategia
        {
            get
            {
                _Strategia ??= StrategyUtils.ConvertIDToStrategy(_StrategiaID);
                return _Strategia;
            }
            private set => _Strategia = value;
        }


        [Required(ErrorMessage = "Pole wymagane.")]
        [Display(Name = "Czesne")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Czesne musi być dodatnią liczbą rzeczywistą z dokładnością do 2 miejsc po przecinku.")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [RegularExpression(@"^[0-9]*(\.[0-9]{1,2}){0,1}$", ErrorMessage = "Czesne musi być dodatnią liczbą rzeczywistą z dokładnością do 2 miejsc po przecinku.")]
        public double Czesne { get; set; }

        [Required(ErrorMessage = "Pole wymagane.")]
        [Display(Name = "Czesne dla obcokrajowców")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Czesne musi być dodatnią liczbą rzeczywistą z dokładnością do 2 miejsc po przecinku.")]
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        [RegularExpression(@"^[0-9]*(\.[0-9]{1,2}){0,1}$", ErrorMessage = "Czesne musi być dodatnią liczbą rzeczywistą z dokładnością do 2 miejsc po przecinku.")]
        public double CzesneDlaObcokrajowcow { get; set; }

        [Required]
        [Display(Name = "Poziom studiów")]
        public int PoziomStudiow { get; set; }

        [Required]
        [Display(Name = "Miejsce studiów")]
        public int MiejsceStudiow { get; set; }

        public KierunekStudiow()
        {
        }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Nazwa kierunku")]
        public string NazwaKierunku { get; set; }

        [Display(Name = "Forma studiów")]
        [Required]
        public int FormaStudiow { get; set; }

        [Display(Name = "Wydział")]
        [Required]
        public int Wydzial { get; set; }

        [Display(Name = "Opis kierunku")]
        [MaxLength(1023, ErrorMessage = "Opis może zawierać do 1023 znaków.")]
        public string OpisKierunku { get; set; }

        public ICollection<DziedzinaEgzaminuWstepnegoKierunekStudiow> DostepneEgzaminyWstepne { get; set; }

        public ICollection<TuraRekrutacji> turyRekrutacji { get; set; }
        public ICollection<AplikacjaRekrutacyjna> aplikacje { get; set; }

        public ICollection<KandydatKierunekStudiow> kandydaci { get; set; }
        public ICollection<KandydatUlubionyKierunekStudiow> ulubioneKandydat { get; set; }
        public ICollection<WspolczynnikRekrutacyjny> WspolczynnikiRekrut { get; set; }



        public KierunekStudiow(int iD, int jezykWykladowyID, double czesne, double czesneDlaObcokrajowcow, int poziomStudiowID, int miejsceStudiowID, string nazwaKierunku, int formaStudiowID, int wydzialID, string opisKierunku, RodzajStrategii strategia)
        {
            ID = iD;
            JezykWykladowy = jezykWykladowyID;
            Czesne = czesne;
            CzesneDlaObcokrajowcow = czesneDlaObcokrajowcow;
            PoziomStudiow = poziomStudiowID;
            MiejsceStudiow = miejsceStudiowID;
            NazwaKierunku = nazwaKierunku;
            FormaStudiow = formaStudiowID;
            Wydzial = wydzialID;
            OpisKierunku = opisKierunku;
            StrategiaID = Convert.ToInt32(strategia);
        }        
        
        public KierunekStudiow(int iD, Jezyk jezykWykladowy, double czesne, double czesneDlaObcokrajowcow, int poziomStudiow, int miejsceStudiow, string nazwaKierunku, int formaStudiow, int wydzial, string opisKierunku, int strategiaID)
        {
            ID = iD;
            JezykWykladowy = Convert.ToInt32(jezykWykladowy);
            Czesne = czesne;
            CzesneDlaObcokrajowcow = czesneDlaObcokrajowcow;
            PoziomStudiow = Convert.ToInt32(poziomStudiow);
            MiejsceStudiow = Convert.ToInt32(miejsceStudiow);
            NazwaKierunku = nazwaKierunku;
            FormaStudiow = Convert.ToInt32(formaStudiow);
            Wydzial = Convert.ToInt32(wydzial); ;
            OpisKierunku = opisKierunku;
            StrategiaID = strategiaID;
        }

    }
}