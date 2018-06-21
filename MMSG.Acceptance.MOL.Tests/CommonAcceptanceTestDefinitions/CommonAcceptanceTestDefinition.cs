using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.CommonAcceptanceTestDefinitions
{
    [Binding]
    public class CommonAcceptanceTestDefinitions : BasePage
    {
        /// <summary>
        /// The instance for Login Page
        /// </summary>
        private BrowseMMSGUserURL loginPage;

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CommonAcceptanceTestDefinitions));

        /// <summary>
        /// Access the login pagebased on the application URL
        /// </summary>
        /// <param name="applicationURL">This is application under test URL </param>
        [Given(@"I access application URL as ""(.*)""")]
        public void LaunchApplicationURL(string userType)
        {
            UserType = userType;
            UserName = User.Get((User.UserTypeEnum)Enum.Parse(typeof(User.UserTypeEnum), userType)).Name.ToString();
            CurrentBrowserName = ConfigurationManager.AppSettings.Get("Browser");
            TransactionTimings = DateTime.Now.ToString();
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
        /// Validate the display of error message
        /// </summary>
        /// <param name="messageType">This is message type</param>
        [Then(@"I should be displayed with ""(.*)"" message")]
        public void ValidateErrorMessageOnLoginScreen(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CommonAcceptanceTestDefinitions", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new LoginPage().GetStatusOfValidationMessage(messageType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the page name as user
        /// </summary>
        /// <param name="pageTitle">This is page title.</param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ValidatePageName(string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Assert the expected value with the actual value
            //Get current opened page title
            string actualPageTitle = GetPageTitle;
            Thread.Sleep(2000);
            //Assert we have correct page opened
            Assert.IsTrue(actualPageTitle.Contains(pageTitle));
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
        /// Deinitialize test after the execution of test
        /// and clean the WebDriver Instance.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {
            new CommonAcceptanceTestDefinitions().WebDriverCleanUp();
        }

        /// <summary>
        /// Enter Date of birth and car activation code
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [When(@"I enter 'Date of Birth' and 'Card Activation Code' of ""(.*)""")]
        public void EnterDOBandCardActivationCode(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string product = string.Empty;
            new LoginPage().EnterDOBAndCardActivationCode(userType, product);
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click continue button
        /// </summary>
        [When(@"I click on Continue button")]
        public void ClickContinueButtonMOLRegestrationPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().ClickContinueButtonMOL();
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}
