using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SoftUniLoginPage
{
    public static class SoftUniLoginPageAsserter
    {
        public static void AssertSoftUniUserLoggedIn(this SoftUniLoginPage softUniPage)
        {
            Assert.IsTrue(softUniPage.Logo.Displayed);
            Assert.IsTrue(softUniPage.UserAvatar.Displayed);
        }
        
    }
}
