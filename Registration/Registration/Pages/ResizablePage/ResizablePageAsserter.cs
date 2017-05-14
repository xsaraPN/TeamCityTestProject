using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.ResizablePage
{
    public static class ResizablePageAsserter
    {
        public static void AssertAnimation(this ResizablePage page)
        {
            try
            {
                String styleAttrib = page.AnimateResizeWindow.GetAttribute("style");
                Boolean animationExists = styleAttrib.Contains("overflow");
                Assert.IsTrue(animationExists);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Animation doesn't exist: style={page.AnimateResizeWindow.GetAttribute("style")}");
            }
        }

        public static void AssertNewSize(this ResizablePage page, int pixelsToWidth, int pixelsToHeight)
        {
            int upLimitWidth = new int();
            int downLimitWidth = new int();
            int upLimitHeight = new int();
            int downLimitHeight = new int();
            try
            {
                if (pixelsToWidth != 0)
                {
                    upLimitWidth = page.Width + pixelsToWidth - page.resizeButton.Size.Width;
                    downLimitWidth = page.Width + pixelsToWidth - page.resizeButton.Size.Width - 5;
                }
                else
                {
                    upLimitWidth = page.Width + 1;
                    downLimitWidth = page.Width - 1;                    
                }
                if (pixelsToHeight != 0)
                {                    
                    upLimitHeight = page.Height + pixelsToHeight - page.resizeButton.Size.Height;
                    downLimitHeight = page.Height + pixelsToHeight - page.resizeButton.Size.Height - 5;
                }
                else
                {                    
                    upLimitHeight = page.Height + 1;
                    downLimitHeight = page.Height - 1;
                }
                
                Assert.IsTrue(page.resizeWindow.Size.Width <= upLimitWidth && page.resizeWindow.Size.Width >= downLimitWidth);
                Assert.IsTrue(page.resizeWindow.Size.Height <= upLimitHeight && page.resizeWindow.Size.Height >= downLimitHeight);                
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not resized till Target size: upLimitWidth={upLimitWidth} downLimitWidth={downLimitWidth} upLimitHeight={upLimitHeight} downLimitHeight={downLimitHeight} {page.resizeWindowPosition.GetAttribute("style")}");
            }
        }

        public static void AssertAnimateNewSize(this ResizablePage page, int pixelsToWidth, int pixelsToHeight)
        {
            int upLimitWidth = new int();
            int downLimitWidth = new int();
            int upLimitHeight = new int();
            int downLimitHeight = new int();
            try
            {
                if (pixelsToWidth != 0)
                {
                    upLimitWidth = page.Width + pixelsToWidth;
                    downLimitWidth = page.Width + pixelsToWidth - 5;
                }
                else
                {
                    upLimitWidth = page.Width + 2;
                    downLimitWidth = page.Width - 2;
                }
                if (pixelsToHeight != 0)
                {
                    upLimitHeight = page.Height + pixelsToHeight;
                    downLimitHeight = page.Height + pixelsToHeight - 5;
                }
                else
                {
                    upLimitHeight = page.Height + 2;
                    downLimitHeight = page.Height - 2;
                }

                Assert.IsTrue(page.AnimateResizeWindow.Size.Width <= upLimitWidth && page.AnimateResizeWindow.Size.Width >= downLimitWidth);
                Assert.IsTrue(page.AnimateResizeWindow.Size.Height <= upLimitHeight && page.AnimateResizeWindow.Size.Height >= downLimitHeight);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
               throw new AssertionException($"Element is not resized till Target size: upLimitWidth={upLimitWidth} downLimitWidth={downLimitWidth} upLimitHeight={upLimitHeight} downLimitHeight={downLimitHeight} {page.AnimateResizeWindow.GetAttribute("style")}");
            }
        }

        public static void AssertConstraintsNewSize(this ResizablePage page, int pixelsToWidth, int pixelsToHeight)
        {
            int upLimitWidth = new int();
            int downLimitWidth = new int();
            int upLimitHeight = new int();
            int downLimitHeight = new int();
            try
            {                
                upLimitWidth = 183;
                downLimitWidth = 10;
                upLimitHeight = 138;
                downLimitHeight = 10;
                Assert.IsTrue(page.ConstraintsResizeWindow.Size.Width <= upLimitWidth && page.ConstraintsResizeWindow.Size.Width >= downLimitWidth);
                Assert.IsTrue(page.ConstraintsResizeWindow.Size.Height <= upLimitHeight && page.ConstraintsResizeWindow.Size.Height >= downLimitHeight);
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not resized till Target size: upLimitWidth={upLimitWidth} downLimitWidth={downLimitWidth} upLimitHeight={upLimitHeight} downLimitHeight={downLimitHeight} {page.ConstraintsResizeWindow.GetAttribute("style")}");
            }
        }
    }
}
