using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using lv317.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace lv317.Tools
{
    public interface IBrowser
    {
        // Factory Method
        IWebDriver GetBrowser(ApplicationSource applicationSource);
    }

    public class FirefoxTemporaryWhithUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            return new FirefoxDriver();
        }
    }

    public class ChromeTemporaryWhithUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            return new ChromeDriver();
        }
    }

    public class ChromeTemporaryWithoutUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            //options.addArguments("--headless");
            ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            options.AddArguments("--headless");
            //options.BinaryLocation = @"C:\...\ChromiumPortable.exe";
            return new ChromeDriver(options); ;
        }
    }

    public class ChromeTemporaryMaximizedWhithUI : IBrowser
    {
        public IWebDriver GetBrowser(ApplicationSource applicationSource)
        {
            //options.addArguments("--headless");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--no-proxy-server");
            //options.AddArguments("--no-sandbox");
            //options.AddArguments("--disable-web-security");
            options.AddArguments("--ignore-certificate-errors");
            //options.AddArguments("--disable-extensions");
            //options.AddArguments("--headless");
            //options.BinaryLocation = @"C:\...\ChromiumPortable.exe";
            return new ChromeDriver(options); ;
        }
    }

    public class BrowserWrapper
    {
        private const string DEFAULT_BROWSER = "DefaultTemporary";
        //
        // Fields
        private Dictionary<string, IBrowser> Browsers;
        public IWebDriver Driver { get; private set; }

        public BrowserWrapper(ApplicationSource applicationSource)
        {
            InitDictionary();
            InitWebDriver(applicationSource);
        }

        private void InitDictionary()
        {
            // TODO Use Const
            Browsers = new Dictionary<string, IBrowser>();
            Browsers.Add(DEFAULT_BROWSER, new ChromeTemporaryWhithUI());
            Browsers.Add("FirefoxTemporaryWhithUI", new FirefoxTemporaryWhithUI());
            Browsers.Add("ChromeTemporaryWhithUI", new ChromeTemporaryWhithUI());
            Browsers.Add("ChromeTemporaryMaximizedWhithUI", new ChromeTemporaryMaximizedWhithUI());
            Browsers.Add("ChromeTemporaryWithoutUI", new ChromeTemporaryWithoutUI());
        }

        private void InitWebDriver(ApplicationSource applicationSource)
        {
            IBrowser currentBrowser = Browsers[DEFAULT_BROWSER];
            foreach (KeyValuePair<string, IBrowser> current in Browsers)
            {
                if (current.Key.ToString().ToLower()
                        .Contains(applicationSource.BrowserName.ToLower()))
                {
                    currentBrowser = current.Value;
                    break;
                }
            }
            Driver = currentBrowser.GetBrowser(applicationSource);

            // TODO Move to Search Class
            // Driver.Manage().Timeouts().ImplicitWait = TimeSpan
            //        .FromSeconds(applicationSource.ImplicitWaitTimeOut);
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
            MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase): "
                + Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase),
            "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            // TODO Create Const for 6
            return Path.GetDirectoryName(Assembly.GetAssembly(typeof(BrowserWrapper)).CodeBase).Substring(6);
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
            ITakesScreenshot takesScreenshot = Driver as ITakesScreenshot;
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
            File.WriteAllText(GetCurrentDirectory() + "\\" + namePrefix + "_SourceCode.txt",
                Driver.PageSource);
            return namePrefix;
        }

        public void OpenUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void NavigateForward()
        {
            Driver.Navigate().Forward();
        }

        public void NavigateBack()
        {
            Driver.Navigate().Back();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }

    }

}
