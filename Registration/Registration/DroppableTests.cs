using log4net.Config;
using Microsoft.Office.Interop.Excel;
using Microsoft.Vbe.Interop;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Registration.Pages.DroppablePage;
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
    class DroppableTests
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
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
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

        [Test]
        [Property("DemoQA", 3)]
        [Property("DroppableTests", 3)]
        [Author("Петя Николова")]

        public void DroppableTarget()
        {
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDrop();
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");


            droppablePage.DragAndDrop(71, -49);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(71, 0);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(80, 50);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(219, -49);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(180, 20);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(219, 0);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(219, 99);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.DragAndDrop(71, 99);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DroppableTests", 3)]
        [Author("Петя Николова")]

        public void DroppableOutsideTarget()
        {
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDrop(280, 40);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(150, 170);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(50, 60);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(-40, -30);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(71, -50);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(70, 0);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(1000, 1000);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(219, -50);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(220, 0);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(219, 100);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.DragAndDrop(71, 100);
            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DroppableTests", 3)]
        [Author("Петя Николова")]

        public void DroppableAcceptTarget()
        {
            var droppablePage = new DroppablePage(this.driver);
            
            droppablePage.AcceptValidDragAndDrop();
            droppablePage.AssertAcceptTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DroppableTests", 3)]
        [Author("Петя Николова")]

        public void DroppableNotAcceptTarget()
        {
            var droppablePage = new DroppablePage(this.driver);
            
            droppablePage.AcceptNotValidDragAndDrop();
            droppablePage.AssertNotAcceptTargetAttributeValue("ui-widget-header ui-droppable");

            droppablePage.AcceptNotValidDragAndDrop(280, 40);
            droppablePage.AssertNotAcceptTargetAttributeValue("ui-widget-header ui-droppable");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DroppableTests", 3)]
        [Author("Петя Николова")]

        public void DroppablePropagationTarget()
        {
            var droppablePage = new DroppablePage(this.driver);
            droppablePage.NavigateTo();
            droppablePage.PropagationDrop.Click();
            droppablePage.InnerPropagationDragAndDrop();
            droppablePage.AssertPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.PropagationDragAndDrop();
            droppablePage.AssertPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable");
                        
            droppablePage.BothPropagationDragAndDrop1();            
            droppablePage.AssertPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.BothPropagationDragAndDrop2();            
            droppablePage.AssertPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DroppableTests", 3)]
        [Author("Петя Николова")]

        public void DroppableLimitPropagationTarget()
        {
            var droppablePage = new DroppablePage(this.driver);
           
            droppablePage.InnerLimitPropagationDragAndDrop();
            droppablePage.AssertLimitPropagationTargetAttributeValue("ui-widget-header ui-droppable", "ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.PropagationDragAndDrop(380, 20);
            droppablePage.AssertLimitPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable");

            droppablePage.BothLimitPropagationDragAndDrop1();            
            droppablePage.AssertLimitPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.BothLimitPropagationDragAndDrop2();            
            droppablePage.AssertLimitPropagationTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight", "ui-widget-header ui-droppable ui-state-highlight");

            droppablePage.PropagationDragAndDrop(230, 120);
            droppablePage.AssertLimitPropagationTargetAttributeValue("ui-widget-header ui-droppable", "ui-widget-header ui-droppable");
        }
    }
}
