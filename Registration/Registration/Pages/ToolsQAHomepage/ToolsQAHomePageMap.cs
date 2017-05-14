using OpenQA.Selenium;

namespace Registration.Pages.ToolsQAHomepage
{
    public partial class ToolsQAHomePage
    {
        public IWebElement Logo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"page\"]/div[1]/header/div/a/img"));
            }
        }
    }
}
