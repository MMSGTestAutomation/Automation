using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.MOL.ActivationSitePages
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
        /// <returns>Page title.</returns>
        public bool PageLandedOnSmSValidtionPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool pageTilteStatus = false;
            try
            {
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);

                string url = GetCurrentUrl;
                int lastIndex = url.LastIndexOf("/");
                string pageName = url.Remove(0, lastIndex);
                if (pageName == "/Authenticate")
                {
                    pageTilteStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return pageTilteStatus;
        }

        /// <summary>
        /// Enter the SMS Code and Submit the Code
        /// </summary>
        public void EnterTheSMSAndSumbit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);

                //Clicking on the Get SMS button
                WaitForElement(By.XPath(SMSValidationResource.
                    SMSValidation_GetSMSButton_Xpath_Locator));
                IWebElement getSMSButton = GetWebElementProperties(By.XPath(SMSValidationResource.
                    SMSValidation_GetSMSButton_Xpath_Locator));
                ClickByJavaScriptExecutor(getSMSButton);
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                Thread.Sleep(2000);
                WaitForElement(By.Id("response-message"), 50);
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                //Entering the SMS code value
                WaitForElement(By.Id(SMSValidationResource.
                    SMSValidation_SMSTextBox_Id_Locator), 50);
                ClearTextById(SMSValidationResource.
                    SMSValidation_SMSTextBox_Id_Locator);
                FillTextBoxById(SMSValidationResource.
                    SMSValidation_SMSTextBox_Id_Locator,
                    SMSValidationResource.
                    SMSValidation_SMSTextBox_Xpath_Value);
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                //Clicking on the Submit button
                WaitForElement(By.XPath(SMSValidationResource.
                    SMSValidation_SMSValidateButton_Xpath_Value));
                IWebElement getSubmitButton = GetWebElementProperties(By.XPath(SMSValidationResource.
                    SMSValidation_SMSValidateButton_Xpath_Value));
                ClickByJavaScriptExecutor(getSubmitButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}