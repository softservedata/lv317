using lv317.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Pages.Users
{
    public class WishListComponent
    {
        protected ISearch Search { get; private set; }

        public WishListComponent()
        {
            Search = Application.Get().Search;
        }
    }
}
