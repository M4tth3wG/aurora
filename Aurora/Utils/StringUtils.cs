using System;
using System.Text;

namespace Aurora.Utils
{
    public static class StringUtils
    {


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
                        stringBuilder.Append(' '); // Dodaj spację przed każdym słowem (oprócz pierwszego słowa)
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
            switch (text.ToLower())
            {
                case "formastudiow":
                    return "Dowolna";
                case "miejscestudiow":
                    return "Dowolne";
                default:
                    return "Dowolny";
            }
        }


    }
}
