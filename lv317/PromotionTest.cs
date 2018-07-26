using System;
using System.Threading;
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
    [TestFixture]
    public class PromotionTest : TestRunnerFirst
    {
        public override string UrlUnderTest
        {
            get { return "http://www.eloggo.com/"; }
        }
        public override IWebDriver DefaultDriver
        {
            get { return InitFirefoxWhithUI(); }
            //get { return InitChromeWhithoutUI(); }
        }

        private static readonly object[] search =
        {
            new object[] { "open cart", "many items" },
            new object[] { "open cart", "many items" },
            new object[] { "open cart", "many items" },
            new object[] { "open cart", "many items" },
            new object[] { "open cart", "many items" }
        };

        [Test, TestCaseSource(nameof(search))]
        public void SearchItem(string searchText, string description)
        {
            //Console.WriteLine("Start Test");
            //
            Thread.Sleep(2000);
            driver.FindElement(By.Id("q")).Click();
            driver.FindElement(By.Id("q")).Clear();
            driver.FindElement(By.Id("q")).SendKeys(searchText);
            Thread.Sleep(2000);
            //Console.WriteLine("Type " + searchText);
            //
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);
            //Console.WriteLine("Click submit");
            //
            IWebElement theBestShopLink = driver.FindElement(By.CssSelector("a[href*='atqc-shop.epizy.com']"));
            IWebElement theBestShop = driver.FindElement(By.XPath("//a[contains(@href,'atqc-shop.epizy.com')]/following-sibling::p[@class='info']"));
            //
            // MoveToElement
            //Actions action = new Actions(driver);
            //action.MoveToElement(theBestShopLink).Perform();
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", theBestShopLink);
            //
            Assert.True(theBestShop.Text.Contains(description));
            Thread.Sleep(2000);
            //
            isTestSuccess = true;
        }
    }
}
