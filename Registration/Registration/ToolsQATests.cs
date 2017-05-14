using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Registration.Models;
using Registration.Pages.AutomationPracticePage;
using Registration.Pages.DroppablePage;
using Registration.Pages.ResizablePage;
using Registration.Pages.SoftUniLoginPage;
using Registration.Pages.ToolsQAHomepage;
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
    public class ToolsQATests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [Test]
        [Property("ToolsQA", 3)]
        [Author("Петя Николова")]

        public void HandlePopUp()
        {          
            var automationPage = new AutomationPage(this.driver);
            var homePage = new ToolsQAHomePage(this.driver);

            automationPage.NavigateTo();
            automationPage.NewTabButton.Click();
            this.driver.SwitchTo().ActiveElement();
            var secondTab = this.driver.WindowHandles.Last();

            Assert.AreEqual("http://toolsqa.com/wp-content/uploads/2014/08/Toolsqa.jpg",
                homePage.Logo.GetAttribute("currentSrc"));
            Assert.AreEqual(2, this.driver.WindowHandles.Count);
        }

        [Test]
        [Property("DemoQA", 3)]
        [Author("Петя Николова")]

        public void DroppableFirstTry()
        {
            this.driver = new ChromeDriver();
            var droppablePage = new DroppablePage(this.driver);

            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");

        }

        [Test]
        [Property("DemoQA", 3)]
        [Author("Петя Николова")]

        public void ResizeFirstTry()
        {
            this.driver = new ChromeDriver();
            var resizblePage = new ResizablePage(this.driver);

            resizblePage.IncreaseWidthAndHeightBy(100);

            resizblePage.AssertAnimateNewSize(100, 100);
        }

        [Test]
        [Property("SoftUniQA", 3)]
        [Author("Петя Николова")]

        public void NavigateToSoftUni()
        {
            SoftUniLoginPage softUniPage = new SoftUniLoginPage(this.driver);
            softUniPage.Driver.Manage().Window.Maximize();
            softUniPage.Driver.Url = (ConfigurationManager.GetSection("server") as NameValueCollection).Get("SoftUni");            
            softUniPage.LoginSoftUni();
            softUniPage.AssertSoftUniUserLoggedIn();
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

                var fileNameScreenshot = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name;

                if (File.Exists(fileNameScreenshot))
                {
                    File.Delete(fileNameScreenshot);
                }

                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }

            this.driver.Quit();
        }

    }
}
