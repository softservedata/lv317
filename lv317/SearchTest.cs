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
using lv317.Data;
using lv317.Tools;
using lv317.Pages;
using lv317.Pages.Users;
using lv317.Data.Products;
using lv317.Data.Users;

namespace lv317
{
    [TestFixture]
    public class SearchTest : TestRunner
    {
        // DataProvider
        private static readonly object[] Items =
        {
            //new object[] { "iPhone", "iPhone is a revolutionary new mobile phone that allows you to make a call by simply tapping" },
            new object[] { "Apple iPhone SE 64GB", "IPS, 1136x640) / Apple A9 /" }
        };

        //[Test, TestCaseSource(nameof(Items))]
        //public void SearchItem0(string itemName, string description)
        //{
        //    driver.FindElement(By.Name("search")).Click();
        //    driver.FindElement(By.Name("search")).Clear();
        //    driver.FindElement(By.Name("search")).SendKeys(itemName);
        //    Thread.Sleep(1000);
        //    //
        //    driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")).Click();
        //    Thread.Sleep(1000);
        //    //
        //    IWebElement webDescription = driver.FindElement(By.XPath("//h4/a[text()='" + itemName + "']/../following-sibling::p[not(@*)]"));
        //    // MoveToElement
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(webDescription).Perform();
        //    //IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
        //    //javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", webDescription);
        //    //
        //    Assert.True(webDescription.Text.Contains(description));
        //    Thread.Sleep(2000);
        //    //
        //    MessageBox.Show("Congratulation! Item " + itemName + "Found. \nDescription: " + description, "info " + itemName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //
        //    isTestSuccess = true;
        //}

        // DataProvider
        private static readonly object[] ProductItems =
        {
            //new object[] { ProductRepository.AppleIPhone() },
            //new object[] { ProductRepository.MacBook() },
            new object[] { ProductRepository.MacBookAir() }
        };

        //[Test, TestCaseSource(nameof(ProductItems))]
        public void SearchItem1(Product product)
        //public void SearchItem1(string itemName, string description)
        {
            // Steps
            //SuccesSearchPage succesSearchPage = GotoHomePage()
            //        .SuccesSearchProduct(product.Name);
            SuccesSearchPage succesSearchPage = Pages.Application.Get().LoadHomePage()
                    .SuccesSearchProduct(product.Name);
            // Check
            Assert.True(succesSearchPage
                    .GetProductDescriptionByProductName(product.Name)
                    .Contains(product.Description));
            //
            MessageBox.Show("Web Description: " + succesSearchPage.GetProductDescriptionByProductName(product.Name),
                "info " + product.Name,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            isTestSuccess = true;
        }

        // DataProvider
        private static readonly object[] ValidUsers =
        {
            new object[] {UserRepository.Get().Registered() }
       };

        // DataProvider
        private static readonly object[] ExternalValidUsers =
            ListUtils.ToMultiArray(UserRepository.Get().FromCsv("ExistUsers.csv"));
        //ListUtils.ToMultiArray(UserRepository.Get().FromExcel("ExistUsers.xlsx"));

        //[Test, TestCaseSource(nameof(ExternalValidUsers))]
        [Test, TestCaseSource("ExternalValidUsers")]
        public void LoginUser1(IUser validUser)
        {
            // Steps
            MyAccountPage myAccountPage = Pages.Application.Get().LoadHomePage()
                    .OpenLoginPage()
                    .SuccessfulLogin(validUser);
            // Check
            //Assert.True(succesSearchPage
            //        .GetProductDescriptionByProductName(product.Name)
            //        .Contains(product.Description));
            //
            isTestSuccess = true;
        }

        // DataProvider
        private static readonly object[] ValidUserProduct =
        {
            new object[] { UserRepository.Get().Registered(), ProductRepository.MacBookAir() }
        };

        //[Test, TestCaseSource(nameof(ValidUserProduct))]
        public void WishList1NotEmpty(IUser validUser, Product product)
        {
            // Precondition
            List<string> products = new List<string>();
            products.Add(product.Name);
            // Steps
            WishListPage wishListPage = Pages.Application.Get().LoadHomePage()
                .SuccesSearchProduct(product.Name)
                .ClickAddToWishByProductName(product.Name)
                .OpenLoginPage()
                .SuccessfulLogin(validUser)
                .GotoWishListPage(products);
            // Check
            Assert.False(wishListPage.isWishListEmpty());
            //
            // Return to Previous State.
            wishListPage
                .ClickRemoveWishByProductName(product.Name)
                .GotoLogout();
            //
            isTestSuccess = true;
        }

    }

}
