using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.ROL.Home.Dashboard;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class ContactDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ContactDefinition));

        /// <summary>
        /// Navigate to the tab based on the tab name
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        [When(@"I navigate to ""(.*)"" tab")]
        public void NavigateToTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Navigate to tab based on the tab name
            new DashboardPage().NavigateToTab("RemServ Online", tabName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate User Details in Your Details page
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" details")]
        public void ValidateTheUserDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ContactDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new ContactPage().ValidateUserDetailsinYourDetails(userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select dropdown in content page.
        /// </summary>
        /// <param name="dropDownOption">This is dropdown option.</param>
        /// <param name="dropDownName">This is dropdown name.</param>
        [When(@"I select ""(.*)"" in the dropdown ""(.*)""")]
        public void SelelctingTheDropDownInContactPage(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().ClickOnDropDown(dropDownOption, dropDownName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify dropdown existance status.
        /// </summary>
        /// <param name="DropDownName">This is dropdown name.</param>
        [Then(@"I should be display ""(.*)"" dropdown")]
        public void VerifyDropDownAppeared(string DropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ContactDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.IsTrue(new ContactPage().ValidateDropDownIsPresent(DropDownName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enters value to the text box
        /// </summary>
        /// <param name="textBoxName">This is text box name.</param>
        [When(@"I Enter the ""(.*)""")]
        public void EnterTheValeInTextBox(string textBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().EnterValueToTextBox(textBoxName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select radio button
        /// </summary>
        /// <param name="radioButtonName">This is radip button name.</param>
        [When(@"I select the Radio Button ""(.*)""")]
        public void SelelctingTheRadioButton(string radioButtonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().SelectRadioButton(radioButtonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking  on the Button
        /// </summary>
        /// <param name="buttonName">Button Name which need to be click</param>
        [When(@"I click on ""(.*)"" Button")]
        public void ClickingOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().ClickOnButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Message is been displayed
        /// </summary>
        /// <param name="message">Message to be dispayed</param>
        [Then(@"I should be displayed with ""(.*)"" message")]
        public void VerifyTheMessage(string message)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ContactDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.IsTrue(new ContactPage().VerifyTheMessage(message)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}