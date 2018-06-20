using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Profile
{
    public class ProfilePersonalDetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ProfilePersonalDetailsPage));

        /// <summary>
        /// Fill text box based on the text fill type criteria
        /// </summary>
        /// <param name="textFillType">Thisis text fill type.</param>
        /// <param name="textBoxName">This is text box name.</param>
        /// <param name="pageName">This is page name.</param>
        public void FilltextBoxBasedOnText(string textFillType, string textBoxName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Waituntill window loads and select window
                WaitUntilWindowLoads(pageName);
                SelectWindow(pageName);

                switch (textBoxName)
                {
                    case "Home phone":
                        EditHomePhoneTextBox(textFillType);
                        break;

                    case "Mobile":
                        EditMobileTextBox(textFillType);
                        break;

                    case "Personal Email address":
                        EditPersonalEmailAddressTextBox(textFillType);
                        break;

                    case "Address Line1":
                        EditAddressLine1extBox(textFillType);
                        break;

                    case "Suburb":
                        EditSuburbTextBox(textFillType);
                        break;

                    case "Peninsula Health":
                        EditPeninsulaHealthTextBox(textFillType);
                        break;

                    case "Post Code":
                        EditPostCodeTextBox(textFillType);
                        break;
                }
                Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Verify the mobile number validation
        /// </summary>
        /// <param name="textFillType">Type of fielsd to be filled </param>
        private void EditMobileTextBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_TextBox_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_TextBox_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_TextBox_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_Valid_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_TextBox_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_InValid_TextBox_Value);
                        break;

                    case "Blank":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_TextBox_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Mobile_Blank_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit personal email ID text box
        /// </summary>
        /// <param name="textFillType">This is text fill type.</param>
        private void EditPersonalEmailAddressTextBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_TextBox_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_TextBox_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_TextBox_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_ValidPersonalEmail_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_TextBox_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_InvalidPersonalEmail_TextBox_Value);
                        break;

                    case "Empty":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_TextBox_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_BlankPersonalEmail_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                    ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit adress line1 text box
        /// </summary>
        /// <param name="textFillType">This is fill text type.</param>
        private void EditAddressLine1extBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_AddressLine1TextBox_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_AddressLine1TextBox_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_AddressLine1TextBox_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_ValidAddressLine1TextBox_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_AddressLine1TextBox_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_InValidAddressLine1TextBox_TextBox_Value);
                        break;

                    case "Blank":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_AddressLine1TextBox_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_BlankAddressLine1TextBox_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// verify the Suburb text box validation
        /// </summary>
        /// <param name="textFillType">Text box type</param>
        private void EditSuburbTextBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_ValidText_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_InValidText_TextBox_Value);
                        break;

                    case "Empty":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Suburb_BlankText_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Postacal code text box validation
        /// </summary>
        /// <param name="textFillType">Filling the text box type</param>
        private void EditPostCodeTextBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PostCode_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PostCode_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PostCode_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Postcode_ValidText_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PostCode_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Postcode_InValidText_TextBox_Value);
                        break;

                    case "Blank":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PostCode_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Postcode_BlankText_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the text box
        /// </summary>
        /// <param name="textFillType">Text box typ[e to be filled</param>
        private void EditPeninsulaHealthTextBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PeninsulaHealth_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PeninsulaHealth_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PeninsulaHealth_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_ValidPersonalEmail_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PeninsulaHealth_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_InvalidPersonalEmail_TextBox_Value);
                        break;

                    case "Empty":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PeninsulaHealth_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_BlankPersonalEmail_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit home phone text box
        /// </summary>
        /// <param name="textFillType">This is text fill type.</param>
        private void EditHomePhoneTextBox(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and clear personal email id textbox
                WaitForElement(By.Id(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_TextBox_ID_Locator));
                ClearTextById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_TextBox_ID_Locator);
                // Text fill type
                switch (textFillType)
                {
                    case "Valid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_TextBox_ID_Locator,
                            ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Valid_TextBox_Value);
                        break;

                    case "Invalid":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_TextBox_ID_Locator,
                        ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_InValid_TextBox_Value);
                        break;

                    case "Blank":
                        FillTextBoxById(ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_TextBox_ID_Locator,
                       ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Blank_TextBox_Value);
                        break;
                }
                IWebElement getSaveButton = GetWebElementPropertiesByXPath(
                ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Save_Button_XPath);
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the validation message from application
        /// </summary>
        /// <param name="messageType">This is message type enum.</param>
        /// <param name="textBoxName">This is text box name.</param>
        /// <param name="pageName">This is page name.</param>
        /// <returns>Return page name.</returns>
        public bool GetValidationMessageStatus(string messageType, string textBoxName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getValidationMessageFromApplication = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                // Waituntill window loads and select window
                WaitUntilWindowLoads(pageName);
                SelectWindow(pageName);

                switch (textBoxName)
                {
                    case "Home phone":
                        getMessageComparisionStatus = GetHomePhoneTextBoxMessage(messageType);
                        break;

                    case "Mobile":
                        getMessageComparisionStatus = GetMobileTextBoxMessage(messageType);
                        break;

                    case "Personal Email address":
                        getMessageComparisionStatus = GetPersonalEmailAddressTextBoxMessage(messageType);
                        break;
                    //case "Address Line1":
                    //    getValidationMessage = EditAddressLine1extBox(messageType);
                    //    break;
                    case "Suburb":
                        getMessageComparisionStatus = GettSuburbTextBoxMessage(messageType);
                        break;

                    case "Peninsula Health":
                        getMessageComparisionStatus = GetPeninsulaHealthTextBoxMessage(messageType);
                        break;

                    case "Post Code":
                        getMessageComparisionStatus = GetPostCodeTextBoxMessage(messageType);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }

        /// <summary>
        /// Verify the personal Email  validation
        /// </summary>
        /// <param name="messageType">type of field</param>
        /// <returns></returns>
        private bool GetPersonalEmailAddressTextBoxMessage(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getActualPersonalEmailAddressTextBoxMessage = string.Empty;
            string getExpectedPersonalEmailAddressTextBoxMessage = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath
                (ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Error_XPath_Locator);
                switch (messageType)
                {
                    case "Invalid":
                        //Get inner text based on the ID
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.
                            ProfilePersonalDetailsPage_PersonalEmail_Invalid_Error;
                        break;

                    case "Empty":
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.
                            ProfilePersonalDetailsPage_PersonalEmail_Blank_Error;

                        break;
                }
                //Compare actual and expected message
                if (getActualPersonalEmailAddressTextBoxMessage == getExpectedPersonalEmailAddressTextBoxMessage)
                {
                    getMessageComparisionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }

        private bool GetPostCodeTextBoxMessage(string messageType)
        {
            string getActualPersonalEmailAddressTextBoxMessage = string.Empty;
            string getExpectedPersonalEmailAddressTextBoxMessage = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                switch (messageType)
                {
                    case "Invalid":
                        getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath("//div[@class='success-content']/div[2]/span");
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_Success_Error;
                        break;

                    case "Empty":
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.
                            ProfilePersonalDetailsPage_PostCode_Invalid_Error;
                        getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath
                        (ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Error_XPath_Locator);

                        break;
                }
                //Compare actual and expected message
                if (getActualPersonalEmailAddressTextBoxMessage == getExpectedPersonalEmailAddressTextBoxMessage)
                {
                    getMessageComparisionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }

        /// <summary>
        /// Verify the text box validation
        /// </summary>
        /// <param name="messageType">type of text bo be filled</param>
        /// <returns></returns>
        private bool GetPeninsulaHealthTextBoxMessage(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getActualPersonalEmailAddressTextBoxMessage = string.Empty;
            string getExpectedPersonalEmailAddressTextBoxMessage = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                switch (messageType)
                {
                    case "Invalid":
                        //Get inner text based on the ID
                        getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath("//div[@class='success-content']/div[2]/span");
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_Success_Error;
                        break;

                    case "Empty":
                        //Get inner text based on the ID
                        getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath("//div[@class='success-content']/div[2]/span");
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_Success_Error;
                        break;
                }
                //Compare actual and expected message
                if (getActualPersonalEmailAddressTextBoxMessage == getExpectedPersonalEmailAddressTextBoxMessage)
                {
                    getMessageComparisionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }

        /// <summary>
        /// Verify the subur text box valiadtion
        /// </summary>
        /// <param name="messageType">Type of text to be filled</param>
        /// <returns></returns>
        private bool GettSuburbTextBoxMessage(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getActualPersonalEmailAddressTextBoxMessage = string.Empty;
            string getExpectedPersonalEmailAddressTextBoxMessage = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                switch (messageType)
                {
                    case "Invalid":
                        //Get inner text based on the ID
                        getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath("//div[@class='success-content']/div[2]/span");
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_Success_Error;
                        break;

                    case "Empty":
                        getExpectedPersonalEmailAddressTextBoxMessage = ProfilePersonalDetailsResource.
                            ProfilePersonalDetailsPage_Suburb_Empty_Error;
                        getActualPersonalEmailAddressTextBoxMessage = GetInnerTextAttributeValueByXPath
                        (ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Error_XPath_Locator);
                        break;
                }
                //Compare actual and expected message
                if (getActualPersonalEmailAddressTextBoxMessage == getExpectedPersonalEmailAddressTextBoxMessage)
                {
                    getMessageComparisionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }

        /// <summary>
        /// Edit home phone text box
        /// </summary>
        /// <param name="textFillType">This is text fill type.</param>
        private bool GetHomePhoneTextBoxMessage(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getActualHomePhoneTextBoxMessage = string.Empty;
            string getExpectedHomePhoneTextBoxMessage = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                switch (textFillType)
                {
                    case "Invalid":
                        //Get inner text based on the ID
                        getActualHomePhoneTextBoxMessage = GetInnerTextAttributeValueByXPath
                        (ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Error_XPath_Locator);
                        getExpectedHomePhoneTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_HomePhone_Invalid_Error;
                        break;

                    case "Empty":
                        getActualHomePhoneTextBoxMessage = GetInnerTextAttributeValueByXPath("//div[@class='success-content']/div[2]/span");
                        getExpectedHomePhoneTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_Success_Error;
                        break;
                }
                //Compare actual and expected message
                if (getActualHomePhoneTextBoxMessage == getExpectedHomePhoneTextBoxMessage)
                {
                    getMessageComparisionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }

        /// <summary>
        /// Edit home phone text box
        /// </summary>
        /// <param name="textFillType">This is text fill type.</param>
        private bool GetMobileTextBoxMessage(string textFillType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string getActualHomePhoneTextBoxMessage = string.Empty;
            string getExpectedHomePhoneTextBoxMessage = string.Empty;
            bool getMessageComparisionStatus = false;
            try
            {
                switch (textFillType)
                {
                    case "Invalid":
                        //Get inner text based on the ID
                        getActualHomePhoneTextBoxMessage = GetInnerTextAttributeValueByXPath
                        (ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_Error_XPath_Locator);
                        getExpectedHomePhoneTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_MobilePhone_Invalid_Error;
                        break;

                    case "Empty":
                        getActualHomePhoneTextBoxMessage = GetInnerTextAttributeValueByXPath("//div[@class='success-content']/div[2]/span");
                        getExpectedHomePhoneTextBoxMessage = ProfilePersonalDetailsResource.ProfilePersonalDetailsPage_PersonalEmail_Success_Error;
                        break;
                }
                //Compare actual and expected message
                if (getActualHomePhoneTextBoxMessage == getExpectedHomePhoneTextBoxMessage)
                {
                    getMessageComparisionStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getMessageComparisionStatus;
        }
    }
}