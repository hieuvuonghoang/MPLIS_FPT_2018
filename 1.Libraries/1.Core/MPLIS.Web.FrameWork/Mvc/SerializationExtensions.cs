using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MPLIS.Web.FrameWork.Mvc
{
    internal static class SerializationExtensions
    {
        // Methods
        internal static string ForJsonArray(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "[]";
            }
            if (s.Trim() == string.Empty)
            {
                return "[]";
            }
            return s;
        }

        internal static Guid[] GetGuidArray(this string s)
        {
            return new JavaScriptSerializer().Deserialize<Guid[]>(s.ForJsonArray());
        }

        internal static int[] GetIntArray(this string s)
        {
            return new JavaScriptSerializer().Deserialize<int[]>(s.ForJsonArray());
        }

        internal static long[] GetLongArray(this string s)
        {
            return new JavaScriptSerializer().Deserialize<long[]>(s.ForJsonArray());
        }

        internal static string[] GetStringArray(this string s)
        {
            return new JavaScriptSerializer().Deserialize<string[]>(s.ForJsonArray());
        }

        internal static string ToJson(this object o)
        {
            if (o == null)
            {
                return string.Empty;
            }
            return new JavaScriptSerializer().Serialize(o);
        }
    }
}
