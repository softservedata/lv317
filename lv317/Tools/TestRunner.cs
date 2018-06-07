using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace lv317.Tools
{
    [TestFixture]
    public abstract class TestRunner
    {
        private readonly int IMPLICIT_WAIT = 10;
        private string urlUnderTest = "http://atqc-shop.epizy.com";
        public virtual string UrlUnderTest
        {
            get { return urlUnderTest; }
        }
        protected IWebDriver driver;
        //
        protected bool isTestSuccess = false;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(IMPLICIT_WAIT);
            //
            Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
            Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(UrlUnderTest);
            isTestSuccess = false;
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            // TODO logout
            if (!isTestSuccess)
            {
                SaveScreenshot();
                SaveSourceCode();
            }
            Console.WriteLine("[TearDown] TearDown()");
        }

        private string GetTime()
        {
            DateTime localDate = DateTime.Now;
            //return new DateTime().ToString("yyyyMMddHHmmssffff");
            //return new DateTime().ToStringlocalDate("yyyy_MM_dd_HH_mm_ss_ffff");
            return localDate.ToString("yyyy_MM_dd_HH_mm_ss");
        }

        private string GetCurrentDirectory()
        {
            //Console.WriteLine("Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase) = "
            //    + Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase).Substring(6));
            //Console.WriteLine("Current Path = " + Path.GetDirectoryName(Assembly.GetAssembly(typeof(TestRunner)).CodeBase));
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(TestRunner)).CodeBase).Substring(6);
        }

        public string SaveScreenshot()
        {
            return SaveScreenshot(null);
        }

        public string SaveScreenshot(string namePrefix)
        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            //Console.WriteLine("namePrefix = " + namePrefix + "  Directory.GetCurrentDirectory() = " + Directory.GetCurrentDirectory());
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            //screenshot.SaveAsFile(namePrefix + "_Screenshot.png", ScreenshotImageFormat.Png);
            //screenshot.SaveAsFile(namePrefix + "_Screenshot.png");
            //screenshot.SaveAsFile(@"D:\Screenshot.png", ScreenshotImageFormat.Png);
            screenshot.SaveAsFile(GetCurrentDirectory() + "\\" + namePrefix + "_Screenshot.png",
                ScreenshotImageFormat.Png);
            return namePrefix;
        }

        public string SaveSourceCode()
        {
            return SaveSourceCode(null);
        }

        public string SaveSourceCode(string namePrefix)
        {
            if ((namePrefix == null) || (namePrefix.Length == 0))
            {
                namePrefix = GetTime();
            }
            //File.WriteAllText(namePrefix + "_SourceCode.txt", Driver.PageSource);
            //File.WriteAllText(@"D:\SourceCode.txt", Driver.PageSource);
            File.WriteAllText(GetCurrentDirectory() + "\\" + namePrefix + "_SourceCode.html", driver.PageSource);
            return namePrefix;
        }

    }
}
