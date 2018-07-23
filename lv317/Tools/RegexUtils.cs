using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lv317.Tools
{
    public sealed class RegexUtils
    {
        public static double DoubleParseCulture(string text)
        {
            // I18N
            //return Convert.ToDouble(text.Replace('.', ','));
            //return Double.Parse(text, NumberStyles.AllowDecimalPoint);
            //
            //CultureInfo culture = new CultureInfo("ua");
            //return Double.Parse(text, culture);
            //
            NumberFormatInfo format = new NumberFormatInfo();
            // Set the 'splitter' for thousands
            //format.NumberGroupSeparator = ".";
            // Set the decimal seperator
            //format.NumberDecimalSeparator = ",";
            format.NumberDecimalSeparator = ".";
            return Double.Parse(text, format);
        }

        public static MatchCollection ExtractMatchCollection(string pattern, string text)
        {
            Regex regexPattern = new Regex(pattern, RegexOptions.IgnoreCase);
            return regexPattern.Matches(text);
        }

        public static List<int> ExtractNumbers(string text)
        {
            List<int> result = new List<int>();
            MatchCollection collectionNumbers = ExtractMatchCollection(@"\d+", text);
            if (collectionNumbers.Count == 0)
            {
                // TODO Develop Custom Exception
                throw new Exception("Digits not Found in " + text);
            }
            foreach (Match current in collectionNumbers)
            {
                result.Add(Convert.ToInt32(current.Value));
            }
            return result;
        }

        public static int ExtractFirstNumber(string text)
        {
            return ExtractNumbers(text)[0];
        }

        public static List<double> ExtractDoubles(string text)
        {
            List<double> result = new List<double>();
            MatchCollection collectionNumbers = ExtractMatchCollection(@"\d+\.\d+", text);
            if (collectionNumbers.Count == 0)
            {
                // TODO Develop Custom Exception
                throw new Exception("Double Type not Found in " + text);
            }
            //foreach (string current in collectionNumbers)
            foreach (Match current in collectionNumbers)
            {
                //Console.WriteLine("current.Value = " + current.Value);
                //result.Add(Convert.ToDouble(current.Value));
                // I18N
                result.Add(DoubleParseCulture(current.Value));
            }
            return result;
        }

        public static double ExtractFirstDouble(string text)
        {
            return ExtractDoubles(text)[0];
        }

    }
}
