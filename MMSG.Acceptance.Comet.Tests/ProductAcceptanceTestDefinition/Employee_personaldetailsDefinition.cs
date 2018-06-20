using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class Employee_personaldetailsDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(Employee_personaldetailsDefinition));

        /// <summary>
        /// Validate the display of page name.
        /// </summary>
        /// <param name="pageName">This is Page name.</param>
        [Then(@"I should be on ""(.*)"" page")]
        public void ValidatePageName(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Get page title
            string expectedPageTitle = GetCometDomain() + " " + pageName;

            Logger.LogAssertion("Employee_personaldetailsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(expectedPageTitle, new Employee_personaldetailsPage().GetCommetNewEmoplyeePageTitle(expectedPageTitle)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate popup name.
        /// </summary>
        /// <param name="expectedPopupTitle">This is popup name.</param>
        [Then(@"I should be on ""(.*)"" popup")]
        public void ValidatePopupName(string expectedPopupTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("Employee_personaldetailsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(expectedPopupTitle, new Employee_personaldetailsPage().GetpopupTitle(expectedPopupTitle)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate popup title
        /// </summary>
        /// <param name="expectedPopupTitle">This is popup title</param>
        [Then(@"I should be on ""(.*)""")]
        public void ValidatePopupTitle(string expectedPopupTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("Employee_personaldetailsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(expectedPopupTitle, new Employee_personaldetailsPage().GetWindowTitle(expectedPopupTitle)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter new user details
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I enter new ""(.*)"" employee details")]
        public void EnterNewEmployeeDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Employee_personaldetailsPage().FillEmployeeDetails(userType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on close buton
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click on ""(.*)"" button in ""(.*)"" popup")]
        public void ClickOnButtonByName(string buttonName, string popupName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Employee_personaldetailsPage().ClickOnButtonInPopup(buttonName, popupName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}