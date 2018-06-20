using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.ROL.Your_Account;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
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
        /// Method to Verify drop downs and values are displayed
        /// </summary>
        /// <param name="dropDownName">This is dropdown name.</param>
        /// <param name="dropDownValue">This dropdown value.</param>
        [Then(@"I should be displayed with ""(.*)"" dropdown and contains ""(.*)"" value")]
        public void ValidateDropDownAndValue(string dropDownName, string dropDownValue)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("TransactionDefination", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new TransactionsPage().ValidateDropDownAndValue(dropDownName, dropDownValue)));
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
        /// Verify the the tab status
        /// </summary>
        /// <param name="tabName">Tab name to be checked</param>
        [Then(@"I should be on ""(.*)"" Tab")]
        public void VerifyTabIsactive(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("TransactionDefination", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new TransactionsPage().ValidateTabStatus(tabName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the transaction filter type tabs
        /// </summary>
        /// <param name="tabName">tab name to be clicked</param>
        [When(@"I click on ""(.*)"" tab")]
        public void ClickOnTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);           
            new TransactionsPage().ClickOnTheTab(tabName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the date picker and selecting the date
        /// </summary>
        /// <param name="pickerType">Date picker to be clicked</param>
        /// <param name="numberMonth">Number of months to set back</param>
        [When(@"I click on ""(.*)"" date picker and pick ""(.*)"" month back transaction")]
        public void WhenIClickOnDatePickerAndPickMonthBackTransaction(string pickerType, int numberMonth)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new TransactionsPage().AddFilter(pickerType, numberMonth);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the date picker and selecting the date
        /// </summary>
        /// <param name="datePickerType">date picker type</param>
        [When(@"I click on ""(.*)"" date picker and pick todays date")]
        public void WhenIClickOnDatePickerAndPickTodaysDate(string datePickerType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new TransactionsPage().AddFilter(datePickerType, 0);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on button in Transction page
        /// </summary>
        /// <param name="buttonName">button to be clicked</param>
        [When(@"I click on ""(.*)"" Button in Tansaction page")]
        public void WhenIClickOnButtonInTansactionPage(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new TransactionsPage().ClickonButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

    }
}