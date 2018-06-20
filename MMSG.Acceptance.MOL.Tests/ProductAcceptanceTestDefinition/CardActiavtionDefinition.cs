using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.MOL.ActivationSitePages;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class CardActiavtionDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CardActiavtionDefinition));

        /// <summary>
        /// Running the store Proc
        /// </summary>
        /// <param name="SMSStorPoc">Store proc name </param>
        [When(@"I run the ""(.*)"" Store proc to handel SMS validation")]
        public void RunTheStoreProcTodisabeOeEnbaleSMSValidation(string SMSStorPoc)
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            new ActivateLogin().SMSValidationControler(SMSStorPoc);
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Running the store poc
        /// </summary>
        /// <param name="storeProcName">Name of the Store Proc</param>
        [When(@"I should run Store Poc ""(.*)"" to insert Data to Respective Table")]
        public void WhenIShouldRunStorePocToInsertDataToRespectiveTable(string storeProcName)
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            new ActivateLogin().RunningStoreProcToInsertInTable(storeProcName);
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the SMS and Submit the SMS Code
        /// </summary>
        [When(@"I Enter the SMS and Submit the SMS Code")]
        public void EnterTheSMSAndSubmit()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            new SMSValidationPage().EnterTheSMSAndSumbit();
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the SMS Authenticate page
        /// </summary>
        [Then(@"I should be on SMS Authenticate page")]
        public void VerifyTheDisplaOfSMSAuthenticatePage()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new SMSValidationPage().PageLandedOnSmSValidtionPage()));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selelct the Bebefit from the Screen
        /// </summary>
        [Then(@"I should be on Benefit selection page")]
        public void VerifyPageIsOnbenefitPage()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new BenefitSelectPage().PageLandedOnSelelctBenefitPage()));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Bebefit and activate the page
        /// </summary>
        [When(@"I select the benefit from the page and activate")]
        public void SelelctTheBenefitFromPage()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            new BenefitSelectPage().SelelctTheBenefit();
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the Success page
        /// </summary>
        [Then(@"I should be on success page")]
        public void verifyPageLandedOntheSuccessPage()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new SuccessPage().PageLandedOnSuccessPage()));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Congragulation Message
        /// </summary>
        [Then(@"I should see congragulation Message")]
        public void VerifySuccessMessage()
        {
            Logger.LogMethodEntry(base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new SuccessPage().CongragulationMessage()));
            Logger.LogMethodExit(base.IsTakeScreenShotDuringEntryExit);
        }
    }
}