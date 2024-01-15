using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Aurora.Models
{
    public class KandydatUlubionyKierunekStudiow
    {
        public KandydatUlubionyKierunekStudiow()
        {
        }

        [Key, Column(Order = 0)]
        public int KandydatID { get; set; }
        [AllowNull]
        public virtual Kandydat Kandydat { get; set; }

        [Required]
        [Key, Column(Order = 1)]

        public int UlubionyKierunekStudiowID { get; set; }

        [AllowNull]
        public virtual KierunekStudiow UlubionyKierunekStudiow { get; set; }

        public KandydatUlubionyKierunekStudiow(int kandydatID, int ulubionyKierunekStudiowID)
        {
            KandydatID = kandydatID;
            UlubionyKierunekStudiowID = ulubionyKierunekStudiowID;
        }
    }
}
