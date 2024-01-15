using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class KandydatKierunekStudiow
    {
        public KandydatKierunekStudiow()
        {
        }

        [Required]
        [Key, Column(Order = 0)]
        public int KandydatID { get; set; }
        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        [Required]
        [Key, Column(Order = 1)]

        public int KierunekStudiowID { get; set; }

        [AllowNull]
        public virtual KierunekStudiow KierunekStudiow { get; set; }

        public KandydatKierunekStudiow(int kandydatID, int kierunekStudiowID)
        {
            KandydatID = kandydatID;
            KierunekStudiowID = kierunekStudiowID;
        }
    }
}
