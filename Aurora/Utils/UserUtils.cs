using Aurora.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Aurora.Utils
{
    public static class UserUtils
    {

        static List<string> nazwiska = new List<string>() {
            "Woźniak", "Krawczyk", "Szewczyk", "Nowak", "Kowalczyk", "Duda", "Wójcik", "Krupa", "Socha", "Skiba"
        };

        static List<string> imiona = new List<string>() {
            "Jakub", "Szymon", "Jan", "Adam", "Krzysztof", "Anna", "Joanna", "Julia", "Hanna", "Natalia"
        };

        static Random random = new Random();

        public static (string, string, string) GetDanePracownika(DataDbContext context) {
            //var imie = GetFromSession("UserName", session, imiona);
            //var nazwisko = GetFromSession("UserLastName", session, nazwiska);
            //var id = GetIDFromSession("UserID", session);

            //return (imie, nazwisko, id);
            var pracownik = context.PracownicyDziekanatu.FirstOrDefault();
            if(pracownik == null)
            {
                return ("Natalia", "Kowalczyk", "123456");
            }
            return (pracownik.Imie, pracownik.Nazwisko, pracownik.ID.ToString("D6"));
        }

        private static string GetFromSession(string key, ISession session, List<string> list)
        {
            var str = session.GetString(key);
            if (str == null || list.Count != 0)
            {
                str = list[random.Next(list.Count)];
                session.SetString(key, str);
            }
            return str;
        } 
        
        private static string GetIDFromSession(string key, ISession session)
        {
            var id = session.GetString(key);
            if (id == null)
            {
                id = random.Next(100000, 1000000).ToString(); ;
                session.SetString(key, id);
            }
            return id;
        }
    }
}
