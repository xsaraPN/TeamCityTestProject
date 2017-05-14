using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Registration.Pages.SelectablePage;
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
    class SelectableTests
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
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("SelectableTests", 3)]
        [Author("Петя Николова")]
        
        public void SelectItems()
        {
            SelectablePage selectablePage = new SelectablePage(this.driver); 
            
            selectablePage.DragAndDrop("2","5");
            selectablePage.AssertTargetAttributeValue("ui-widget-content ui-corner-left ui-selectee ui-selected", 2,5);
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("SelectableTests", 3)]
        [Author("Петя Николова")]

        public void SelectDisplayGrid()
        {
            SelectablePage selectablePage = new SelectablePage(this.driver);

            selectablePage.ChooseItemDisplayGrid(11);
            selectablePage.AssertSelectDisplayGrid("ui-state-default ui-corner-left ui-selectee ui-selected", "11");

            selectablePage.ChooseGroupDisplayGrid(1,11);
            selectablePage.AssertSelectDisplayGrid("ui-state-default ui-corner-left ui-selectee ui-selected", "1,2,3,5,6,7,9,10,11");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("SelectableTests", 3)]
        [Author("Петя Николова")]

        public void SelectSerialized()
        {
            SelectablePage selectablePage = new SelectablePage(this.driver);

            selectablePage.ChooseSerializedDisplayGrid("1,2,4,6");
            selectablePage.AssertSelectSerialized("ui-widget-content ui-corner-left ui-selectee ui-selected", "1,2,4,6");            
        }
    }
}
