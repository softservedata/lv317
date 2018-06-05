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
    public class SearchTest : TestRunner
    {
        // DataProvider
        private static readonly object[] Items =
        {
            new object[] { "iPhone", "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping" },
            new object[] { "Apple iPhone SE 64GB", "IPS, 1136x640) / Apple A9 /" }
        };

        [Test, TestCaseSource(nameof(Items))]
        public void SearchItem(string itemName, string description)
        {
            driver.FindElement(By.Name("search")).Click();
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(itemName);
            Thread.Sleep(1000);
            //
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();
            Thread.Sleep(1000);
            //
            IWebElement webDescription = driver.FindElement(By.XPath("//h4/a[text()='" + itemName + "']/../following-sibling::p[not(@*)]"));
            Assert.True(webDescription.Text.Contains(description));
            Thread.Sleep(2000);
        }
    }

}
