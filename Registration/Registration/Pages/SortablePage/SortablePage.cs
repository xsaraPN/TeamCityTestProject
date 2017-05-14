using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SortablePage
{
    public partial class SortablePage: BasePage
    {
        public SortablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "sortable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDropOffset(int indexFrom, int indexTo)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement element1 = this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[" + indexFrom + "]"));
            
            var drag = builder.DragAndDropToOffset(element1, 10, indexTo).Release();
            drag.Perform();
        }

        public void ConnectListDifferGreyBlankDragAndDropOffset(int indexFrom, int indexTo)
        {
            this.NavigateTo();
            this.ConnectedLists.Click();
            Actions builder = new Actions(this.Driver);
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement element1 = this.Driver.FindElement(By.XPath("//*[@id=\"sortable1\"]/li[" + indexFrom + "]"));            

            var drag = builder.DragAndDropToOffset(element1, 122, indexTo).Release();
            drag.Perform();
        }


        public void ConnectListDifferBlankGreyDragAndDropOffset(int indexFrom, int indexTo)
        {
            this.NavigateTo();
            this.ConnectedLists.Click();
            Actions builder = new Actions(this.Driver);
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement element1 = this.Driver.FindElement(By.XPath("//*[@id=\"sortable2\"]/li[" + indexFrom + "]"));
            
            var drag = builder.DragAndDropToOffset(element1, -100, indexTo).Release();
            drag.Perform();
        }

        public void ConnectListSameGreyDragAndDropOffset(int indexFrom, int indexTo)
        {
            this.NavigateTo();
            this.ConnectedLists.Click();
            Actions builder = new Actions(this.Driver);
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement element1 = this.Driver.FindElement(By.XPath("//*[@id=\"sortable1\"]/li[" + indexFrom + "]"));
            
            var drag = builder.DragAndDropToOffset(element1, 10, indexTo).Release();
            drag.Perform();
        }
        
        public void ConnectListSameBlankDragAndDropOffset(int indexFrom, int indexTo)
        {
            this.NavigateTo();
            this.ConnectedLists.Click();
            Actions builder = new Actions(this.Driver);
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement element1 = this.Driver.FindElement(By.XPath("//*[@id=\"sortable2\"]/li[" + indexFrom + "]"));
            
            var drag = builder.DragAndDropToOffset(element1, 10, indexTo).Release();
            drag.Perform();
        }

        public void DiplayAsGridDragAndDropOffset(int index, int indexFrom, int indexTo)
        {            
            Actions builder = new Actions(this.Driver);
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement element1 = this.Driver.FindElement(By.XPath("//*[@id=\"sortable_grid\"]/li[" + index + "]"));

            var drag = builder.DragAndDropToOffset(element1, indexFrom, indexTo).Release();
            drag.Perform();
        }
    }
}
