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
    public interface ISearch
    {
        // TODO Remove from interface ISearch

        IWebElement GetWebElement(By by);

        IWebElement GetWebElement(By by, IWebElement fromIWebElement);

        ICollection<IWebElement> GetWebElements(By by);

        ICollection<IWebElement> GetWebElements(By by, IWebElement fromIWebElement);

        bool StalenessOf(IWebElement IWebElement);

        // Search Element

        IWebElement Id(string id);

        IWebElement Name(string name);

        IWebElement XPath(string xpath);

        IWebElement CssSelector(string cssSelector);

        IWebElement ClassName(string className);

        IWebElement PartialLinkText(string partialLinkText);

        IWebElement LinkText(string linkText);

        IWebElement TagName(string tagName);

        // Search From Element

        IWebElement Id(string id, IWebElement fromIWebElement);

        IWebElement Name(string name, IWebElement fromIWebElement);

        IWebElement XPath(string xpath, IWebElement fromIWebElement);

        IWebElement CssSelector(string cssSelector, IWebElement fromIWebElement);

        IWebElement ClassName(string className, IWebElement fromIWebElement);

        IWebElement PartialLinkText(string partialLinkText, IWebElement fromIWebElement);

        IWebElement LinkText(string linkText, IWebElement fromIWebElement);

        IWebElement TagName(string tagName, IWebElement fromIWebElement);

        // Get List

        ICollection<IWebElement> Names(string name);

        ICollection<IWebElement> XPaths(string xpath);

        ICollection<IWebElement> XPaths(string xpath, IWebElement fromIWebElement);

        ICollection<IWebElement> CssSelectors(string cssSelector);

        ICollection<IWebElement> ClassNames(string className);

        ICollection<IWebElement> PartialLinkTexts(string partialLinkText);

        ICollection<IWebElement> LinkTexts(string linkText);

        ICollection<IWebElement> TagNames(string tagName);

    }

}
