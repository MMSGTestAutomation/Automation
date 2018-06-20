using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages
{
    public class ApplictionForgotPasswordPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ApplictionForgotPasswordPage));

        private static string restPassword;

        // Random password generation
        private static readonly Random Random = new Random();

        /// <summary>
        /// Verify the page landed on the forgot password page
        /// </summary>
        /// <returns>Returs the last word of the URL</returns>
        public string VerifyThePageLandedOnTheForgotPassword(string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string lastContextOfURL = "";
            try
            {
                WaitUntilWindowLoads(pageTitle);
                // Get the URL
                string url = GetCurrentUrl;
                //Get the last index string to verify
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
        /// Gets the Success message text
        /// </summary>
        /// <returns>Success Message</returns>
        public string GetPasswordChangeSuccessMessage(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getMessage = "";
            try
            {
                SwitchToDefaultWindow();
                // Wait untill window loads
                WaitUntilWindowLoads("Maxxia Online");
                // Select window
                SelectWindow("Maxxia Online");
                // Get the message from application
                WaitForElement(By.XPath(ApplictionForgotPasswordResources.
                    ForgotPassword_MOL_PasswordResetSuccessful_Text), 40);
                getMessage = GetInnerTextAttributeValueByXPath(ApplictionForgotPasswordResources.
                    ForgotPassword_MOL_PasswordResetSuccessful_Text);
                User user = User.Get(userType);
                user.WriteUserInMemory(user, "Password", restPassword);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessage;
        }

        /// <summary>
        /// Enter the Value to the Text box
        /// </summary>
        /// <param name="textName">Text box type</param>
        /// <param name="userType">Uers type</param>
        public void EnterValueToTextBoxMOL(string textName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            string userId = user.Name.ToString();
            string SMSCode = "123456";

            try
            {
                switch (textName)
                {
                    //Enter the user Id
                    case "UserId":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.ForgotPassword_MOL_UserIdTextBox_Id_Locator));
                        ClearTextById(ApplictionForgotPasswordResources.ForgotPassword_MOL_UserIdTextBox_Id_Locator);
                        FillTextBoxById(ApplictionForgotPasswordResources.ForgotPassword_MOL_UserIdTextBox_Id_Locator, userId);
                        break;

                    //Enter the SMSCode
                    case "SMSCode":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.ForgotPassword_MOL_SMSCodeTextBox_Id_Locator));
                        ClearTextById(ApplictionForgotPasswordResources.ForgotPassword_MOL_SMSCodeTextBox_Id_Locator);
                        FillTextBoxById(ApplictionForgotPasswordResources.ForgotPassword_MOL_SMSCodeTextBox_Id_Locator, SMSCode);
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
        /// Enter the Value to the Text box
        /// </summary>
        /// <param name="textName">Text box type</param>
        /// <param name="userType">Uers type</param>
        public void EnterValueToTextBoxROL(string textName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            string userId = user.Name.ToString();
            string SMSCode = "123456";
            try
            {
                switch (textName)
                {
                    //Enter the user Id
                    case "UserId":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.ForgotPassword_ROL_UserIdTextBox_Id_Locator));
                        ClearTextById(ApplictionForgotPasswordResources.ForgotPassword_ROL_UserIdTextBox_Id_Locator);
                        FillTextBoxById(ApplictionForgotPasswordResources.ForgotPassword_ROL_UserIdTextBox_Id_Locator, userId);
                        break;

                    //Enter the SMSCode
                    case "SMSCode":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.ForgotPassword_ROL_SMSCodeTextBox_Id_Locator));
                        ClearTextById(ApplictionForgotPasswordResources.ForgotPassword_ROL_SMSCodeTextBox_Id_Locator);
                        FillTextBoxById(ApplictionForgotPasswordResources.ForgotPassword_ROL_SMSCodeTextBox_Id_Locator, SMSCode);
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
        /// Enter the the Password
        /// </summary>
        public void EnterThePasswordAndReenterPasswordMOL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Enter the new password
                restPassword = this.GeneratePassword(true, true, true, false, false, 8);
                WaitForElement(By.Id(ApplictionForgotPasswordResources.ForgotPassword_MOL_NewPasswordTextBox_Id_Locator));
                ClearTextById(ApplictionForgotPasswordResources.ForgotPassword_MOL_NewPasswordTextBox_Id_Locator);
                FillTextBoxById(ApplictionForgotPasswordResources.ForgotPassword_MOL_NewPasswordTextBox_Id_Locator, restPassword);

                // Re enter the password
                WaitForElement(By.Id(ApplictionForgotPasswordResources.ForgotPassword_MOL_ConfirmPasswordTextBox_Id_Locator));
                ClearTextById(ApplictionForgotPasswordResources.ForgotPassword_MOL_ConfirmPasswordTextBox_Id_Locator);
                FillTextBoxById(ApplictionForgotPasswordResources.ForgotPassword_MOL_ConfirmPasswordTextBox_Id_Locator, restPassword);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the new password and re enter the password
        /// </summary>
        public void EnterThePasswordAndReenterPasswordROL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Enter the new password
                restPassword = this.GeneratePassword(true, true, true, false, false, 8);
                WaitForElement(By.Id(ApplictionForgotPasswordResources.
                    ForgotPassword_ROL_NewPasswordTextBox_Id_Locator));
                ClearTextById(ApplictionForgotPasswordResources.
                    ForgotPassword_ROL_NewPasswordTextBox_Id_Locator);
                FillTextBoxById(ApplictionForgotPasswordResources.
                    ForgotPassword_ROL_NewPasswordTextBox_Id_Locator, restPassword);
                // Enter the new password
                WaitForElement(By.Id(ApplictionForgotPasswordResources.
                    ForgotPassword_ROL_ConfirmPasswordTextBox_Id_Locator));
                ClearTextById(ApplictionForgotPasswordResources.
                    ForgotPassword_ROL_ConfirmPasswordTextBox_Id_Locator);
                FillTextBoxById(ApplictionForgotPasswordResources.
                    ForgotPassword_ROL_ConfirmPasswordTextBox_Id_Locator, restPassword);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Cliking on the Button in forgot page
        /// </summary>
        /// <param name="buttonName">Button name to be clicked</param>
        public void ClickOnTheButtonMOL(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    // clicking on the Uesr id submit button
                    case "Submit UserID":
                        WaitForElement(By.XPath(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_UserIdSubmitButton_Xpath_Locator));
                        ClickButtonByXPath(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_UserIdSubmitButton_Xpath_Locator);
                        break;
                    // clicking on the Get SMS  button
                    case "getCode":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_GetSMSCodeButton_Id_Locator));
                        ClickButtonById(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_GetSMSCodeButton_Id_Locator);
                        break;
                    // clicking on the submit button
                    case "Submit":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_SubmitButton_Id_Locator));
                        ClickButtonById(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_SubmitButton_Id_Locator);
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
        /// Cliking on the Button in forgot page
        /// </summary>
        /// <param name="buttonName">Button name to be clicked</param>
        public void ClickOnTheButtonROL(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    // clicking on the Uesr id submit button
                    case "Submit UserID":
                        WaitForElement(By.XPath(ApplictionForgotPasswordResources.
                            ForgotPassword_ROL_UserIdSubmitButton_Xpath_Locator));
                        ClickButtonByXPath(ApplictionForgotPasswordResources.
                            ForgotPassword_ROL_UserIdSubmitButton_Xpath_Locator);
                        break;
                    // clicking on the Get SMS  button
                    case "getCode":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.
                            ForgotPassword_ROL_GetSMSCodeButton_Id_Locator));
                        ClickButtonById(ApplictionForgotPasswordResources.
                            ForgotPassword_MOL_GetSMSCodeButton_Id_Locator);
                        break;
                    // clicking on the submit button
                    case "Submit":
                        WaitForElement(By.Id(ApplictionForgotPasswordResources.
                            ForgotPassword_ROL_SubmitButton_Id_Locator));
                        ClickButtonById(ApplictionForgotPasswordResources.
                            ForgotPassword_ROL_SubmitButton_Id_Locator);
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
        /// Verify the new passsword text box is appearing
        /// </summary>
        /// <returns>True if the New Password Text Box appeare</returns>
        public bool VerifyTheNewPasswordTextAppered()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool ispresent = false;
            try
            {
                // verify new password text box is present
                ispresent = IsElementPresent(By.Id(ApplictionForgotPasswordResources.
                    ForgotPassword_MOL_NewPasswordTextBox_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return ispresent;
        }

        /// <summary>
        /// Generate random password
        /// </summary>
        /// <param name="includeLowercase">Enable or disable the includeLowercase.</param>
        /// <param name="includeUppercase">Enable or disable the includeUppercase.</param>
        /// <param name="includeNumeric">Enable or disable the includeNumeric.</param>
        /// <param name="includeSpecial">Enable or disable the includeSpecial.</param>
        /// <param name="includeSpaces">Enable or disable includeSpacese.</param>
        /// <param name="lengthOfPassword">Enable or disable lengthOfPassword</param>
        /// <returns>random password.</returns>
        private string GeneratePassword(bool includeLowercase, bool includeUppercase,
            bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                restPassword = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase,
                    includeNumeric, includeSpecial, includeSpaces, lengthOfPassword);

                while (!PasswordGenerator.PasswordIsValid(includeLowercase, includeUppercase,
                    includeNumeric, includeSpecial, includeSpaces, restPassword))
                {
                    restPassword = PasswordGenerator.GeneratePassword(includeLowercase, includeUppercase,
                        includeNumeric, includeSpecial, includeSpaces, lengthOfPassword);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);

            return restPassword;
        }
    }
}