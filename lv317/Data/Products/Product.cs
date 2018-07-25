using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Data.Products
{
    public class Product
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Dictionary<string, double> Prices { get; private set; }

        // TODO Develop Builder

        public Product(string name, string description, Dictionary<string, double> prices)
        {
            this.Name = name;
            this.Description = description;
            this.Prices = prices;
        }

        public Product(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Prices = new Dictionary<string, double>();
        }

        public void AddPrice(string currencyName, double price)
        {
            Prices[currencyName] = price;
        }

        public double GetPrice(string currencyName)
        {
            return Prices[currencyName];
        }

    }
}
