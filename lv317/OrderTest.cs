using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using lv317.Tools;
using lv317.Pages;

namespace lv317
{
    public class Order
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Order(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }

    [TestFixture]
    public class OrderTest : TestRunnerFirst
    {
        private static List<Order> orders = new List<Order>();

        public OrderTest()
        {
            //orders = new List<Order>();
            orders.Add(new Order("Samsung Galaxy J5 (2016) J510H ", "Super AMOLED, 1280x720) / Qualcomm Snapdragon 410 (1.2 GHz)"));
            orders.Add(new Order("Apple iPhone SE 64GB", "IPS, 1136x640) / Apple A9 /"));
        }

        // DataProvider
        private static readonly object[] Orders =
        {
            new object[] { orders }
        };

        //[Test, TestCaseSource(nameof(Orders))]
        public void OrderItems(List<Order> orders)
        {
            Actions action;
            IWebElement webDescription;
            IWebElement addToCart;
            IWebElement cart;
            //
            foreach (Order currentOrder in orders)
            {
                driver.FindElement(By.Name("search")).Click();
                driver.FindElement(By.Name("search")).Clear();
                driver.FindElement(By.Name("search")).SendKeys(currentOrder.Name);
                Thread.Sleep(1000);
                //
                driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();
                Thread.Sleep(1000);
                //
                //webDescription = driver.FindElement(By.XPath("//h4/a[text()='" + currentOrder.Name + "']/../following-sibling::p[not(@*)]"));
                webDescription = driver.FindElement(By.XPath("//h4/a[contains(text(), '" + currentOrder.Name
                    + "')]/../following-sibling::p[not(@*)]"));
                // MoveToElement
                action = new Actions(driver);
                action.MoveToElement(webDescription).Perform();
                //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
                //javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webDescription);
                //
                Assert.True(webDescription.Text.Contains(currentOrder.Description));
                Thread.Sleep(2000);
                //
                //addToCart = driver.FindElement(By.XPath("//h4/a[text()='" + currentOrder.Name 
                //    + "']/../../following-sibling::div[@class='button-group']/button[contains(@onclick,'cart.add')]"));
                addToCart = driver.FindElement(By.XPath("//h4/a[contains(text(), '" + currentOrder.Name
                    + "')]/../../following-sibling::div[@class='button-group']/button[contains(@onclick,'cart.add')]"));
                addToCart.Click();
            }
            //
            cart = driver.FindElement(By.CssSelector(".btn.btn-inverse.btn-block.btn-lg.dropdown-toggle"));
            action = new Actions(driver);
            action.MoveToElement(cart).Perform();
            cart.Click();
            Thread.Sleep(2000);
            cart.Click();
            //
            MessageBox.Show("Congratulation! Orders Completed", "info ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            isTestSuccess = true;
        }
    }
}
