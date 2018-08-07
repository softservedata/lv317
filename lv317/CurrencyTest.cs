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
using lv317.Pages.Users;
using lv317.Data.Commons;
using lv317.Data.Products;

namespace lv317
{
    [TestFixture]
    public class CurrencyTest : TestRunner
    {
        private static readonly object[] CurrencyData =
        {
            new object[] { "EUR", "MacBook", "560.94" },
            new object[] { "GBP", "MacBook", "487.62" },
            new object[] { "USD", "MacBook", "602.00" }
        };

        //[Test, TestCaseSource(nameof(CurrencyData))]
        //public void CheckChangeCurrency0(string currencyName, string itemName, string expectedPrice)
        //{
        //    driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")).Click();
        //    driver.FindElement(By.Name(currencyName)).Click();
        //    IWebElement actualPrice = driver.FindElement(By.XPath("//a[text()='"
        //        + itemName + "']/../../p[@class='price']"));
        //    Console.WriteLine("actual string: " + actualPrice.Text.Trim());
        //    Assert.True(actualPrice.Text.Trim().Contains(expectedPrice));
        //    Console.WriteLine("CheckChangeCurrency done, currency = " + currencyName);
        //    Thread.Sleep(1000);
        //}

        // DataProvider
        private static readonly object[] CurrencyProducts =
        {
            //new object[] { CurrencyRepository.Euro(), ProductRepository.MacBook() },
            //new object[] { CurrencyRepository.PoundSterling(), ProductRepository.MacBook() },
            new object[] { CurrencyRepository.USDollar(), ProductRepository.MacBook() },
        };

        //[Test, TestCaseSource(nameof(CurrencyProducts))]
        public void CheckChangeCurrency1(string currencyText, Product product)
        {
            // Steps
            SuccesSearchPage succesSearchPage = Pages.Application.Get().LoadHomePage()
                    .SuccesSearchProduct(product.Name)
                    .ChooseCurrencyByPartialName(currencyText);
            // Check
            Assert.AreEqual(product.GetPrice(currencyText),
                    succesSearchPage.GetPriceAmountByProductName(product.Name),
                    DOUBLE_PRECISE);
            // Return to Previous State
            HomePage homePage = succesSearchPage.GotoHomePage();
            // Check
            Assert.IsTrue(homePage.GetAlternativeText().Equals(HomePage.EXPECTED_ALT_IMAGE));
            Thread.Sleep(2000);
            //
            isTestSuccess = true;
        }

    }

}
