using NUnit.Framework;

namespace Registration.Pages.RegistrationPage
{
    //Include Asserts

    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssertSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed, page.UnsuccessRegistrationMessage.Text);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {            
            Assert.IsTrue(page.ErrorMessagesForNames.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForNames.Text);
        }

        public static void AssertPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPhone.Text);
        }

        public static void AssertUsernameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForUsername.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForUsername.Text);
        }

        public static void AssertMailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMail.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMail.Text);
        }

        public static void AssertPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPassword.Text);
        }

        public static void AssertConfirmPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForConfirmPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForConfirmPassword.Text);
        }
        
        public static void AssertHobbyErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForHobby.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForHobby.Text);
        }

        public static void AssertUploadPicFileErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForUploadPicFile.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForUploadPicFile.Text);
        }

        public static void AssertPasswordStrengthMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.PasswordStrength.Displayed);
            StringAssert.Contains(text, page.PasswordStrength.Text);
        }

        public static void AssertUnsuccessRegistrationMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.UnsuccessRegistrationMessage.Displayed);
            StringAssert.Contains(text, page.UnsuccessRegistrationMessage.Text);
        }

        public static void AssertExistTopMenu(this RegistrationPage page)
        {
            string[] menuName = new string[] {"Home", "About us", "Services", "Demo", "Blog","Contact"};
            for(int i =0; i< page.TopMenu.Count; i++)
            {
                Assert.IsTrue(page.TopMenu[i].Displayed);
                StringAssert.Contains(menuName[i], page.TopMenu[i].Text);
            }
            string[] SubMenuNames = new string[] {"Draggable", "Tabs"};
            for (int i = 0; i < page.SubTopMenus.Count; i++)
            {
                Assert.IsTrue(page.SubTopMenus[i].Enabled);
                StringAssert.Contains(SubMenuNames[i], page.SubTopMenus[i].GetAttribute("title"));
            }
        }

        public static void AssertExistRightMenu(this RegistrationPage page)
        {
            string[] TitlesMenuName = new string[] { "Registration",
                                                    "interaction",
                                                    "Widget",
                                                    "Frames and Windows"};
            for (int i = 0; i < page.TitlesRightMenu.Count; i++)
            {
                Assert.IsTrue(page.TitlesRightMenu[i].Displayed);
                StringAssert.Contains(TitlesMenuName[i], page.TitlesRightMenu[i].Text);
            }

            string[] menuName = new string[] { "Registration",
                                               "Draggable",
                                               "Droppable",
                                               "Resizable",
                                               "Selectable",
                                               "Sortable",
                                               "Accordion",
                                               "Autocomplete",
                                               "Datepicker",
                                               "Menu",
                                               "Slider",
                                               "Tabs",
                                               "Tooltip",
                                               "Frames and windows"};
            for (int i = 0; i < page.RightMenu.Count; i++)
            {
                Assert.IsTrue(page.RightMenu[i].Displayed);
                StringAssert.Contains(menuName[i], page.RightMenu[i].Text);
            }            
        }
    }
}
