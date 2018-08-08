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
    public class StartPage
    {
        private IWebDriver driver;
        //
        [FindsBy(How = How.Name, Using = "search")]
        public IWebElement SearchProductField { get; set; }
        //{ get { return Search.Name("search"); } }
        //{ get { return driver.FindElement(By.Name("search")); } }
        //
        //[CacheLookup]
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-default.btn-lg")]
        public IWebElement SearchProductButton { get; set; }
        //{ get { return Search.CssSelector(".btn.btn-default.btn-lg"); } }

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            //PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(20)));
        }

        // SearchProductField
        public string GetSearchProductFieldText()
        {
            return SearchProductField.GetAttribute("value");
        }

        public void SetSearchProductField(string text)
        {
            SearchProductField.SendKeys(text);
        }

        public void ClearSearchProductField()
        {
            SearchProductField.Clear();
        }

        public void ClickSearchProductField()
        {
            SearchProductField.Click();
        }

        // SearchProductButton
        public void ClickSearchProductButton()
        {
            SearchProductButton.Click();
        }

        public FindPage SuccesSearchProduct(string partialProductName)
        {
            ClickSearchProductButton();
            //
            ClickSearchProductField();
            ClearSearchProductField();
            driver.Navigate().Refresh();
            SetSearchProductField(partialProductName);
            ClickSearchProductButton();
            return new FindPage(driver);
        }
    }
}
