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
    public abstract class ALeftComponent : ANavigatePanelComponent
    {
        public ICollection<IWebElement> LeftCategories { get; private set; }

        public ALeftComponent(IWebDriver driver) : base(driver) { }

    }

}
