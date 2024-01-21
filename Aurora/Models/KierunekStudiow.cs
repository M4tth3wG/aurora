using Aurora.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Display(Name = "Czesne")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Czesne musi być dodatnią liczbą rzeczywistą.")]
        [DisplayFormat(DataFormatString = "{0:F1}", ApplyFormatInEditMode = true)]
        public double Czesne { get; set; }

        [Required]
        [Display(Name = "Czesne dla obcokrajowców")]
        [Range(0.0d, double.MaxValue, ErrorMessage = "Czesne dla obcokrajowców musi być dodatnią liczbą rzeczywistą.")]
        [DisplayFormat(DataFormatString = "{0:F1}", ApplyFormatInEditMode = true)]
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

        public ICollection<TuraRekrutacji> turyRekrutacji { get; set; }
        public ICollection<AplikacjaRekrutacyjna> aplikacje { get; set; }

        public ICollection<KandydatKierunekStudiow> kandydaci { get; set; }
        public ICollection<KandydatUlubionyKierunekStudiow> ulubioneKandydat { get; set; }



        public KierunekStudiow(int iD, int jezykWykladowyID, double czesne, double czesneDlaObcokrajowcow, int poziomStudiowID, int miejsceStudiowID, string nazwaKierunku, int formaStudiowID, int wydzialID, string opisKierunku)
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
        }

        public KierunekStudiow(int iD, Jezyk jezykWykladowy, double czesne, double czesneDlaObcokrajowcow, int poziomStudiow, int miejsceStudiow, string nazwaKierunku, int formaStudiow, int wydzial, string opisKierunku)
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
        }

    }
}