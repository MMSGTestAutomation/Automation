using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.ROL.Profile
{
   public class ChangePasswordPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ChangePasswordPage));

        // Random password generation valid 
        private static string restPassword;

        private static string restPasswordValid;

        private static string restPasswordInValid;
        


        /// <summary>
        /// Fill the text box on Text field criteria  
        /// </summary>
        public void FillTextBoxOnTextFieldCriteria(string currentPasswordType, string newPasswordType, string reEnterNewPassword,string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Waituntill window loads and select window
                WaitUntilWindowLoads(pageName);
                SelectWindow(pageName);
                restPasswordValid = this.GeneratePassword(true, true, true, false, false, 8);
                restPasswordInValid= this.GeneratePassword(true, false, true, false, false, 8);

                WaitForElement(By.Id(ChangePasswordResources.ChangePasswordPage_CurrentPassword_TextBox_Id_Locator));
                ClearTextById(ChangePasswordResources.ChangePasswordPage_CurrentPassword_TextBox_Id_Locator);
                //Current password type
                switch (currentPasswordType)
                {
                    case "Valid": 
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_CurrentPassword_TextBox_Id_Locator, ChangePasswordResources.
                            ChangePasswordPage_ValidPassword_Password123_Text);
                        break;
                    case "Invalid":                      
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_CurrentPassword_TextBox_Id_Locator, ChangePasswordResources.
                            ChangePasswordPage_InvalidValidPassword_Password1234_Text);
                        break;
                    case "Empty":                       
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_CurrentPassword_TextBox_Id_Locator, "");
                        break;
                }

                WaitForElement(By.Id(ChangePasswordResources.ChangePasswordPage_NewPassword_TextBox_Id_Locator));
                ClearTextById(ChangePasswordResources.ChangePasswordPage_NewPassword_TextBox_Id_Locator);
                //new PasswordType
                switch (newPasswordType)
                {
                    case "Valid":                       
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_NewPassword_TextBox_Id_Locator, restPasswordValid);                        
                        break;
                    case "Invalid":                       
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_NewPassword_TextBox_Id_Locator, restPasswordInValid);
                        break;
                    case "Empty":                       
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_NewPassword_TextBox_Id_Locator, "");
                        break;
                }

                WaitForElement(By.Id(ChangePasswordResources.ChangePasswordPage_ReEnterNewPassword_TextBox_Id_Locator));
                ClearTextById(ChangePasswordResources.ChangePasswordPage_ReEnterNewPassword_TextBox_Id_Locator);
                //   re enter password type
                switch (reEnterNewPassword)
                {
                    case "Valid":                       
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_ReEnterNewPassword_TextBox_Id_Locator, restPasswordValid);                        
                        break;
                    case "Invalid":                       
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_ReEnterNewPassword_TextBox_Id_Locator, restPasswordInValid);
                        break;
                    case "Empty":                      
                        FillTextBoxById(ChangePasswordResources.ChangePasswordPage_ReEnterNewPassword_TextBox_Id_Locator, "");
                        break;
                } 
                //Click on the save changes             
                WaitForElement(By.XPath(ChangePasswordResources.ChangePasswordPage_SaveChanges_Button_Xpath_Locator), 10);
                IWebElement saveButton = GetWebElementPropertiesByXPath(ChangePasswordResources.ChangePasswordPage_SaveChanges_Button_Xpath_Locator);
                PerformClickAction(saveButton);         
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
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

        /// <summary>
        /// Verify the Error message in Change password screen 
        /// </summary>
        /// <param name="currentPasswordMessageType">Current password Message type</param>
        /// <param name="newPasswordMessageType">New passord message type</param>
        /// <param name="reEnterNewPasswordMessageType"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
       public bool ValidateErrorMessageInChangePasswordScreen(string currentPasswordMessageType,
           string newPasswordMessageType, string reEnterNewPasswordMessageType, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);           
            bool currentPasswordStatus = false;
            bool newPasswordStatus = false;
            bool reEnterPasswordStatus = false;
            bool returenStatus = false;
            try
            {
                WaitUntilWindowLoads(pageName);
                SelectWindow(pageName);
                // Message in Current password
                switch (currentPasswordMessageType)
                {
                    case "Password Required":
                        string cureenrPasswordRequiredMessage = GetInnerTextAttributeValueByXPath
                            (ChangePasswordResources.ChangePasswordPage_CurrentPasswordValidationMessage_Xpath_Locator);
                        if (cureenrPasswordRequiredMessage== ChangePasswordResources.ChangePasswordPage_CurrentPasswordMessage_PasswordRequired_Message)
                        {
                            currentPasswordStatus = true;
                        }
                        break;
                    case "No Message":
                        bool cureenrPasswordNoMessage = IsElementPresent(By.XPath
                            (ChangePasswordResources.ChangePasswordPage_CurrentPasswordValidationMessage_Xpath_Locator),10);                          
                        if (!cureenrPasswordNoMessage )
                        {
                            currentPasswordStatus = true;
                        }
                        break;
                }

                //Message in New password 
                switch (newPasswordMessageType)
                {
                    case "Password Required":
                        string newPasswordRequiredMessage= GetInnerTextAttributeValueByXPath
                            (ChangePasswordResources.ChangePasswordPage_NewPasswordValidationMessage_Xpath_Locator);
                        if (newPasswordRequiredMessage== ChangePasswordResources.ChangePasswordPage_NewPasswordPasswordMessage_PasswordRequired_Message)
                        {
                            newPasswordStatus = true;
                        }
                        break;
                    case "Validation  Message":
                        string ValiadtionMessage = GetInnerTextAttributeValueByXPath
                            (ChangePasswordResources.ChangePasswordPage_NewPasswordValidationMessage_Xpath_Locator);
                        if (ValiadtionMessage ==
                            ChangePasswordResources.ChangePasswordPage_NewPasswordPasswordMessage_UpperCaseLowerCase15CharRequiredMessage_Message)
                        {
                            newPasswordStatus = true;
                        }
                        break;
                    case "No Message":
                        bool cureenrPasswordNoMessage = IsElementPresent(By.XPath
                            (ChangePasswordResources.ChangePasswordPage_NewPasswordValidationMessage_Xpath_Locator),10);
                        if (!cureenrPasswordNoMessage)
                        {
                            currentPasswordStatus = true;
                        }
                        break;

                }

                //Validation message in Re enter password 
                switch (reEnterNewPasswordMessageType)
                {
                    case "Password Required":
                        string reEnterPasswordMessage = GetInnerTextAttributeValueByXPath
                            (ChangePasswordResources.ChangePasswordPage_ReEnterNewPasswordValidationMessage_Xpath_Locator);
                        if (reEnterPasswordMessage== ChangePasswordResources.ChangePasswordPage_ReEnterNewPasswordMessage_PasswordRequired_Message)
                        {
                            reEnterPasswordStatus = true;
                        }
                        break;
                    case "Validation  Message":
                        string ValiadtionMessage = GetInnerTextAttributeValueByXPath
                            (ChangePasswordResources.ChangePasswordPage_ReEnterNewPasswordValidationMessage_Xpath_Locator);
                        if (ValiadtionMessage ==
                           ChangePasswordResources. ChangePasswordPage_ReEnterNewPasswordPasswordMessage_UpperCaseLowerCase15CharRequiredMessage_Message)
                        {
                            newPasswordStatus = true;
                        }
                        break;
                    case "No Message":
                        bool cureenrPasswordNoMessage = IsElementPresent(By.XPath
                            (ChangePasswordResources.ChangePasswordPage_ReEnterNewPasswordValidationMessage_Xpath_Locator),10);
                        if (!cureenrPasswordNoMessage)
                        {
                            currentPasswordStatus = true;
                        }
                        break;
                    case "Both Password Match Validtion":
                        string cureenrPasswordBothPasswordMatch = GetInnerTextAttributeValueByXPath
                            (ChangePasswordResources.ChangePasswordPage_ReEnterNewPasswordValidationMessage_Xpath_Locator);
                        if (cureenrPasswordBothPasswordMatch== ChangePasswordResources.
                            ChangePasswordPage_ReEnterNewPasswordMessage_NewPasswordReEnterPasswordBothMatch_Message)
                        {
                            currentPasswordStatus = true;
                        }
                        break;
                }

                if (currentPasswordStatus && newPasswordStatus && reEnterPasswordStatus)
                {
                    returenStatus = true;
                } 
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return returenStatus;
        }

        /// <summary>
        /// Verify the success message 
        /// </summary>
        /// <returns>True if the sucess</returns>
        public bool ValidateSuccessMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool returenStatus = false;
            try
            {               
                string successMessageStatus = GetInnerTextAttributeValueByXPath(ChangePasswordResources.
                    ChangePasswordPage_SuccessMessage_Xpath_Loctor);
                if (successMessageStatus== ChangePasswordResources.ChangePasswordPage_SuccessMessage_Message)
                {
                    returenStatus = true;
                }
            }
             catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return returenStatus;
        }
    }
}
