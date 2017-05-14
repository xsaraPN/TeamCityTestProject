using OpenQA.Selenium;
using System.Collections.Specialized;
using System.Configuration;

namespace Registration.Pages.AutomationPracticePage
{
    public partial class AutomationPage: BasePage
    {
        public AutomationPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                var server = ConfigurationManager.GetSection("server") as NameValueCollection;
                return server.Get("TOOLS");
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }
    }
}
