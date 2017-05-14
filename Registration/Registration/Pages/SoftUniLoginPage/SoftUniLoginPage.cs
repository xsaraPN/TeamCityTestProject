using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SoftUniLoginPage
{
    public partial class SoftUniLoginPage : BasePage
        {
            protected string SoftUniUrl = (ConfigurationManager.GetSection("server") as NameValueCollection).Get("SoftUni");

            public SoftUniLoginPage(IWebDriver driver) : base(driver)
            {
            }

            public string URL
            {
                get
                {
                    return SoftUniUrl;
                }
            }

            public void NavigateTo()
            {
                this.Driver.Navigate().GoToUrl(this.URL);
            }

            public void LoginSoftUni()
            {
                WebDriverWait wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(60));
                IWebElement loginButton = wait.Until<IWebElement>((w) => { return w.FindElement(By.LinkText("Вход")); });
                loginButton.Click();
                SoftUniUser softUniUser = AccessExcelData.GetTestDataSoftUniUser("Login");                
                this.userName.Clear();
                this.userName.SendKeys(softUniUser.Username);                
                this.passWord.Clear();
                this.passWord.SendKeys(softUniUser.Password);
                this.Login.Click();
        }        
    }
}
