using lv317.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Pages.Users
{
    public class WishComponent
    {
        public IWebElement WishLayout { get; private set; }
        private string productName;
        //
        // TODO Use Search
        public IWebElement ProductNameLink
        //{ get { return WishLayout.FindElement(By.XPath("//td/a[contains(@href,'route=product/product')]")); } }
            { get { return WishLayout.FindElement(By.XPath("//td/a[contains(text(),'" + productName + "')]")); } }
        public IWebElement RemoveButton
        //{ get { return WishLayout.FindElement(By.XPath("//td/a[contains(@href,'route=account/wishlist&remove')]")); } }
            { get { return WishLayout.FindElement(By.XPath("//td/a[contains(text(),'" + productName + "')]/../following-sibling::td/a")); } }

        public WishComponent(IWebElement wishLayout, string productName)
        {
            WishLayout = wishLayout;
            this.productName = productName;
        }

        // ProductNameLink
        public string GetProductNameLinkText()
        {
            return ProductNameLink.Text;
        }

        // RemoveButton
        public void ClickRemoveButton()
        {
            RemoveButton.Click();
        }

    }
}
