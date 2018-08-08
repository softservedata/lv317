using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace lv317.PFPages
{
    public class FindPage
    {
        private IWebDriver driver;
        //
        [FindsBy(How = How.CssSelector, Using = ".product-layout")]
        public IList<IWebElement> ProductComponents { get; set; }

        public FindPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // ProductComponents
        public IWebElement GetProductComponentByPartialName(string partialProductName)
        {
            IWebElement result = null;
            //ICollection<IWebElement> productComponents = driver.FindElements(By.CssSelector(".product-layout"));
            foreach (IWebElement current in ProductComponents)
            {
                if (current.FindElement(By.CssSelector("h4 a")).Text
                        .ToLower().Contains(partialProductName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        // Business Logic
        public string GetProductDescriptionByProductName(string productName)
        {
            return GetProductComponentByPartialName(productName)
                    .FindElement(By.XPath(".//p[not(@*)]")).Text;
        }
    }
}
