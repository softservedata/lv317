using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Pages.Users
{
    public abstract class ARightLoggedComponent : ARightCommonComponent
    {
        // TODO Edit Account, Password, Logout

        public ARightLoggedComponent() : base()
        {
        }

        // Override My Account, Address Book, Wish List, Order History, Downloads, Recurring payments, Reward Points, Returns, Transactions, Newsletter

        // Business Logic

        // TODO My Account, Address Book, Wish List, Order History, Downloads, Recurring payments, Reward Points, Returns, Transactions, Newsletter
        public WishListPage GotoWishListPage(List<string> productNames)
        {
            ClickWishListLink();
            Thread.Sleep(4000);
            return new WishListPage(productNames);
        }

    }
}
