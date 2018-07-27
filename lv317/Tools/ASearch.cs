using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace lv317.Tools
{
    public abstract class ASearch : ISearch
    {
        private const string NO_SUCH_ELEMENT = "Unable to locate element(s):";

        // Abstract Methods

        public abstract IWebElement GetWebElement(By by);

        public abstract IWebElement GetWebElement(By by, IWebElement fromIWebElement);

        public abstract ICollection<IWebElement> GetWebElements(By by);

        public abstract ICollection<IWebElement> GetWebElements(By by, IWebElement fromIWebElement);

        public abstract bool StalenessOf(IWebElement IWebElement);

        public abstract void RemoveWaits();

        // Search WebElements

        private IWebElement SearchWebElement(By by)
        {
            try
            {
                return GetWebElement(by);
            }
            catch (Exception e)
            {
                //throw new ScreenCaptureException(String.format(NO_SUCH_ELEMENT, by.toString()));
                //throw new RuntimeException(String.format(NO_SUCH_ELEMENT, by.toString()));
                // TODO Develop Custom Exception
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        private IWebElement SearchWebElement(By by, IWebElement fromIWebElement)
        {
            try
            {
                return GetWebElement(by, fromIWebElement);
            }
            catch (Exception e)
            {
                //throw new ScreenCaptureException(String.format(NO_SUCH_ELEMENT, by.toString()));
                //throw new RuntimeException(String.format(NO_SUCH_ELEMENT, by.toString()));
                // TODO
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        private ICollection<IWebElement> SearchWebElements(By by)
        {
            try
            {
                return GetWebElements(by);
            }
            catch (Exception e)
            {
                //throw new ScreenCaptureException(String.format(NO_SUCH_ELEMENT, by.toString()));
                //throw new RuntimeException(String.format(NO_SUCH_ELEMENT, by.toString()));
                // TODO
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        private ICollection<IWebElement> SearchWebElements(By by, IWebElement fromIWebElement)
        {
            try
            {
                return GetWebElements(by, fromIWebElement);
            }
            catch (Exception e)
            {
                //throw new ScreenCaptureException(String.format(NO_SUCH_ELEMENT, by.toString()));
                //throw new RuntimeException(String.format(NO_SUCH_ELEMENT, by.toString()));
                // TODO
                throw new Exception(NO_SUCH_ELEMENT);
            }
        }

        // Implemented Interface ISearch

        // Search Element

        public IWebElement Id(string id)
        {
            return SearchWebElement(By.Id(id));
        }

        public IWebElement Name(string name)
        {
            return SearchWebElement(By.Name(name));
        }

        public IWebElement XPath(string xpath)
        {
            return SearchWebElement(By.XPath(xpath));
        }

        public IWebElement CssSelector(string cssSelector)
        {
            return SearchWebElement(By.CssSelector(cssSelector));
        }

        public IWebElement ClassName(String className)
        {
            return SearchWebElement(By.ClassName(className));
        }

        public IWebElement PartialLinkText(string partialLinkText)
        {
            return SearchWebElement(By.PartialLinkText(partialLinkText));
        }

        public IWebElement LinkText(string linkText)
        {
            return SearchWebElement(By.LinkText(linkText));
        }

        public IWebElement TagName(string tagName)
        {
            return SearchWebElement(By.TagName(tagName));
        }

        // Search From Element

        public IWebElement Id(string id, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.Id(id), fromIWebElement);
        }

        public IWebElement Name(string name, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.Name(name), fromIWebElement);
        }

        public IWebElement XPath(string xpath, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.XPath(xpath), fromIWebElement);
        }

        public IWebElement CssSelector(string cssSelector, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.CssSelector(cssSelector), fromIWebElement);
        }

        public IWebElement ClassName(string className, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.ClassName(className), fromIWebElement);
        }

        public IWebElement PartialLinkText(string partialLinkText, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.PartialLinkText(partialLinkText), fromIWebElement);
        }

        public IWebElement LinkText(string linkText, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.LinkText(linkText), fromIWebElement);
        }

        public IWebElement TagName(string tagName, IWebElement fromIWebElement)
        {
            return SearchWebElement(By.TagName(tagName), fromIWebElement);
        }

        // Get List

        public ICollection<IWebElement> Names(string name)
        {
            return SearchWebElements(By.Name(name));
        }

        public ICollection<IWebElement> XPaths(string xpath)
        {
            return SearchWebElements(By.XPath(xpath));
        }

        public ICollection<IWebElement> XPaths(string xpath, IWebElement fromIWebElement)
        {
            return SearchWebElements(By.XPath(xpath), fromIWebElement);
        }

        public ICollection<IWebElement> CssSelectors(string cssSelector)
        {
            return SearchWebElements(By.CssSelector(cssSelector));
        }

        public ICollection<IWebElement> ClassNames(string className)
        {
            return SearchWebElements(By.ClassName(className));
        }

        public ICollection<IWebElement> PartialLinkTexts(string partialLinkText)
        {
            return SearchWebElements(By.PartialLinkText(partialLinkText));
        }

        public ICollection<IWebElement> LinkTexts(string linkText)
        {
            return SearchWebElements(By.LinkText(linkText));
        }

        public ICollection<IWebElement> TagNames(string tagName)
        {
            return SearchWebElements(By.TagName(tagName));
        }

    }

}
