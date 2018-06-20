using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class MotorVehicle_AccessoriesPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MotorVehicle_AccessoriesPage));

        /// <summary>
        /// Enter the details in Accessries page
        /// </summary>
        public void EnterDetailsInAccessories()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Fill the details in Description
                WaitForElement(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_DescriptionTextBox_Id_Locator));
                FillTextBoxById(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_DescriptionTextBox_Id_Locator,
                    MotorVehicle_AccessoriesResource.MotorVehicle_AccessoriesPage_DescriptionTextBox_Value);

                //Fill the cost of Accessories
                WaitForElement(By.Id(MotorVehicle_AccessoriesResource.MotorVehicle_AccessoriesPage_CostTxetBox_Id_Locator));
                FillTextBoxById(MotorVehicle_AccessoriesResource.MotorVehicle_AccessoriesPage_CostTxetBox_Id_Locator,
                    MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_CostTxetBox_Value);

                //Click on the Add button
                base.WaitForElement(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_AddButton_Id_Loctor));
                IWebElement addButtonProperties = base.GetWebElementProperties(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_AddButton_Id_Loctor));
                ClickByJavaScriptExecutor(addButtonProperties);

                string registerPageTitle = GetCometDomain() + " Motor Vehicle-Accessories";
                WaitUntilPopUpLoads(registerPageTitle);
                SelectWindow(registerPageTitle);
                //Wait for the Result grid to appeare
                WaitForElement(By.XPath(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_Resultgrid_Xpath_Locator));

                // Click on the Next button
                base.WaitForElement(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_NextButton_Id_Locator));
                IWebElement nextButtonProperties = base.GetWebElementProperties(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_NextButton_Id_Locator));
                ClickByJavaScriptExecutor(nextButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Next Button in Accessories page
        /// </summary>
        public void ClickOnNextButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                string registerPageTitle = GetCometDomain() + " Motor Vehicle-Accessories";
                WaitUntilPopUpLoads(registerPageTitle);
                SelectWindow(registerPageTitle);
                WaitForElement(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_NextButton_Id_Locator));
                IWebElement nextButtonProperties = base.GetWebElementProperties(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_NextButton_Id_Locator));
                ClickByJavaScriptExecutor(nextButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the next button in Amount Page of Vehicle creation
        /// </summary>
        public void ClickOnNextInAmountsPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement nextButtonProperties = base.GetWebElementProperties(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_AmuntPageNextButton_Id_Locator));
                ClickByJavaScriptExecutor(nextButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Elements are present
        /// </summary>
        /// <returns></returns>
        public bool AllElements()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool isElements = false;
            try
            {
                string a = GetPageTitle;
                string registerPageTitle = GetCometDomain() + " Motor Vehicle-Accessories";
                WaitUntilPopUpLoads(registerPageTitle);
                SelectWindow(registerPageTitle);
                bool isAccessoryDescription = IsElementPresent(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_DescriptionTextBox_Id_Locator));
                bool isAccessoryCost = IsElementPresent(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_CostTxetBox_Id_Locator));
                if (isAccessoryDescription && isAccessoryCost)
                {
                    isElements = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return isElements;
        }

        /// <summary>
        /// Verify the Elements are present
        /// </summary>
        /// <returns>True if Elemnets are present</returns>
        public bool AllElementsAccountPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool isElements = false;
            try
            {
                bool isTotalRequiredVehicleIncome = IsElementPresent(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_TotalRequestVehicleIncome_Id_Locator));
                bool isPreTaxIncomeComp = IsElementPresent(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_PreTaxIncomeComp_Id_Locator));
                bool isPostTaxIncomeComp = IsElementPresent(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_PostTaxIncomeComp_Id_Locator));
                bool isFBTIncomeComp = IsElementPresent(By.Id(MotorVehicle_AccessoriesResource.
                    MotorVehicle_AccessoriesPage_FBTIncomeComp_Id_Locator));
                if (isTotalRequiredVehicleIncome && isPreTaxIncomeComp && isPostTaxIncomeComp && isFBTIncomeComp)
                {
                    isElements = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return isElements;
        }
    }
}