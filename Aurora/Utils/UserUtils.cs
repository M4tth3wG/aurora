using Aurora.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Aurora.Utils
{
    public static class UserUtils
    {



        static Random random = new Random();



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
