using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class MotorVehicle_FuelCardsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MotorVehicle_FuelCardsPage));

        /// <summary>
        /// Enter the details in Fual card Page
        /// </summary>
        public void EnterFuelCardDetails()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Selecting the Fuel Card Supplier from Drop Down
                WaitForElement(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardSupplierDropDown_Id_Locator));
                SelectDropDownValueThroughIndexById(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardSupplierDropDown_Id_Locator, 3);

                // geting the Effective Date
                string getDateText = GetInnerTextAttributeValueByXPath(
                   Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string EffectiveDateText = getDate.Replace(")", "").Trim();

                // Entering  Date Request Received Date
                WaitForElement(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_DateRequestReceivedTextBox_Id_Locator));
                FillTextBoxById(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_DateRequestReceivedTextBox_Id_Locator, EffectiveDateText);

                //Selecting the Fuel Card Version from Drop Down
                WaitForElement(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardVersionDropDown_Id_Locator));
                SelectDropDownValueThroughIndexById(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardVersionDropDown_Id_Locator, 1);

                //Clicking on The add button
                WaitForElement(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_AddButton_Id_Locator));
                IWebElement getAddProperties = GetWebElementProperties(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_AddButton_Id_Locator));
                ClickByJavaScriptExecutor(getAddProperties);

                string registerPageTitle = GetCometDomain() + " Motor Vehicle-Fuel Cards";
                WaitUntilPopUpLoads(registerPageTitle);
                SelectWindow(registerPageTitle);
                //Wait for thr Result grid to appeare
                WaitForElement(By.XPath(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_ResultGrid_Xpath_Locator));

                //Clicking on the Save Button
                WaitForElement(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_SaveButton_Id_Locator));
                IWebElement getSaveButtonProperties = GetWebElementProperties(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_SaveButton_Id_Locator));
                ClickByJavaScriptExecutor(getSaveButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the save button in MotorVehicle_FuelCardsPage
        /// </summary>
        public void ClickOnSaveButtton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Clicking on the Save Button
                WaitForElement(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_SaveButton_Id_Locator));
                IWebElement getSaveButtonProperties = GetWebElementProperties(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_SaveButton_Id_Locator));
                ClickByJavaScriptExecutor(getSaveButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify all the elements are present
        /// </summary>
        /// <returns>True if all elements are present</returns>
        public bool AllElementsPresnt()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool isElement = false;
            try
            {
                bool isFuelCardSupplier = IsElementPresent(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardSupplierDropDown_Id_Locator));
                bool isDateRequestReceived = IsElementPresent(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardSupplierDropDown_Id_Locator));
                bool isFuelCardVersion = IsElementPresent(By.Id(MotorVehicle_FuelCardsResource.
                    MotorVehicle_FuelCardsPage_FuelCardSupplierDropDown_Id_Locator));

                if (isFuelCardSupplier && isDateRequestReceived && isFuelCardVersion)
                {
                    isElement = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return isElement;
        }
    }
}