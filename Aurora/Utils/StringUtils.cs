using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora.Utils
{
    public static class StringUtils
    {
        public static bool IsSubstring(string mainString, string substring)
        {
            return mainString.ToLower().Contains(substring.ToLower());
        }

        public static string ConvertCamelCaseToTitleCase(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (i == 0 || (i > 0 && char.IsUpper(currentChar)))
                {
                    if (i > 0)
                    {
                        stringBuilder.Append(' ');
                    }
                    stringBuilder.Append(currentChar);
                }
                else
                {
                    stringBuilder.Append(char.ToLower(currentChar));
                }
            }

            return stringBuilder.ToString();
        }

        public static string GetDowolnyTekst(string text)
        { 
            switch (text.ToLower().Trim())
            {
                case "formastudiow":
                    return "Dowolna";
                case "miejscestudiow":
                    return "Dowolne";
                default:
                    return "Dowolny";
            }
        }

        public static string ConvertListToTupleFormat<T>(List<T> list, char beginChar = '(', char sep = ',', char endChar = ')')
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(beginChar);

            foreach (var item in list)
            {
                stringBuilder.Append($"{item}{sep} ");
            }

            stringBuilder = stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(endChar);
            return stringBuilder.ToString().Trim();
        }

        public static bool CzyKandydatPasuje(string Imie, string Nazwisko, string SearchText)
        {
            var imieMalaLitera = Imie.ToLower();
            var nazwiskoMalaLitera = Nazwisko.ToLower();
            var SearchTextMalaLitera = SearchText.ToLower();
            var polaczoneNazwiskoIImie = $"{nazwiskoMalaLitera} {imieMalaLitera}";
            var polaczoneImieINazwisko = $"{imieMalaLitera} {nazwiskoMalaLitera}";

            return imieMalaLitera.Contains(SearchTextMalaLitera) ||
                   nazwiskoMalaLitera.Contains(SearchTextMalaLitera) ||
                   polaczoneNazwiskoIImie.Contains(SearchTextMalaLitera) ||
                   polaczoneImieINazwisko.Contains(SearchTextMalaLitera);

        }

    }
}
