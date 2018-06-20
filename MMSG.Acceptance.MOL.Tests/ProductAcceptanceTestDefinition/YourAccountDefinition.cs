using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.MOL.Home.Dashboard;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class YourAccountDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(YourAccountDefinition));

        /// <summary>
        /// Clicking on the link present in the dashbord
        /// </summary>
        /// <param name="linkName">This is link name.</param>
        [When(@"I click on the link ""(.*)""")]
        public void CLickOnTheLink(string linkName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new DashboardPage().ClickOnTheLink(linkName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verying the test landed on the Payroll Deductions And Transfers Page
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should be display with page name ""(.*)""")]
        public void VerifyPageLandedOnPayrollDeductionsAndTransfers(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("YourAccountDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new PayrollDeductionsAndTransfersPage().
                VerifyThepageLandedOnPayrollDeductionsAndTransfers(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the tab tab present in the transaction page
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I click on the tab ""(.*)""")]
        public void ClickOnTheTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new PayrollDeductionsAndTransfersPage().ClickOnTheTab(tabName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the default 30days tab is been active in Transaction
        /// </summary>
        /// <param name="tabName">Tab name</param>
        [Then(@"I should see  default ""(.*)"" tab active")]
        public void ThenIShouldSeeDefaultTabActive(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("YourAccountDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new PayrollDeductionsAndTransfersPage().
                VerifyTheActiveTab(tabName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}