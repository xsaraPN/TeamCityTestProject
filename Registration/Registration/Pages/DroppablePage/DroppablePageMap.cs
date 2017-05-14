using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.DroppablePage
{
    public partial class DroppablePage
    {
        public IWebElement SourcePosition
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]"));
            }
        }

        public IWebElement Source
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]/p"));
            }
        }

        public IWebElement Target
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableview"));
            }
        }
        
        public IWebElement AcceptDrop
        {
            get
            {
                return this.Driver.FindElement(By.CssSelector("#ui-id-2"));
            }
        }

        public IWebElement DragNotValidSource
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable-nonvalid"));
            }
        }

        public IWebElement DragValidSource
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"draggableaccept\"]/p"));
            }
        }

        public IWebElement DropAcceptTarget
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableaccept"));
            }
        }

        public IWebElement PropagationSource
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggableprop"));
            }
        }

        public IWebElement PropagationDrop
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"ui-id-3\"]"));
            }
        }

        public IWebElement PropagationTargetInner
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppable-inner"));
            }
        }

        public IWebElement PropagationTarget
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableprop"));
            }
        }

        public IWebElement LimitPropagationTargetInner
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppable2-inner"));
            }
        }

        public IWebElement LimitPropagationTarget
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableprop2"));
            }
        }
    }
}
