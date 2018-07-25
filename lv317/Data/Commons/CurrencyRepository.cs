using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Data.Commons
{
    public sealed class CurrencyRepository
    {
        private CurrencyRepository() { }

        public static string Euro()
        {
            return "Euro";
        }

        public static string PoundSterling()
        {
            return "Pound Sterling";
        }

        public static string USDollar()
        {
            return "US Dollar";
        }

        public static List<string> GetAll()
        {
            List<string> result = new List<string>();
            result.Add(Euro());
            result.Add(PoundSterling());
            result.Add(USDollar());
            return result;
        }

    }

}
