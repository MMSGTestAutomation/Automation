using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UI_Pages.MOL.Home;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.MOL.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class ContactDetailsDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(ContactDetailsDefinition));

        /// <summary>
        /// Verify the toggle fuctionality status
        /// </summary>
        /// <param name="toggleStatus">Expected status</param>
        [Then(@"I should be ""(.*)"" toggle betwwen Employee")]
        public void ToggleBetwwenEmployee(string toggleStatus)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ContactDetailsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.AreEqual(toggleStatus, new ContactPage().VerifyTheToggleBetweenEmployeer()));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Should be able t selelct the dropdown
        /// </summary>
        /// <param name="dropDownOption">Option to be clicked </param>
        /// <param name="dropDownName">Option drop down</param>
        [When(@"I select ""(.*)"" in the dropdown ""(.*)"" in Contact Page")]
        public void SelectDropdownInContactPage(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().SelectDropDown(dropDownOption, dropDownName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Pay date
        /// </summary>
        /// <param name="payDateForChangeOption">Option tio be selected</param>
        [When(@"I should Select Pay date for Change as ""(.*)""")]
        public void SelectPayDateForChangeAs(string payDateForChangeOption)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().ClickOnPayDateForChange(payDateForChangeOption);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the benefits from the remove benfit dropdown
        /// </summary>
        [When(@"I select benefit from Remove Benefit dropdown in Contact Page")]
        public void WhenISelectBenefitFromRemoveBenefitDropdownInContactPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().SelectBenefitFromRemoveBenefit();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Preferred contact
        /// </summary>
        /// <param name="optionToBeSelected">Option to be select</param>
        [When(@"I should select ""(.*)"" as Preferred contact in Contact Page")]
        public void SelectAsPreferredContactInContactPage(string optionToBeSelected)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().SelectPreferredContact(optionToBeSelected);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the fields in Contact page
        /// </summary>
        /// <param name="filfieldsTobeFilled">field to be filled</param>
        [When(@"I should fill  ""(.*)"" in Contact Page")]
        public void ShouldFillFielsInInContactPage(string filfieldsTobeFilled)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new ContactPage().FillTheFields(filfieldsTobeFilled);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on submit and verify the Iqueue is created
        /// </summary>
        /// <param name="userType"></param>
        [Then(@"I should verify Iqueue is created when I Click on submit button as ""(.*)""")]
        public void VerifyIqueueIsCreatedWhenIClickOnSibmitButtonAs(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ContactDetailsDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
           Assert.IsTrue(new ContactPage().VerifyIqueueCreatedWhenClickedOnSubmit(userType)));
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}