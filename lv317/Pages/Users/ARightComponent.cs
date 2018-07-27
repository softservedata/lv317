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
    public abstract class ARightComponent : ANavigatePanelComponent
    {
        //public ICollection<IWebElement> RightCategories { get; private set; }
        public IWebElement MyAccountLink
            { get { return Search.XPath("//div/a[contains(@href,'route=account/account')]"); } }
        public IWebElement EditAccountLink
            { get { return Search.XPath("//div/a[contains(@href,'route=account/edit')]"); } }
        public IWebElement LogoutLink
            { get { return Search.XPath("//div/a[contains(@href,'route=account/logout')]"); } }

        //public ARightComponent(IWebDriver driver) : base(driver) { }
        public ARightComponent() : base() { }

        // MyAccountLink
        public string GetMyAccountLinkText()
        {
            return MyAccountLink.Text;
        }

        public void ClickMyAccountLink()
        {
            MyAccountLink.Click();
        }

        // EditAccountLink
        public string GetEditAccountLinkText()
        {
            return EditAccountLink.Text;
        }

        public void ClickEditAccountLink()
        {
            EditAccountLink.Click();
        }

        // LogoutLink
        public string GetLogoutLinkText()
        {
            return LogoutLink.Text;
        }

        public void ClickLogoutLink()
        {
            LogoutLink.Click();
        }

    }

}
