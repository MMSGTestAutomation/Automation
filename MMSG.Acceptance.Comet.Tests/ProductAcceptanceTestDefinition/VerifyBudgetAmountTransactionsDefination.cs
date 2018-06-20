using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class VerifyBudgetAmountTransactionsDefination : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(VerifyBudgetAmountTransactionsDefination));

        /// <summary>
        /// Click on Employee Number
        /// </summary>
        [Given(@"I click on employee number")]
        public void ClickOnEmpNumber()
        {
            //Click Employee Number
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new VerifyBudgetAmountTransactionPage().ClickEmployeeNumber();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Proces menu and select EAMS option
        /// </summary>
        [When(@"I Select EAMS option")]
        public void SelectEAMS()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new VerifyBudgetAmountTransactionPage().SelectEAMS();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the system name and theEmployee name
        /// </summary>
        /// <param name="p0"></param>
        [Then(@"I should be Display with systems name and Employee name which is been validated with VMS as ""(.*)""")]
        public void ValidateSystemsNameAndEmployeeNameWithVMSA(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyBudgetAmountTransactionsDefination", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new VerifyBudgetAmountTransactionPage().VerifyTheSystemNameAndEmployeeName(userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}