using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Registration.Pages.HomePage
{
    //Include locators

    public partial class HomePage
    {
        [FindsBy(How = How.ClassName, Using = "entry-title")]
        public IWebElement Title { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id=\"menu-item-374\"]/a")]
        public IWebElement RegistrationButton { get; set; }
        

    }
}
