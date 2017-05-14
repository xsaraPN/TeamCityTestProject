using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Registration.Pages.ResizablePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration
{
    [TestFixture]
    class ResizableTests
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

        [Test]
        [Property("DemoQA", 3)]
        [Property("ResizableTests", 3)]
        [Author("Петя Николова")]

        public void ResizeWidthAndHeight()
        {
            var resizablePage = new ResizablePage(this.driver);

            resizablePage.IncreaseWidthAndHeightBy(250, 200);
            resizablePage.AssertNewSize(250, 200);

            resizablePage.IncreaseWidthAndHeightBy(100);
            resizablePage.AssertNewSize(100, 100);
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("ResizableTests", 3)]
        [Author("Петя Николова")]

        public void ResizeWidth()
        {
            var resizablePage = new ResizablePage(this.driver);

            resizablePage.IncreaseWidthBy(100);

            resizablePage.AssertNewSize(100, 0);
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("ResizableTests", 3)]
        [Author("Петя Николова")]

        public void ResizeHeight()
        {
            var resizablePage = new ResizablePage(this.driver);

            resizablePage.IncreaseHeightBy(100);

            resizablePage.AssertNewSize(0, 100);
        }

        [Test]
        [Property("DemoQA", 3)]
        [Property("ResizableTests", 3)]
        [Author("Петя Николова")]

        public void AnimateResizeWidthAndHeight()
        {
            var resizablePage = new ResizablePage(this.driver);

            resizablePage.AnimateIncreaseWidthAndHeightBy(250, 200);            
            resizablePage.AssertAnimation();
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(resizablePage.AnimateResizeWindow);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String styleAttrib = resizablePage.AnimateResizeWindow.GetAttribute("style");
                if (!styleAttrib.Contains("overflow"))
                {
                    return true;
                }
                return false;
            });
            wait.Until(waiter);

            resizablePage.AssertAnimateNewSize(250, 200);

            /*Stop script for some time           

            Thread.Sleep(6000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(500);
            driver.Manage().Timeouts().PageLoad =TimeSpan.FromSeconds(500);
            
            Case 1 (wait):

            WebElement element = wait.until(ExpectedConditions.presenceOfElementLocated(By.id(“myId")));

            WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.tagName("input")));

            wait.Until(driver => driver.FindElement(By.Id("someLabelId")).Text == "expectedValue")

            Case 2 (wait):

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                Console.WriteLine(Web.FindElement(By.Id("target")).GetAttribute("innerHTML"));
                return true;
            });
             wait.Until(waitForElement);
            
            Case 3 (wait):

             IWebElement element = driver.FindElement(By.Id("colorVar"));
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
 
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
                {
                    String styleAttrib = element.GetAttribute("style");
                    if (styleAttrib.Contains("red"))
                    {
                        return true;
                    }
                    Console.WriteLine("Color is still " + styleAttrib);
                     return false;
                });
            wait.Until(waiter);            
            */

            resizablePage.AnimateIncreaseWidthAndHeightBy(100);
            resizablePage.AssertAnimation();            
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);            
            wait.Until(waiter);
            resizablePage.AssertAnimateNewSize(100, 100);

            resizablePage.AnimateIncreaseWidthBy(100);
            resizablePage.AssertAnimation();            
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(waiter);
            resizablePage.AssertAnimateNewSize(100, 0);

            resizablePage.AnimateIncreaseHeightBy(100);
            resizablePage.AssertAnimation();            
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.Until(waiter);
            resizablePage.AssertAnimateNewSize(0, 100);
        }

        [Test]
        [Property("DemoQA", 3)]
        [Property("ResizableTests", 3)]
        [Author("Петя Николова")]

        public void ConstraintsResizeWidthAndHeight()
        {
            var resizablePage = new ResizablePage(this.driver);
            //window 181x28
            resizablePage.ConstraintsIncreaseWidthAndHeightBy(250, 200);          
            //Limit movement to 181x138 pixels
            resizablePage.AssertConstraintsNewSize(250, 200);

            resizablePage.ConstraintsIncreaseWidthAndHeightBy(-50, -20);
            resizablePage.AssertConstraintsNewSize(-50, -20);

            resizablePage.ConstraintsIncreaseWidthAndHeightBy(0, 50);
            resizablePage.AssertConstraintsNewSize(0, 50);

            resizablePage.ConstraintsIncreaseWidthAndHeightBy(-80, 80);
            resizablePage.AssertConstraintsNewSize(-80, 80);
        }
    }
}
