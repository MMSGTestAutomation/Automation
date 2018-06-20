using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.ROL.ActivationSitePage;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.ROL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class CardActivationDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CardActivationDefinition));

        /// <summary>
        /// Enter the SMS Code and Submit the Code
        /// </summary>
        [When(@"I Enter the SMS and Submit the SMS Code")]
        public void EnterTheSMSAndSubmit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new SMSValidationPage().EnterTheSMSAndSumbit();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page Landed on the selelct Benefit page
        /// </summary>
        [Then(@"I should be on Benefit selection page")]
        public void VerifyPageIsOnbenefitPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new BenefitSelectPage().PageLandedOnSelectBenefitPage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selelct the Benefit by clicking on the checkbox
        /// </summary>
        [When(@"I select the benefit from the page and activate")]
        public void SelelctTheBenefitFromPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new BenefitSelectPage().SelectTheBenefit();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the success Meassage
        /// </summary>
        [Then(@"I should be on success page")]
        public void verifyPageLandedOntheSuccessPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new SuccessPage().PageLandedOnSuccessPage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Congratulation Message
        /// </summary>
        [Then(@"I should see congratulation Message")]
        public void VerifyThecongratulationMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActiavtionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new SuccessPage().CongragulationMessage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}