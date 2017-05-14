using NUnit.Framework;
using Registration.Pages.ToolsQAHomepage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.AutomationPracticePage
{
    public static class AutomationPageAsserter
    {
        public static void AssertNewTab(this AutomationPage autoPage, ToolsQAHomePage homePage)
        {
            var ToolsImagePath = ConfigurationManager.AppSettings["ImageToolsQAPath"];
            Assert.AreEqual(ToolsImagePath, homePage.Logo.GetAttribute("currentSrc"));
            Assert.AreEqual(2, autoPage.Driver.WindowHandles.Count);
        }
    }
}
