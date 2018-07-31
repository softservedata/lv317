using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lv317.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Pages.Users
{
    public class ProductComponent
    {
        // protected ISearch Search { get; private set; }
        //protected IWebDriver driver;
        //
        public IWebElement ProductLayout { get; private set; }
        //
        // TODO Use Search
        public IWebElement Name
            { get { return ProductLayout.FindElement(By.CssSelector("h4 a")); } }
        public IWebElement Description
            { get { return ProductLayout.FindElement(By.XPath("//h4/a[text()='" + Name.Text + "']/../following-sibling::p[not(@*)]")); } }
        public IWebElement Price
            { get { return ProductLayout.FindElement(By.CssSelector(".price")); } }
        public IWebElement AddToCart
            { get { return ProductLayout.FindElement(By.CssSelector(".fa.fa-shopping-cart")); } }
        public IWebElement AddToWish
            { get { return ProductLayout.FindElement(By.CssSelector(".fa.fa-heart")); } }

        public ProductComponent(IWebElement productLayout)
        {
            //this.Search = Application.Get().Search;
            this.ProductLayout = productLayout;
            //
            // Verify Web Elements
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement verify = Name;
            // TODO Check, if Web Elements Exist
        }

        // Name
        public string GetNameText()
        {
            return Name.Text;
        }

        // Description
        public string GetDescriptionText()
        {
            return Description.Text;
        }

        // Price
        public String GetPriceText()
        {
            return Price.Text;
        }

        public double GetPriceAmount()
        {
            //Console.WriteLine("GetPriceText() = " + GetPriceText());
            return RegexUtils.ExtractFirstDouble(GetPriceText());
        }

        public void ClickName()
        {
            Name.Click();
        }

        // AddToCart
        public void ClickAddToCart()
        {
            AddToCart.Click();
        }

        // AddToWish
        public void ClickAddToWish()
        {
            AddToWish.Click();
        }

    }

}
