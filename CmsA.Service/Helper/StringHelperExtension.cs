using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CmsA.Service.Helper
{
    public static class StringHelperExtension
    {
        public static string RemoveNoneAlphaNumerics(this string str)
        {
            Regex rgx = new ("[^a-zA-Z0-9]");
            return  rgx.Replace(str, "");
        }
    }
}
