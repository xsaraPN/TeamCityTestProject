using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SortablePage
{
    public partial class SortablePage
    {
        public IWebElement Serialize
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]"));
            }
        }
        
        public IWebElement ConnectedLists
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            }
        }
        
        public IWebElement DisplayAsGrid
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]"));
            }
        }
    }
}
