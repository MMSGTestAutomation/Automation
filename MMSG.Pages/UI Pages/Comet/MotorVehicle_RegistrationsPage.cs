using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class MotorVehicle_RegistrationsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MotorVehicle_RegistrationsPage));

        /// <summary>
        ///  Get The Page Title oof the page
        /// </summary>
        /// <param name="expectedPageTitle">Title need to be validated</param>
        /// <returns>Title Value</returns>
        public string GetThePageTitle(string expectedPageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string popupTitle = null;
            try
            {
                base.SwitchToDefaultWindow();
                base.SwitchToWindow(expectedPageTitle);
                base.WaitUntilWindowLoads(expectedPageTitle);
                // Get page title
                popupTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return popupTitle;
        }

        /// <summary>
        /// Enter the details in Registration page
        /// </summary>
        public void EnterDetails()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Fill the details in Registration Number
                ClearTextById(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_RegistrationNumberText_ID_Locator);
                FillTextBoxById(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_RegistrationNumberText_ID_Locator, MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_RegistrationNumberText_Value);

                //Select State of Registration in Drop Down
                SelectDropDownValueThroughIndexById(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_StateRegistrationDropDown_ID_Locator, 3);

                //Enter the Effective the date
                string getDateText = base.GetInnerTextAttributeValueByXPath(
                   Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string EffectiveDateText = getDate.Replace(")", "").Trim();
                ClearTextById(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_EffectiveDateTextBox_Id_Locator);
                FillTextBoxById(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_EffectiveDateTextBox_Id_Locator, EffectiveDateText);

                //Clicking on the add Button
                WaitForElement(By.Id(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_AddButton_Id_Locator));
                IWebElement getAddButtonProperties = base.GetWebElementProperties(By.Id(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_AddButton_Id_Locator));
                ClickByJavaScriptExecutor(getAddButtonProperties);

                string registerPageTitle = GetCometDomain() + " Motor Vehicle-Registrations";
                WaitUntilPopUpLoads(registerPageTitle);
                SelectWindow(registerPageTitle);
                // Click on the Result Grid Appeared
                WaitForElement(By.Id(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_ResultGrid_Id_Locator));

                //Click On the next Button
                WaitForElement(By.Id(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_NextButton_Id_Locator));
                IWebElement saveButton = base.GetWebElementProperties(By.Id(MotorVehicle_RegistrationsResource.
                     MotorVehicle_Registrations_NextButton_Id_Locator));
                ClickByJavaScriptExecutor(saveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Next button in the Page
        /// </summary>
        public void ClickOnNextButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(MotorVehicle_RegistrationsResource.
                  MotorVehicle_Registrations_NextButton_Id_Locator));
                IWebElement saveButton = GetWebElementProperties(By.Id(MotorVehicle_RegistrationsResource.
                     MotorVehicle_Registrations_NextButton_Id_Locator));
                ClickByJavaScriptExecutor(saveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify elements are present
        /// </summary>
        /// <returns>True if all Elements are present</returns>
        public bool AllElementArePresent()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool elements = false;
            try
            {
                bool isRegistration_NumberTextBoxPresent = IsElementPresent(By.Id(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_RegistrationNumberText_ID_Locator));
                bool isState_of_RegistrationPresent = IsElementPresent(By.Id(MotorVehicle_RegistrationsResource.
                    MotorVehicle_Registrations_StateRegistrationDropDown_ID_Locator));
                bool isEffectiveDateTextBox_Present = IsElementPresent(By.Id(MotorVehicle_RegistrationsResource.
                  MotorVehicle_Registrations_EffectiveDateTextBox_Id_Locator));
                if (isRegistration_NumberTextBoxPresent && isState_of_RegistrationPresent && isEffectiveDateTextBox_Present)
                {
                    elements = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return elements;
        }
    }
}