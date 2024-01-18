using System.ComponentModel;

namespace Aurora.Enums
{
    public enum RodzajStatusuAplikacji
    {
        [Description("W trakcie wprowadzania")]
        WTrakcieWprowadzania,
        Zatwierdzona,
        Anulowana,
        [Description("Opłacona")]
        Oplacona,
        [Description("Oczekuje na opłatę")]
        OczekujeNaOplate,
        [Description("Zakończona sukcesem")]
        ZakonczonaSukcesem,
        [Description("Zakończona niepowodzeniem")]
        ZakonczonaNiepowodzeniem,
        Odrzucona,
        [Description("Oczekuje na rozpatrzenie")]
        OczekujeNaRozpatrzenie

    }
}