using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.BatchProcess;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages;
using MMSG.Pages.UI_Pages.Comet;
using MMSG.Pages.UI_Pages.MOL.ActivationSitePages;
using System.Threading;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class CardActivationDefinition : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(CardActivationDefinition));

        /// <summary>
        /// Verify the page landed on the Maxxia Wallet page
        /// </summary>
        [Then(@"I should dispalay with Maxxia Wallet Page")]
        public void VerifyThePageLandedOnMaxxiaWallet()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("CardActivationDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new MaxxiaWalletPage().VerifyThePageLandedOnMaxxiaWalletPage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check the status of the card
        /// </summary>
        /// <param name="expepctedStatus">Expected Status of the Card</param>
        [Then(@"I should be display with Card status as ""(.*)""")]
        public void VerifyTheStatusOdCard(string expepctedStatus)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyTheStatusOdCard", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(expepctedStatus, new MaxxiaWalletPage().GetTheStatusOfCard()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click cancel button
        /// </summary>
        [When(@"I click on cancel button")]
        public void ClickOnCancelButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MaxxiaWalletPage().ClickCancelButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Run the Batch
        /// </summary>
        [When(@"I run OrderCard Batch using Power Shell script")]
        public void ExecuteTheOrderBatch()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            BatchProcessTest batchProcessTest = new BatchProcessTest();
            batchProcessTest.ExecuteBatchProcess();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
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
        /// Enter Date of birth and car activation code
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        [When(@"I enter 'Date of Birth' and 'Card Activation Code' of ""(.*)"" in ""(.*)"" application")]
        public void EnterDOBandCardActivationCode(User.UserTypeEnum userType, string productName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().EnterDOBAndCardActivationCode(userType, productName);
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should be on page ""(.*)""")]
        public void ValidatePageName(string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Assert the expected value with the actual value
            //Get current opened page title
            string actualPageTitle = GetPageTitle;
            Thread.Sleep(2000);
            //Assert we have correct page opened
            Assert.IsTrue(actualPageTitle.Contains(pageTitle));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
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
        /// Click continue button
        /// </summary>
        [When(@"I click on Continue button")]
        public void ClickContinueButtonMOLRegestrationPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new LoginPage().ClickContinueButtonMOL();
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

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
    }
}