using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class CallCentreEnquiryDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CallCentreEnquiryDefinition));

        /// <summary>
        /// Search the user based on the user information search criteria
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I enter ""(.*)"" of ""(.*)"" in the search textbox from ""(.*)""")]
        public void SearchUserDetails(string optionName, User.UserTypeEnum userType, string dataFetchType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().UserSearch(optionName, userType, dataFetchType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Random employee of the Employeer
        /// </summary>
        /// <param name="searchType">Search type in to get the meploye</param>
        /// <param name="employeerCode">Get the employee based on te employer code</param>
        [When(@"I enter ""(.*)"" Employee number from ""(.*)"" Employeer")]
        public void EnterEmployeeNumberFromEmployeer(string searchType, string employeerCode)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().SearchEmployee(searchType, employeerCode);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on search button.
        /// </summary>
        [When(@"I click on Search button")]
        public void ClickSearchButton()
        {
            //Click search button
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().ClickSearchButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the parameter for the further use
        /// </summary>
        /// <param name="parameter">parameter to be saved </param>
        /// <param name="userType">User type</param>
        [Then(@"I should Save the ""(.*)"" in ""(.*)""")]
        public void ThenIShouldSaveTheIn(string parameter, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().SaveTheData(parameter, userType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of searched employee.
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should be displayed with employee information of ""(.*)""")]
        public void ValidateDisplayOfEmployeeInformation(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CallCentreEnquiryDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new CallCentreEnquiryPage().GetEmployeeDetailsDisplayStatus(userType)));
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate page Landed
        /// </summary>
        /// <param name="pageName">Page Name</param>
        [Then(@"I should be on the ""(.*)"" page")]
        public void ValidatePageName(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Get page title
            SwitchToDefaultWindow();
            string expectedPageTitle = GetCometDomain() + " " + pageName;
            Logger.LogAssertion("CallCentreEnquiryDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(expectedPageTitle, new Employee_personaldetailsPage().GetCommetNewEmoplyeePageTitle(expectedPageTitle)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the option
        /// </summary>
        /// <param name="optionName">Option Name</param>
        /// <param name="pageName">Page Name</param>
        [When(@"I click on ""(.*)"" in ""(.*)"" page")]
        public void ClickOption(string optionName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            //Get page title
            SelectDefaultWindow();
            string PageTitle = GetCometDomain() + " " + pageName;
            new CallCentreEnquiryPage().ClickOptionOnCCEnquiryPage(optionName, PageTitle);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Package is  created successfully
        /// </summary>
        /// <param name="packageTypeEnum">This is package type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" for ""(.*)""")]
        public void ValidateDisplayOfPackage(Package.PackageTypeEnum packageTypeEnum, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CallCentreEnquiryDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new CallCentreEnquiryPage().VeriFyPackageName(packageTypeEnum, userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Employee nuber and search
        /// </summary>
        /// <param name="employeeNo"> Employee numner is been send</param>
        [When(@"I enter Employee number as ""(.*)"" and search in Call centre Enquiry")]
        public void SearchEmployee(string employeeNo)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().EnterTheEmployeeNumberAndSearch(employeeNo);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }       

    }
}