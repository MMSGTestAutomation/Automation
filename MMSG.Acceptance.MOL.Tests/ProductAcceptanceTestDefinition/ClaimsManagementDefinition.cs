using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.MOL;
using MMSG.Pages.UI_Pages.MOL.Claims;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class ClaimsManagementDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ClaimsManagementDefinition));

        /// <summary>
        /// Verify the page landed on the expepcted page
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        [Then(@"I should be display with page ""(.*)""")]
        public void VerifyThePageName(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new SelectBenefitPage().VerifyThePageLanded(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// selecting theBenefit and Click on the Start reimbursement button
        /// </summary>
        [When(@"I select the Benefit and Click on Start Reimbursement button")]
        public void SelectTheBenefitAndClickOnReembusmentButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new SelectBenefitPage().SelectTheBenefitAndStartReimbursement();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the upload screen page
        /// </summary>
        /// <param name="pageName">page name</param>
        [Then(@"I should be display with ""(.*)""")]
        public void VerifyThepageLandedOnTheUploadPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new UploadReceiptPage().VerifyThepageLandedOnTheUploadpage(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the uplaod button
        /// </summary>
        /// <param name="uplaodType">upload button</param>
        [When(@"I click on the ""(.*)"" button")]
        public void ClinkOnTheUploadButton(string uplaodType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new UploadReceiptPage().ClickingOnTheUploadButton(uplaodType);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload the claim
        /// </summary>
        [When(@"I upload the Claim invoices and Click on Processed button")]
        public void UploadTheClaimInvoices()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new UploadReceiptPage().UploadForm();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// VerifyTehpageLanded On the Claim details
        /// </summary>
        /// <param name="pageName">Page Name to be validate</param>
        [Then(@"I should be display with ""(.*)"" page")]
        public void VerifyTheClaimDetailPageLanded(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.IsTrue(new ClaimDetailsPage().VerifyPageLandedOnClaimDetails(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the Value to text box
        /// </summary>
        /// <param name="textBoxName">Text box name</param>
        [When(@"I enter ""(.*)"" in ""(.*)"" textbox")]
        public void EnterTheValueToTextBox(string valueType, string textBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ClaimDetailsPage().EnterValueToText(valueType, textBoxName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Process button
        /// </summary>
        [When(@"I click on Proceed button")]
        public void ClickingOnTheProceedButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ClaimDetailsPage().ClickOnTheProcessedButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the Submit page
        /// </summary>
        /// <param name="pageName">Page Name</param>
        [Then(@"I should be display with ""(.*)"" page name")]
        public void VerifyThepageLandedOntheSubmitPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new SubmitClaimPage().VerifyThepageLandedOnTheSubmitClaimPage(pageName)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on thechecking box
        /// </summary>
        /// <param name="checkBoxName">Check box name</param>
        [When(@"I click on ""(.*)"" CheckBox")]
        public void ClickOnTheCheckBox(string checkBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new SubmitClaimPage().ClickOnTheAcceptancesCheckBox(checkBoxName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the submit button
        /// </summary>
        [When(@"I click on the Submit button")]
        public void WhenIClickOnTheSubmitButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new SubmitClaimPage().ClickOnTheSubmitButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the SucessMeassage
        /// </summary>
        [Then(@"I should see success messages")]
        public void VerifyTheSucessMeassageDispalyed()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.IsTrue(new SubmitClaimPage().VerifyTheSuccessMessages()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the No Reimbusment message is been dispalyed
        /// </summary>
        /// <param name="pageName">Message text</param>
        [Then(@"I should be display with ""(.*)"" Message")]
        public void ThenIShouldBeDisplayWithMessage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ClaimsManagementDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(pageName.Trim(), new SelectBenefitPage().VerifyTheNoReiembusmentMessage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the button in Claim status page
        /// </summary>
        /// <param name="buttonName">Button name to be clicked</param>
        [When(@"I click on ""(.*)"" Button in Claim Status page")]
        public void ClikcingOnButtonInClaimStatusPage(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ClaimStatusPage().ClickOnAddNewClaimButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}