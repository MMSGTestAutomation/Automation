using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using System;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.CommonAcceptanceTestDefinitions
{
    [Binding]
    public class CommonAcceptanceTestDefinitions : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CommonAcceptanceTestDefinitions));

        /// <summary>
        /// The instance for Login Page
        /// </summary>
        private BrowseMMSGUserURL loginPage;

        /// <summary>
        /// Access the login pagebased on the application URL
        /// </summary>
        /// <param name="applicationURL">This is application under test URL </param>
        [Given(@"I access application URL as ""(.*)""")]
        public void LaunchApplicationURL(string userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Pick Url based on user type enum
            loginPage = new BrowseMMSGUserURL((User.UserTypeEnum)
                Enum.Parse(typeof(User.UserTypeEnum), userType));
            //Login  the type of the user
            Boolean isBaseMMSGUrlBrowsedSuccessful =
                loginPage.IsUrlBrowsedSuccessful();
            //Check Is Url Browsed Successfully
            if (isBaseMMSGUrlBrowsedSuccessful)
            {
                //Open Url in Browser
                loginPage.GoToLoginUrl();
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login as user based on the user type
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I login as ""(.*)"" with ""(.*)"" and ""(.*)""")]
        public void LoginAsUser(User.UserTypeEnum userType, string userNameType, string passwordType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().LoginAsUser(userType, userNameType, passwordType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page name as user
        /// </summary>
        /// <param name="pageTitle"></param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ValidatePageName(string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Assert the expected value with the actual value
            Logger.LogAssertion("CommonAcceptanceTestDefinitions", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(pageTitle, new LoginPage().GetUserHomePageName()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout as user
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I click on Logout link as ""(.*)""")]
        public void LogoutAsUser(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LogoutPage().LogoutAsUser(userType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User Enter the DOB and Card Activation Code
        /// </summary>
        [When(@"I Enter the DOB and Card Activation Code")]
        public void WhenIEnterTheDOBAndCardActivationCode()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().EnterDOBAndCardActivationCodeROL();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User clickon the Continue button
        /// </summary>
        [When(@"I click on Continue button")]
        public void WhenIClickOnContinueButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().ClickContinueButtonROL();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Error  Message in login page
        /// </summary>
        /// <param name="messageType">Type of Message to be validated</param>
        [Then(@"I should be displayed with ""(.*)"" message in LoginPage")]
        public void DisplayedWithErrorMessageInLoginPage(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Assert the expected value with the actual value
            Logger.LogAssertion("CommonAcceptanceTestDefinitions", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new LoginPage().GetStatusOfValidationMessageROL(messageType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// updating the the loginfail attempt to Zero
        /// </summary>
        /// <param name="userType">User login attempt to be set Zero </param>
        [When(@"I reset Failed Login attempt to Zero for ""(.*)""")]
        public void ResetFailedLoginAttemptToZeroFor(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().ResetFailEdLoginAttemptToZero(userType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Deinitialize test after the execution of test
        /// and clean the WebDriver Instance.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {
            new CommonAcceptanceTestDefinitions().WebDriverCleanUp();
        }
    }
}