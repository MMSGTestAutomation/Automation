using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.MOL.Your_Account;
using MMSG.Pages.UI_Pages.ROL.Home.Dashboard;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class TransactionDefination : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TransactionDefination));

        /// <summary>
        /// Navigate to the tab based on the tab name
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I navigate to ""(.*)"" tab")]
        public void NavigateToTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Navigate to tab based on the tab name
            new DashboardPage().NavigateToTab("Maxxia Online", tabName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Method to Verify drop downs and values are displayed
        /// </summary>
        /// <param name="dropDownName">This is dropdown name.</param>
        [Then(@"I should be displayed with ""(.*)"" dropdown")]
        public void ValidateDropDownIsPresent(string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("TransactionDefination", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().ValidateDropDownIsPresent(dropDownName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Method to select drop down option
        /// </summary>
        /// <param name="dropDownOption">This is dropdown option name.</param>
        /// <param name="dropDownName">This is dropdown name.</param>
        [When(@"I select ""(.*)"" in the dropdown ""(.*)""")]
        public void SelectingTheDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new TransactionsPage().ClickOnDropDown(dropDownOption, dropDownName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Available Balance
        /// </summary>
        [Then(@"I should be displayed with Available Balance")]
        public void ValidateAvailableBalance()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("TransactionDefination", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().ValidateAvailableBalance()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Transaction are appearing in MOL Site
        /// </summary>
        [Then(@"I should see Transaction")]
        public void VerifyTransactionIsDisplayed()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("TransactionDefination", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().VerifyTheTransactionIsDisplayed()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}