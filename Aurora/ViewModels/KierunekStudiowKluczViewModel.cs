using Aurora.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.ViewModels
{
    [NotMapped]
    public class KierunekStudiowKluczViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Display(Name = "Język Wykładowy")]
        [Required]
        public Jezyk JezykWykladowy { get; set; }

        [Required]
        [Display(Name = "Poziom studiów")]
        public PoziomStudiow PoziomStudiow { get; set; }

        [Required]
        [Display(Name = "Miejsce studiów")]
        public MiejsceStudiow MiejsceStudiow { get; set; }

        [Required(ErrorMessage = "Pole wymagane.")]
        [MaxLength(255, ErrorMessage = "Nazwa kierunku może zawierać do {1} znaków.")]
        [Display(Name = "Nazwa kierunku")]
        public string NazwaKierunku { get; set; }

        [Display(Name = "Forma studiów")]
        [Required]
        public FormaStudiow FormaStudiow { get; set; }

    }
}
