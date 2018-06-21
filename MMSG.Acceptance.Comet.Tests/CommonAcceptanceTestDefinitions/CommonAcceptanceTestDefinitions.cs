using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using MMSG.Pages.UI_Pages.Comet;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.CommonAcceptanceTestDefinitions
{
    [Binding]
    public sealed class CommonAcceptanceTestDefinitions : BaseTestFixture
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
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
        /// Launch application URL
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
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
                loginPage.GoToCometLoginUrl();
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of Comet logo
        /// </summary>
        [Then(@"I should be displayed with Comet logo")]
        public void ValidateDisplayCometLogo()
        {
            // Validate the logo existance status
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateTheUserDetails", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new CallCentreEnquiryPage().GetApplicationLogoExistance()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Logout as Comet user
        /// </summary>
        [When(@"I logout of Comet application")]
        public void LogoutOfCometApplication()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LogoutPage().LogoutAsCometUser();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Access the login pagebased on the application URL
        /// </summary>
        /// <param name="applicationURL">This is application under test URL </param>
        [Given(@"I launch application URL as ""(.*)""")]
        public void LaunchAplicationURL(string userType)
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
