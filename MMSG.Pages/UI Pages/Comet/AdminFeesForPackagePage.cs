using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class AdminFeesForPackagePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AdminFeesForPackagePage));

        /// <summary>
        /// Verify the page landed on the Admin Fees For Package pge
        /// </summary>
        /// <returns>Return page title</returns>
        public string VerifyPageLandedOnAdminFees()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageHeader = "";
            try
            {
                // Switch to popup
                SwitchToPopup();
                // Get the popup title
                pageHeader = GetInnerTextAttributeValueByXPath(AdminFeesForPackageResource.
                    AdminFeesForPackage_PageTitle_Xpath_Locator);
                return pageHeader;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return pageHeader;
        }

        /// <summary>
        /// Enter the effective date in the Admin fees for Package
        /// </summary>
        public void EnterTheEffectiveDate()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get effective date from the application
                string getDateText = GetInnerTextAttributeValueByXPath(
                    Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string EffectiveDateText = getDate.Replace(")", "").Trim();
                // Fill the Effective date in Admin fee page
                WaitForElement(By.Name(AdminFeesForPackageResource.
                    AdminFeesForPackage_EffectiveDate_ID_Locator));
                FillTextBoxByName(AdminFeesForPackageResource.
                    AdminFeesForPackage_EffectiveDate_Name_Locator,
                    EffectiveDateText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on look up image and selelcting the fees
        /// </summary>
        public void ClickOnLookUpImgAndSelelctFeesName()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // switching on the pop up
                SwitchToPopup();
                // waiting for the admin look up image
                WaitForElement(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_LookUpImg_ID_Locator));
                IWebElement lookUpImg = GetWebElementProperties(By.Id(AdminFeesForPackageResource.
                    AdminFeesForPackage_LookUpImg_ID_Locator));
                ClickButtonById(AdminFeesForPackageResource.AdminFeesForPackage_LookUpImg_ID_Locator);
                SwitchToPopup();
                //Selelcting the fees from Pop Up
                SelelctTheFeesTypeFromPopUp();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selelcting the fees type from the pop up
        /// </summary>
        public void SelelctTheFeesTypeFromPopUp()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // switch to pop up window
                SwitchToPopup();
                WaitUntilPopUpLoads(AdminFeesForPackageResource.
                    AdminFeesForPackage_SearchText_Text);
                SelectWindow(AdminFeesForPackageResource.
                    AdminFeesForPackage_SearchText_Text);

                //switch to iframe
                IWebElement ifreamElement = GetWebElementProperties(
                    By.TagName(AdminFeesForPackageResource.
                    AdminFeesForPackage_PopUpGrid_IframeTagName_Locator));
                SwitchToIFrameByWebElement(ifreamElement);

                //wait for the git to appeare
                WaitForElement(By.XPath(AdminFeesForPackageResource.
                    AdminFeesForPackage_PopUpGrid_Xpath_Locator));

                // click on the Git option
                IWebElement feesTypeGrid = GetWebElementProperties(By.
                    XPath(AdminFeesForPackageResource.
                    AdminFeesForPackage_PopUpGrid_Xpath_Locator));
                ClickByJavaScriptExecutor(feesTypeGrid);
                SwitchToPopup();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Add and save the Admin fees
        /// </summary>
        public void ClickOnAddAndSaveTheFees()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                SwitchToDefaultWindow();
                //Get page name from the URL
                string PageTitle = GetCometDomain() + " " + "Package";
                // Wait untill popup load and select window
                SwitchToPopup();
                WaitUntilPageGetSwitchedSuccessfully(PageTitle);
                WaitUntilPopUpLoads(PageTitle);
                SelectWindow(PageTitle);
                SetPageLoadWaitTime(20);
                // cliking on the Add button
                WaitForElement(By.Id(AdminFeesForPackageResource.
                    AdminFeesForPackage_AddButton_ID_Locator), 20);
                IWebElement addButton = GetWebElementProperties(By.Id(
                    AdminFeesForPackageResource.AdminFeesForPackage_AddButton_ID_Locator));
                ClickByJavaScriptExecutor(addButton);
                // Wait for grid to load
                WaitUntilPopUpLoads(PageTitle);
                SelectWindow(PageTitle);
                WaitForElement(By.Id(AdminFeesForPackageResource.AdminFeesForPackage_Grid_ID_Locator), 10);
                //WaitTillElementFound(By.XPath(AdminFeesForPackageResource.
                //    AdminFeesForPackage_Grid_Xpath_Locator), 20);
                // Clicking on the save button
                SetPageLoadWaitTime(20);
                WaitForElement(By.Id(AdminFeesForPackageResource.
                    AdminFeesForPackage_SaveButton_ID_Locator), 20);
                IWebElement SaveButton = GetWebElementProperties(By.Id
                    (AdminFeesForPackageResource.AdminFeesForPackage_SaveButton_ID_Locator));
                ClickByJavaScriptExecutor(SaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}