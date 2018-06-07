using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using lv317.Tools;

namespace lv317
{
    [TestFixture]
    public class PromotionTest : TestRunner
    {
        public override string UrlUnderTest
        {
            get { return "http://www.eloggo.com/"; }
        }

        private static readonly object[] search =
        {
            new object[] { "open cart" },
            new object[] { "open cart" },
            new object[] { "open cart" },
            new object[] { "open cart" },
            new object[] { "open cart" }
        };

        [Test, TestCaseSource(nameof(search))]
        public void SearchItem(string searchText)
        {
            driver.FindElement(By.Id("q")).Click();
            driver.FindElement(By.Id("q")).Clear();
            driver.FindElement(By.Id("q")).SendKeys("searchText");
            Thread.Sleep(1000);
            //
            driver.FindElement(By.Id("submit")).Click();
            Thread.Sleep(2000);
            //
            //IWebElement webDescription = driver.FindElement(By.XPath("//h4/a[text()='" + itemName + "']/../following-sibling::p[not(@*)]"));
            //Assert.True(webDescription.Text.Contains(description));
            //Thread.Sleep(2000);
            //
            isTestSuccess = true;
        }
    }
}
