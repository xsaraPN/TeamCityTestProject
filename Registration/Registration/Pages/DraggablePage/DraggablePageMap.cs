using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.DraggablePage
{
    public partial class DraggablePage
    {
        public IWebElement Source
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable"));
            }
        }
        
        public IWebElement DragSort
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-5\"]"));
            }
        }

        public IWebElement SourceDragBox
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggablebox"));
            }
        }

        public IWebElement SortDragBox
        {
            get
            {
                return this.Driver.FindElement(By.Id("sortablebox"));
            }
        }

        public IWebElement EventDrag
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-4\"]"));
            }
        }

        public IWebElement EventDragBox
        {
            get
            {
                return this.Driver.FindElement(By.Id("dragevent"));
            }
        }

        public IWebElement StartEventDrag
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("#event-start > span.count"));
            }
        }

        public IWebElement DragEventDrag
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("#event-drag > span.count"));
            }
        }

        public IWebElement StopEventDrag
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("#event-stop > span.count"));
            }
        }
    }
}
