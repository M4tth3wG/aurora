using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class DziedzinaEgzaminuWstepnegoKierunekStudiow
    {
        [Required]
        [Key, Column(Order = 0)]
        public int DziedzinaID { get; set; }

        public virtual DziedzinaEgzaminuWstepnego Dziedzina { get; set; }

        [Key, Column(Order = 1)]
        public int KierunekStudiowID { get; set; }

        public virtual KierunekStudiow KierunekStudiow { get; set; }
    }
}
