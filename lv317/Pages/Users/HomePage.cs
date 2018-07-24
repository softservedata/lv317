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
    public class HomePage : AHeadProduct
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            InitProductComponents(By.CssSelector(PRODUCT_BASE_ELEMENT_CSS));
        }

        // ProductComponents
        public new string GetProductDescriptionByProductName(string productName)
        {
            return base.GetProductDescriptionByProductName(productName);
        }

        public new List<string> GetProductComponentTexts()
        {
            return base.GetProductComponentTexts();
        }

        public new string GetPriceTextByProductName(string productName)
        {
            return base.GetPriceTextByProductName(productName);
        }

        public new double GetPriceAmountByProductName(string productName)
        {
            return base.GetPriceAmountByProductName(productName);
        }

        public new void ClickAddToCartByProductName(string productName)
        {
            base.ClickAddToCartByProductName(productName);
        }

        public new void ClickAddToWishByProductName(string productName)
        {
            base.ClickAddToWishByProductName(productName);
        }

        // Business Logic
        public new SuccesSearchPage SuccesSearchProduct(string partialProductName)
        {
            base.SuccesSearchProduct(partialProductName);
            return new SuccesSearchPage(driver);
        }

    }

}
