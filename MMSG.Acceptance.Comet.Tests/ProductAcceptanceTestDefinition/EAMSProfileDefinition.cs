using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.Comet;
using MMSG.Pages.UI_Pages.Comet.Eams;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class EAMSProfileDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(EAMSProfileDefinition));

        /// <summary>
        /// Verify the MOL User name is not null
        /// </summary>
        [Then(@"I should display with the MOL UserName not Empty")]
        public void VerifyNotNullUserName()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Assert.IsTrue(new VerifyBudgetAmountTransactionPage().VerifyTheUserNameIsNotNull());
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Search button
        /// </summary>
        [When(@"I click on employee number")]
        public void ClickOnEmployeeNumber()
        {
            //Click Employee Number
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new VerifyBudgetAmountTransactionPage().ClickEmployeeNumber();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// verify th tree view structure appeare
        /// </summary>
        [Then(@"I should display Tree view structure")]
        public void VerifyTheTreeViewAppeared()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EAMSProfileDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new VerifyBudgetAmountTransactionPage().VerifytheTreeViewAppeare()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Compareing the VMS blance with the DB
        /// </summary>
        [Then(@"I Compare the the VMS value with the DB")]
        public void ComparetheValuewithDB()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EAMSProfileDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
          Assert.IsTrue(new VerifyBudgetAmountTransactionPage().CompareTheVMSAmountWithDB()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click link or delink
        /// </summary>
        [When(@"I click on the Link or Delink")]
        public void ClickLinkOrDelink()
        {
            //Click Employee Number
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new VerifyBudgetAmountTransactionPage().ClickOnTheLinkAndDelinkButton();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Link or delink button
        /// </summary>
        [Then(@"I should display with Link or Delink Button")]
        public void DisplayedWithLinkOrDelink()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EAMSProfileDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            Assert.IsTrue(new VerifyBudgetAmountTransactionPage().VerifyTheButtonLinkAndDelink()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of EAMS ID for newly created employee
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should be 'EAMS' ID for newly created employee ""(.*)""")]
        public void ValidateDisplayOfEamsProfile(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("EAMSProfileDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
             Assert.IsTrue(new WrapperPage().GetEamsProfileIDStatus(userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Dashboard is been displayed
        /// </summary>
        [Then(@"I should display with Dashboard of the user")]
        public void ThenIShouldDisplayWithDashboardOfTheUser()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            //Logger.LogAssertion("EAMSProfileDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
            // Assert.IsTrue(new WrapperPage().GetEamsProfileIDStatus(userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}