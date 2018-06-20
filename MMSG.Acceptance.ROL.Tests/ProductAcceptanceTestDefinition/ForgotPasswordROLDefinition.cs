using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using MMSG.Pages.UI_Pages.MOL.ActivationSitePages;
using MMSG.Pages.UI_Pages.ROL.Home.Dashboard;
using MMSG.Pages.UI_Pages.ROL.Profile;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class ForgotPasswordROLDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(ForgotPasswordROLDefinition));

        /// <summary>
        /// Execute the Disable Store poc to diable SMS Validation
        /// </summary>
        /// <param name="SMSStorPoc">This is SMS store procidure</param>
        [When(@"I run the ""(.*)"" Store proc to handel SMS validation")]
        public void RunTheStorePocToControlSMSValidation(string SMSStorPoc)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ActivateLogin().SMSValidationControler(SMSStorPoc);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Value to the Text box
        /// </summary>
        /// <param name="textBoxName">This is text box name.</param>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I enter ""(.*)"" in text box as ""(.*)""")]
        public void EnterValueToTextboxROL(string textBoxName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplictionForgotPasswordPage().EnterValueToTextBoxROL(textBoxName, userType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Button in forgot password page
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click on ""(.*)""")]
        public void WhenIClickOn(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplictionForgotPasswordPage().ClickOnTheButtonROL(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the new passsword text box is appearing
        /// </summary>
        [Then(@"I should view New password and Reenter")]
        public void VerifyNewPasswordTextAppered()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ForgotPasswordROLDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new ApplictionForgotPasswordPage().VerifyTheNewPasswordTextAppered()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the new password and re enter the password
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I enter New Password and Confirm password in text box as ""(.*)""")]
        public void EnterPasswordAndReenterPasswordROL(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplictionForgotPasswordPage().EnterThePasswordAndReenterPasswordROL();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on the button in Dashboard
        /// </summary>
        /// <param name="buttonName">Button to be click name</param>
        [When(@"I click on ""(.*)"" in Dashboard")]
        public void WhenIClickOnInDashboard(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new DashboardPage().ClickOnButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the button in personal details page
        /// </summary>
        /// <param name="elementName">Element to be click</param>
        [When(@"I click on ""(.*)"" in Personal Details page")]
        public void WhenIClickOnInPersonalDetailsPage(string elementName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new PersonalDetailsPage().ClickOnWebElement(elementName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the Value to the password change page 
        /// </summary>
        /// <param name="currentPasswordType">current password type</param>
        /// <param name="newPasswordType">New password type</param>
        /// <param name="reEnterNewPassword">Re enter Passowrd type</param>
        /// <param name="pageName">Page name </param>
        [When(@"I enter ""(.*)"" Old Password,""(.*)"" New password, ""(.*)"" re enter password in ""(.*)"" Page and click on save")]
        public void FillThefieldsAndSave(string currentPasswordType, string newPasswordType, string reEnterNewPassword, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ChangePasswordPage().FillTextBoxOnTextFieldCriteria(currentPasswordType, 
                newPasswordType, reEnterNewPassword, pageName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the error message in Password change validation page
        /// </summary>
        /// <param name="currentPasswordMessageType">current password error message validation type</param>
        /// <param name="newPasswordMessageType">New Password error message validation type</param>
        /// <param name="reEnterNewPasswordMessageType">ReEnterNewPassword error message validation type</param>
        /// <param name="pageName">Page name </param>
        [Then(@"I should see ""(.*)"" in Oldpassword, ""(.*)"" in new password and ""(.*)"" in Reenter password in ""(.*)""")]
        public void ValidateErrorMessage(string currentPasswordMessageType, string newPasswordMessageType, string reEnterNewPasswordMessageType, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ForgotPasswordROLDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new ChangePasswordPage().ValidateErrorMessageInChangePasswordScreen(currentPasswordMessageType,
                newPasswordMessageType, reEnterNewPasswordMessageType, pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Verify the Success maessage
        /// </summary>
        [Then(@"I should be display with Success Message")]
        public void ThenIShouldBeDisplayWithSuccessMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ForgotPasswordROLDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new ChangePasswordPage().ValidateSuccessMessage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }        
    }
}