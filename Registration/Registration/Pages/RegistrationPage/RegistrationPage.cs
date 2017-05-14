using NUnit.Framework;
using OpenQA.Selenium;
using Registration.Models;
using System;
using System.Collections.Generic;

namespace Registration.Pages.RegistrationPage
{
    // Include methods, constructors, properties

    public partial class RegistrationPage : BasePage
    {        
        private string Regurl = "registration/";
       
        public RegistrationPage(IWebDriver driver)
            :base(driver)
        {           
        }

        public void NavigateTo()
        {
            string RegURL = base.Url + this.Regurl;
            this.Driver.Navigate().GoToUrl(RegURL);
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
             
            SelectBox(this.Driver, this.MartialStatus, user.MatrialStatus);
            SelectBox(this.Driver, this.Hobby, user.Hobby);
            
            this.CountryOption.SelectByText(user.Country);
            this.MounthOption.SelectByText(user.BirthMonth);
            this.DayOption.SelectByText(user.BirthDay);
            this.YearOption.SelectByText(user.BirthYear);
            
            Type(this.Phone, user.Phone);
            Type(this.UserName, user.UserName);
            Type(this.Email, user.Email);
 
            this.UploadButton.Click();
            this.Driver.SwitchTo().ActiveElement().SendKeys(user.UploadPicDir);

            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.SubmitButton.Click();
        }

        public void FillRegistrationFormNotSubmit(RegistrationUser user)
        {
            Type(this.Password, user.Password);            
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
        
        private void SelectBox(IWebDriver driver, List<IWebElement> locator, int[] index)
        {            
            int a = new int();
            for (int i = 0; i < index.Length; i++)
            {
                a = index[i];
                locator[a].Click();
                try
                {
                    Assert.IsTrue(locator[a].Selected, $"The selected value '{locator[a].GetAttribute("value")}' is not set.");
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                }
               
            }
        }
    }
}
