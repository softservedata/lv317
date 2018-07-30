using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Pages.Users
{
    public class RegisterPage : ARightUnloggedComponent
    {
        public IWebElement FirstnameField
            { get { return Search.Id("input-firstname"); } }

        // TODO all webElements

        public IWebElement ContinueButton
            { get { return Search.CssSelector(".btn.btn-primary"); } }

        public RegisterPage() : base()
        {
        }

    }
}
