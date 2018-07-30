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
    public class ProductsListComponent : AHeadProduct
    {
        // TODO List/Grid, SortBy, Show, Pagination

        public ProductsListComponent() : base()
        {
        }

        public ProductsListComponent(By searchLocator) : base(searchLocator)
        {
        }

    }
}
