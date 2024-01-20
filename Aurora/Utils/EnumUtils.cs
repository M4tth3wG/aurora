using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Aurora.Utils
{
    public static class EnumUtils
    {
        public static TEnum ConvertIDToType<TEnum>(int id) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), id))
            {
                return (TEnum)Enum.ToObject(typeof(TEnum), id);
            }

            return default;
        }

        public static string ConvertIDToTypeAsString<TEnum>(int id) where TEnum : Enum
        {
            
            if (Enum.IsDefined(typeof(TEnum), id))
            {
                return GetDescription<TEnum>((TEnum)Enum.ToObject(typeof(TEnum), id));
            }

            return GetDescription<TEnum>(default);
        }

        public static string GetDescription<TEnum>(TEnum enumerationValue) where TEnum : Enum
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumerationValue.ToString();
        }

        // TODO refactor
        public static IEnumerable<SelectListItem> GetWartosciEnumaJakoSelectList<TEnum>(bool sorted = true) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var dowolnyTekst = StringUtils.GetDowolnyTekst(typeof(TEnum).Name);

            List<SelectListItem> selectList = enumValues.Select(e => new SelectListItem
            {
                Text = EnumUtils.GetDescription<TEnum>(e),
                Value = Convert.ToInt32((Enum)e).ToString()
            }).ToList();

            if (sorted) selectList = selectList.OrderBy(s => s.Text).ToList();

            selectList.Insert(0, new SelectListItem { Text = dowolnyTekst, Value = "" });

            return selectList;
        }

        // TODO refactor
        public static IEnumerable<SelectListItem> GetEnumSelectList<TEnum>(bool sorted = true) where TEnum : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();


            List<SelectListItem> selectList = enumValues.Select(e => new SelectListItem
            {
                Text = EnumUtils.GetDescription<TEnum>(e),
                Value = Convert.ToInt32((Enum)e).ToString()
            }).ToList();

            if (sorted) selectList = selectList.OrderBy(s => s.Text).ToList();

            return selectList;
        }
    }
}
