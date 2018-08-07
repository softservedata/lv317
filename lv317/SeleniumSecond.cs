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

namespace lv317
{
    public class SeleniumSecond
    {
        //[Test]
        public void CheckLogin1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/");
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(2000);
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(2000);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Thread.Sleep(2000);
            //
            IWebElement actualLogin = driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm:not(.dropdown-toggle)"));
            Assert.AreEqual("work", actualLogin.Text);
            Thread.Sleep(2000);
            //
            driver.FindElement(By.CssSelector(".btn.btn-primary.btn-sm.dropdown-toggle")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("a[href *= 'logout']")).Click();
            Thread.Sleep(2000);
            //
            IWebElement actualImage = driver.FindElement(By.CssSelector("div img"));
            Assert.True(actualImage.GetAttribute("src").ToLower().Contains("ukraine_logo2.gif"));
            Thread.Sleep(2000);
            //
            driver.Quit();
        }

        //[Test]
        public void CheckLogin2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://regres.herokuapp.com/");
            //
            //IWebElement login = driver.FindElement(By.Id("login"));
            //login.Click();
            //login.Clear();
            //login.SendKeys("hahaha");
            //Thread.Sleep(2000);
            //
            //driver.Navigate().Refresh();
            //
            //login.Click();
            //login.Clear();
            //login.SendKeys("work");
            //Thread.Sleep(2000);
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("hahaha");
            Thread.Sleep(2000);
            //
            driver.Navigate().Refresh();
            //
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys("work");
            Thread.Sleep(2000);
            driver.Quit();
        }

        //[Test]
        public void CheckSelenium1()
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
            // MoveToElement
            Actions action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(By.XPath("//a[text()='2']"))).Perform();
            //
            // Use JavaScript Injection
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//a[text()='2']")));
            Thread.Sleep(2000);
            //
            // TakesScreenshot
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/ScreenshotGoogle1.png", ScreenshotImageFormat.Png);
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
            IWebElement legacy = driver.FindElement(By.CssSelector("a[name = 'side_plugins'] > h3"));
            IWebElement legacyJs = (IWebElement)js.ExecuteScript("return document.getElementsByName('side_plugins')[0];", new object[1] { "" });
            //
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", legacy);
            action.MoveToElement(legacy).Perform();
            Thread.Sleep(2000);
            //
            screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/ScreenshotSelen1.png", ScreenshotImageFormat.Png);
            //
            Assert.AreEqual("Legacy Selenium IDE Plugins", legacy.Text);
            Assert.AreEqual("Legacy Selenium IDE Plugins", legacyJs.Text);
            Thread.Sleep(2000);
            //
            driver.Quit();
        }
    }
}
