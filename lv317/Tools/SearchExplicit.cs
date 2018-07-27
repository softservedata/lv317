using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lv317.Data;
using lv317.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace lv317.Tools
{
    class SearchExplicit : ASearch
    {
        private WebDriverWait wait;

        public SearchExplicit(ApplicationSource applicationSource)
        {
            InitExplicit(applicationSource);
        }

        private void InitExplicit(ApplicationSource applicationSource)
        {
            RemoveWaits();
            // TODO +++ Read ExplicitWait From applicationSource
            wait = new WebDriverWait(Application.Get().Browser.Driver,
                TimeSpan.FromSeconds(10));
        }

        public override void RemoveWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        // Implemented Interface ISearch

        public override IWebElement GetWebElement(By by)
        {
            // TODO Remove
            RemoveWaits();
            //Console.WriteLine("+++SearchExplicit: GetWebElement(By by): " + by.ToString());
            //
            return wait.Until(driver => driver.FindElement(by));
            //return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public override IWebElement GetWebElement(By by, IWebElement fromIWebElement)
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
            return fromIWebElement.FindElement(by);
        }

        public override ICollection<IWebElement> GetWebElements(By by)
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
            return Application.Get().Browser.Driver.FindElements(by);
        }

        public override ICollection<IWebElement> GetWebElements(By by, IWebElement fromIWebElement)
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
            return fromIWebElement.FindElements(by);
        }

        public override bool StalenessOf(IWebElement webElement)
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(Application.Get().ApplicationSource.ImplicitWaitTimeOut);
            return webElement == null || !webElement.Enabled;
        }

    }

}
