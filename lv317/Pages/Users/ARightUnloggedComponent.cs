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
    public abstract class ARightUnloggedComponent : ARightCommonComponent
    {
        // TODO Login, Register, Forgotten Password

        public IWebElement LoginLink
            { get { return Search.XPath("//div/a[contains(@href,'route=account/login')]"); } }

        public ARightUnloggedComponent() : base()
        {
        }

        // Override My Account, Address Book, Wish List, Order History, Downloads, Recurring payments, Reward Points, Returns, Transactions, Newsletter

        // MyAccountLink
        public string GetLoginLinkText()
        {
            return LoginLink.Text;
        }

        public void ClickLoginLink()
        {
            LoginLink.Click();
        }

        // Business Logic
        public LoginPage GotoLoginPage()
        {
            ClickLoginLink();
            return new LoginPage();
        }

    }
}
