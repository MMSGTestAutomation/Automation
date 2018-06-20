using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class PaymentInstructionDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(PaymentInstructionDefinition));

        /// <summary>
        /// Verify the benefit grid is dispalyed
        /// </summary>
        [Then(@"I should be display with the Benefit Grid")]
        public void VerifyBenefitGridHasAppeared()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("PaymentInstructionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new CallCentreEnquiryPage().VerifyTheBenefitGridHasAppeared()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on The Benefit in the grid
        /// </summary>
        [When(@"I click on the Benefit in benefit grid")]
        public void ClickingOnThebenefitofGrid()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().ClickingOnTheBenefitOfGrid();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the Payment Instruction page
        /// </summary>
        [Then(@"I should see ""(.*)"" as title in Payment Instruction Page")]
        public void VerifyPageLandedOnPaymentInstruction(string pageTypeOfPaymentInstruction)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("PaymentInstructionDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new PaymentInstructionPage().VerifyThePagePageLandedOnPaymentInstruction(pageTypeOfPaymentInstruction)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill all the details in Payment instruction page
        /// </summary>
        [When(@"I should fill the all the details for payment type ""(.*)"" and Payment Frequency ""(.*)""")]
        public void FillDetailsInPaymentInstructionPage(string paymentType, string paymentFrequency)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new PaymentInstructionPage().FillThedetailsInPaymentInstructionPage(paymentType, paymentFrequency);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click in on the cancel button on the Edit payment instruction page
        /// </summary>
        [When(@"I click on the Cancel Button on the Edit Payment Instruction page")]
        public void ClickOnPayentInstructionCancelButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new PaymentInstructionPage().ClickOnEditePaymentInstructionCancelButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}