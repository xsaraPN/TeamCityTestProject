using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SoftUniLoginPage
{
    public partial class SoftUniLoginPage
    {
        public IWebElement userName
        {
            get
            {
                return this.Driver.FindElement(By.Name("username"));
            }
        }

        public IWebElement passWord
        {
            get
            {
                return this.Driver.FindElement(By.Name("password"));
            }
        }

        public IWebElement Login
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div[2]/div[1]/form/input[2]"));
            }
        }

        public IWebElement Logo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"page-header\"]/div[1]/div/div/div[1]/a/img[1]"));
            }
        }

        public IWebElement UserAvatar
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("user-avatar"));
            }
        }
    }
}
