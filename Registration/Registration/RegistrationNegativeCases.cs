using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Registration.Models;
using Registration.Pages.HomePage;
using Registration.Pages.RegistrationPage;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;

namespace Registration
{
    [TestFixture]     
    class RegistrationNegativeCases
    {
        public IWebDriver driver;
        public readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            XmlConfigurator.Configure(new FileInfo(ConfigurationManager.AppSettings["log4net.Config"]));
            this.log.Info("INFO LOGGING");
        }

        [TearDown]

        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = (ConfigurationManager.GetSection("path") as NameValueCollection).Get("Logs") + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }
            this.driver.Quit();
        }           

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA",3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void NavigationToHomePage()
        {            
            HomePage homePage = new HomePage(this.driver);
            PageFactory.InitElements(homePage.Driver, homePage);

            homePage.NavigateTo();            
            Assert.AreEqual("Home", homePage.Title.Text);
        }

        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA",3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void NavigationToRegistrationPage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.AssertRegistrationPageIsOpen("Registration");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutFirstName()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutFirstName_MartialStatus", "RegistrationWithoutFirstName_Hobby", "RegistrationWithoutFirstName");
            
            regPage.FillRegistrationForm(user);
            regPage.AssertNamesErrorMessage("* This field is required");

        }

        /*
        [Test]
        [Property("RegistrationTests", 3)]

        // Read Excel using worksheet, application, workbook
        DON'T KNOW HOW TO IMPLEMENT THIS FUNCTIONALITY USING THESE OBJECTS, CAN YOU HELP ME?

        public void DoSomethingWithExcel()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser regUser = new RegistrationUser();

            List<DataTable> worksheets = new List<DataTable>();
            worksheets = Registration.Models.AccessExcelData.ImportFile(fileName);
            foreach (var item in worksheets)
            {
                foreach (DataRow row in item.Rows)
                {
                    //add to array
                    regUser.FirstName = row["FirstName"].ToString();
                    regUser.LastName = row["LastName"].ToString();
                    string[] martial = new string[item.Rows.Count];
                    for (int m = 0; m < martial.Length; m++)
                        martial[m] = item.Rows[m]["MartialStatus"].ToString();
                    int[] int_martial = new int[item.Rows.Count];
                    for (int i = 0; i < martial.Length; i++)
                        int_martial[i] = int.Parse(martial[i]);
                    regUser.MatrialStatus = int_martial;
                    
                }

            }
            regPage.FillRegistrationForm(regUser);
            regPage.AssertNamesErrorMessage("* This field is required");
        }
        */


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutLastName()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutLastName_MartialStatus", "RegistrationWithoutLastName_Hobby", "RegistrationWithoutLastName");

            regPage.FillRegistrationForm(user);
            regPage.AssertNamesErrorMessage("* This field is required");
        }


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutPhone()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutPhone_MartialStatus", "RegistrationWithoutPhone_Hobby", "RegistrationWithoutPhone");

            regPage.FillRegistrationForm(user);
            regPage.AssertPhoneErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWrongPhone1()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWrongPhone1_MartialStatus", "RegistrationWrongPhone1_Hobby", "RegistrationWrongPhone1");

            regPage.FillRegistrationForm(user);
            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWrongPhone2()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWrongPhone2_MartialStatus", "RegistrationWrongPhone2_Hobby", "RegistrationWrongPhone2");

            regPage.FillRegistrationForm(user);
            regPage.AssertPhoneErrorMessage("* Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationValidPhone()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationValidPhone_MartialStatus", "RegistrationValidPhone_Hobby", "RegistrationValidPhone");

            regPage.FillRegistrationForm(user);
            regPage.AssertSuccessMessage("Thank you for your registration");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutUsername()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutUsername_MartialStatus", "RegistrationWithoutUsername_Hobby", "RegistrationWithoutUsername");

            regPage.FillRegistrationForm(user);
            regPage.AssertUsernameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutMail()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutMail_MartialStatus", "RegistrationWithoutMail_Hobby", "RegistrationWithoutMail");

            regPage.FillRegistrationForm(user);
            regPage.AssertMailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutPassword()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutPassword_MartialStatus", "RegistrationWithoutPassword_Hobby", "RegistrationWithoutPassword");

            regPage.FillRegistrationForm(user);
            regPage.AssertPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutConfirmPassword()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutConfirmPassword_MartialStatus", "RegistrationWithoutConfirmPassword_Hobby", "RegistrationWithoutConfirmPassword");

            regPage.FillRegistrationForm(user);
            regPage.AssertConfirmPasswordErrorMessage("* This field is required");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWrongMail1()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWrongMail1_MartialStatus", "RegistrationWrongMail1_Hobby", "RegistrationWrongMail1");

            regPage.FillRegistrationForm(user);
            regPage.AssertMailErrorMessage("* Invalid email address");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWrongMail2()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWrongMail2_MartialStatus", "RegistrationWrongMail2_Hobby", "RegistrationWrongMail2");

            regPage.FillRegistrationForm(user);
            regPage.AssertMailErrorMessage("* Invalid email address");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWrongPassword()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWrongPassword_MartialStatus", "RegistrationWrongPassword_Hobby", "RegistrationWrongPassword");

            regPage.FillRegistrationForm(user);
            regPage.AssertPasswordErrorMessage("* Minimum 8 characters required");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationMatchPasswords()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationMatchPasswords_MartialStatus", "RegistrationMatchPasswords_Hobby", "RegistrationMatchPasswords");

            regPage.FillRegistrationForm(user);
            regPage.AssertConfirmPasswordErrorMessage("* Fields do not match");
            regPage.AssertPasswordStrengthMessage("Mismatch");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("New Tests", 1)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWithoutHobby()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWithoutHobby_MartialStatus", "RegistrationWithoutHobby_Hobby", "RegistrationWithoutHobby");

            regPage.FillRegistrationForm(user);
            regPage.AssertHobbyErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("New Tests", 1)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationWrongUploadPicFileFormat()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationWrongUploadPicFileFormat_MartialStatus", "RegistrationWrongUploadPicFileFormat_Hobby", "RegistrationWrongUploadPicFileFormat");

            regPage.FillRegistrationForm(user);
            regPage.AssertUploadPicFileErrorMessage("* Invalid File");
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("New Tests", 1)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        //Change Username with already-existing one in DB

        public void RegistrationUnsuccessRegistrationUsername()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationUnsuccessRegistrationUsername_MartialStatus", "RegistrationUnsuccessRegistrationUsername_Hobby", "RegistrationUnsuccessRegistrationUsername");

            regPage.FillRegistrationForm(user);
            regPage.AssertUnsuccessRegistrationMessage("Error: Username already exists");           
        }


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("New Tests", 1)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        //Change Username with not-existing one in DB

        public void RegistrationUnsuccessRegistrationMail()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = AccessExcelData.GetTestDataRegUser("RegistrationUnsuccessRegistrationMail_MartialStatus", "RegistrationUnsuccessRegistrationMail_Hobby", "RegistrationUnsuccessRegistrationMail");

            regPage.FillRegistrationForm(user);
            regPage.AssertUnsuccessRegistrationMessage("Error: E-mail address already exists");            
        }
        
        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("New Tests", 1)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationPasswordStrength()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();

            RegistrationUser user = new RegistrationUser();

            string[] password_change = new string[4];
            password_change = AccessExcelData.GetTestDataPasswordRegUser("RegistrationPasswordStrength");
            user.Password = password_change[0];
            regPage.FillRegistrationFormNotSubmit(user);
            regPage.AssertPasswordStrengthMessage("Very weak");
            user.Password = password_change[1];
            regPage.FillRegistrationFormNotSubmit(user);
            regPage.AssertPasswordStrengthMessage("Weak");
            user.Password = password_change[2];
            regPage.FillRegistrationFormNotSubmit(user);
            regPage.AssertPasswordStrengthMessage("Medium");
            user.Password = password_change[3];
            regPage.FillRegistrationFormNotSubmit(user);
            regPage.AssertPasswordStrengthMessage("Strong");
        }


        [Test, Property("Priority", 1)]
        [Property("DemoToolsQA", 3)]
        [Property("New Tests", 1)]
        [Property("RegistrationTests", 3)]
        [Author("Петя Николова")]

        public void RegistrationMenus()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            PageFactory.InitElements(regPage.Driver, regPage);

            regPage.NavigateTo();
            regPage.Driver.Manage().Window.Maximize();
                                   
            regPage.AssertExistTopMenu();
            regPage.AssertExistRightMenu();
        }    
    }
}
