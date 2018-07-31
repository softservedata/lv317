using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lv317.Data.Users;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Pages.Users
{
    public class LoginPage : ARightUnloggedComponent
    {
        public IWebElement EmailField
            { get { return Search.Id("input-email"); } }
        public IWebElement PasswordField
            { get { return Search.Id("input-password"); } }

        // TODO all webElements

        public IWebElement LoginButton
            { get { return Search.CssSelector(".btn.btn-primary[type='submit']"); } }

        public LoginPage() : base()
        {
        }

        // EmailField
        public string GetEmailFieldText()
        {
            return EmailField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetEmailField(string text)
        {
            EmailField.SendKeys(text);
        }

        public void ClearEmailField()
        {
            EmailField.Clear();
        }

        public void ClickEmailField()
        {
            EmailField.Click();
        }

        // PasswordField
        public string GetPasswordFieldText()
        {
            return PasswordField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetPasswordField(string text)
        {
            PasswordField.SendKeys(text);
        }

        public void ClearPasswordField()
        {
            PasswordField.Clear();
        }

        public void ClickPasswordField()
        {
            PasswordField.Click();
        }

        // LoginButton
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        // Business Logic
        public void SetLoginData(IUser user)
        {
            ClickEmailField();
            ClearEmailField();
            SetEmailField(user.GetEmail());
            //
            ClickPasswordField();
            ClearPasswordField();
            SetPasswordField(user.GetPassword());
            //
            ClickLoginButton();
        }

        public MyAccountPage SuccessfulLogin(IUser validUser)
        {
            SetLoginData(validUser);
            return new MyAccountPage();
        }

        public LoginValidatorPage UnsuccessfulLogin(IUser invalidUser)
        {
            SetLoginData(invalidUser);
            return new LoginValidatorPage();
        }

    }
}
