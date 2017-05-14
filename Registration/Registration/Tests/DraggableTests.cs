using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Registration.Pages.DraggablePage;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    [TestFixture]
    class DraggableTests
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
                string filename = AppDomain.CurrentDomain.BaseDirectory + (ConfigurationManager.GetSection("path") as NameValueCollection).Get("Logs") + TestContext.CurrentContext.Test.Name + ".txt";
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
        [Property("DraggableTests", 3)]
        [Author("Петя Николова")]

        public void DraggableSource()
        {
            var draggablePage = new DraggablePage(this.driver);

            draggablePage.DragAndDrop(380, 130);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragAndDrop(0, -75);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragAndDrop(50, 60);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragAndDrop(-40, -30);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragAndDrop(71, -50);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragAndDrop(1000, 1000);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragAndDrop(219, 100);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle");

            draggablePage.DragElement(70, 100);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
            draggablePage.DragElement(200, 250);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
            draggablePage.DragElement(150, 120);
            draggablePage.AssertTargetAttributeValue("ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DraggableTests", 3)]
        [Author("Петя Николова")]

        public void DraggableSort()
        {
            var draggablePage = new DraggablePage(this.driver);

            draggablePage.SortDragAndDrop(60);
            draggablePage.AssertSort("Drag me down", 3);
        }


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("DraggableTests", 3)]
        [Author("Петя Николова")]

        public void DraggableEvent()
        {
            var draggablePage = new DraggablePage(this.driver);

            draggablePage.EventDragAndDrop(50,60);
            draggablePage.AssertEvent("1","1","1");
        }
    }
}
