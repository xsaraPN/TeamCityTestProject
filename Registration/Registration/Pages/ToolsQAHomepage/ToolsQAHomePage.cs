using OpenQA.Selenium;
using System.Collections.Specialized;
using System.Configuration;

namespace Registration.Pages.ToolsQAHomepage
{
    public partial class ToolsQAHomePage: BasePage
    {
        protected new string url = (ConfigurationManager.GetSection("server") as NameValueCollection).Get("TOOLS");

        public ToolsQAHomePage(IWebDriver driver) : base(driver)
        {
        }        
    }
}
