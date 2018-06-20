using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages
{
    public class LoginPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LoginPage));

        /// <summary>
        /// Clicking on the button
        /// </summary>
        /// <param name="buttonName">Button name</param>
        public void ClickOnButtonMOL(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                switch (buttonName)
                {
                    case "Register now":
                        base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                            Login_Page_ActivatePage_MOL_RegisterButton_Xpath_Locator));
                        IWebElement getRegButton = GetWebElementPropertiesByXPath(ApplicationLoginPageResource.
                            Login_Page_ActivatePage_MOL_RegisterButton_Xpath_Locator);
                        ClickByJavaScriptExecutor(getRegButton);
                        break;

                    case "Forgot your password":
                        base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_ForgotPassword_Xpath_Locator));
                        base.ClickButtonByXPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_ForgotPassword_Xpath_Locator);
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
        /// Clicking on the button
        /// </summary>
        /// <param name="buttonName">Button name</param>
        public void ClickOnButtonROL(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                switch (buttonName)
                {
                    case "Register now":
                        base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                            Login_Page_ActivatePage_ROL_RegisterButton_Xpath_Locator));
                        IWebElement getRegButton = GetWebElementPropertiesByXPath(ApplicationLoginPageResource.
                            Login_Page_ActivatePage_ROL_RegisterButton_Xpath_Locator);
                        ClickByJavaScriptExecutor(getRegButton);
                        break;

                    case "Forgot your password":
                        base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_ForgotPassword_Xpath_Locator));
                        base.ClickButtonByXPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_ForgotPassword_Xpath_Locator);
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
        /// Enter DOB and Card activation code
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void EnterDOBAndCardActivationCode(User.UserTypeEnum userType, string productName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Date of birth from inmemory
                string nd = GetPageTitle;
                User user = User.Get(userType);
                string DOB = user.DOB.ToString();
                string employeeNo = User.Get(userType).EmployeeNumber;
                // Get Card Activation Code from DB
                string cardActivationCode = new DBUserQueries().GetCardActivationCode(userType, productName);
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                // Fill Date of Birth(DD / MM / YYYY)
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_LoginDOB_ID_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_LoginDOB_ID_Locator);
                // base.FillTextBoxById("DOBTextBox", DOB);
                base.FillTextBoxById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_LoginDOB_ID_Locator, DOB);

                // Fill Card Activation Code
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_LoginActiavtionCodeTextBox_ID_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_LoginActiavtionCodeTextBox_ID_Locator);
                base.FillTextBoxById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_LoginActiavtionCodeTextBox_ID_Locator,
                    cardActivationCode);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter DOB and Card activation code
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void EnterDOBAndCardActivationCodeROL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Fill Date of Birth(DD / MM / YYYY)/
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_ROL_LoginDOB_ID_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_ROL_LoginDOB_ID_Locator);
                // base.FillTextBoxById("DOBTextBox", DOB);
                base.FillTextBoxById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_ROL_LoginDOB_ID_Locator, "4/11/1980");

                // Fill Card Activation Code
                base.WaitForElement(By.Id("CardActivationCode"));
                base.ClearTextById("CardActivationCode");
                base.FillTextBoxById("CardActivationCode", "YV5Z0710H");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on continue button.
        /// </summary>
        public void ClickContinueButtonMOL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                //Wait and click on continue button
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_ContinueButton_ID_Locator), 50);
                IWebElement getContinueButton = GetWebElementProperties(By.Id(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_MOL_ContinueButton_ID_Locator));
                ClickByJavaScriptExecutor(getContinueButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on continue button.
        /// </summary>
        public void ClickContinueButtonROL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_ROL_ContinueButton_ID_Locator));
                base.ClickButtonById(ApplicationLoginPageResource.
                    Login_Page_ActivatePage_ROL_ContinueButton_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User login as ROL user
        /// </summary>
        /// <param name="userName">This is the user name.</param>
        /// <param name="password">This is password.</param>
        public void ROLUserLogin(string userName, string password, string userNameType, string passwordType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                this.WaitandSelectROLWindow();

                // Enter username
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator);
                // Enter user name based on the user name type
                switch (userNameType)
                {
                    case "Valid username":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator, userName);
                        break;

                    case "Invalid username":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                  ApplicationLoginPage_ROL_UserNameTextBox_Id_Locator, "Invalid User");
                        break;
                }

                // Enter Password
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator);
                switch (passwordType)
                {
                    case "Valid password":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator, password);
                        break;

                    case "Invalid password":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                   ApplicationLoginPage_ROL_PasswordTextBox_Id_Locator, "Invalid Password");
                        break;
                }
                // Click Login
                base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_LoginButton_Click_XPath_Locator));
                base.ClickButtonByXPath(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_LoginButton_Click_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Wait untill window loads and select the window.
        /// </summary>
        protected void WaitandSelectROLWindow()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                // Select window
                base.SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login as user based on the user type
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void LoginAsUser(User.UserTypeEnum userType, string userNameType, string passwordType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the username and password based on the user type
                User user = User.Get(userType);
                // Execute based on the user type
                switch (userType)
                {
                    case User.UserTypeEnum.ROLUser:
                    case User.UserTypeEnum.ROLWalletTransactionUser:
                    case User.UserTypeEnum.ROLNonWalletTransactionUser:
                    case User.UserTypeEnum.ROLNoReimbursement:
                        string ROLuserName = user.Name.ToString();
                        string ROLpassword = new DBUserQueries().ChangePasswordOfUserName(ROLuserName);
                        // Enter user name and password
                        new LoginPage().ROLUserLogin(ROLuserName, ROLpassword, userNameType, passwordType);
                        break;

                    case User.UserTypeEnum.MOLUser:
                    case User.UserTypeEnum.MOLWalletTransactionUser:
                    case User.UserTypeEnum.MOLNonWalletTransactionUser:
                    case User.UserTypeEnum.MOLNoReimbursement:
                    case User.UserTypeEnum.MOLMultipleEmployeerEmployee:
                    case User.UserTypeEnum.MOLActiveTerminatedEmployeerEmployee:
                    case User.UserTypeEnum.MOLBenefitMergeWithEmployeer:
                    case User.UserTypeEnum.MOLNovetedLeaseBenefitSingleTitle:
                    case User.UserTypeEnum.MOLMultipleLeasePackaingWithTELSRA:
                        string MOLuserName = user.Name.ToString();
                        string MOLpassword = new DBUserQueries().ChangePasswordOfUserName(MOLuserName);
                        // Enter user name and password
                        new LoginPage().MOLUserLogin(MOLuserName, MOLpassword, userNameType, passwordType);
                        break;

                    case User.UserTypeEnum.OnlyVMSUser:
                        // Get VMS only users from DB
                        string getOnlyVMSuserName = new DBUserQueries().GetOnlyVMSEmloyeeWithPasswordChange();
                        string OnlyVMSpassword = "Password123";
                        // Enter user name and password
                        new LoginPage().VMSAndMOLRandomUserLogin(getOnlyVMSuserName, OnlyVMSpassword, userType);
                        // Store data in memory
                        user.Password = "Password123";
                        user.Name = getOnlyVMSuserName;
                        user.UpdateUserInMemory(user);
                        break;

                    case User.UserTypeEnum.MOLRandomUser:
                        string MOLRandomuserName = new DBUserQueries().RandomEmployeeUsernameWithChagedPassword("PHCN");
                        user.Name = MOLRandomuserName;
                        string MOLRandompassword = "Password123";
                        // Enter user name and password
                        new LoginPage().VMSAndMOLRandomUserLogin(MOLRandomuserName, MOLRandompassword, userType);
                        // Store data in memory
                        user.Password = "Password123";
                        user.UpdateUserInMemory(user);
                        break;
                }
            }
            catch (Exception e)
            {
                LoginSpace = "";
                UserName = "";
                UserType = "";
                Password = "";
                ExceptionHandler.HandleException(e);
                throw;
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User login as MOL user
        /// </summary>
        /// <param name="userName">This is the user name.</param>
        /// <param name="password">This is password.</param>
        public void MOLUserLogin(string userName, string password, string userNameType, string passwordType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                this.WaitandSelectMOLWindow("Loginpage");

                // Enter username
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator);
                // Enter user name based on the user name type
                switch (userNameType)
                {
                    case "Valid username":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator, userName);
                        break;

                    case "Invalid username":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator, ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_InvalidUserName);
                        break;
                }

                // Enter Password
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator);
                // Enter password based on the user name type
                switch (passwordType)
                {
                    case "Valid password":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator, password);
                        break;

                    case "Invalid password":
                        base.FillTextBoxById(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator,
                            ApplicationLoginPageResource.ApplicationLoginPage_MOL_PasswordTextBox_InvalidPassword_Text);
                        break;
                }
                // Click
                base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginButton_Click_XPath_Locator));
                base.ClickButtonByXPath(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginButton_Click_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User login as MOL user
        /// </summary>
        /// <param name="userName">This is the user name.</param>
        /// <param name="password">This is password.</param>
        public void VMSAndMOLRandomUserLogin(string userName, string password, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                int numberOfAttempts = 1;
            Found:
                User user = User.Get(userType);
                //Wait untill window load
                this.WaitandSelectMOLWindow("Loginpage");

                // Enter username
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator);
                base.FillTextBoxById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_UserNameTextBox_Id_Locator, userName);

                // Enter Password
                base.WaitForElement(By.Id(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator));
                base.ClearTextById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator);
                base.FillTextBoxById(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_PasswordTextBox_Id_Locator, password);

                // Click
                base.WaitForElement(By.XPath(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginButton_Click_XPath_Locator));
                base.ClickButtonByXPath(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginButton_Click_XPath_Locator);

                if (IsElementPresent(By.XPath(ApplicationLoginPageResource.
                    Login_Page_MOL_LoginErrorMessage_XpathLocator), 10))
                {
                    if (numberOfAttempts <= 3)
                    {
                        numberOfAttempts++;
                        goto Found;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Wait until window loads and select the window.
        /// </summary>
        protected void WaitandSelectMOLWindow(string pageStatus)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);

            try
            {
                switch (pageStatus)
                {
                    case "Loginpage":
                        // Wait until window loads
                        base.WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_LoginPageTitle_Title);
                        // Select window
                        base.SelectWindow(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_LoginPageTitle_Title);
                        break;

                    case "Dashboard":
                        // Wait until window loads
                        base.WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                        // Select window
                        base.SelectWindow(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_DashboardPageTitle_Title);
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
        /// Get the home page title from the application.
        /// </summary>
        /// <returns>This will return the page title.</returns>
        public string GetUserHomePageName()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            // Initialize the page name veriable to null
            string getPageName = null;

            try
            {
                //Wait untill the page loads
                base.WaitUntilWindowLoads(base.GetPageTitle);
                base.SelectWindow(base.GetPageTitle);
                // Get the page name
                getPageName = base.GetWindowTitleByJavaScriptExecutor();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getPageName;
        }

        /// <summary>
        /// Get the Current URL of rge appliction
        /// </summary>
        /// <returns> URL string is been returened</returns>
        public string GetURL()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string URL = "";
            try
            {
                URL = base.GetCurrentUrl;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return URL;
        }

        /// <summary>
        /// Return validation message exeistance status
        /// </summary>
        /// <returns>Return status of validation message.</returns>
        public bool GetStatusOfValidationMessage(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getStatusOfValidationMessage = false;
            try
            {
                string validationMessage = string.Empty;
                string appValidationMessage = string.Empty;
                switch (messageType)
                {
                    case "InvalidPasswordError":
                        WaitForElement(By.XPath(ApplicationLoginPageResource.
                        ApplicationLoginPage_MOL_Errormessage_GetText_Xpath), 50);
                        if (GetInnerTextAttributeValueByXPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_Errormessage_GetText_Xpath).Equals(
                            ApplicationLoginPageResource.ApplicationLoginPage_MOL_ValidUNandInvalidPWD_ErroeText))
                        {
                            getStatusOfValidationMessage = true;
                        }
                        break;

                    case "InvalidUserNameError":
                        WaitForElement(By.XPath(ApplicationLoginPageResource.
                        ApplicationLoginPage_MOL_Errormessage_GetText_Xpath), 50);
                        if (GetInnerTextAttributeValueByXPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_Errormessage_GetText_Xpath).Equals(
                            ApplicationLoginPageResource.ApplicationLoginPage_MOL_InValidUNandValidPWD_ErroeText))
                        {
                            getStatusOfValidationMessage = true;
                        }
                        break;

                    case "InvalidUserNameandPasswordError":
                        WaitForElement(By.XPath(ApplicationLoginPageResource.
                        ApplicationLoginPage_MOL_Errormessage_GetText_Xpath), 50);
                        if (GetInnerTextAttributeValueByXPath(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_Errormessage_GetText_Xpath).Equals(
                            ApplicationLoginPageResource.ApplicationLoginPage_MOL_InValidUNandValidPWD_ErroeText))
                        {
                            getStatusOfValidationMessage = true;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getStatusOfValidationMessage;
        }

        /// <summary>
        /// Verify the ROL login validtion error
        /// </summary>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public bool GetStatusOfValidationMessageROL(string messageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool returenStatus = false;
            try
            {
                WaitForElement(By.XPath(ApplicationLoginPageResource.Login_Page_ROL_LoginErrorMessage_XpathLocator));
                string errorMessage = GetInnerTextAttributeValueByXPath(ApplicationLoginPageResource.Login_Page_ROL_LoginErrorMessage_XpathLocator);
                switch (messageType)
                {
                    case "InvalidPasswordError":

                        if (errorMessage == ApplicationLoginPageResource.Login_Page_ROL_LoginErrorMessageInvalidPasswordUserName_Text_Message)
                        {
                            returenStatus = true;
                        }
                        break;

                    case "AccountSuspenndedError":
                        if (errorMessage == ApplicationLoginPageResource.Login_Page_ROL_LoginErrorMessageAccountSuspended_Text_Message)
                        {
                            returenStatus = true;
                        }
                        break;
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
        /// Reset the nuber of failed login attempt to Zero
        /// </summary>
        /// <param name="userType">User type to reset</param>
        public void ResetFailEdLoginAttemptToZero(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                User user = User.Get(userType);
                string userName = user.Name;
                new DBUserQueries().UnLockSuspenedAccount(userName);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}