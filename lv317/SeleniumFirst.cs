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

namespace lv317
{
    [TestFixture]
    public class SeleniumFirst
    {
        private string expected = "Selenium IDE is a Chrome and Firefox plugin which records and plays back user interactions with the browser. Use this to either create simple scripts or assist in exploratory testing.";

        //[Test]
        public void TheFirstTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            Thread.Sleep(1000);
            //
            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium" + Keys.Enter);
            Thread.Sleep(1000);
            //
            //driver.FindElement(By.Name("btnK")).Click();
            //Thread.Sleep(1000);
            //
            driver.FindElement(By.LinkText("Selenium - Web Browser Automation")).Click();
            Thread.Sleep(1000);
            //
            driver.FindElement(By.LinkText("Download")).Click();
            //
            IWebElement actual = driver.FindElement(By.CssSelector("a[name='selenium_ide'] > p"));
            Assert.AreEqual("Selenium IDE is a Chrome and Firefox plugin which records and plays back user interactions with the browser. Use this to either create simple scripts or assist in exploratory testing.",
                actual.Text);
            Thread.Sleep(1000);
            //
            driver.Quit();
        }
    }
}
