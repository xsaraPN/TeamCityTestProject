using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.SortablePage
{
    public static class SortablePageAsserter
    {
        public static void AssertSortableChecks(this SortablePage page, string text, int indexTo)
        {
            try
            {
                IWebElement ele = page.Driver.FindElement(By.CssSelector("#sortable > li:nth-child(" + indexTo + ")"));
                Assert.AreEqual(text, ele.Text);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not placed to expected place");
            }
        }

        public static void AssertSortableGreyConnectListsChecks(this SortablePage page, string text, int indexTo)
        {
            try
            {
                IWebElement ele = page.Driver.FindElement(By.CssSelector("#sortable1 > li:nth-child(" + indexTo + ")"));
                Assert.AreEqual(text, ele.Text);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not placed to expected place");
            }
        }

        public static void AssertSortableBlankConnectListsChecks(this SortablePage page, string text, int indexTo)
        {
            try
            {
                IWebElement ele = page.Driver.FindElement(By.CssSelector("#sortable2 > li:nth-child(" + indexTo + ")"));
                Assert.AreEqual(text, ele.Text);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not placed to expected place");
            }
        }
        
        public static void AssertSortableDisplayAsGridChecks(this SortablePage page, string text, int indexTo)
        {
            try
            {
                IWebElement ele = page.Driver.FindElement(By.CssSelector("#sortable_grid > li:nth-child(" + indexTo + ")"));
                Assert.AreEqual(text, ele.Text);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not placed to expected place");
            }
        }
    }
}
