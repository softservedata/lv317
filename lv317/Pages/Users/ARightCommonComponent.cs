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
    public abstract class ARightCommonComponent : ANavigatePanelComponent
    {
        // TODO My Account, Address Book, Wish List, Order History, Downloads, Recurring payments, Reward Points, Returns, Transactions, Newsletter

        public IWebElement WishListLink
            { get { return Search.XPath("//div/a[contains(@href,'route=account/wishlist')]"); } }

        public ARightCommonComponent() : base()
        {
        }

        // WishList
        public string GetWishListLinkText()
        {
            return WishListLink.Text;
        }

        public void ClickWishListLink()
        {
            WishListLink.Click();
        }

    }
}
