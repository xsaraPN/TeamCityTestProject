using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.DraggablePage
{
    public partial class DraggablePage: BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "draggable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop(int increaseWidth, int increasеHeight)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDropToOffset(this.Source, increaseWidth, increasеHeight);
            drag.Perform();
        }

        public void DragElement(int increaseWidth, int increasеHeight)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            var drag = builder.ClickAndHold(this.Source).MoveByOffset(increaseWidth, increasеHeight);           
            drag.Perform();
        }

        public void SortDragAndDrop(int index)
        {
            this.NavigateTo();
            this.DragSort.Click();
            Actions builder = new Actions(this.Driver);
            var drag = builder.ClickAndHold(this.SourceDragBox).MoveByOffset(10,index).Release();            
            drag.Perform();
        }

        public void EventDragAndDrop(int increaseWidth, int increasеHeight)
        {
            this.NavigateTo();
            this.EventDrag.Click();
            Actions builder = new Actions(this.Driver);
            var drag = builder.ClickAndHold(this.EventDragBox).MoveByOffset(increaseWidth, increasеHeight).Release();
            drag.Perform();
        }


    }
}
