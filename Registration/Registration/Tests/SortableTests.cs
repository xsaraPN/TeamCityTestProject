using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Registration.Pages.SortablePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    [TestFixture]
    class SortableTests
    {
        public IWebDriver driver;
        public readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
            XmlConfigurator.Configure(new FileInfo(ConfigurationManager.AppSettings["log4net.Config"]));
            this.log.Info("INFO LOGGING");
        }

        [TearDown]

        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }
            this.driver.Quit();
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("SortableTests", 3)]
        [Author("Петя Николова")]
        
        public void SortableItems()
        {
            SortablePage sortablePage = new SortablePage(this.driver);

            //item=30 pixels, placed to next 2 position = 2*30
            sortablePage.DragAndDropOffset(1,100);
            sortablePage.AssertSortableChecks("Item 1", 4);
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("SortableTests", 3)]
        [Author("Петя Николова")]

        public void SortableConnectedListItems()
        {
            SortablePage sortablePage = new SortablePage(this.driver);
            
            //item=30 pixels, placed to next 2 position = 2*30
            sortablePage.ConnectListDifferGreyBlankDragAndDropOffset(1, 100);
            sortablePage.AssertSortableBlankConnectListsChecks("Item 1", 4);

            sortablePage.ConnectListDifferBlankGreyDragAndDropOffset(3, 30);
            sortablePage.AssertSortableGreyConnectListsChecks("Item 3", 5);

            sortablePage.ConnectListSameBlankDragAndDropOffset(2, 50);
            sortablePage.AssertSortableBlankConnectListsChecks("Item 2", 3);
            
            sortablePage.ConnectListSameGreyDragAndDropOffset(4, -90);
            sortablePage.AssertSortableGreyConnectListsChecks("Item 4", 2);
        }


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("SortableTests", 3)]
        [Author("Петя Николова")]

        public void SortableDisplayAsGridItems()
        {
            SortablePage sortablePage = new SortablePage(this.driver);

            sortablePage.NavigateTo();
            sortablePage.DisplayAsGrid.Click();
            //item=100/90 pixels, placed to next 2 position = 2*100/90*2
            sortablePage.DiplayAsGridDragAndDropOffset(1, 210, 110);
            sortablePage.AssertSortableDisplayAsGridChecks("1", 7);

            sortablePage.DiplayAsGridDragAndDropOffset(7, -120, 110);
            sortablePage.AssertSortableDisplayAsGridChecks("1", 10);
            
            sortablePage.DiplayAsGridDragAndDropOffset(10, -120, -110);
            sortablePage.AssertSortableDisplayAsGridChecks("1", 5);
            
            sortablePage.DiplayAsGridDragAndDropOffset(5, 110, -70);
            sortablePage.AssertSortableDisplayAsGridChecks("1", 3);            
        }
    }
}
