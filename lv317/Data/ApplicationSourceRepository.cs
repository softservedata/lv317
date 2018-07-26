using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Data
{
    public sealed class ApplicationSourceRepository
    {
        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return ChromeEpizy();
        }

        public static ApplicationSource FirefoxEpizy()
        {
            return new ApplicationSource("FirefoxTemporaryWhithUI", 10L,
                "http://atqc-shop.epizy.com",
                "http://atqc-shop.epizy.com/index.php?route=account/logout",
                "http://atqc-shop.epizy.com/admin/");
        }

        public static ApplicationSource ChromeEpizy()
        {
            return new ApplicationSource("ChromeTemporaryWhithUI", 10L,
                "http://atqc-shop.epizy.com",
                "http://atqc-shop.epizy.com/index.php?route=account/logout",
                "http://atqc-shop.epizy.com/admin/");
        }

        public static ApplicationSource ChromeMaximizedEpizy()
        {
            return new ApplicationSource("ChromeTemporaryMaximizedWhithUI", 10L,
                "http://atqc-shop.epizy.com",
                "http://atqc-shop.epizy.com/index.php?route=account/logout",
                "http://atqc-shop.epizy.com/admin/");
        }

        public static ApplicationSource ChromeWithoutUIEpizy()
        {
            return new ApplicationSource("ChromeTemporaryWithoutUI", 10L,
                "http://atqc-shop.epizy.com",
                "http://atqc-shop.epizy.com/index.php?route=account/logout",
                "http://atqc-shop.epizy.com/admin/");
        }

    }

}
