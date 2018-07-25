using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Data.Products
{
    public sealed class ProductRepository
    {
        private ProductRepository() { }

        public static Product MacBook()
        {
            Dictionary<string, double> macBookPrices = new Dictionary<string, double>();
            macBookPrices.Add("Euro", 560.94);
            macBookPrices.Add("Pound Sterling", 487.62);
            macBookPrices.Add("US Dollar", 602.00);
            return new Product("MacBook",
                "Intel Core 2 Duo processor Powered by an Intel Core 2 Duo processor at speeds up to 2.1..",
                macBookPrices);
        }

        public static Product MacBookAir()
        {
            Dictionary<string, double> macBookPrices = new Dictionary<string, double>();
            macBookPrices.Add("Euro", 1120.02);
            macBookPrices.Add("Pound Sterling", 973.62);
            macBookPrices.Add("US Dollar", 1202.00);
            return new Product("MacBook Air",
                "MacBook Air is ultrathin, ultraportable, and ultra unlike anything else. But you don’t lose..",
                macBookPrices);
        }

        public static Product AppleIPhone()
        {
            Dictionary<string, double> macBookPrices = new Dictionary<string, double>();
            macBookPrices.Add("Euro", 616.85);
            macBookPrices.Add("Pound Sterling", 536.22);
            macBookPrices.Add("US Dollar", 662.00);
            return new Product("Apple iPhone SE 64GB",
                "IPS, 1136x640) / Apple A9 /",
                macBookPrices);
        }

        //public static List<Product> GetFromCSV() { }
        //public static List<Product> GetFromExcel() { }
        //public static List<Product> GetFromDB() { }
    }

}
