using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using MMSG.Pages.UI_Pages.Comet.IQueuePages;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class IqueueDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(IqueueDefinition));

        /// <summary>
        /// Verify the Iqueue pop has displayed
        /// </summary>
        /// <param name="popUpName">Pop Name</param>
        [Then(@"I should be display with ""(.*)"" Pop up")]
        public void VerifyThePopupName(string popUpName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("IqueueDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(popUpName, new CreateRequestPage().VerifyThePageLandedOnTheCreatePage()));
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selelct the drop down option
        /// </summary>
        /// <param name="TabName">Tab Name to be Filled</param>
        [When(@"I fill details in ""(.*)""")]
        public void FillingTheTabDetails(string TabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CreateRequestPage().FillDataInTab(TabName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Submit the Iqueue Request
        /// </summary>
        [When(@"I Submit the IQueue")]
        public void ClickingOnTheSubmitButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CreateRequestPage().ClickOnSubmitButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the page is loaded
        /// </summary>
        /// <param name="pageName">page name</param>
        [Then(@"I should be displayed ""(.*)""")]
        public void VerifyPageLandedOnMaxxiaWalletPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyPageLandedOnMaxxiaWalletPage", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(pageName, new SearchForCoustomerRequetsPage().VerifyThePageLandedOnMaxxiaWalletPage()));
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Request Id
        /// </summary>
        [When(@"I click on Request ID")]
        public void ClickingOnReqiestId()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new SearchForCoustomerRequetsPage().ClickOnTheRequestId();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the button on the view request Id
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I Click on ""(.*)""in View Request Iqueue page")]
        public void ClickButtonOnViewRequestPage(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ViewRequestPage().ClickOnButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the close button
        /// </summary>
        [When(@"I close the PopUp in View Request page")]
        public void ClickinOnTheCloseButtonOnpopUp()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ViewRequestPage().ClosePopUp();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the statue og the Iqueue
        /// </summary>
        /// <param name="statusName">This is status message.</param>
        [Then(@"I display with IQueue status as ""(.*)""")]
        public void VerifyTheStatus(string statusName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("IQueueDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.AreEqual(statusName, new SearchForCoustomerRequetsPage().IQueueStatus()));
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the cancel button on the search screen
        /// </summary>
        /// <param name="buttonName">Button name to click.</param>
        [When(@"I click on the ""(.*)"" button")]
        public void ClickingOnCancelButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new SearchForCoustomerRequetsPage().ClickOnTheCancelButton(buttonName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}