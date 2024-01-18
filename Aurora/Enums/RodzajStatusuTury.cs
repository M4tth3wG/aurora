using System.ComponentModel;

namespace Aurora.Enums
{
    public enum RodzajStatusuTury
    {
        planowana,
        otwarta,
        [Description("zamknięta")]
        zamknieta,
        anulowana,
        [Description("zakończona")]
        zakonczona
    }
}