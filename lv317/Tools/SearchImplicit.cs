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

namespace lv317.Tools
{
    class SearchImplicit : ASearch
    {
        public SearchImplicit(ApplicationSource applicationSource)
        {
            InitImplicitWaits(applicationSource);
        }

        private void InitImplicitWaits(ApplicationSource applicationSource)
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait
                = TimeSpan.FromSeconds(applicationSource.ImplicitWaitTimeOut);
            // TODO ImplicitLoadTimeOut, ImplicitScriptTimeOut
        }

        public override void RemoveWaits()
        {
            Application.Get().Browser.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            // TODO ImplicitLoadTimeOut, ImplicitScriptTimeOut
        }

        // Implemented Interface ISearch

        public override IWebElement GetWebElement(By by)
        {
            return Application.Get().Browser.Driver.FindElement(by);
        }

        public override IWebElement GetWebElement(By by, IWebElement fromIWebElement)
        {
            return fromIWebElement.FindElement(by);
        }

        public override ICollection<IWebElement> GetWebElements(By by)
        {
            return Application.Get().Browser.Driver.FindElements(by);
        }

        public override ICollection<IWebElement> GetWebElements(By by, IWebElement fromIWebElement)
        {
            return fromIWebElement.FindElements(by);
        }

        public override bool StalenessOf(IWebElement webElement)
        {
            // TODO
            //removeImplicitWaits();
            //new WebDriverWait(Application.Get().Browser.Driver,
            //        Application.Get().GetApplicationSource().GetExplicitTimeOut())
            //                .Until(ExpectedConditions.StalenessOf(IWebElement));
            //InitImplicitWaits();
            return webElement == null || !webElement.Enabled;
        }

    }

}
