using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class RegistrationROLDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(RegistrationROLDefinition));

        /// <summary>
        /// Clicking on the Button
        /// </summary>
        /// <param name="buttonName">Button name</param>
        [When(@"I click on Button ""(.*)""")]
        public void ClickOnTheButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().ClickOnButtonROL(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page lannded on the Expected page
        /// </summary>
        /// <param name="pageName">Page Name</param>
        [Then(@"I should be on ""(.*)"" page of ROL")]
        public void VerifyPageLAndedOnTheRegistrationPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("RegistrationROLDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(pageName, new ApplicationRegistrationPage().VerifyThePageLandedOnTheRegisterpageOfROL()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Email Id
        /// </summary>
        /// <param name="emailType">Email Id Type</param>
        [When(@"I enter ""(.*)"" email")]
        public void EnterTheEmailType(string emailType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplicationRegistrationPage().EnterTheEmailROL(emailType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the button
        /// </summary>
        /// <param name="buttonName">This is button name</param>
        [When(@"I click on Button ""(.*)"" in Register page")]
        public void ClickOnTheRegisterButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplicationRegistrationPage().RegisterButtonROL();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the error message if the error message as expected returens true
        /// </summary>
        /// <param name="errorMessageType">This is message type</param>
        [Then(@"I should be dispalyed with ""(.*)""")]
        public void ValidateTheMessage(string errorMessageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("Employee_personaldetailsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new ApplicationRegistrationPage().VerifyTheErrorMessageROL(errorMessageType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}