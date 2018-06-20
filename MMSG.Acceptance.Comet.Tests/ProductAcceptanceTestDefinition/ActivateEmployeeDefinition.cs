﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class ActivateEmployeeDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(ActivateEmployeeDefinition));

        /// <summary>
        /// Verify the Pop has appeared
        /// </summary>
        /// <param name="popUpTitle"> pop up title</param>

        [Then(@"I should be display with ""(.*)"" Pop up in Call Centre Enqiury screen")]
        public void VerifyAmendmentPage(string popUpTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ActivateEmployeeDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(popUpTitle, new CallCentreEnquiryPage().GetTheTitleOfpopUp()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the element in Pop Up
        /// </summary>
        /// <param name="clickOnOption">option need to clicked</param>
        [When(@"I click on ""(.*)"" option in Pop up")]
        public void SelelctAdminFeesInPopUp(string clickOnOption)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().ProcessMenuPopUpClickOnElement(clickOnOption);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the Admin Fees for Package
        /// </summary>
        /// <param name="pageTitle">Title of the apge</param>

        [Then(@"I should be display with  ""(.*)"" in title")]
        public void VerifyThePageHeader(string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ActivateEmployeeDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(pageTitle, new AdminFeesForPackagePage().VerifyPageLandedOnAdminFees()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the effective Date in to the text box
        /// </summary>
        [When(@"I enter Effective Date in Admin Fees for Package")]
        public void EnteringTheEffectiveDate()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AdminFeesForPackagePage().EnterTheEffectiveDate();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User click on the look up image and selelct the fees name from the pop up
        /// </summary>
        [When(@"I should Click on the lookup button and select Fees Name from PopUp")]
        public void ClickingOnLookupImgAndsectingTheFees()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AdminFeesForPackagePage().ClickOnLookUpImgAndSelelctFeesName();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Add button and save the fees
        /// </summary>
        [When(@"I click on Add button and Save the Fees")]
        public void ClickOnTheAddButtonAndSaveTheAdminFees()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new AdminFeesForPackagePage().ClickOnAddAndSaveTheFees();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page landed on the review and Activate Page
        /// </summary>
        [Then(@"I should Display the Review And Activate Package")]
        public void VerifyThePageLandedOnTheReviewAndActivatePage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ActivateEmployeeDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new ReviewActivatePage().VerifyThePageLandedOnReviewAndActivatePage()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Save button in Review and Activate button
        /// </summary>
        [When(@"I click on Save button in Review and Activate Page")]
        public void ClickingOnTheSaveButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ReviewActivatePage().ClickOnSaveButtonOnReviwAndActivatePage();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the status of Employee
        /// </summary>
        [Then(@"I should display the package status as Active")]
        public void VerifytheStatusOfThePage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().VerifyThePackageStatusAsActive();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Confirm general PAC information
        /// </summary>
        [When(@"I Confirm the General PAC information")]
        public void ConfirmTheGeneralPACInformation()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ReviewActivatePage().ConfirmGeneralPACInformation();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}