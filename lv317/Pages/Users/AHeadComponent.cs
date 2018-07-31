using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lv317.Tools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Pages.Users
{

    public class DropdownOptions
    {
        protected ISearch Search { get; private set; }
        //protected IWebDriver driver;
        //
        public ICollection<IWebElement> ListOptions { get; private set; }

        //private DropdownOptions(IWebDriver driver)
        private DropdownOptions()
        {
            Search = Application.Get().Search;
            //this.driver = driver;
            //this.Search = Application.Get().Search;
        }

        //public DropdownOptions(IWebDriver driver, By searchLocator) : this(driver)
        public DropdownOptions(By searchLocator) : this()
        {
            InitListOptions(searchLocator);
        }

        //public DropdownOptions(IWebDriver driver, By searchLocator, By lastLocator) : this(driver)
        public DropdownOptions(By searchLocator, By lastLocator) : this()
        {
            InitListOptions(searchLocator);
            //ListOptions.Add(driver.FindElement(lastLocator));
            ListOptions.Add(Search.GetWebElement(lastLocator));
        }

        private void InitListOptions(By searchLocator)
        {
            //ListOptions = driver.FindElements(searchLocator);
            ListOptions = Search.GetWebElements(searchLocator);
        }

        public IWebElement GetDropdownOptionByPartialName(string optionName)
        {
            IWebElement result = null;
            foreach (IWebElement current in ListOptions)
            {
                if (current.Text.ToLower().Contains(optionName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        public List<string> GetListOptions()
        {
            List<string> result = new List<string>();
            foreach (IWebElement current in ListOptions)
            {
                result.Add(current.Text);
            }
            return result;
        }

        public void ClickDropdownOptionByPartialName(string optionName)
        {
            GetDropdownOptionByPartialName(optionName).Click();
        }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    // TODO Develop Base Class and Children
    public class MyAccountOptions
    {
        public static bool IsLoggedin { get; set; } = false;

        private ISearch Search { get; set; }
        //protected IWebDriver driver;
        //
        public IWebElement Register
            { get { return Search.XPath("//a[contains(@href,'route=account/register')]"); } }
        public IWebElement Login
            { get { return Search.XPath("//a[contains(@href,'route=account/login')]"); } }
        public IWebElement MyAccount
            { get { return Search.XPath("//a[contains(@href,'route=account/account')]"); } }
        public IWebElement Logout
            { get { return Search.XPath("//a[contains(@href,'route=account/logout')]"); } }

        //static MyAccountOptions()
        //{
        //    IsLoggedin = false;
        //}

        //public MyAccountOptions(IWebDriver driver)
        public MyAccountOptions()
        {
            Search = Application.Get().Search;
            //this.driver = driver;
            //this.Search = Application.Get().Search;
        }

        // Register
        public string GetRegisterText()
        {
            return Register.Text;
        }

        public void ClickRegister()
        {
            Register.Click();
        }

        // Login
        public string GetLoginText()
        {
            return Login.Text;
        }

        public void ClickLogin()
        {
            //ClickMyAccount();
            Login.Click();
        }

        // MyAccount
        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        // Logout
        public string GetLogoutText()
        {
            return Logout.Text;
        }

        public void ClickLogout()
        {
            Logout.Click();
        }

    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    public abstract class AHeadComponent
    {
        public const string TAG_ATTRIBUTE_VALUE = "value";
        public const string TAG_ATTRIBUTE_HREF = "href";
        public const string TAG_ATTRIBUTE_ALT = "alt";
        public const string FIRST_ANCHOR_CSS = "a:first-child";
        public const string MENUTOP_OPTIONS_XPATH = "//li/a[contains(text(),'{0}')]/..//li/a";
        public const string MENUTOP_LAST_OPTION_XPATH = "//a[contains(text(),'Show All {0}')]";
        public const string CURRENCY_SELECT_CSS = "button.currency-select.btn.btn-link.btn-block";

        //
        protected ISearch Search { get; private set; }
        //protected IWebDriver driver;
        //
        public IWebElement Currency
            { get { return Search.CssSelector(".btn.btn-link.dropdown-toggle"); } }
            //{ get { return driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle")); } }
        public IWebElement MyAccount
            { get { return Search.CssSelector(".list-inline > li > a.dropdown-toggle"); } }
            //{ get { return driver.FindElement(By.CssSelector(".list-inline > li > a.dropdown-toggle")); } }
        public IWebElement WishList
            { get { return Search.Id("wishlist-total"); } }
            //{ get { return driver.FindElement(By.Id("wishlist-total")); } }
        public IWebElement ShoppingCart
            { get { return Search.CssSelector("a[title='Shopping Cart']"); } }
            //{ get { return driver.FindElement(By.CssSelector("a[title='Shopping Cart']")); } }
        public IWebElement Checkout
            { get { return Search.CssSelector("a[title='Checkout']"); } }
            //{ get { return driver.FindElement(By.CssSelector("a[title='Checkout']")); } }
        public IWebElement Logo
            { get { return Search.CssSelector("#logo > a"); } }
            //{ get { return driver.FindElement(By.CssSelector("#logo > a")); } }
        public IWebElement SearchProductField
            { get { return Search.Name("search"); } }
            //{ get { return driver.FindElement(By.Name("search")); } }
        public IWebElement SearchProductButton
            { get { return Search.CssSelector(".btn.btn-default.btn-lg"); } }
            //{ get { return driver.FindElement(By.CssSelector(".btn.btn-default.btn-lg")); } }
        public IWebElement Cart
            { get { return Search.CssSelector("#cart > button"); } }
            //{ get { return driver.FindElement(By.CssSelector("#cart > button")); } }
        public ICollection<IWebElement> MenuTop
            { get { return Search.CssSelectors("ul.nav.navbar-nav > li"); } }
            //{ get { return driver.FindElements(By.CssSelector("ul.nav.navbar-nav > li")); } }
            //
            // Create dropdownOptions class if Top Menu Click and Window Opened
        private DropdownOptions dropdownOptions;
        private DropdownOptions currencyOptions;
        //protected List<ProductComponent> ProductComponents { get; private set; }
        public MyAccountOptions MyAccountOption { get; private set; }
        //private DropdownCart DropdownCart;

        //public AHeadComponent(IWebDriver driver)
        public AHeadComponent()
        {
            this.Search = Application.Get().Search;
            //this.driver = driver;
            //currency = driver.FindElement(By.CssSelector(".btn.btn-link.dropdown-toggle"));
            //
            VerifyWebElements();
        }

        private void VerifyWebElements()
        {
            IWebElement verify = Currency;
            // TODO Check, if Web Elements Exist
        }

        //protected void InitProductComponents(By searchLocator)
        //{
        //    ProductComponents = new List<ProductComponent>();
        //    ICollection<IWebElement> productWebElements = Search.GetWebElements(searchLocator);
        //    foreach (IWebElement current in productWebElements)
        //    {
        //        ProductComponents.Add(new ProductComponent(current));
        //    }
        //}

        // Currency
        public string GetCurrencyText()
        {
            return Currency.Text.Substring(0, 1);
        }

        public void ClickCurrency()
        {
            Currency.Click();
        }

        // MyAccount
        public string GetMyAccountText()
        {
            return MyAccount.Text;
        }

        public void ClickMyAccount()
        {
            MyAccount.Click();
        }

        // WishList
        public string GetWishListText()
        {
            return WishList.Text;
        }

        public int GetWishListNumber()
        {
            return RegexUtils.ExtractFirstNumber(GetWishListText());
        }

        public void ClickWishList()
        {
            WishList.Click();
        }

        // ShoppingCart
        public string GetShoppingCartText()
        {
            return ShoppingCart.Text;
        }

        public void ClickShoppingCart()
        {
            ShoppingCart.Click();
        }

        // Checkout
        public string GetCheckoutText()
        {
            return Checkout.Text;
        }

        public void ClickCheckout()
        {
            Checkout.Click();
        }

        // Logo
        public void ClickLogo()
        {
            Logo.Click();
        }

        // SearchProductField
        public string GetSearchProductFieldText()
        {
            return SearchProductField.GetAttribute(TAG_ATTRIBUTE_VALUE);
        }

        public void SetSearchProductField(string text)
        {
            SearchProductField.SendKeys(text);
        }

        public void ClearSearchProductField()
        {
            SearchProductField.Clear();
        }

        public void ClickSearchProductField()
        {
            SearchProductField.Click();
        }

        // SearchProductButton
        public void ClickSearchProductButton()
        {
            SearchProductButton.Click();
        }

        // Cart
        public string GetCartText()
        {
            return Cart.Text;
        }

        public int GetCartAmount()
        {
            return RegexUtils.ExtractFirstNumber(GetCartText());
        }

        public double GetCartSum()
        {
            return RegexUtils.ExtractFirstDouble(GetCartText());
        }

        public void ClickCart()
        {
            Cart.Click();
        }

        // MenuTop
        public IWebElement GetMenuTopByCategoryPartialName(string categoryName)
        {
            IWebElement result = null;
            foreach (IWebElement current in MenuTop)
            {
                //if (Search.CssSelector(FIRST_ANCHOR_CSS, current)
                if (current.FindElement(By.CssSelector(FIRST_ANCHOR_CSS))
                        .Text.ToLower().Contains(categoryName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            return result;
        }

        public List<string> GetMenuTopTexts()
        {
            List<string> result = new List<string>();
            foreach (IWebElement current in MenuTop)
            {
                //result.Add(Search.CssSelector(FIRST_ANCHOR_CSS, current).Text);
                result.Add(current.FindElement(By.CssSelector(FIRST_ANCHOR_CSS)).Text);
            }
            return result;
        }

        public bool isExistMenuTopByCategoryPartialName(string categoryName)
        {
            bool isExist = false;
            foreach (string current in GetMenuTopTexts())
            {
                if (current.ToLower().Contains(categoryName.ToLower()))
                {
                    isExist = true;
                }
            }
            if (!isExist)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("Menu Element not Found");
            }
            return isExist;
        }


        public void ClickMenuTopByCategoryPartialName(string categoryName)
        {
            if (isExistMenuTopByCategoryPartialName(categoryName))
            {
                GetMenuTopByCategoryPartialName(categoryName).Click();
            }
        }

        // DropdownOptions
        private void CreateDropdownOptions(By searchLocator, By lastLocator)
        {
            if (lastLocator == null)
            {
                dropdownOptions = new DropdownOptions(searchLocator);
            }
            else
            {
                dropdownOptions = new DropdownOptions(searchLocator, lastLocator);
            }
        }

        private void ClickDropdownOptionByPartialName(string optionName, By searchLocator, By lastLocator)
        {
            bool isClickable = false;
            CreateDropdownOptions(searchLocator, lastLocator);
            foreach (string current in dropdownOptions.GetListOptions())
            {
                if (current.ToLower().Contains(optionName.ToLower()))
                {
                    isClickable = true;
                }
            }
            if (!isClickable)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("SubMenu Element " + optionName + " not Found");
            }
            dropdownOptions.ClickDropdownOptionByPartialName(optionName);
        }

        public List<string> GetSubMenuTopByPartialName(string categoryName)
        {
            ClickMenuTopByCategoryPartialName(categoryName);
            dropdownOptions = new DropdownOptions(By
                    .XPath(String.Format(MENUTOP_OPTIONS_XPATH, categoryName)));
            return dropdownOptions.GetListOptions();
        }

        public void ClickSubMenuTopByPartialName(string categoryName, string optionName)
        {
            ClickMenuTopByCategoryPartialName(categoryName);
            ClickDropdownOptionByPartialName(optionName,
                    By.XPath(String.Format(MENUTOP_OPTIONS_XPATH, categoryName)),
                    By.XPath(String.Format(MENUTOP_LAST_OPTION_XPATH, categoryName)));
        }

        // CurrencyOptions
        private void InitcurrencyOptions()
        {
            ClickSearchProductField();
            ClickCurrency();
            currencyOptions = new DropdownOptions(By.CssSelector(CURRENCY_SELECT_CSS));
        }

        public IWebElement GetCurrencyByPartialName(string currencyName)
        {
            InitcurrencyOptions();
            return currencyOptions.GetDropdownOptionByPartialName(currencyName);
        }

        public List<string> GetCurrencies()
        {
            InitcurrencyOptions();
            return currencyOptions.GetListOptions();
        }

        public void ClickCurrencyByPartialName(string currencyName)
        {
            InitcurrencyOptions();
            currencyOptions.ClickDropdownOptionByPartialName(currencyName);
        }


        // Business Logic
        public void GotoHome()
        {
            ClickLogo();
        }

        public void SuccesSearchProduct(string partialProductName)
        {
            ClickSearchProductField();
            ClearSearchProductField();
            SetSearchProductField(partialProductName);
            ClickSearchProductButton();
        }

        public void GotoRegister()
        {
            ClickSearchProductField();
            ClickMyAccount();
            //
            //MyAccountOption = new MyAccountOptions(driver);
            MyAccountOption = new MyAccountOptions();
            MyAccountOption.ClickRegister();
        }

        // TODO
        public void GotoLogin()
        {
            // TODO +++
            //if (MyAccountOptions.IsLoggedin)
            //{
            //    throw new Exception("You Must be Logout");
            //}
            ClickSearchProductField();
            ClickMyAccount();
            //
            MyAccountOption = new MyAccountOptions();
            // if MyAccountOptions.isLogined()
            MyAccountOption.ClickLogin();
            // TODO Modify +++
            MyAccountOptions.IsLoggedin = true;
        }

        // TODO
        public void GotoMyAccount()
        {
            ClickSearchProductField();
            ClickMyAccount();
            //
            MyAccountOption = new MyAccountOptions();
            // if MyAccountOptions.isLogined()
            MyAccountOption.ClickMyAccount();
        }

        // TODO
        public void GotoLogout()
        {
            if (!MyAccountOptions.IsLoggedin)
            {
                throw new Exception("You Must be Login");
            }
            ClickSearchProductField();
            ClickMyAccount();
            //
            MyAccountOption = new MyAccountOptions();
            // if MyAccountOptions.isLogined()
            MyAccountOption.ClickLogout();
            MyAccountOptions.IsLoggedin = false;
        }

        // Business Logic
        public LoginPage OpenLoginPage()
        {
            GotoLogin();
            return new LoginPage();
        }

    }
}
