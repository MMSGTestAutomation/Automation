using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class MotorVehicle_SearchPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MotorVehicle_SearchPage));

        /// <summary>
        /// Search the Vechicle uisng the field
        /// </summary>
        /// <param name="fieldName">Field user to search vehicle</param>
        public void SearchVehicleUsingTheField(string fieldName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // searching based on the field name
                switch (fieldName)
                {
                    case "Registration Number":
                        base.WaitForElement(By.Id(MotorVehicle_SearchResource.
                            MotorVehicle_SearchPage_RegistrationTextBox_Id_Locator));
                        base.ClearTextById(MotorVehicle_SearchResource.
                            MotorVehicle_SearchPage_RegistrationTextBox_Id_Locator);
                        base.FillTextBoxById(MotorVehicle_SearchResource.
                            MotorVehicle_SearchPage_RegistrationTextBox_Id_Locator, MotorVehicle_SearchResource.
                            MotorVehicle_SearchPage_RegistrationTextBox_Value);
                        break;
                }
                // clicking on the search button
                IWebElement getSearchproperties = base.GetWebElementProperties(By.Id(MotorVehicle_SearchResource.
                    MotorVehicle_SearchPage_SearchButton_Id_Locator));
                base.ClickByJavaScriptExecutor(getSearchproperties);

                //Verify the result has diplayed
                base.WaitForElement(By.ClassName(MotorVehicle_SearchResource.
                    MotorVehicle_SearchPage_ResultGride_Id_Locator));

                //Clicking on the result
                IWebElement getResultproperties = base.GetWebElementProperties(By.XPath(MotorVehicle_SearchResource.
                    MotorVehicle_SearchPage_ResultGride_Xpath_Locator));
                base.ClickByJavaScriptExecutor(getResultproperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the button in Vehice search PopUp
        /// </summary>
        /// <param name="optionName">Option nedd to be clicked</param>
        public void ClickingOnOptionInPopUp(string optionName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    //Click on the Edite Button in Popup
                    case "Edit Vehicle":
                        base.WaitForElement(By.Id(MotorVehicle_SearchResource.
                            MotorVehicle_SearchPage_ProcessMenuPopup_Id_Locator));
                        base.ClickButtonById(MotorVehicle_SearchResource.
                            MotorVehicle_SearchPage_ProcessMenuPopup_Id_Locator);
                        break;
                }
                base.SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}