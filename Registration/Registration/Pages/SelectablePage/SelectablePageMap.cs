using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SelectablePage
{
    public partial class SelectablePage
    {
        public IWebElement DisplayGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            }
        }

        public IWebElement Serialize
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]"));
            }
        }
    }
}
