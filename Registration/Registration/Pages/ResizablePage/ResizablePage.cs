using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.ResizablePage
{
    public partial class ResizablePage: BasePage
    {
        private int width;
        private int height;

        public ResizablePage(IWebDriver driver) : base(driver)
        {
        }

        public int Width {
            get
            {
                return this.width;
            }
        }

        public int Height {
            get
            {
                return this.height;
            }
        }

        public string URL
        {
            get
            {
                return base.url + "resizable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        //Default Functionality

        public void IncreaseWidthAndHeightBy(int increaseSize)
        {
            this.NavigateTo();
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, increaseSize, increaseSize);
            resize.Perform();
        }

        public void IncreaseWidthAndHeightBy(int increaseSizeWidth, int increaseSizeHeight)
        {
            this.NavigateTo();
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, increaseSizeWidth, increaseSizeHeight);
            resize.Perform();
        }

        public void IncreaseWidthBy(int increaseSize)
        {
            this.NavigateTo();
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, increaseSize, 0);
            resize.Perform();
        }

        /*Refresh page
         * 
         * this.driver.Navigate().refresh();
         * driver.Navigate().Refresh();
         * Actions actions = new Actions(driver);
         * actions.keyDown(Keys.CONTROL).sendKeys(Keys.F5).perform();
         * */

        public void IncreaseHeightBy(int increaseSize)
        {
            this.NavigateTo();
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, 0, increaseSize);
            resize.Perform();
        }

        //Animate Functionality

        public void AnimateIncreaseWidthAndHeightBy(int increaseSize)
        {
            this.NavigateTo();
            AnimateResize.Click();
            this.width = this.AnimateResizeWindow.Size.Width;
            this.height = this.AnimateResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.AnimateResizeButton, increaseSize, increaseSize);
            resize.Perform();
        }

        public void AnimateIncreaseWidthAndHeightBy(int increaseSizeWidth, int increaseSizeHeight)
        {
            this.NavigateTo();
            AnimateResize.Click();
            this.width = this.AnimateResizeWindow.Size.Width;
            this.height = this.AnimateResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.AnimateResizeButton, increaseSizeWidth, increaseSizeHeight);
            resize.Perform();
        }

        public void AnimateIncreaseWidthBy(int increaseSize)
        {
            this.NavigateTo();
            AnimateResize.Click();
            this.width = this.AnimateResizeWindow.Size.Width;
            this.height = this.AnimateResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.AnimateResizeButton, increaseSize, 0);
            resize.Perform();
        }

        public void AnimateIncreaseHeightBy(int increaseSize)
        {
            this.NavigateTo();
            AnimateResize.Click();
            this.width = this.AnimateResizeWindow.Size.Width;
            this.height = this.AnimateResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.AnimateResizeButton, 0, increaseSize);
            resize.Perform();
        }

        //Constraints Functionality

        public void ConstraintsIncreaseWidthAndHeightBy(int increaseSize)
        {
            this.NavigateTo();
            ConstraintsResize.Click();
            this.width = this.ConstraintsResizeWindow.Size.Width;
            this.height = this.ConstraintsResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.ConstraintsResizeButton, increaseSize, increaseSize);
            resize.Perform();
        }

        public void ConstraintsIncreaseWidthAndHeightBy(int increaseSizeWidth, int increaseSizeHeight)
        {
            this.NavigateTo();
            ConstraintsResize.Click();
            this.width = this.ConstraintsResizeWindow.Size.Width;
            this.height = this.ConstraintsResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.ConstraintsResizeButton, increaseSizeWidth, increaseSizeHeight);
            resize.Perform();
        }

        public void ConstraintsIncreaseWidthBy(int increaseSize)
        {
            this.NavigateTo();
            ConstraintsResize.Click();
            this.width = this.ConstraintsResizeWindow.Size.Width;
            this.height = this.ConstraintsResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.ConstraintsResizeButton, increaseSize, 0);
            resize.Perform();
        }

        public void ConstraintsIncreaseHeightBy(int increaseSize)
        {
            this.NavigateTo();
            AnimateResize.Click();
            this.width = this.ConstraintsResizeWindow.Size.Width;
            this.height = this.ConstraintsResizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.ConstraintsResizeButton, 0, increaseSize);
            resize.Perform();
        }
    }
}
