using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertTargetAttributeValue(this DraggablePage page, string classValue)
        {
            try
            {
                Assert.AreEqual(classValue, page.Source.GetAttribute("class"));

            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dropped in Target place: {page.Source.GetAttribute("style")}");
            }
        }

        public static void AssertSort(this DraggablePage page, string textValue, int index)
        {            
            IWebElement dragElement = page.SortDragBox.FindElement(By.XPath($".//li[text()='{textValue}']"));
            IWebElement ele = page.SortDragBox.FindElement(By.XPath("//*[@id=\"sortablebox\"]/li[" + index + "]"));
            try
            {
               //List<IWebElement> dragElements = page.EventDragBox.FindElements(By.XPath(".//li[text()='Drag me down']"));
               
                Assert.AreEqual(textValue, dragElement.Text);
                Assert.AreEqual(textValue, ele.Text);
                //Assert.AreSame(ele, dragElement);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dragged to Target place: {ele.Text} {dragElement.Text}");
            }
        }

        public static void AssertEvent(this DraggablePage page, string start, string drag, string stop)
        {
            try
            {
                Assert.AreEqual(start, page.StartEventDrag.Text);
                Assert.AreEqual(drag, page.DragEventDrag.Text);
                Assert.AreEqual(stop, page.StopEventDrag.Text);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dragged to Target place: {page.StartEventDrag.Text} {page.DragEventDrag.Text} {page.StopEventDrag.Text}");
            }
        }
    }
}
