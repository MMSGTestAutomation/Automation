using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.ActivationSitePage
{
    public class SMSValidationPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SMSValidationPage));

        /// <summary>
        /// Verify the page landed on the SMSValidtion page
        /// </summary>
        /// <returns>page title.</returns>
        public string PageLandedOnSmSValidtionPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageTilte = "";
            try
            {
                pageTilte = GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return pageTilte;
        }

        /// <summary>
        /// Enter the SMS Code and Submit the Code
        /// </summary>
        public void EnterTheSMSAndSumbit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Clicking on the Get SMS button
                WaitForElement(By.XPath(SMSValidationResource.
                    SMSValidation_GetSMSButton_Xpath_Locator));
                ClickButtonByXPath(SMSValidationResource.
                    SMSValidation_GetSMSButton_Xpath_Locator);

                //Entering the value
                WaitForElement(By.XPath(SMSValidationResource.
                    SMSValidation_SMSTextBox_Xpath_Locator));
                FillTextBoxByXPath(SMSValidationResource.
                    SMSValidation_SMSTextBox_Xpath_Locator, SMSValidationResource.
                    SMSValidation_SMSTextBox_Xpath_Value);

                //Clicking on the Submit button
                WaitForElement(By.XPath(SMSValidationResource.
                    SMSValidation_SMSValidateButton_Xpath_Value));
                ClickButtonByXPath(SMSValidationResource.
                    SMSValidation_SMSValidateButton_Xpath_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}