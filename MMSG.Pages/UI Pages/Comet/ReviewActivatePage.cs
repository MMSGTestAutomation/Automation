using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class ReviewActivatePage : BasePage
    {      /// <summary>
           /// The static instance of the logger for the class.
           /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ReviewActivatePage));

        /// <summary>
        /// Verify the page landed on the Review and Activate page
        /// </summary>
        /// <returns>Returns the status as true for is page is landed</returns>
        public bool VerifyThePageLandedOnReviewAndActivatePage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getTheReviewAndActivatePageStatus = false;
            try
            {
                SwitchToPopup();
                String pagetittle = GetInnerTextAttributeValueByXPath(
                    ReviewActivateResource.
                    ReviewActivatePage_Title_Xpath_Locator);
                if (pagetittle == "Review And Activate Package")
                {
                    getTheReviewAndActivatePageStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getTheReviewAndActivatePageStatus;
        }

        /// <summary>
        /// Clicking on the save button in Review and activate page
        /// </summary>
        public void ClickOnSaveButtonOnReviwAndActivatePage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain() + " " + "Package";
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                WaitForElement(By.Id(ReviewActivateResource.
                    ReviewActivatePage_SaveButton_Id_Locator));
                IWebElement getSaveButton = GetWebElementPropertiesById(
                    ReviewActivateResource.
                    ReviewActivatePage_SaveButton_Id_Locator);
                PerformMouseClickAction(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Confirm general PAC information
        /// </summary>
        public void ConfirmGeneralPACInformation()
        {
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill popup loads
                WaitUntilPopUpLoads(ReviewActivateResource.
                    ReviewActivatePage_FWAPopup_Title);
                SelectWindow(ReviewActivateResource.
                    ReviewActivatePage_FWAPopup_Title);
                // Wait untill radio button loads
                WaitForElement(By.Id(ReviewActivateResource.
                    ReviewActivatePage_PACStatus_RadioButton_ID_Locator));
                // Select confirm radio button
                SelectRadioButtonById(ReviewActivateResource.
                    ReviewActivatePage_PACStatus_RadioButton_ID_Locator);
                WaitForElement(By.Id(ReviewActivateResource.
                    ReviewActivatePage_FWAPopup_SubmitButton_ID_Locator));
                // Click on save button
                IWebElement getButton = GetWebElementPropertiesById(
                    ReviewActivateResource.
                    ReviewActivatePage_FWAPopup_SubmitButton_ID_Locator);
                ClickByJavaScriptExecutor(getButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}