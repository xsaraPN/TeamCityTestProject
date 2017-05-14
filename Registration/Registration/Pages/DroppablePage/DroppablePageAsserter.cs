using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Pages.DroppablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertTargetAttributeValue(this DroppablePage page, string classValue)
        {
            try
            {
                Assert.AreEqual(classValue, page.Target.GetAttribute("class"));
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);               
                throw new AssertionException($"Element is not dropped in Target place: {page.SourcePosition.GetAttribute("style")}");                
            }
        }

        public static void AssertAcceptTargetAttributeValue(this DroppablePage page, string classValue)
        {
            try
            {
                Assert.AreEqual(classValue, page.DropAcceptTarget.GetAttribute("class"));
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dropped in Target place: {page.DragValidSource.GetAttribute("style")}");
            }
        }

        public static void AssertNotAcceptTargetAttributeValue(this DroppablePage page, string classValue)
        {
            try
            {
                Assert.AreEqual(classValue, page.DropAcceptTarget.GetAttribute("class"));
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dropped in Target place: {page.DragNotValidSource.GetAttribute("style")}");
            }
        }

        public static void AssertPropagationTargetAttributeValue(this DroppablePage page, string DropOuterClassValue, string DropInnerClassValue)
        {
            try
            {
                Assert.AreEqual(DropOuterClassValue, page.PropagationTarget.GetAttribute("class"));
                Assert.AreEqual(DropInnerClassValue, page.PropagationTargetInner.GetAttribute("class"));
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dropped in Target place:{page.PropagationTarget.GetAttribute("class")} {page.PropagationTargetInner.GetAttribute("class")} {page.PropagationSource.GetAttribute("style")}");
            }
        }

        public static void AssertLimitPropagationTargetAttributeValue(this DroppablePage page, string DropOuterClassValue, string DropInnerClassValue)
        {
            try
            {
                Assert.AreEqual(DropOuterClassValue, page.LimitPropagationTarget.GetAttribute("class"));
                Assert.AreEqual(DropInnerClassValue, page.LimitPropagationTargetInner.GetAttribute("class"));
            }
            catch (Exception e)
            {
                page.log.Error("EXCEPTION LOGGING", e);
                throw new AssertionException($"Element is not dropped in Target place: {page.LimitPropagationTarget.GetAttribute("class")} {page.LimitPropagationTargetInner.GetAttribute("class")} {page.PropagationSource.GetAttribute("style")}");
            }
        }
    }
}
