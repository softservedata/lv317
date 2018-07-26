using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using lv317.Data;
using lv317.Pages.Users;

namespace lv317.Pages
{
    [TestFixture]
    public abstract class TestRunner
    {
        protected readonly double DOUBLE_PRECISE = 0.01;
        //
        protected bool isTestSuccess = false;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            Application.Get(ApplicationSourceRepository.ChromeEpizy());
            //Application.Get(ApplicationSourceRepository.ChromeWithoutUIEpizy);
            //Application.Get(); // Default
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            //Application.Get().LoadHomePage();
            isTestSuccess = false;
        }

        [TearDown]
        public void TearDown()
        {
            if (!isTestSuccess)
            {
                Application.Get().SaveCurrentState();
            }
            // Logout
            Application.Get().LogoutAction();
        }

    }
}
