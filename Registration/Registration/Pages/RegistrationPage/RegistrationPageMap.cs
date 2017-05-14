using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Pages.RegistrationPage
{
    //Include locators

    public partial class RegistrationPage
    {
        public IWebElement Title
        {
            get
            {
                return this.Driver.FindElement(By.TagName("title"));
            }
        }

        public IWebElement Header
        {
            get
            {
                return this.Driver.FindElement(By.ClassName("entry-title"));
            }
        }

        public IWebElement FirstName
        {
            get
            {
                return this.Driver.FindElement(By.Id("name_3_firstname"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.Driver.FindElement(By.Id("name_3_lastname"));
            }
        }

        public List<IWebElement> MartialStatus
        {
            get
            {
                return this.Driver.FindElements(By.Name("radio_4[]")).ToList();
            }
        }

        public List<IWebElement> Hobby
        {
            get
            {
                return this.Driver.FindElements(By.Name("checkbox_5[]")).ToList();
            }
        }

        private IWebElement CountryDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("dropdown_7"));
            }
        }

        public SelectElement CountryOption
        {
            get
            {
                return new SelectElement(CountryDD);
            }
        }

        private IWebElement MounthDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("mm_date_8"));
            }
        }

        public SelectElement MounthOption
        {
            get
            {
                return new SelectElement(MounthDD);
            }
        }

        private IWebElement DayDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("dd_date_8"));
            }
        }

        public SelectElement DayOption
        {
            get
            {
                return new SelectElement(DayDD);
            }
        }

        private IWebElement YearDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("yy_date_8"));
            }
        }

        public SelectElement YearOption
        {
            get
            {
                return new SelectElement(YearDD);
            }
        }

        public IWebElement Phone
        {
            get
            {
                return this.Driver.FindElement(By.Id("phone_9"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return this.Driver.FindElement(By.Id("username"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("email_1"));
            }
        }

        public IWebElement UploadButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("profile_pic_10"));
            }
        }

        public IWebElement Description
        {
            get
            {
                return this.Driver.FindElement(By.Id("description"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("password_2"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("confirm_password_password_2"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return this.Driver.FindElement(By.Name("pie_submit"));
            }
        }

        public IWebElement SuccessMessage
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.ClassName("piereg_message")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.ClassName("piereg_message"));
            }
        }

        public IWebElement ErrorMessagesForNames
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                    // throw new WebDriverTimeoutException("Not found such element for error message after timeout");
                }

                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[1]/div[1]/div[2]/span"));
            }
        }

        public IWebElement ErrorMessagesForPhone
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[6]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForMail
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[8]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForUsername
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[7]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForPassword
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[11]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForConfirmPassword
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[12]/div/div/span"));
            }
        }

        public IWebElement ErrorMessagesForHobby
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[3]/div/div[2]/span"));
            }
        }

        public IWebElement ErrorMessagesForUploadPicFile
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"pie_register\"]/li[9]/div/div/span")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[9]/div/div/span"));
            }
        }

        public IWebElement PasswordStrength
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"piereg_passwordStrength\"]")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"piereg_passwordStrength\"]"));
            }
        }
        
        public IWebElement UnsuccessRegistrationMessage
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"post-49\"]/div/p")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element for error message");
                }
                return this.Driver.FindElement(By.XPath("//*[@id=\"post-49\"]/div/p"));
            }
        }

        public List<IWebElement> TopMenu
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-primary-menu")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element TopMenu");
                }

                List<IWebElement> TopMenuElements = new List<IWebElement>();
                TopMenuElements.Add(this.Driver.FindElement(By.Id("menu-item-38")));
                TopMenuElements.Add(this.Driver.FindElement(By.Id("menu-item-158")));
                TopMenuElements.Add(this.Driver.FindElement(By.Id("menu-item-155")));
                TopMenuElements.Add(this.Driver.FindElement(By.Id("menu-item-66")));                
                TopMenuElements.Add(this.Driver.FindElement(By.Id("menu-item-65")));
                TopMenuElements.Add(this.Driver.FindElement(By.Id("menu-item-64")));

                return TopMenuElements;
            }
        }

        public List<IWebElement> SubTopMenus
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.Id("menu-item-66")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element SubTopMenus");
                }

                List<IWebElement> SubTopMenusElements = new List<IWebElement>();                
                SubTopMenusElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-73\"]/a")));
                SubTopMenusElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-153\"]/a")));
                
                return SubTopMenusElements;
            }
        }

        public List<IWebElement> RightMenu
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.Id("secondary")));
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"nav_menu-6\"]/div[1]/h3")));
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"nav_menu-3\"]/div[1]/h3")));
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"nav_menu-2\"]/div[1]/h3")));
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"nav_menu-4\"]/div[1]/h3")));                    
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element RigthMenu");
                }

                List<IWebElement> RigthMenuElements = new List<IWebElement>();
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-6\"]/div[1]/h3")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-374\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-3\"]/div[1]/h3")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-140\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-141\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-143\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-142\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-151\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-2\"]/div[1]/h3")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-144\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-145\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-146\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-147\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-97\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-98\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-99\"]/a")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-4\"]/div[1]/h3")));
                RigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"menu-item-148\"]/a")));

                return RigthMenuElements;
            }
        }

            public List<IWebElement> TitlesRightMenu
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.Id("secondary")));
                }
                catch (Exception e)
                {
                    this.log.Error("EXCEPTION LOGGING", e);
                    throw new NoSuchElementException("Not found such element TitlesRightMenu");
                }

                List<IWebElement> TitlesRigthMenuElements = new List<IWebElement>();
                TitlesRigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-6\"]/div[1]/h3")));               
                TitlesRigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-3\"]/div[1]/h3")));                
                TitlesRigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-2\"]/div[1]/h3")));               
                TitlesRigthMenuElements.Add(this.Driver.FindElement(By.XPath("//*[@id=\"nav_menu-4\"]/div[1]/h3")));
                
                return TitlesRigthMenuElements;
            }
        }
    }
}
