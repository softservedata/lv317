using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using lv317.Tools;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using lv317.Pages;

namespace lv317
{
    public class Item
    {
        public string Name { get; private set; }
        public Item(string name)
        {
            this.Name = name;
        }
    }

    [TestFixture]
    public class WishWish : TestRunnerFirst
    {
        private static List<Item> wishItems = new List<Item>();
        public WishWish()
        {
            wishItems.Add(new Item("apple"));
            wishItems.Add(new Item("htc"));
        }
        private static object[] AddWishItems =
        {
            new object[] {wishItems}
        };

        //[Test, TestCaseSource(nameof(AddWishItems))]
        public void AddToWishList(List<Item> wishItems)
        {
            driver.FindElement(By.ClassName("dropdown")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[text()='Login']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("email")).SendKeys("kimachuk88@yahoo.com");
            driver.FindElement(By.Name("password")).SendKeys("qwerty");
            driver.FindElement(By.CssSelector("input.btn.btn-primary")).Click();

            Actions action = new Actions(driver);
            foreach (Item iwish in wishItems)
            {
                IWebElement searchField = driver.FindElement(By.CssSelector(".form-control.input-lg"));
                searchField.Click();
                searchField.Clear();

                searchField.SendKeys(iwish.Name);
                Thread.Sleep(1000);

                driver.FindElement(By.CssSelector("i.fa.fa-search")).Click();
                Thread.Sleep(2000);

                IWebElement firstHeart = driver.FindElement(By.CssSelector(".product-layout:first-child .fa-heart"));
                IWebElement secondHeart = driver.FindElement(By.CssSelector(".product-layout:nth-child(2) .fa-heart"));

                action = new Actions(driver);
                action.MoveToElement(firstHeart).Perform();
                firstHeart.Click();
                Thread.Sleep(3000);
                action.MoveToElement(secondHeart).Perform();
                secondHeart.Click();
                Thread.Sleep(3000);


            }
        }


    }

}

