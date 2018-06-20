using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Employee_personaldetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Employee_personaldetailsPage));

        /// <summary>
        /// Get the page title from commet application
        /// </summary>
        /// <returns>This will return page title.</returns>
        public string GetCommetNewEmoplyeePageTitle(string expectedPageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string popupTitle = null;
            try
            {
                // Switch to default window and select window
                SwitchToDefaultWindow();
                SwitchToWindow(expectedPageTitle);
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                // Get page title
                popupTitle = GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return popupTitle;
        }

        /// <summary>
        /// Get popup title.
        /// </summary>
        /// <returns>Return the popup title.</returns>
        public string GetWindowTitle(string expectedPopupTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string returnPopupTitle = null;
            try
            {
                // Get page title
                returnPopupTitle = GetPageTitle;
                SwitchToDefaultWindow();
                Thread.Sleep(5000);
                SwitchToLastOpenedWindow();
                returnPopupTitle = GetPageTitle;
                if (returnPopupTitle == expectedPopupTitle)
                {
                    WaitUntilPageGetSwitchedSuccessfully(expectedPopupTitle);
                    SwitchToWindow(expectedPopupTitle);
                    WaitUntilPopUpLoads(GetPageTitle);
                    returnPopupTitle = GetPageTitle;
                    CloseBrowserWindow();
                    return returnPopupTitle;
                }
                else
                {
                    return expectedPopupTitle;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return returnPopupTitle;
        }

        /// <summary>
        /// Get popup title.
        /// </summary>
        /// <returns>Return the popup title.</returns>
        public string GetpopupTitle(string expectedPopupTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string returnPopupTitle = null;
            try
            {
                base.SetPageLoadWaitTime(20);
                // Get page title
                SwitchToDefaultWindow();
                SwitchToWindow(expectedPopupTitle);
                WaitUntilPopUpLoads(GetPageTitle);
                returnPopupTitle = GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return returnPopupTitle;
        }

        /// <summary>
        /// Fill the textbox using customized GUID and store the data inmemory
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void FillEmployeeDetails(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                SwitchToDefaultWindow();
                MaximizeWindow();
                //Step one form fill for new employee
                this.NewEmployeeCreationFirstStep(userType);

                // Click next button
                WaitForElement(By.XPath(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_NextButton1_Xpath));
                IWebElement getNextButton = GetWebElementPropertiesByXPath(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_NextButton1_Xpath);
                ClickByJavaScriptExecutor(getNextButton);

                //Step two form fill for new employee
                this.NewEmployeeCreationSecondStep(userType);

                // Click next button
                IWebElement getButtonXpath = GetWebElementPropertiesByXPath(
                    Employee_personaldetailsResource.EmployeepersonaldetailsPage__NextButton2_Xpath);
                ClickByJavaScriptExecutor(getButtonXpath);

                //Step three form fill for new employee
                this.NewEmployeeCreationThirdStep(userType);

                // Click next button
                WaitForElement(By.XPath(Employee_personaldetailsResource.EmployeepersonaldetailsPage__NextButton2_Xpath));
                getButtonXpath = GetWebElementPropertiesByXPath(
                     Employee_personaldetailsResource.EmployeepersonaldetailsPage__NextButton2_Xpath);
                ClickByJavaScriptExecutor(getButtonXpath);

                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain() + " " + "Employee";
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);

                // Click on save button
                WaitForElement(By.XPath(Employee_personaldetailsResource.EmployeepersonaldetailsPage_SaveButton_Xpath), 20);
                getButtonXpath = GetWebElementPropertiesByXPath(
                     Employee_personaldetailsResource.EmployeepersonaldetailsPage_SaveButton_Xpath);
                ClickByJavaScriptExecutor(getButtonXpath);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Step one form fill for new employee
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        private void NewEmployeeCreationFirstStep(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Generate Customized GUID for text fill
                string givenNameGUID = String.Concat(Guid.NewGuid().ToString("N").Select(c => (char)(c + 17))).Substring(0, 8);
                string surnameGUID = String.Concat(Guid.NewGuid().ToString("N").Select(c => (char)(c + 17))).Substring(0, 8);
                string otherNameGUID = String.Concat(Guid.NewGuid().ToString("N").Select(c => (char)(c + 17))).Substring(0, 8);
                string preferredName = String.Concat(Guid.NewGuid().ToString("N").Select(c => (char)(c + 17))).Substring(0, 8);
                string userDOB = Employee_personaldetailsResource.EmployeepersonaldetailsPage_DateOfBirth_Textbox_ID_Locator;
                string tenDigitMobileRandomNumbers = GetTenDigitMobileRandomNumbers();
                string preferredEmail = Employee_personaldetailsResource.EmployeepersonaldetailsPage_Mail_Textbox_ID_Locator;
                string homeTelephone = Employee_personaldetailsResource.EmployeepersonaldetailsPage_PhoneNumber_Textbox_ID_Locator;
                string mobileNumber = Employee_personaldetailsResource.EmployeepersonaldetailsPage_MobileNumber_Textbox_ID_Locator;
                string gESBMenberNumber = Employee_personaldetailsResource.EmployeepersonaldetailsPage_ESBMenberNumber_Textbox_ID_Locator;
                string password = User.Get(userType).Password;
                string email = User.Get(userType).Email.ToString();
                string employeeNumber = User.Get(userType).EmployeeNumber.ToString();
                string employerCode = User.Get(userType).EmployerCode.ToString();
                string firstName = User.Get(userType).FirstName.ToString();
                string middleName = User.Get(userType).MiddleName.ToString();
                string lastName = User.Get(userType).LastName.ToString();
                string surname = User.Get(userType).Surname.ToString();
                string gender = User.Get(userType).Gender.ToString();
                string memberNumber = User.Get(userType).MemberNumber.ToString();
                string phone = User.Get(userType).Phone.ToString();

                //Start Stop Watch
                Stopwatch stopWatch = new Stopwatch();
                //Get Transaction Time
                double getTransactionTime = stopWatch.Elapsed.TotalSeconds;
                // Get user details to track the information in Log
                UserName = givenNameGUID;
                Password = password;
                CurrentBrowserName = AutomationConfigurationManager.BrowserExecutionInstance;

                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain() + " " + "Employee";
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);

                // Wait for Title dropdown and select the value
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_Dropdown_ID_Locator));
                SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_Dropdown_ID_Locator, 6);

                // Fill Given Name textbox
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_GivenName_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_GivenName_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_GivenName_Textbox_ID_Locator, givenNameGUID);

                // Fill OtherNames Textbox
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_OtherNamesText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_OtherNamesText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_OtherNamesText_Textbox_ID_Locator, otherNameGUID);

                // Fill Surname textbox
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_SurnameText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_SurnameText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_SurnameText_Textbox_ID_Locator, surnameGUID);

                // Fill Preferred Name text box
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PreferredNameText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PreferredNameText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PreferredNameText_Textbox_ID_Locator, preferredName);

                // Fill data of birth text box
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_DateOfBirthText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_DateOfBirthText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_DateOfBirthText_Textbox_ID_Locator, userDOB);

                // Select Gender option from the dropdown
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_Gender_Dropdown_ID_Locator));
                SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_Gender_Dropdown_ID_Locator, 2);

                // Fill Home Telephone textbox
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PhoneNumberHomeText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PhoneNumberHomeText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PhoneNumberHomeText_Textbox_ID_Locator, homeTelephone);

                // Fill Home Mobile Number textbox
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_MobileNumberText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_MobileNumberText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_MobileNumberText_Textbox_ID_Locator, mobileNumber);

                // Fill textbox by email id
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmailAddressText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmailAddressText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmailAddressText_Textbox_ID_Locator, preferredEmail);

                // Fill GESB Member Number Text
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_GESBMemberNumberText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_GESBMemberNumberText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_GESBMemberNumberText_Textbox_ID_Locator, gESBMenberNumber);

                // Select Employee Asked Marketing No Radio
                SelectRadioButtonById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmployeeAskedMarketingNoRadio_RadioButton_ID);

                // Select Receive Marketing Info Yes Radio
                SelectRadioButtonById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_ReceiveMarketingInfoYesRadio_RadioButton_ID);

                // Select Employee Asked Green Statement Yes Radio
                SelectRadioButtonById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmployeeAskedGreenStatementYesRadio_RadioButton_ID);

                // Select Receive Substantiation Reminders Yes Radio
                SelectRadioButtonById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_ReceiveSubstantiationRemindersYesRadio_RadioButton_ID);

                // Select Receive Payment Notifications Yes Radio
                SelectRadioButtonById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_ReceivePaymentNotificationsYesRadio_RadioButton_ID);

                // Select Online Claims Approval Required No Radio
                SelectRadioButtonById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_OnlineClaimsApprovalRequiredNo_RadioButton_ID);

                // Store the data in memory
                this.StoreUserDetails(userType, givenNameGUID,
                    surnameGUID, otherNameGUID, tenDigitMobileRandomNumbers,
                    preferredEmail, gESBMenberNumber, password, employeeNumber, employerCode, firstName, middleName, lastName, gender, phone, userDOB);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Step two form fill new employee
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        private void NewEmployeeCreationSecondStep(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain() + " " + Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmployeeAddressDetailsPage_Title;
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);

                // Fill Home adress in adress text box
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_Text);

                // Fill Home Suburb text box
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_Text);

                // Select state from Home state dropdown
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeStateCombo_Dropdown_ID_Locator));
                SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeStateCombo_Dropdown_ID_Locator, 7);

                // Fill Postcode in the home Postcode textbox
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_Text);

                // Fill Postal Address
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalAddressLine1Text_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                 EmployeepersonaldetailsPage_PostalAddressLine1Text_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PostalAddressLine1Text_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_HomeAddressLine1Text_Textbox_Text);

                //Fill Postal Suburb Text
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalSuburbText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalSuburbText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalSuburbText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomeSuburbText_Textbox_Text);

                // Select state from Postal state dropdown
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalStateCombo_Dropdown_ID_Locator));
                SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalStateCombo_Dropdown_ID_Locator, 7);

                // Select Postal Post Code Text
                WaitForElement(By.Id(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalPostCodeText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalPostCodeText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_PostalPostCodeText_Textbox_ID_Locator,
                Employee_personaldetailsResource.
                EmployeepersonaldetailsPage_HomePostCodeText_Textbox_Text);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Step three form fill new employee
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        private void NewEmployeeCreationThirdStep(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain() + " " + Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EmployeePage_Title;
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);

                WaitForElement(By.XPath(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage__EffectiveDate_Xpath));
                string getDateText = GetInnerTextAttributeValueByXPath(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string effectiveDateText = getDate.Replace(")", "").Trim();

                // Fill Effective Date Text
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EffectiveDateText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EffectiveDateText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EffectiveDateText_Textbox_ID_Locator, effectiveDateText);

                // Select payment method from dropdow
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PaymentMethodCombo_Dropdown_ID_Locator));
                SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_PaymentMethodCombo_Dropdown_ID_Locator, 1);

                // Fill bank account number details
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BankAccountNumberText_Textbox_Text);

                // Fill BSN number
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_ID_Locator));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_ID_Locator);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_ID_Locator,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_BSBNumberText_Textbox_Text);

                //Select renittance from drop down
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_RemittanceDropDown_ID_Locator));
                SelectDropDownValueThroughIndexById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_RemittanceDropDown_ID_Locator, 5);

                // Fill IQ number text
                WaitForElement(By.Id(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_IQueueNumberText_Textbox_ID));
                ClearTextById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_IQueueNumberText_Textbox_ID);
                FillTextBoxById(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_IQueueNumberText_Textbox_ID,
                    Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_IQueueNumberText_Textbox_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Stores User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        /// <param name="userInformation">This is User Information Guid.</param>
        public void StoreUserDetails(User.UserTypeEnum userTypeEnum,
            string givenNameGUID, string surnameGUID, string otherNameGUID,
            string tenDigitMobileRandomNumbers,
               string preferredEmail, string gESBMenberNumber, string password,
               string employeeNumber, string employerCode, string firstName,
               string middleName, string lastName,
               string gender, string phone, string userDOB)
        {
            //Stores User Details in Memory

            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            //Store User Details in Memory
            this.StoreUserDetailsInMemory(userTypeEnum, givenNameGUID,
                surnameGUID, otherNameGUID, tenDigitMobileRandomNumbers,
                preferredEmail, gESBMenberNumber, password, employeeNumber,
                employerCode, firstName, middleName, lastName, gender, phone, userDOB);

            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Saving the User Details in Memory
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="userName">This is Username guid</param>
        /// <param name="userPassword">This is Password</param>
        /// <param name="firstName">This Is First Name</param>
        /// <param name="lastName">This Is Last Name</param>
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum,
            string givenNameGUID, string surnameGUID, string otherNameGUID,
            string tenDigitMobileRandomNumbers,
               string preferredEmail, string gESBMenberNumber, string password,
               string employeeNumber, string employerCode, string firstName,
               string middleName, string lastName,
               string gender, string phone, string userDOB)
        {
            //Save user in Memory
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            //Save user Details
            this.SaveUserInMemory
             (userTypeEnum, givenNameGUID,
                surnameGUID, otherNameGUID, tenDigitMobileRandomNumbers,
                preferredEmail, gESBMenberNumber, password, employeeNumber, employerCode,
                firstName, middleName, lastName, gender, phone, userDOB);
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save User In Memory
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="userName">This is UserName Guid</param>
        /// <param name="userPassword">This is Password</param>
        /// <param name="firstName">This is First Name</param>
        /// <param name="lastName">This is Last Name</param>
        public void SaveUserInMemory(User.UserTypeEnum userTypeEnum,
            string givenNameGUID, string surnameGUID, string otherNameGUID, string tenDigitMobileRandomNumbers,
               string preferredEmail, string gESBMenberNumber, string password,
               string employeeNumber, string employerCode, string firstName, string middleName, string lastName,
               string gender, string phone, string userDOB)
        {
            //Save The User In Memory
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            User newUser = new User
            {
                Email = preferredEmail,
                OtherName = otherNameGUID,
                Surname = surnameGUID.ToString(),
                GivenName = givenNameGUID,
                MemberNumber = gESBMenberNumber,
                UserType = userTypeEnum,
                Password = password,
                EmployeeNumber = employeeNumber,
                EmployerCode = employerCode,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Gender = gender,
                Phone = phone,
                DOB = userDOB,
                IsCreated = true,
            };

            //Save The User In Memory
            newUser.StoreUserInMemory();
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Auto generate 10 digit mobile number
        /// </summary>
        /// <returns>Return 10 digit mobile number.</returns>
        public static string GetTenDigitMobileRandomNumbers()
        {
            Random generator = new Random();
            return generator.Next(0, 1000000).ToString("D10");
        }

        /// <summary>
        /// Click on option name in popup
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="popupName">This is popup name.</param>
        public void ClickOnButtonInPopup(string optionName, string popupName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitUntilPopUpLoads(popupName);
                MaximizeWindow();
                SwitchToIFrameByName(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EAMS_Frame_Locator);
                WaitForElement(By.XPath(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EAMS_CancelButton_Name_Locator));
                IWebElement getButton = base.GetWebElementProperties(By.XPath(Employee_personaldetailsResource.
                    EmployeepersonaldetailsPage_EAMS_CancelButton_Name_Locator));
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