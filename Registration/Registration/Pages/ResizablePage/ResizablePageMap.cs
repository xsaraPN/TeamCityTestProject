using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.ResizablePage
{
    public partial class ResizablePage
    {
        //button size 16x16 pixels

        public IWebElement resizeButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizable\"]/div[3]"));
            }
        }

        public IWebElement resizeWindowPosition
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizable\"]"));
            }
        }

        //window size 150x150 pixels

        public IWebElement resizeWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizable"));
            }
        }

        public IWebElement AnimateResize
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-2\"]"));
            }
        }
        // 200x200 pixels
        public IWebElement AnimateResizeWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizableani"));
            }
        }
        // 16x16 pixels
        public IWebElement AnimateResizeButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizableani\"]/div[3]"));
            }
        }
        
        public IWebElement ConstraintsResize
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]"));
            }
        }
        // 183x45 pixels
        public IWebElement ConstraintsResizeWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizableconstrain"));
            }
        }
        // 16x16 pixels
        public IWebElement ConstraintsResizeButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"resizableconstrain\"]/div[3]"));
            }
        }
    }
}
