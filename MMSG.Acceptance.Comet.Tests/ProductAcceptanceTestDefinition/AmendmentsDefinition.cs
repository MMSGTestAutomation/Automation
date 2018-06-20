using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public class AmendmentsDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(AmendmentsDefinition));

        /// <summary>
        /// Verify the display of Amendment page
        /// </summary>
        [Then(@"I should be on the Amendment page")]
        public void VerifyAmendmentPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("AmendmentsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new AmendmentPage().VerifyThepageLandedOnAmendment()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the New Button in Amendment Screen
        /// </summary>
        /// <param name="clickOption">Button Name</param>
        [When(@"I click on ""(.*)"" in Amendment page")]
        public void ClickingOnTheAmendmentOption(string clickOption)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AmendmentPage().ClickOnOption(clickOption);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the apge landed on the Amendment Benefit page
        /// </summary>
        /// <param name="pageName"> Page Name</param>
        [Then(@"I should be display ""(.*)"" in Amendments_NewBenefits Page")]
        public void VerifyThePageLandedOnAmendmentBenefit(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("AmendmentsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new Amendment_BenefitPage().VerifyPageLandedOnAmendmentBenefitPage(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the benefit from the dropdown
        /// </summary>
        /// <param name="benefitType">Benenfit type</param>
        [When(@"I select Benefit for ""(.*)""")]
        public void SelctingTheBenefitDropdown(Benefit.BenefitTypeEnum benifitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().SelectTheBenefitDropDown(benifitType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the Effective date
        /// </summary>
        [When(@"I enter Effective date in Amendments_NewBenefits Page")]
        public void EnteringTheEffectiveDate()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().EffectiveDate();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selcying the Pay date in the drop down
        /// </summary>
        [When(@"I select Next Paydate for change")]
        public void SelelctingTheNextPayDate()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().NextPayDate();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Budget calcution method type
        /// </summary>
        /// <param name="calculationMethodType">Budget Method type</param>
        [When(@"I select Budget Calculation Method of ""(.*)""")]
        public void SelelctingTheCalculationMethodType(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().BudgetCalculationMethod(benefitType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the amount to the Txt box budget ammount
        /// </summary>
        /// <param name="budgetAmount">Budget Amount</param>

        [When(@"I enter the Budget Amount of ""(.*)""")]
        public void EnteringTheBudgetAmount(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().BudgetAmount(benefitType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the save button in the amendmentBenefit page
        /// </summary>

        [When(@"I enter save Button in Amendments_NewBenefits Page")]
        public void ClickingOnTheaSaveButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new Amendment_BenefitPage().ClickOnSaveButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checking the Benefit is added and displayed in the amendment Page
        /// </summary>
        /// <param name="benefitname">Benefit Name which needto be added </param>
        [Then(@"I should see the New benefit Name of ""(.*)""")]
        public void VerifyingTheBenefitIsBeenAdded(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("AmendmentsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new AmendmentPage().BenefitIsAdded(benefitType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}