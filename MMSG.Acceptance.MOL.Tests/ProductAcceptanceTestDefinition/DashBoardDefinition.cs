using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.MOL.Home.Dashboard;
using MMSG.Pages.UI_Pages.MOL.Your_Account;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class DashBoardDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashBoardDefinition));

        /// <summary>
        /// Method to verify benefit text is present.
        /// </summary>
        /// <param name="benefitName">This is benefit name.</param>
        [Then(@"I should be display with the benefit ""(.*)""")]
        public void VerifyTheBenefitIsPresent(string benefitName)
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("DashBoardDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new DashboardPage().VerifyTheBenefitIsPresent(benefitName)));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the benefit are present in dropdown
        /// </summary>
        /// <param name="benfitName"></param>
        [Then(@"I should see Benefit in DropDown as ""(.*)""")]
        public void VerifyBenefitInDropDownAs(Benefit.BenefitTypeEnum userBenfitType)
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("DashBoardDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().VerifiyBenefitName(userBenfitType)));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the Benefit in Inmenoery
        /// </summary>
        /// <param name="userBenefit">Benefit type</param>
        [When(@"I should Save benefit from dashboard as ""(.*)""")]
        public void WhenIShouldSaveBenefitFromDashboardAs(Benefit.BenefitTypeEnum userBenefit)
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            new DashboardPage().SaveBenefitInMemory(userBenefit);
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Novated lease benefit conatins Comma Separated Value
        /// </summary>
        [Then(@"I should see Novated Lease comma separated values")]
        public void ThenIShouldSeeNovatedLeaseCommaSeparatedValues()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("DashBoardDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new DashboardPage().VerifyNovatedLeaseConatainCommaSeperatedValue()));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }
    }
}