using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Registration.Pages.SelectablePage
{
    public static class SelectablePageAsserter
    {
        public static void AssertTargetAttributeValue(this SelectablePage page, string classValue, int indexFrom, int indexTo)
        {
            try
            {
                IWebElement ele;
                for (int i = indexFrom; i < indexTo + 1; i++)
                {                    
                    ele = page.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[" + i + "]"));
                    Assert.AreEqual(classValue, ele.GetAttribute("class"));
                }
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Selected Elements are not selected");
            }
        }

        public static void AssertSelectDisplayGrid(this SelectablePage page, string classValue, string indexes)
        {
            try
            {
                IWebElement ele;
                int t=0;
                string[] index= Regex.Split(indexes, ",");
                int[] indexInt = new int[index.Length];                
                for (int i = 0; i < indexInt.Length; i++)
                    indexInt[i] = int.Parse(index[i]);
                for (int j = 1; j < 13; j++)
                {
                    ele = page.Driver.FindElement(By.CssSelector("#selectable_grid > li:nth-child(" + j + ")"));
                    if (classValue == ele.GetAttribute("class"))                           
                        for (int s = 0; s < indexInt.Length; s++)
                            if (indexInt[s] == j)
                                t++;                               
                }
                Assert.AreEqual(t, indexInt.Length);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Selected Elements are not selected");
            }
        }

        public static void AssertSelectSerialized(this SelectablePage page, string classValue, string indexes)
        {
            try
            {
                IWebElement ele;
                int t = 0;
                string[] index = Regex.Split(indexes, ",");
                int[] indexInt = new int[index.Length];
                for (int i = 0; i < indexInt.Length; i++)
                    indexInt[i] = int.Parse(index[i]);
                for (int j = 1; j < 7; j++)
                {
                    ele = page.Driver.FindElement(By.CssSelector("#selectable-serialize > li:nth-child(" + j + ")"));
                    if (classValue == ele.GetAttribute("class"))                          
                        for (int s = 0; s < indexInt.Length; s++)
                            if (indexInt[s] == j)
                                t++;
                }
                Assert.AreEqual(t, indexInt.Length);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Selected Elements are not selected");
            }
        }

        public static void AssertSelectSerializedLabel(this SelectablePage page, string indexes)
        {
            try
            {                
                int t = 0;
                string[] index = Regex.Split(indexes, ",");
                int[] indexInt = new int[index.Length];
                for (int i = 0; i < indexInt.Length; i++)
                    indexInt[i] = int.Parse(index[i]);
                IWebElement label = page.Driver.FindElement(By.Id("select-results"));
                
                for (int s = 0; s < indexInt.Length; s++)                
                    if(label.Text.Contains($"\"#{indexInt[s]}\""))
                        t++;
                                   
                Assert.AreEqual(t, indexInt.Length);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Selected Elements are not selected");
            }
        }
    }
}
