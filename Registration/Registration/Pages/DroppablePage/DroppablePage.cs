using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.DroppablePage
{
    public partial class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "droppable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop()
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.Source, this.Target);
            drag.Perform();
        }

        public void DragAndDrop(int increaseWidth, int increasеHeight)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);            
            var drag = builder.DragAndDropToOffset(this.Source, increaseWidth, increasеHeight);           
            drag.Perform();
        }

        public void AcceptValidDragAndDrop()
        {
            this.NavigateTo();            
            this.AcceptDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.DragValidSource, this.DropAcceptTarget);
            drag.Perform();
        }

        public void AcceptNotValidDragAndDrop()
        {
            this.NavigateTo();
            this.AcceptDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.DragNotValidSource, this.DropAcceptTarget);
            drag.Perform();
        }

        public void AcceptNotValidDragAndDrop(int increaseWidth, int increasеHeight)
        {
            this.NavigateTo();            
            this.AcceptDrop.Click();
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDropToOffset(this.DragNotValidSource, increaseWidth, increasеHeight);
            drag.Perform();
        }

        public void InnerPropagationDragAndDrop()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.PropagationSource, this.PropagationTargetInner);
            drag.Perform();
        }

        public void PropagationDragAndDrop()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);            
            var drag = builder.DragAndDropToOffset(this.PropagationSource, 180, 10);
            drag.Perform();
        }

        public void BothPropagationDragAndDrop1()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag1 = builder.DragAndDrop(this.PropagationSource, this.PropagationTargetInner);
            drag1.Perform();
            var drag2 = builder.DragAndDropToOffset(this.PropagationSource, 180, 10);
            drag2.Perform();
        }

        public void BothPropagationDragAndDrop2()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag1 = builder.DragAndDropToOffset(this.PropagationSource, 180, 10);
            drag1.Perform();
            var drag2 = builder.DragAndDrop(this.PropagationSource, this.PropagationTargetInner);
            drag2.Perform();
        }

        public void PropagationDragAndDrop( int increaseWidth, int increasеHeight)
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDropToOffset(this.PropagationSource, increaseWidth, increasеHeight);
            drag.Perform();
        }
        
        public void InnerLimitPropagationDragAndDrop()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.PropagationSource, this.LimitPropagationTargetInner);
            drag.Perform();
        }

        public void BothLimitPropagationDragAndDrop1()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag1 = builder.DragAndDropToOffset(this.PropagationSource, 380, 20);
            drag1.Perform();
            var drag2 = builder.DragAndDrop(this.PropagationSource, this.LimitPropagationTargetInner);
            drag2.Perform();
        }

        public void BothLimitPropagationDragAndDrop2()
        {
            this.NavigateTo();
            this.PropagationDrop.Click();
            Actions builder = new Actions(this.Driver);
            var drag1 = builder.DragAndDrop(this.PropagationSource, this.LimitPropagationTargetInner);
            drag1.Perform();            
            var drag2 = builder.DragAndDropToOffset(this.PropagationSource, 0, -50);
            //var drag2 = builder.ClickAndHold(this.PropagationSource).MoveByOffset(0, -50).Click().Release().Build();                
            drag2.Perform();
        }

    }
}
