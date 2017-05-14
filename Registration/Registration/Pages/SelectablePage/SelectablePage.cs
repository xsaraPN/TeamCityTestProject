using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Registration.Pages.SelectablePage
{
    public partial class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "selectable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop(string indexFrom, string indexTo)
        {
            this.NavigateTo();
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li["+indexFrom+"]")), this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[" + indexTo + "]")));
            drag.Perform();
        }
        
        public void ChooseItemDisplayGrid(int index)
        {
            this.NavigateTo();
            this.DisplayGrid.Click();
            Actions builder = new Actions(this.Driver);            
            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#selectable_grid > li:nth-child(" + index + ")")));               
            ele.Click();                       
        }

        public void ChooseGroupDisplayGrid(int indexFrom, int indexTo)
        {
            this.NavigateTo();
            this.DisplayGrid.Click();
            Actions builder = new Actions(this.Driver);
            this.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
                        
            IWebElement ele1 = this.Driver.FindElement(By.CssSelector("#selectable_grid > li:nth-child(" + indexFrom + ")"));
            IWebElement ele2 = this.Driver.FindElement(By.CssSelector("#selectable_grid > li:nth-child(" + indexTo + ")"));
            builder.ClickAndHold(ele1).MoveToElement(ele2).Click().Release().Perform();
            
        }

        public void ChooseSerializedDisplayGrid(string indexes)
        {
            this.NavigateTo();
            this.Serialize.Click();
            Actions builder = new Actions(this.Driver);
            this.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);

            string[] index = Regex.Split(indexes, ",");
            int[] indexInt = new int[index.Length];
            for (int i = 0; i < indexInt.Length; i++)
                indexInt[i] = int.Parse(index[i]);
            List<IWebElement> elements = new List<IWebElement>();
            for (int i = 0; i < indexInt.Length; i++)
                elements.Add(this.Driver.FindElement(By.CssSelector("#selectable-serialize > li:nth-child(" + indexInt[i] + ")")));
            builder.KeyDown(Keys.Control);
            for (int i = 0; i < elements.Count; i++)
                builder.Click(elements[i]);  

            builder.KeyUp(Keys.Control).Release().Perform();
        }
    }
}
