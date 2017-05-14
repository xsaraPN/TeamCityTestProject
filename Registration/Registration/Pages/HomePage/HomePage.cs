using OpenQA.Selenium;

namespace Registration.Pages.HomePage
{
    // Include methods, constructors, properties

    public partial class HomePage: BasePage
    {               
        public HomePage(IWebDriver driver)
            :base(driver)
        {
        }

        public void NavigateTo()
        {           
            this.Driver.Navigate().GoToUrl(this.Url);
        }
    }
}
