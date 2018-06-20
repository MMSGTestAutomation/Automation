using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using MMSG.Pages.UI_Pages.MOL.Home.Dashboard;
using MMSG.Pages.UI_Pages.MOL.Profile;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class EmployeePersonalDetailsManagementDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(EmployeePersonalDetailsManagementDefinition));

       

        /// <summary>
        /// Verify the page landed on the Forgot password page
        /// </summary>
        /// <param name="pageName">page name</param>
        [Then(@"I should be on ""(.*)"" url of ""(.*)""Page")]
        public void ThenIShouldBeOnUrlOfPage(string urlEnd, string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EmployeePersonalDetailsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(urlEnd, new ApplictionForgotPasswordPage().VerifyThePageLandedOnTheForgotPassword(pageTitle)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Enter the value to the Text box
        /// </summary>
        /// <param name="textBoxName">Text box name</param>
        /// <param name="userType">Use type</param>
        [When(@"I enter the ""(.*)"" of ""(.*)""")]
        public void EnterValuetoTheTextBox(string textBoxName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplictionForgotPasswordPage().EnterValueToTextBoxMOL(textBoxName, userType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the password and reentring the password
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I enter New Password and Confirm password in text box as ""(.*)""")]
        public void EnteringPasswordAndConfirmPassword(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplictionForgotPasswordPage().EnterThePasswordAndReenterPasswordMOL();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the password change success message.
        /// </summary>
        /// <param name="message">This is message text.</param>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" message for ""(.*)""")]
        public void ValidatePassworChangeMessage(string message, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EmployeePersonalDetailsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(message, new ApplictionForgotPasswordPage().GetPasswordChangeSuccessMessage(userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the button name
        /// </summary>
        /// <param name="buttonMname">This is button name.</param>
        [When(@"I click on ""(.*)""")]
        public void PerformClickBasedOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplictionForgotPasswordPage().ClickOnTheButtonMOL(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of new password enter textbox
        /// </summary>
        [Then(@"I should view New password and Reenter")]
        public void VerifyNewPasswordTextAppered()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ForgotPasswordDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new ApplictionForgotPasswordPage().VerifyTheNewPasswordTextAppered()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Option on the page
        /// </summary>
        /// <param name="OptionName">This is option name.</param>
        /// <param name="pageName">This is page name.</param>
        [When(@"I click on ""(.*)"" option in ""(.*)"" page")]
        public void ClickOnOptionInPage(string optionName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new DashboardPage().ClickOption(optionName, pageName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the text to be filled
        /// </summary>
        /// <param name="textFillType">This is text fill type.</param>
        /// <param name="textBoxName">This is text box name.</param>
        /// <param name="pageName">This is page name.</param>
        [When(@"I enter ""(.*)"" in ""(.*)"" textbox of ""(.*)"" page")]
        public void TextFiledValidation(string textFillType, string textBoxName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ProfilePersonalDetailsPage().FilltextBoxBasedOnText(textFillType, textBoxName, pageName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This is validation message type
        /// </summary>
        /// <param name="messageType">This is message type.</param>
        /// <param name="textBoxName">This is textbox name.</param>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should be displayed with ""(.*)"" message in ""(.*)"" textbox of ""(.*)"" page")]
        public void ValidateMessageDisplay(string messageType, string textBoxName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EmployeePersonalDetailsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new ProfilePersonalDetailsPage().GetValidationMessageStatus(messageType, textBoxName, pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify teh check box ia been checked
        /// </summary>
        /// <param name="checkBoxName">Check box name to be checked</param>
        [Then(@"I should view the ""(.*)"" check box checked")]
        public void ViewTheCheckBoxChecked(string checkBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EmployeePersonalDetailsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new CommunicationPreferencesPage().VerifyCheckBoxIsChecked(checkBoxName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}