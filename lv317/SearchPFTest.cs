using System;
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
using lv317.Data;
using lv317.Tools;
using lv317.Pages;
using lv317.Pages.Users;
using lv317.Data.Products;
using lv317.Data.Users;
using lv317.PFPages;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium.Support.PageObjects;
#pragma warning disable

namespace lv317
{
    [TestFixture]
    class SearchPFTest
    {
        // DataProvider
        private static readonly object[] Items =
        {
            //new object[] { "iPhone", "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping" },
            new object[] { "Apple iPhone SE 64GB", "IPS, 1136x640) / Apple A9 /" }
        };

        //[Test, TestCaseSource(nameof(Items))]
        public void SearchItem0(string itemName, string description)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            //
            //driver.FindElement(By.Name("search")).Click();
            //driver.FindElement(By.Name("search")).Clear();
            //driver.FindElement(By.Name("search")).SendKeys(itemName);
            //
            //IWebElement search = driver.FindElement(By.Name("search"));
            //
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //#pragma warning disable
            IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Name("search")));
            element.Click();
            element.Clear();
            element.SendKeys(itemName);
            Thread.Sleep(1000);
            //
            driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();
            Thread.Sleep(1000);
            //
            IWebElement webDescription = driver.FindElement(By.XPath("//h4/a[text()='" + itemName + "']/../following-sibling::p[not(@*)]"));
            // MoveToElement
            //Actions action = new Actions(driver);
            //action.MoveToElement(webDescription).Perform();
            //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            //javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webDescription);
            //
            Assert.True(webDescription.Text.Contains(description));
            Thread.Sleep(2000);
            //
            //MessageBox.Show("Congratulation! Item " + itemName + "Found. \nDescription: " + description, "info " + itemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            driver.Quit();
        }

        // DataProvider
        private static readonly object[] ProductItems =
        {
            //new object[] { ProductRepository.AppleIPhone() },
            //new object[] { ProductRepository.MacBook() },
            new object[] { ProductRepository.MacBookAir() }
        };

        [Test, TestCaseSource(nameof(ProductItems))]
        public void SearchItem1(Product product)
        //public void SearchItem1(string itemName, string description)
        {
            // Steps
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com");
            //
            //StartPage startPage = new StartPage(driver);
            //PageFactory.InitElements(driver, startPage);
            //FindPage findPage = startPage.SuccesSearchProduct(product.Name);
            //
            FindPage findPage = new StartPage(driver)
                .SuccesSearchProduct(product.Name);
            //
            // Check
            Assert.True(findPage.GetProductDescriptionByProductName(product.Name)
                    .Contains(product.Description));
            //
            driver.Quit();
        }
    }
}
