using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MMSG.Acceptance.Comet.Tests.ProductAcceptanceTestDefinition
{
    [Binding]
    public sealed class VehicleDefinition : BaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
        Logger.GetInstance(typeof(Package_basedetailsDefinition));

        /// <summary>
        ///  User enters the details in MotorVehicle Registrations Page
        /// </summary>
        [When(@"I Enter all the Details in Motor Vehicle-Registrations page")]
        public void EnterAllTheDetailsInMotorVehicle_RegistrationsPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_RegistrationsPage().EnterDetails();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The details in Motor Vehicle Base page
        /// </summary>
        [When(@"I enter all the details in Motor Vehicle-Base Details")]
        public void EnterAllTheDetailsInMotorVehicle_BaseDetails()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_Base_DetailsPage().EnterMotorBaseDetails();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the details Related to the Vehicle Accessories page
        /// </summary>
        [When(@"I enter all the details in Motor Vehicle-Accessories page")]
        public void EnterAllTheDetailsInMotorVehicle_AccessoriesPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_AccessoriesPage().EnterDetailsInAccessories();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Next button in the Amiunt Page
        /// </summary>
        [When(@"I click on the Next button in Amount Page")]
        public void ClickOnTheNextButtonInAmountPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_AccessoriesPage().ClickOnNextInAmountsPage();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering all the Details of Fueal Card
        /// </summary>
        [When(@"I enter all the details of Fuel Card")]
        public void EnterAllTheDetailsOfFuelCard()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_FuelCardsPage().EnterFuelCardDetails();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clikcing on the Search buttton in Menu bar
        /// </summary> 
        [When(@"I click on the Search in Vechicle menu")]
        public void ClickOnTheSearchInVechicleMenu()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new CallCentreEnquiryPage().ClickingOnSearchInVehicalMenu();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Vehicle using fields
        /// </summary>
        /// <param name="fieldsName">Field used search vehicle</param>
        [When(@"I Search Vehicle using ""(.*)"" feild")]
        public void SearchVehicleUsingFeild(string fieldsName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_SearchPage().SearchVehicleUsingTheField(fieldsName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Option in PopUp in vehicle serch screen
        /// </summary>
        /// <param name="optionName">Option Name to be clicked</param>
        [When(@"I click on ""(.*)"" option in Pop up of Vehicle Search Page")]
        public void ClickOnOptionInPopUpOfVehicleSearchPage(string optionName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            new MotorVehicle_SearchPage().ClickingOnOptionInPopUp(optionName);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Next button in Pages
        /// </summary>
        /// <param name="pageName">Page Name</param>
        [When(@"I click on next Button in ""(.*)"" Page")]
        public void ClickOnNextButtonInPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            switch (pageName)
            {
                case "Motor Vehicle-Registrations":
                    new MotorVehicle_RegistrationsPage().ClickOnNextButton();
                    break;
                case "Motor Vehicle-Base Details":
                    new MotorVehicle_Base_DetailsPage().ClickOnNextButton();
                    break;
                case "Motor Vehicle-Accessories":
                    new MotorVehicle_AccessoriesPage().ClickOnNextButton();
                    break;
                case "Motor Vehicle-Amounts":
                    new MotorVehicle_AccessoriesPage().ClickOnNextInAmountsPage();
                    break;
                case "Motor Vehicle-Fuel Cards":
                    new MotorVehicle_FuelCardsPage().ClickOnSaveButtton();
                    break;
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit the field in pages
        /// </summary>
        /// <param name="fieldName">Field which need to be changed</param>
        /// <param name="PageName">Page which need in which need to be changed</param>
        [When(@"I Change ""(.*)"" in ""(.*)"" Page")]
        public void WhenIChangeInPage(string fieldName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            switch (pageName)
            {
                case "Motor Vehicle-Base Details":
                   new MotorVehicle_Base_DetailsPage().EditField(fieldName);
                    break;

            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the the web components are present
        /// </summary>
        /// <param name="pageName">Page which need to be verified</param>
        [Then(@"I should verify Elements are present in""(.*)""")]
        public void VerifyElementsArePresentIn(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            switch (pageName)
            {
                case "Motor Vehicle-Registrations":
                    Logger.LogAssertion("VehicleDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                     Assert.IsTrue(new MotorVehicle_RegistrationsPage().AllElementArePresent()));                   
                    break;
                case "Motor Vehicle-Base Details":
                    Logger.LogAssertion("VehicleDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                     Assert.IsTrue(new MotorVehicle_Base_DetailsPage().AllElemnetsPresnt()));                   
                    break;
                case "Motor Vehicle-Accessories":
                    Logger.LogAssertion("VehicleDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.IsTrue(new MotorVehicle_AccessoriesPage().AllElements()));                   
                    break;
                case "Motor Vehicle-Amounts":
                    Logger.LogAssertion("VehicleDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                   Assert.IsTrue(new MotorVehicle_AccessoriesPage().AllElementsAccountPage()));                   
                    break;
                case "Motor Vehicle-Fuel Cards":
                    Logger.LogAssertion("VehicleDefinition", ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.IsTrue(new  MotorVehicle_FuelCardsPage().AllElementsPresnt()));                    
                    break;
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

    }
}
