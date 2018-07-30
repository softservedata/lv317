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
    public abstract class ANavigatePanelComponent : AHeadComponent
    {
        // TODO Init PathElements
        public ICollection<IWebElement> PathElements { get; private set; }

        //public ANavigatePanelComponent(IWebDriver driver) : base(driver) { }
        public ANavigatePanelComponent() : base() { }
    }

    // TODO
}
