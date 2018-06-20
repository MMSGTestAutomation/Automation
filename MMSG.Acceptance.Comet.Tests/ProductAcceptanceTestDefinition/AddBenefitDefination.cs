using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet.Process_Menu;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class AddBenefitDefination : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(AddBenefitDefination));

        /// <summary>
        /// Verify application landed on Benefit Screen
        /// </summary>
        [Then(@"I will land on ""(.*)"" page")]
        public void VerifyLandedOnScreen(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Assert.AreEqual(pageName, new AddBenefitPage().GetPageHeader(pageName));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the browser header with page name
        /// </summary>
        /// <param name="pageName">This is page title.</param>
        [Then(@"I will land on ""(.*)"" window")]
        public void GetBrowserWindowTitleandValidate(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Assert.AreEqual(pageName, new AddBenefitPage().GetBrowserHeader(pageName));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Benefit from the drop down
        /// </summary>
        [When(@"I select ""(.*)"" in  ""(.*)"" dropdown")]
        public void SelectBenefit(Benefit.BenefitTypeEnum benifitType, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AddBenefitPage().SelectDropDown(benifitType, dropDownName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Button
        /// </summary>
        [When(@"I click on ""(.*)"" Button")]
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AddBenefitPage().ClickOnButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Budget Amount
        /// </summary>
        [When(@"I Enter Budget Amount for ""(.*)""")]
        public void EnterBudgetAmount(Benefit.BenefitTypeEnum benifitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AddBenefitPage().BudgetAmount(benifitType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}