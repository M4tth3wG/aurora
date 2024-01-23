using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Aurora.Models
{

    [Index(nameof(Dziedzina), IsUnique = true)]
    public class DziedzinaEgzaminuWstepnego
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Dziedzina { get; set; }

        public ICollection<DziedzinaEgzaminuWstepnegoKierunekStudiow> KierunkiStudiow { get; set; }

        public ICollection<AplikacjaRekrutacyjna> AplikacjeRekrutacyjne { get; set; }
    }
}
