using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Registration.Pages
{
    // Include constructors, properties

    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        protected string url = (ConfigurationManager.GetSection("server") as NameValueCollection).Get("DEV");
        public readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BasePage(IWebDriver driver)
        {                        
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));            
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
        }
    }
}
