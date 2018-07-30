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
    public class SuccesSearchPage : SearchPage
    {

        protected ProductsListComponent productsListComponent { get; private set; }

        //public SuccesSearchPage(IWebDriver driver) : base(driver)
        public SuccesSearchPage() : base()
        {
            productsListComponent = new ProductsListComponent();
            //productsListComponent = new ProductsListComponent(By.CssSelector(AHeadProduct.PRODUCT_BASE_ELEMENT_CSS));
            //InitProductComponents(By.CssSelector(PRODUCT_BASE_ELEMENT_CSS));
        }

        public string GetProductDescriptionByProductName(string productName)
        {
            //return base.GetProductDescriptionByProductName(productName);
            return productsListComponent.GetProductDescriptionByProductName(productName);
        }

        public List<string> GetProductComponentTexts()
        {
            return productsListComponent.GetProductComponentTexts();
        }

        public string GetPriceTextByProductName(string productName)
        {
            return productsListComponent.GetPriceTextByProductName(productName);
        }

        public double GetPriceAmountByProductName(string productName)
        {
            //Console.WriteLine("public new double GetPriceAmountByProductName(string productName) productName = " + productName);
            return productsListComponent.GetPriceAmountByProductName(productName);
        }

        public void ClickAddToCartByProductName(string productName)
        {
            productsListComponent.ClickAddToCartByProductName(productName);
        }

        public void ClickAddToWishByProductName(string productName)
        {
            productsListComponent.ClickAddToWishByProductName(productName);
        }

        // Business Logic
        public SuccesSearchPage ChooseCurrencyByPartialName(string currencyName)
        {
            ClickCurrencyByPartialName(currencyName);
            //return new SuccesSearchPage(driver);
            return new SuccesSearchPage();
        }

        public HomePage GotoHomePage()
        {
            ClickLogo();
            //return new HomePage(driver);
            return new HomePage();
        }
    }

}
