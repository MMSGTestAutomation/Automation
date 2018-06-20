using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.ROL.Claims;
using MMSG.Pages.UI_Pages.ROL.Home.Dashboard;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class ClaimsDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ClaimsDefinition));

        /// <summary>
        /// User clicks on the Claim Button
        /// </summary>
        [When(@"I Click on Claim button")]
        public void ClickOnClaimButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Navigate to tab based on the tab name
            new DashboardPage().NavigateToTab("RemServ Online", "Claims");
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// verify the page landed on the Claim Screen
        /// </summary>
        [Then(@"I should display with Claim page")]
        public void VerifyTheDisplayOfClaimPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new MakeAClaimPage().VerifyPageLandedOnMakeAClaimPage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the No Reimbusment Message
        /// </summary>
        [Then(@"I should see No Reimbusment Message")]
        public void ValidateReimbusmentMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
              Assert.IsTrue(new MakeAClaimPage().VerifyTheNoReimbusmentMessage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}