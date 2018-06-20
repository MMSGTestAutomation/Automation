using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.Home.Dashboard
{
    public class ContactPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ContactPage));

        /// <summary>
        /// Validate user details in your details page
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        /// <returns>True if all the detils are validated</returns>
        public bool ValidateUserDetailsinYourDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getUserDetailsExistance = false;
            try
            {
                // Get user details based on the user type
                User user = User.Get(userType);
                string getUserFirstName = user.LastName.ToString();
                string getSurname = user.Surname.ToString();
                string getPhoneName = user.Phone.ToString();
                string getEmail = user.Email.ToString();
                //Wait untill window load and select window
                SwitchToDefaultWindow();
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);

                // Get the existance status
                bool getFirstNameExistance = this.getFirstNameExistanceStatus(getUserFirstName);
                bool getSurnameExistance = this.getSurnameExistanceStatus(getSurname);
                bool getPhoneExistance = this.getPhoneNumberExistanceStatus(getPhoneName);
                bool getEmailExistance = this.getEmailExistanceStatus(getEmail);
                // Check if the element is present on the page
                if (getFirstNameExistance == true && getSurnameExistance == true && getPhoneExistance == true
                    && getEmailExistance == true)
                {
                    getUserDetailsExistance = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            //return user detail existance
            return getUserDetailsExistance;
        }

        /// <summary>
        /// Get the first name existance status
        /// </summary>
        /// <param name="getUserFirstName">This is user first name.</param>
        /// <returns>If first name is present</returns>
        public bool getFirstNameExistanceStatus(string getUserFirstName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getFirstNameExistance = false;
            try
            {
                bool asd = base.IsElementPresent(By.XPath("//form[@id='contactForm']/div[6]/div/div[2]/label"), 10);
                WaitForElement(By.XPath("//form[@id='contactForm']/div[6]/div/div[2]/label"), 20);
                string getFirstName = GetInnerTextAttributeValueByXPath("//form[@id='contactForm']/div[6]/div/div[2]/label");

                if (getFirstName.Equals(getUserFirstName))
                {
                    getFirstNameExistance = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getFirstNameExistance;
        }

        /// <summary>
        /// Verify the surname field is present
        /// </summary>
        /// <param name="getUserSurname">Surname expected</param>
        /// <returns>True if theSurname field is present</returns>
        public bool getSurnameExistanceStatus(string getUserSurname)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getSurnameExistance = false;
            try
            {
                WaitForElement(By.Id("Surname"), 20);
                string getFirstName = GetInnerTextAttributeValueById("Surname");

                if (getFirstName.Equals(getUserSurname))
                {
                    getSurnameExistance = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getSurnameExistance;
        }

        /// <summary>
        /// Verify the Phone Number field is present
        /// </summary>
        /// <param name="getUserPhoneNumber">Phone number Expected</param>
        /// <returns>True if the Phone number field is present</returns>
        public bool getPhoneNumberExistanceStatus(string getUserPhoneNumber)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getPhoneExistance = false;
            try
            {
                WaitForElement(By.Id("Phone"), 20);
                string getPhoneNumber = GetValueAttributeById("Phone");

                if (getPhoneNumber.Equals(getUserPhoneNumber))
                {
                    getPhoneExistance = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getPhoneExistance;
        }

        /// <summary>
        /// Verify the Email Field is present
        /// </summary>
        /// <param name="getUserEmail">Email Paramenter Expected</param>
        /// <returns>true if the Email Id field is present</returns>
        public bool getEmailExistanceStatus(string getUserEmail)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getEmailExistance = false;
            try
            {
                WaitForElement(By.Id("Email"), 20);
                string getEmail = GetValueAttributeById("Email");

                if (getEmail.Equals(getUserEmail))
                {
                    getEmailExistance = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getEmailExistance;
        }

        /// <summary>
        /// Method Verify that the dropdown is present
        /// </summary>
        /// <param name="dropDownName"> Drop Down Name</param>
        /// <returns>Returns true idf the element present</returns>
        public bool ValidateDropDownIsPresent(string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "I want to":
                        return IsElementPresent(By.XPath(ContactResource.
                            ContactPage_IWantToButton_Xpath_Locator));

                    case "Change":
                        return IsElementPresent(By.XPath(ContactResource.
                            ContactPage_ChangeButton_Xpath_Locator));

                    case "Add benefit":
                        return IsElementPresent(By.XPath(ContactResource.
                            ContactPage_AddBenefitButton_Xpath_Locator));

                    case "Deduction per pay":
                        return IsElementPresent(By.XPath(ContactResource.
                            ContactPage_PayDeductionTextBox_Xpath_Locator));

                    case "Pay date for change":
                        return IsElementPresent(By.XPath(ContactResource.
                            ContactPage_PayDeductionTextBox_Xpath_Locator));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return false;
        }

        /// <summary>
        /// Click on the dropdown  button presnt on the contact us page
        /// </summary>
        /// <param name="dropDownOption">Drop Option to be selected</param>
        /// <param name="dropDownName">Drop down Name</param>
        public void ClickOnDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "I want to":
                        ClickButtonByXPath(ContactResource.ContactPage_IWantToButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;

                    case "Change":
                        ClickButtonByXPath(ContactResource.ContactPage_ChangeButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;

                    case "Add benefit":
                        ClickButtonByXPath(ContactResource.ContactPage_AddBenefitButton_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
                        break;

                    case "Pay date for change":
                        ClickButtonByXPath(ContactResource.ContactPage_PayDateForChangesDropDown_Xpath_Locator);
                        SelectTheDropDown(dropDownOption);
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
        /// Select the drop down option in the dropdown button
        /// </summary>
        /// <param name="dropDownOption">Drop down Option which need to be select</param>
        public void SelectTheDropDown(string dropDownOption)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Clicking on the Drop down
                ClickLinkByPartialLinkText(dropDownOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enters value to the text box
        /// </summary>
        /// <param name="textBoxName">Text Box name to be filed.</param>
        public void EnterValueToTextBox(string textBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (textBoxName)
                {
                    case "Amount":
                        ClearTextByXPath(ContactResource.ContactPage_PayDeductionTextBox_Xpath_Locator);
                        FillTextBoxByXPath(ContactResource.ContactPage_PayDeductionTextBox_Xpath_Locator,
                            ContactResource.ContactPage_PayDeductionTextBox_Amount_Value);
                        break;

                    case "Phone":
                        ClearTextById(ContactResource.ContactPage_PhoneNumberTextBox_ID_Locator);
                        FillTextBoxById(ContactResource.ContactPage_PhoneNumberTextBox_ID_Locator,
                            ContactResource.ContactPage_PhoneNumberTextBox_PhoneNumber_Value);
                        break;

                    case "Email":
                        ClearTextById(ContactResource.ContactPage_EmailIdTextBox_ID_Locator);
                        FillTextBoxById(ContactResource.ContactPage_EmailIdTextBox_ID_Locator,
                            ContactResource.ContactPage_EmailId_Email_Value);
                        break;

                    case "Message":
                        ClearTextById(ContactResource.ContactPage_Messagel_ID_Locator);
                        FillTextBoxById(ContactResource.ContactPage_Messagel_ID_Locator,
                            ContactResource.ContactPage_Messagel_Message_Value);
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
        /// Selelct the radio button
        /// </summary>
        /// <param name="radioButtonNmae">Radio Button Name</param>
        public void SelectRadioButton(string radioButtonNae)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (radioButtonNae)
                {
                    case "Once off deduction":
                        ClickButtonById(ContactResource.
                            ContactPage_PayDeductionRadioButtonOncesOffDeduction_ID_Locator);
                        break;

                    case "Ongoing deduction":
                        ClickButtonById(ContactResource.
                            ContactPage_PayDeductionRadioButtonOnGoingDeduction_ID_Locator);
                        break;

                    case "Select a pay date":
                        ClickButtonById(ContactResource.
                            ContactPage_PayDateChangeSelectPayDate_ID_Locator);
                        break;

                    case "Next pay date for change":
                        ClickButtonById(ContactResource.
                            ContactPage_NextPayDateForChange_ID_Locator);
                        break;

                    case "Phone":
                        ClickButtonById(ContactResource.
                            ContactPage_PreferredPhone_ID_Locator);
                        break;

                    case "Email":
                        ClickButtonById(ContactResource.
                            ContactPage_PreferredEmail_ID_Locator);
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
        /// Clicking on the Button
        /// </summary>
        /// <param name="buttonName">Button Name to be click</param>
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Submit":
                        ClickButtonById(ContactResource.
                            ContactPage_SubmitButtonl_ID_Locator);
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
        /// Verify the Message is present or not. If present it returns true.
        /// </summary>
        /// <param name="message">Message to be verified</param>
        /// <returns>True if the message is verified</returns>
        public bool VerifyTheMessage(string message)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                string messageOnWebPage = GetElementInnerTextByXPath(
                    ContactResource.ContactPage_SuccessMessage_Xpath_Locator);
                if (messageOnWebPage == message)
                {
                    status = true;
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