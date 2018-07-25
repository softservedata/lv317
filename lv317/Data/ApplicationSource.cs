using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Data
{
    public class ApplicationSource
    {
        // Browser Data
        public string BrowserName { get; private set; }
        //public string DriverPath { get; private set; }
        // public string BrowserPath { get; private set; }
        // public string DefaulProfile { get; private set; }
        //
        // Implicit and Explicit Waits
        public long ImplicitWaitTimeOut { get; private set; }
        //public long ImplicitLoadTimeOut { get; private set; }
        //public long ImplicitScriptTimeOut { get; private set; }
        //public long ExplicitTimeOut { get; private set; }
        //
        // Localization Strategy
        // public string Language { get; private set; }
        //
        // Search Strategy
        //public string SearchStrategy { get; private set; }
        //
        // Logger Strategy
        // public string LoggerStrategy { get; private set; }
        //
        // Reporter Console Output
        //public boolean ConsoleOutput { get; private set; }
        //
        // URLs
        public string BaseUrl { get; private set; }
        //public string UserLoginUrl { get; private set; }
        public string UserLogoutUrl { get; private set; }
        //
        public string AdminLoginUrl { get; private set; }
        //public string AdminLogoutUrl { get; private set; }
        //
        // Database Connection
        //public string DatabaseUrl { get; private set; }
        //public string DatabaseLogin { get; private set; }
        //public string DatabasePassword { get; private set; }

        // TODO Develop Builder
        public ApplicationSource(string browserName,
                long implicitWaitTimeOut,
                string baseUrl,
                string userLogoutUrl,
                string adminLoginUrl)
        {
            this.BrowserName = browserName;
            //this.DriverPath = driverPath;
            this.ImplicitWaitTimeOut = implicitWaitTimeOut;
            this.BaseUrl = baseUrl;
            //this.UserLoginUrl = userLoginUrl;
            this.UserLogoutUrl = userLogoutUrl;
            this.AdminLoginUrl = adminLoginUrl;
            //this.AdminLogoutUrl = adminLogoutUrl;
        }

    }

}
