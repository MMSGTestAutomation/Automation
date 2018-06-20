using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class Package_basedetailsDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(Package_basedetailsDefinition));

        /// <summary>
        /// Entering the data to fields while creating the Package
        /// </summary>
        /// <param name="packageType">This is package name</param>
        [When(@"I enter new ""(.*)"" package details")]
        public void EnterNewPackageDetails(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Package_basedetailsPage().FillNewPackageDetails(packageType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify thye page landed expected page
        /// </summary>
        /// <param name="pageName">page name to be validated</param>
        [Then(@"I should display ""(.*)"" Page")]
        public void VerifyThePageLanded(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new Package_basedetailsPage().VerifyPageLandedOnEditPage(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Changeing the the value in the Eit package
        /// </summary>
        /// <param name="changeType">change type</param>
        /// <param name="ChangeValue">value of the change</param>
        [When(@"I change ""(.*)"" with  ""(.*)"" in Edit package Page")]
        public void ChangeTheDetails(string changeType, string changeValue)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Package_basedetailsPage().ChangetheOption(changeType, changeValue);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the next button
        /// </summary>
        [When(@"I click on the Next button")]
        public void ClickOnNextPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Package_basedetailsPage().ClickOnNext();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// clicking on the save button
        /// </summary>
        [When(@"I click on the Save Button")]
        public void ClickingOnSaveButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Package_payrolldetailsPage().ClikingOnSaveInEdit();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}