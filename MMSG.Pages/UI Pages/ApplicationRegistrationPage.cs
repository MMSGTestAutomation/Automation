using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages
{
    public class ApplicationRegistrationPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ApplicationRegistrationPage));

        /// <summary>
        /// Verify the page landed on the Registration page
        /// </summary>
        public string VerifyThePageLandedOnTheRegisterpage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string lastContextOfURL = "";
            try
            {
                string url = GetCurrentUrl;
                int idx = url.LastIndexOf('/');
                lastContextOfURL = url.Substring(idx + 1);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return lastContextOfURL;
        }

        /// <summary>
        /// Verify the page landed on the Registration page
        /// </summary>
        public string VerifyThePageLandedOnTheRegisterpageOfROL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string lastContextOfURL = "";
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);

                string url = GetCurrentUrl;
                int idx = url.LastIndexOf('/');
                lastContextOfURL = url.Substring(idx + 1);
                return lastContextOfURL;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return lastContextOfURL;
        }

        /// <summary>
        /// Enter the Email ID type like Invalid or Valid or no registered
        /// </summary>
        /// <param name="emailType"> Email type is be sent</param>
        public void EnterTheEmail(string emailType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (emailType)
                {
                    // Entering the Invalid Email
                    case "Invalid":
                        WaitForElement(By.Id(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator));
                        ClearTextById(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator);
                        FillTextBoxById(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator,
                            ApplicationRegistrationResource.MOLRegisterPage_InvalidEmailId_Text);
                        break;

                    // Entering the Empty Email
                    case "Empty Email":
                        WaitForElement(By.Id(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator));
                        ClearTextById(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator);
                        FillTextBoxById(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator,
                            ApplicationRegistrationResource.MOLRegisterPage_EmptyEmail_Text);
                        break;

                    // Entering the Unregistered Email
                    case "Unregistered":
                        WaitForElement(By.Id(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator));
                        ClearTextById(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator);
                        FillTextBoxById(ApplicationRegistrationResource.MOLRegisterPage_EmailIdTextBox_Id_Locator,
                            ApplicationRegistrationResource.MOLRegisterPage_UnRegisterEmail_Text);
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
        /// Enter the email ID for ROL
        /// </summary>
        /// <param name="emailType"></param>
        public void EnterTheEmailROL(string emailType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitUntilWindowLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                Thread.Sleep(1000);
                switch (emailType)
                {
                    // Entering the Invalid Email
                    case "Invalid":
                        WaitForElement(By.Id(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator), 30);
                        ClearTextById(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator);
                        FillTextBoxById(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator,
                            ApplicationRegistrationResource.ROLRegisterPage_InvalidEmailId_Text);
                        break;

                    // Entering the Empty Email
                    case "Empty Email":
                        WaitForElement(By.Id(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator), 20);
                        ClearTextById(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator);
                        FillTextBoxById(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator,
                            ApplicationRegistrationResource.ROLRegisterPage_EmptyEmail_Text);
                        break;

                    // Entering the Unregistered Email
                    case "Unregistered":
                        WaitForElement(By.Id(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator), 30);
                        ClearTextById(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator);
                        FillTextBoxById(ApplicationRegistrationResource.ROLRegisterPage_EmailIdTextBox_Id_Locator,
                            ApplicationRegistrationResource.ROLRegisterPage_UnRegisterEmail_Text);
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
        /// Clicking on the Register button
        /// </summary>
        public void RegisterButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //clicking on the submit button
                WaitForElement(By.XPath(ApplicationRegistrationResource.MOLRegisterPage_RegisterButton_Xpath_Locator));
                IWebElement getRegButton = GetWebElementProperties(By.XPath(ApplicationRegistrationResource.MOLRegisterPage_RegisterButton_Xpath_Locator));
                ClickByJavaScriptExecutor(getRegButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Register button
        /// </summary>
        public void RegisterButtonROL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);

                //clicking on the submit button
                WaitForElement(By.XPath(ApplicationRegistrationResource.ROLRegisterPage_SubmitButton_Xpath_Locator));
                IWebElement getSubmitButton = GetWebElementProperties(By.XPath(ApplicationRegistrationResource.ROLRegisterPage_SubmitButton_Xpath_Locator));
                ClickByJavaScriptExecutor(getSubmitButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  verify the error message if the error message as expected returens true
        /// </summary>
        /// <param name="errorMessageType">error message type </param>
        /// <returns>true id exist or returens false</returns>
        public bool VerifyTheErrorMessage(string errorMessageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                WaitUntilWindowLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                Thread.Sleep(1000);
                switch (errorMessageType)
                {
                    // Validating the Error message for Invalid Email Id
                    case "Invalid":
                        WaitForElement(By.XPath(ApplicationRegistrationResource.
                            MOLRegisterPage_InvalidEmailIdErrorMessage_Xpath_Locator));
                        if (GetInnerTextAttributeValueByXPath(ApplicationRegistrationResource.
                            MOLRegisterPage_InvalidEmailIdErrorMessage_Xpath_Locator) ==
                            ApplicationRegistrationResource.MOLRegisterPage_InvalidEmailIdErrorMessage_Text)
                        {
                            status = true;
                        }
                        break;

                    // Validating the Error message for Empty Email Id
                    case "Empty Email":
                        WaitForElement(By.XPath(ApplicationRegistrationResource.
                            MOLRegisterPage_EmptyEmailIdErrorMessage_Xpath_Locator));
                        if (GetInnerTextAttributeValueByXPath(ApplicationRegistrationResource.
                            MOLRegisterPage_EmptyEmailIdErrorMessage_Xpath_Locator) ==
                            ApplicationRegistrationResource.MOLRegisterPage_EmpltyEmailIdErrorMessage_Text)
                        {
                            status = true;
                        }
                        break;

                    // Validating the Error message for Unregistered Email Id
                    case "Unregistered":
                        WaitForElement(By.XPath(ApplicationRegistrationResource.
                            MOLRegisterPage_UnregisterdEmailIdErrorMessage_Xpath_Locator));
                        if (GetInnerTextAttributeValueByXPath(ApplicationRegistrationResource.
                            MOLRegisterPage_UnregisterdEmailIdErrorMessage_Xpath_Locator) ==
                            ApplicationRegistrationResource.MOLRegisterPage_UnRegisteredEmailIdErrorMessage_Text)
                        {
                            status = true;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return status;
        }

        /// <summary>
        ///  verify the error message if the error message as expected returens true
        /// </summary>
        /// <param name="errorMessageType">error message type </param>
        /// <returns>true id exist or returens false</returns>
        public bool VerifyTheErrorMessageROL(string errorMessageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                //Wait untill window load and select window
                SwitchToDefaultWindow();
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                Thread.Sleep(2000);
                switch (errorMessageType)
                {
                    // Validating the Error message for Invalid Email Id
                    case "Invalid":
                        WaitForElement(By.XPath(ApplicationRegistrationResource.
                            ROLRegisterPage_InvalidEmailIdErrorMessage_Xpath_Locator), 50);
                        if (GetInnerTextAttributeValueByXPath(ApplicationRegistrationResource.
                            ROLRegisterPage_InvalidEmailIdErrorMessage_Xpath_Locator) ==
                            ApplicationRegistrationResource.ROLRegisterPage_InvalidEmailIdErrorMessage_Text)
                        {
                            status = true;
                        }
                        break;

                    // Validating the Error message for Empty Email Id
                    case "Empty Email":
                        WaitForElement(By.XPath(ApplicationRegistrationResource.
                            ROLRegisterPage_EmptyEmailIdErrorMessage_Xpath_Locator), 50);
                        if (GetInnerTextAttributeValueByXPath(ApplicationRegistrationResource.
                            ROLRegisterPage_EmptyEmailIdErrorMessage_Xpath_Locator) ==
                            ApplicationRegistrationResource.ROLRegisterPage_EmpltyEmailIdErrorMessage_Text)
                        {
                            status = true;
                        }
                        break;

                    // Validating the Error message for Unregistered Email Id
                    case "Unregistered":
                        WaitForElement(By.XPath(ApplicationRegistrationResource.
                            ROLRegisterPage_UnregisterdEmailIdErrorMessage_Xpath_Locator), 50);
                        if (GetInnerTextAttributeValueByXPath(ApplicationRegistrationResource.
                            ROLRegisterPage_UnregisterdEmailIdErrorMessage_Xpath_Locator) ==
                            ApplicationRegistrationResource.ROLRegisterPage_UnRegisteredEmailIdErrorMessage_Text)
                        {
                            status = true;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return status;
        }
    }
}