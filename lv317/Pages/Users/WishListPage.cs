using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Pages.Users
{
    public class WishListPage : ARightLoggedComponent
    {
        public const string WISH_BASE_ELEMENT_CSS = ".table.table-bordered.table-hover tbody tr";
        public const string WISH_ABSENT_ELEMENT_CSS = "div[id='content'] p";
        //
        public List<WishComponent> WishComponents { get; private set; }
        //
        public IWebElement EmptyWishLabel
            { get { return Search.CssSelector(WISH_ABSENT_ELEMENT_CSS); } }

        // TODO Remove
        public WishListPage() : base()
        {
            InitWishListComponents(By.CssSelector(WISH_BASE_ELEMENT_CSS), new List<string>());
        }

        public WishListPage(List<string> productNames) : base()
        {
            InitWishListComponents(By.CssSelector(WISH_BASE_ELEMENT_CSS), productNames);
        }

        private void InitWishListComponents(By searchLocator, List<string> productNames)
        {
            int counter = 0;
            WishComponents = new List<WishComponent>();
            ICollection<IWebElement> wishWebElements = Search.GetWebElements(searchLocator);
            if (wishWebElements.Count > 0)
            {
                foreach (IWebElement current in wishWebElements)
                {
                    WishComponents.Add(new WishComponent(current, productNames[counter++]));
                }
            }
        }

        public bool isWishListEmpty()
        {
            return WishComponents.Count == 0;
        }

        // WishComponents
        public WishComponent GetProductComponentByProductName(string productName)
        {
            WishComponent result = null;
            foreach (WishComponent current in WishComponents)
            {
                if (current.GetProductNameLinkText().ToLower().Equals(productName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                // TODO Develop Custom Exceptions
                throw new Exception("ProductComponent " + productName + " not Found");
            }
            return result;
        }

        public List<string> GetWishComponentTexts()
        {
            List<string> result = new List<string>();
            foreach (WishComponent current in WishComponents)
            {
                result.Add(current.GetProductNameLinkText());
            }
            return result;
        }

        public WishListPage ClickRemoveWishByProductName(string productName)
        {
            GetProductComponentByProductName(productName).ClickRemoveButton();
            return new WishListPage();
        }

        // EmptyWishLabel
        public string GetEmptyWishLabelText()
        {
            if (!isWishListEmpty())
            {
                // TODO Develop Custom Exceptions
                throw new Exception("Wish List not Empty");
            }
            return EmptyWishLabel.Text;
        }

    }
}

