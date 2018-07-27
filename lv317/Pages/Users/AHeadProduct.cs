using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Pages.Users
{
    public abstract class AHeadProduct : AHeadComponent
    {
        public const string PRODUCT_BASE_ELEMENT_CSS = ".product-layout";
        //
        protected List<ProductComponent> ProductComponents { get; private set; }

        //public AHeadProduct(IWebDriver driver) : base(driver)
        public AHeadProduct() : base()
        {
        }

        protected void InitProductComponents(By searchLocator)
        {
            ProductComponents = new List<ProductComponent>();
            ICollection<IWebElement> productWebElements = Search.GetWebElements(searchLocator);
            //ICollection<IWebElement> productWebElements = driver.FindElements(searchLocator);
            foreach (IWebElement current in productWebElements)
            {
                ProductComponents.Add(new ProductComponent(current));
            }
        }

        // ProductComponents
        protected ProductComponent GetProductComponentByProductName(string productName)
        {
            //Console.WriteLine("ProductComponents.Count = " + ProductComponents.Count + "  productName = " + productName);
            ProductComponent result = null;
            foreach (ProductComponent current in ProductComponents)
            {
                //Console.WriteLine("current = " + current.Name + "  productName = " + productName);
                //if (current.GetNameText().ToLower().Contains(productName.ToLower()))
                if (current.GetNameText().ToLower().Equals(productName.ToLower()))
                {
                    //Console.WriteLine("FOUND: ProductComponent current = " + current.Name);
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("ProductComponent " + productName + " not Found");
            }
            return result;
        }

        protected string GetProductDescriptionByProductName(string productName)
        {
            return GetProductComponentByProductName(productName).GetDescriptionText();
        }

        protected List<string> GetProductComponentTexts()
        {
            List<string> result = new List<string>();
            foreach (ProductComponent current in ProductComponents)
            {
                result.Add(current.GetNameText());
            }
            return result;
        }

        protected string GetPriceTextByProductName(string productName)
        {
            return GetProductComponentByProductName(productName).GetPriceText();
        }

        protected double GetPriceAmountByProductName(string productName)
        {
            //Console.WriteLine("public new double GetPriceAmountByProductName(string productName) productName = " + productName);
            return GetProductComponentByProductName(productName).GetPriceAmount();
        }

        protected void ClickAddToCartByProductName(string productName)
        {
            GetProductComponentByProductName(productName).ClickAddToCart();
        }

        protected void ClickAddToWishByProductName(string productName)
        {
            GetProductComponentByProductName(productName).ClickAddToWish();
        }

    }

}
