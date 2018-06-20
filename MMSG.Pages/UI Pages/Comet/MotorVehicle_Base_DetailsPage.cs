using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class MotorVehicle_Base_DetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MotorVehicle_Base_DetailsPage));

        /// <summary>
        /// Enter the Accessories Details
        /// </summary>
        public void EnterMotorBaseDetails()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Make name from DropDown
                WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.MotorVehicle_Base_Details_MakeDropDown_Id_Locator));
                SelectDropDownValueThroughTextById(MotorVehicle_Base_DetailsResource.MotorVehicle_Base_Details_MakeDropDown_Id_Locator,
                    MotorVehicle_Base_DetailsResource.MotorVehicle_Base_Details_Make_Value);

                string pageTitle = GetCometDomain() + " Motor Vehicle-Base Details";
                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                //Select the Year of Manufacture
                WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_YearOfManufactureDropDown_Id_Locator));
                SelectDropDownValueThroughTextById(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_YearOfManufactureDropDown_Id_Locator, MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_YearOfManufacture_Value);

                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                // Select the Model
                WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ModelDropDown_Id_Locator));
                SelectDropDownValueThroughTextById(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ModelDropDown_Id_Locator, MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ModelDropDown_Value);

                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                //Enter the Colour
                WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ColourTextBox_Id_Locator));
                ClearTextById(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ColourTextBox_Id_Locator);
                FillTextBoxById(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ColourTextBox_Id_Locator, MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_ColourTextBox_Value);

                //Click on the Next Button
                WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_NextButton_Id_Locator));
                IWebElement nextButtonProperties = base.GetWebElementPropertiesById(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_NextButton_Id_Locator);
                ClickByJavaScriptExecutor(nextButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Next button in the page
        /// </summary>
        public void ClickOnNextButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Next Button
                WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.
                 MotorVehicle_Base_Details_NextButton_Id_Locator));
                IWebElement nextButtonProperties = base.GetWebElementPropertiesById(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_NextButton_Id_Locator);
                ClickByJavaScriptExecutor(nextButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit the Field in the page
        /// </summary>
        /// <param name="fieldName">Field to be changed</param>
        public void EditField(string fieldName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (fieldName)
                {
                    case "Colour":
                        WaitForElement(By.Id(MotorVehicle_Base_DetailsResource.
                  MotorVehicle_Base_Details_ColourTextBox_Id_Locator));
                        ClearTextById(MotorVehicle_Base_DetailsResource.
                            MotorVehicle_Base_Details_ColourTextBox_Id_Locator);
                        FillTextBoxById(MotorVehicle_Base_DetailsResource.
                            MotorVehicle_Base_Details_ColourTextBox_Id_Locator, "blue");
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the elements are presnt
        /// </summary>
        /// <returns>true if the elemnets rae present</returns>
        public bool AllElemnetsPresnt()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool iselement = false;
            try
            {
                bool isVehicleIdentificationNumber = IsElementPresent(By.Id(MotorVehicle_Base_DetailsResource.
                    MotorVehicle_Base_Details_VehicleIdentificationNumberTextBox_Id_Locator));
                bool isMake = IsElementPresent(By.Id(MotorVehicle_Base_DetailsResource.
                   MotorVehicle_Base_Details_MakeDropDown_Id_Locator));
                bool isYearOfManufacture = IsElementPresent(By.Id(MotorVehicle_Base_DetailsResource.
                   MotorVehicle_Base_Details_YearOfManufactureDropDown_Id_Locator));
                bool isModel = IsElementPresent(By.Id(MotorVehicle_Base_DetailsResource.
                   MotorVehicle_Base_Details_ModelDropDown_Id_Locator));
                bool isColour = IsElementPresent(By.Id(MotorVehicle_Base_DetailsResource.
                   MotorVehicle_Base_Details_ColourTextBox_Id_Locator));

                if (isVehicleIdentificationNumber && isMake && isModel && isColour)
                {
                    iselement = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return iselement;
        }
    }
}