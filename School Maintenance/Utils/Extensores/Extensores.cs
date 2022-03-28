using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Maintenance.Utils.Extensores
{
    public static class Extensores
    {
        public static int Toint(this object str)
        {
            int.TryParse(str.ToString(), out int value);
            return value;
        }

        public static bool ToBool(this object str)
        {
            if (str != null)
            {
                bool.TryParse(str.ToString(), out bool valor);
                return valor;
            }
            else
            {
                return false;
            }
        }

        public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj)
    where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }
    }
}