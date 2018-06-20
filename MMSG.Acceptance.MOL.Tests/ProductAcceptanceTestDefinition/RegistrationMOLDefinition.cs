using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class RegistrationMOLDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(RegistrationMOLDefinition));

        /// <summary>
        /// Cliking on the button
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click on Button ""(.*)""")]
        public void ClickBasedOnButtonName(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().ClickOnButtonMOL(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify page landed on the Registration page
        /// </summary>
        /// <param name="pageName">Page name</param>
        [Then(@"I should be on ""(.*)""")]
        public void VerifyThePageLandedOnRegister(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("RegistrationMOLDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(pageName, new ApplicationRegistrationPage().VerifyThePageLandedOnTheRegisterpage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Email Id in Email text box
        /// </summary>
        /// <param name="emailType">This is email type.</param>
        [When(@"I enter ""(.*)"" email")]
        public void EnterTheEmailId(string emailType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplicationRegistrationPage().EnterTheEmailROL(emailType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click regestor email
        /// </summary>
        /// <param name="ButtonName">This is button name.</param>
        [When(@"I click on Button ""(.*)"" in Register page")]
        public void ClickOnTheRegisterButton(string ButtonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ApplicationRegistrationPage().RegisterButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the error message
        /// </summary>
        /// <param name="errorMessageType">error type</param>
        [Then(@"I should be dispalyed with ""(.*)""")]
        public void ErrorMessageValidation(string errorMessageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("RegistrationMOLDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new ApplicationRegistrationPage().VerifyTheErrorMessage(errorMessageType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}