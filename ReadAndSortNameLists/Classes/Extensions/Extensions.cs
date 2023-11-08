using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChallenges.Classes.Extensions
{
    internal static class Extensions
    {
        public static string ToListString(this IEnumerable ienum)
        {
            if (ienum == null)
            {
                return $"[ {string.Empty} ]";
            }

            return $"[ {string.Join(", ", ienum.Cast<object>().ToList())} ]";
        }

        public static string ToArrayString(this IEnumerable ienum)
        {
            if (ienum == null)
            {
                return string.Empty;
            }

            return $"{{ {string.Join(", ", ienum.Cast<object>().ToArray())} }}";
        }

        public static string ToBannerString(this string str)
        {
            if (str == null)
            {
                return string.Empty;
            }

            string bannerTopAndBottom = new('#', str.Length + 6);
            string bannerMiddle = $"#  {str}  #";
            return string.Join("\n", bannerTopAndBottom, bannerMiddle, bannerTopAndBottom);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return (str == null || str == string.Empty);
        }
    }
}
