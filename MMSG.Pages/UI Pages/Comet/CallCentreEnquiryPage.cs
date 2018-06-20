using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class CallCentreEnquiryPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CallCentreEnquiryPage));

        public static string empNumber = "";

        /// <summary>
        /// Get the application logo existance status
        /// </summary>
        /// <returns>Return logo existance status.</returns>
        public bool GetApplicationLogoExistance()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getApplicationLogoExistance = false;
            try
            {
                WaitUntilPopUpLoads(GetPageTitle);
                getApplicationLogoExistance = IsElementPresent(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_ApplictionLogo_Id_Locator), 10);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getApplicationLogoExistance;
        }

        /// <summary>
        /// Search user based on the input search criteria
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void UserSearch(string optionName, User.UserTypeEnum userType, string dataFetchType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                string employeeNumber = string.Empty;
                string surName = string.Empty;
                string givenName = string.Empty;
                string employerCode = string.Empty;
                User user = User.Get(userType);

                switch (dataFetchType)
                {
                    case "DB":
                        employeeNumber = new DBUserQueries().GetEmployeeNumberBySurName(userType);
                        break;

                    case "XML":
                        //Get user details from XML
                        employeeNumber = user.EmployeeNumber.ToString();
                        surName = user.Name.ToString();
                        givenName = user.GivenName.ToString();
                        employerCode = user.EmployerCode.ToString();
                        break;

                    case "InMemory":
                        //Get user details from InMemory
                        employeeNumber = user.EmployeeNumber.ToString();
                        string EmployeeNumberFromInMomory = User.Get(userType).EmployeeNumber;
                        break;
                }
                // Enter the data into the search text box based on the data fetch criteria
                SearchComentUser(optionName, employeeNumber, surName, givenName, employerCode);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Employe Random
        /// </summary>
        /// <param name="searchType">Search type is random</param>
        ///  <param name="employerCode">Employer Code ned to searched</param>
        public void SearchEmployee(string searchType, string employerCode)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                string employeeNumber = string.Empty;
                string surName = string.Empty;
                string givenName = string.Empty;
                switch (searchType)
                {
                    case "Random":
                        employeeNumber = new DBUserQueries().GetTheRandomEmployee(employerCode);
                        break;
                }
                // Enter the data into the search text box based on the data fetch criteria
                SearchComentUser("EmployeeNumber", employeeNumber, surName, givenName, employerCode);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search comet user based on the search option type.
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="employeeNumber">This is employee number.</param>
        /// <param name="surName">This is sur name.</param>
        /// <param name="givenName">This is given name.</param>
        /// <param name="employerCode">This is employer code.</param>
        private void SearchComentUser(string optionName, string employeeNumber, string surName,
            string givenName, string employerCode)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitUntilPopUpLoads(GetPageTitle);
                // Search based on option
                switch (optionName)
                {
                    case "EmployeeNumber":
                        WaitForElement(By.Id(CallCentreEnquiryResource.
                            CallCentreEnquiry_EmployeeNumberTextBox_Id_Locator));
                        FillTextBoxById("CCEmployeeSearch_txtEmployeeNumber", employeeNumber);
                        break;

                    case "EmployerCode":
                        WaitForElement(By.Id(CallCentreEnquiryResource.
                            CallCentreEnquiry_EmployerCodeTextBox_Id_Locator));
                        FillTextBoxById(CallCentreEnquiryResource.
                            CallCentreEnquiry_EmployerCodeTextBox_Id_Locator, employerCode);
                        break;

                    case "Surname":
                        WaitForElement(By.Id(CallCentreEnquiryResource.
                            CallCentreEnquiry_SurnametextBox_Id_Locator));
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
        /// Click search button
        /// </summary>
        public void ClickSearchButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill popup loads
                WaitUntilPopUpLoads(GetPageTitle);
                // Wait for search button to load
                WaitForElement(By.Id(CallCentreEnquiryResource.CallCentreEnquiry_SearchButton_Id_Locator));
                // Click button by ID
                IWebElement getSearchButton = GetWebElementPropertiesById(CallCentreEnquiryResource.
                    CallCentreEnquiry_SearchButton_Id_Locator);
                ClickByJavaScriptExecutor(getSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get element existance details from application
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        /// <returns>This will return employee existance status.</returns>
        public bool GetEmployeeDetailsDisplayStatus(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getEmployeeDetailsStatus = false;
            try
            {
                // Get user details from inmemory
                User user = User.Get(userType);
                string employeeNo = user.EmployeeNumber.ToString();
                string employeeName = user.Name.ToString();
                string gender = user.Gender.ToString();
                string email = user.Email.ToString();

                // Get user details from application
                string getEmployeeNo = GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Id_Locator);
                string getEmployeeName = GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeName_Id_Locator);
                string getGender = GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeGender_Id_Locator);
                string getEmail = GetInnerTextAttributeValueById(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeEmail_Id_Locator);

                if (getEmployeeNo.Equals(employeeNo) &&
                    getEmployeeName.Contains(employeeName) && getGender.Equals(gender) && getEmail.Equals(email))
                {
                    getEmployeeDetailsStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getEmployeeDetailsStatus;
        }

        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickOptionOnCCEnquiryPage(string optionName, string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                SetPageLoadWaitTime(20);
                switch (optionName)
                {
                    case "New":
                        ClickNewButton(pageName);
                        break;

                    case "Create New Package":
                        ClickCreateNewPackageLink(pageName);
                        break;

                    case "Amendment":
                        ClickOnTheAmendmentOptionInTreeView(pageName);
                        break;

                    case "Process Menu":
                        ClickOnProcessMenu(pageName);
                        break;

                    case "Benefit":
                        ClickOnBenefit(pageName);
                        break;

                    case "Employee Number":
                        ClickOnEmpNum(pageName);
                        break;

                    case "MOL Co-Navigation":
                        ClickOnCoNavigation(optionName);
                        break;

                    case "Card Screen":
                        ClickCardScreen(pageName);
                        break;

                    case "New Request":
                        ClickOnNewRequest(pageName);
                        break;

                    case "Request History":
                        ClickOnRequestHistory(pageName);
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
        /// Clicking on the Request History
        /// </summary>
        public void ClickOnRequestHistory(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                // Clickin on the New Request link
                WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_RequestHistory_Id_Locator));
                IWebElement getRequestHistory = GetWebElementPropertiesById(
                    CallCentreEnquiryResource.
                    CallCentreEnquiry_RequestHistory_Id_Locator);
                PerformMouseClickAction(getRequestHistory);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On the new Request
        /// </summary>
        public void ClickOnNewRequest(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                // Clickin on the New Request link
                WaitForElement(By.Id(CallCentreEnquiryResource.CallCentreEnquiry_NewRequest_Id_Locator));
                IWebElement getNewRequest = GetWebElementProperties(By.Id(CallCentreEnquiryResource.CallCentreEnquiry_NewRequest_Id_Locator));
                ClickByJavaScriptExecutor(getNewRequest);
                // ClickButtonById(CallCentreEnquiryResource.CallCentreEnquiry_NewRequest_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clickon the processmenu of the Call cenetre Enquiry Screen
        /// </summary>
        public void ClickOnProcessMenu(string PageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(PageTitle);
                SelectWindow(PageTitle);
                // Wait and click on process link
                WaitForElement(By.CssSelector(
                    CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Css_Selector));
                IWebElement getProcessLink = GetWebElementPropertiesByCssSelector
                    (CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Css_Selector);
                PerformMouseClickAction(getProcessLink);
                ClickLinkByCssSelector(CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Css_Selector);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Benefit
        /// </summary>
        public void ClickOnBenefit(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                WaitForDocumentLoadToComplete(20);
                WaitForElement(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_Benifit_LinkText_Locator));
                IWebElement getLink = GetWebElementProperties(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_Benifit_LinkText_Locator));
                PerformMouseClickAction(getLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickNewButton(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                // Wait untill new button loads and click on the button
                WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_NewButton_Id_Locator));
                IWebElement getNewButton = GetWebElementProperties(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_NewButton_Id_Locator));
                ClickByJavaScriptExecutor(getNewButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click new button in Call Centre Enquiry page
        /// </summary>
        public void ClickCreateNewPackageLink(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                // Waiting for the New button and Cliking on the button using the java  script executor
                WaitForElement(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_CreatePackage_LinkText_Locator));
                IWebElement getNewButton = GetWebElementProperties(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_CreatePackage_LinkText_Locator));
                ClickByJavaScriptExecutor(getNewButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the created package display in call center enquiry screen
        /// </summary>
        /// <param name="packageType">This is package type enum.</param>
        /// <param name="userType">This is user type enum.</param>
        /// <returns>Return package existance status.</returns>
        public bool VeriFyPackageName(Package.PackageTypeEnum packageType, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool packageIsPresent = false;
            try
            {
                //Get page title
                SwitchToDefaultWindow();
                string PageTitle = GetCometDomain() + " " + "CCEnquiry";
                // Get user type enum
                User user = User.Get(userType);
                WaitUntilPopUpLoads(PageTitle);
                SelectWindow(PageTitle);
                WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Id_Locator));
                // Employee Number from screen
                string employeeNumber = GetElementInnerTextById(
                    CallCentreEnquiryResource.CallCentreEnquiry_EmployeeNumber_Id_Locator);
                // Employee DOB from screen
                WaitForElement(By.Id(CallCentreEnquiryResource.CallCentreEnquiry_Employee_DOB_Locator));
                string employeeDOB = GetElementInnerTextById(
                    CallCentreEnquiryResource.CallCentreEnquiry_Employee_DOB_Locator);
                Package package = Package.Get(packageType);
                //Package Name From menery
                string getEmployerCode = package.EmployerCode.ToString();
                string toBeCompared = getEmployerCode + " " + "(" + employeeNumber;
                //Package name and employee name
                string employeeNumebrWithPackage = GetElementInnerTextById(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator);
                string text = employeeNumebrWithPackage.Remove(employeeNumebrWithPackage.Length - 7);
                //Store Employee number
                user.WriteUserInMemory(user, "EmployeeNumber", employeeNumber);
                user.EmployeeNumber = employeeNumber;
                user.UpdateUserInMemory(user);
                // Store date of birth
                user.WriteUserInMemory(user, "DOB", employeeDOB);
                if (text == toBeCompared)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return packageIsPresent;
        }

        /// <summary>
        /// Click new button in Call Amendment page
        /// </summary>
        public void ClickOnTheAmendmentOptionInTreeView(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                WaitForElement(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_Amendment_LinkText_Locator));
                IWebElement amendmentProperty = GetWebElementProperties(By.LinkText(CallCentreEnquiryResource.
                    CallCentreEnquiry_Amendment_LinkText_Locator));
                ClickByJavaScriptExecutor(amendmentProperty);
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
        public void StoreUserDetails(User.UserTypeEnum userTypeEnum, string employeeNumber)
        {
            //Stores User Details in Memory
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            //Store User Details in Memory
            this.StoreUserDetailsInMemory(userTypeEnum, employeeNumber);
            string sn = User.Get(userTypeEnum).EmployeeNumber.ToString();
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
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum, string employeeNumber)
        {
            //Save user in Memory
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            //Save user Details
            this.SaveUserInMemory
             (userTypeEnum, employeeNumber);
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
        private void SaveUserInMemory(User.UserTypeEnum userTypeEnum, string employeeNumber)
        {
            //Save The User In Memory
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            User newUser = new User
            {
                EmployeeNumber = employeeNumber.ToString(),
                IsCreated = true,
            };
            //Save The User In Memory
            newUser.StoreUserInMemory();
            string hghj = User.Get(userTypeEnum).EmployeeNumber.ToString();
        }

        /// <summary>
        /// Clicking on the elelment in the process menu
        /// </summary>
        public void ProcessMenuPopUpClickOnElement(string optionName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                WaitUntilPopUpLoads(CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Title);
                SelectWindow(CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Title);
                switch (optionName)
                {
                    case "Admin Fees":
                        IWebElement adminProperties = GetWebElementPropertiesById(CallCentreEnquiryResource.
                            CallCentreEnquiry_ProcessMenuPopUp_AdminFrees_Id_Locator);
                        ClickByJavaScriptExecutor(adminProperties);
                        break;

                    case "Edit":
                        IWebElement editProperties = GetWebElementPropertiesById(CallCentreEnquiryResource.
                            CallCentreEnquiry_ProcessMenuPopUp_Edit_Id_Locator);
                        ClickByJavaScriptExecutor(editProperties);
                        break;

                    case "Review And Activate":
                        IWebElement reviewAndActivateProperties = GetWebElementPropertiesById(
                            CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenuPopUp_ReviewAndActivate_Locator1);
                        ClickByJavaScriptExecutor(reviewAndActivateProperties);
                        break;

                    case "New Benefit":
                        IWebElement newBenefitProperties = GetWebElementPropertiesById(CallCentreEnquiryResource.
                            CallCentreEnquiry_ProcessMenu__NewBenefit_Id_Locator);
                        ClickByJavaScriptExecutor(newBenefitProperties);
                        break;

                    case "Edit Payment Instructions":
                        IWebElement editPaymentInstruction = GetWebElementProperties(By.Id(CallCentreEnquiryResource.
                            CallCentreEnquiry_PopUpProcessMenuEditPaymentInstruction_ID_Locator));
                        ClickByJavaScriptExecutor(editPaymentInstruction);
                        break;

                    case "View Payment Instructions":
                        IWebElement viewPaymentInstruction = GetWebElementProperties(By.Id(CallCentreEnquiryResource.
                            CallCentreEnquiry_PopUpProcessMenuViewPaymentInstruction_ID_Locator));
                        ClickByJavaScriptExecutor(viewPaymentInstruction);
                        break;

                    case "EAMS":
                        IWebElement eamsProperties = base.GetWebElementPropertiesByXPath(CallCentreEnquiryResource.
                            CallCentreEnquiry_ProcessMenu__EAMS_Id_Locator);
                        base.ClickByJavaScriptExecutor(eamsProperties);
                        break;

                    case "New Vehicle":
                        IWebElement newVehicalProperties = base.GetWebElementPropertiesById("PopUpMenu_cmdMenu7");
                        base.ClickByJavaScriptExecutor(newVehicalProperties);
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
        /// Getting the title of Popup menu Process Menu
        /// </summary>
        /// <returns>Page title of pop up</returns>
        public string GetTheTitleOfpopUp()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string titleOfPage = "";
            try
            {
                SwitchToWindow(CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Title);
                WaitUntilPopUpLoads(CallCentreEnquiryResource.CallCentreEnquiry_ProcessMenu_Title);
                // Get page title during runtime
                titleOfPage = GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return titleOfPage;
        }

        /// <summary>
        /// Enter the Employee Number
        /// </summary>
        /// <param name="employeeNumner">Employee number</param>
        public void EnterTheEmployeeNumberAndSearch(string employeeNumner)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for search textbox to appear and fill text
                WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator));
                FillTextBoxById(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator, employeeNumner);

                // Click button by Search
                WaitForElement(By.Id(CallCentreEnquiryResource.
                    CallCentreEnquiry_SearchButton_Id_Locator));
                IWebElement getSearchButton = GetWebElementPropertiesById(
                    CallCentreEnquiryResource.CallCentreEnquiry_SearchButton_Id_Locator);
                ClickByJavaScriptExecutor(getSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the package is active
        /// </summary>
        /// <returns></returns>
        public bool VerifyThePackageStatusAsActive()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                string employeeNumebrWithPackage = GetElementInnerTextById(CallCentreEnquiryResource.
                    CallCentreEnquiry_PackageNameWithEmployeeNumber_Id_Locator);
                var result = employeeNumebrWithPackage.Substring(employeeNumebrWithPackage.Length - 3);
                string text = employeeNumebrWithPackage.Remove(employeeNumebrWithPackage.Length - 7);
                // compare the value with screen value is status is active
                if (result == "(A)")
                {
                    return true;
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
        /// Verify the page benefitGrid has been appeared
        /// </summary>
        /// <returns>Return BenefitGrid status.</returns>
        public bool VerifyTheBenefitGridHasAppeared()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool benefitGridStatus = false;
            try
            {
                IWebElement gridElemnet = GetWebElementProperties(
                    By.TagName(CallCentreEnquiryResource.CallCentreEnquiry_Iframe_TagName_Value));
                SwitchToIFrameByWebElement(gridElemnet);
                benefitGridStatus = IsElementPresent(
                    By.Id(CallCentreEnquiryResource.CallCentreEnquiry_GetBenifitGrid_Status));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return benefitGridStatus;
        }

        /// <summary>
        /// Clicking on the Benefit Grid
        /// </summary>
        public void ClickingOnTheBenefitOfGrid()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Getting the page title
                string PageTitle = GetCometDomain() + " " + "CCEnquiry";
                // selelcting the page
                SelectWindow(PageTitle);
                //Switch to frame
                SwitchToIFrameById(CallCentreEnquiryResource.
                    CallCentreEnquiry_BenefitGridFrame_Id_Locator);
                WaitForDocumentLoadToComplete(20);
                WaitForElement(By.XPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_BenefitGrid_Xpath_Locator));
                ClickLinkByXPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_BenefitGrid_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on employee number
        /// </summary>
        public void ClickOnEmpNum(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                WaitForDocumentLoadToComplete(10);
                WaitForElement(By.XPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Xpath));
                // Click Employee number
                base.FocusOnElementByXPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Xpath);
                ClickLinkByXPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Xpath);
                ClickLinkByXPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_EmployeeNumber_Xpath);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click on MOL Co-Navigation
        /// </summary>
        /// <param name="coNavText"></param>
        public void ClickOnCoNavigation(string coNavText)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SetPageLoadWaitTime(20);
                WaitUntilPopUpLoads(CallCentreEnquiryResource.CallCentreEnquiry_EAMSProfile_Title);
                SelectWindow(CallCentreEnquiryResource.CallCentreEnquiry_EAMSProfile_Title);
                SwitchToIFrameByIndex(0);
                // SwitchToIFrameByName(CallCentreEnquiryResource.CallCentreEnquiry_Iframe_Id);
                IWebElement coNavProperty = GetWebElementProperties(By.PartialLinkText
                    (CallCentreEnquiryResource.CallCentreEnquiry_MOLCoNav_Link_Title));
                ClickByJavaScriptExecutor(coNavProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on card option
        /// </summary>
        public void ClickCardScreen(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait until window load and select window
                SwitchToDefaultWindow();
                WaitUntilPopUpLoads(pageName);
                SelectWindow(pageName);
                // Wait for card screen link to load and click
                WaitForElement(By.Id(CallCentreEnquiryResource.CallCentreEnquiry_CarsScreen_Id_Locator));
                ClickButtonById(CallCentreEnquiryResource.CallCentreEnquiry_CarsScreen_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the Data for the further use
        /// </summary>
        /// <param name="paramenterName">parameter name</param>
        /// <param name="userType">User to type</param>
        public void SaveTheData(string paramenterName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get user from inmemory
                User user = User.Get(userType);
                switch (paramenterName)
                {
                    case "EmployeeName":
                        string employeeName = GetInnerTextAttributeValueById
                            (CallCentreEnquiryResource.CallCentreEnquiry_EmployeeName_Id_Locator);
                        user.Name = employeeName;
                        user.UpdateUserInMemory(user);
                        user.WriteUserInMemory(user, "Name", employeeName);
                        break;

                    case "PhoneNumber":
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
        /// Clicking on the Search in Vehical menu
        /// </summary>
        public void ClickingOnSearchInVehicalMenu()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Hover the mouse on the username option
                base.WaitForElement(By.Name(CallCentreEnquiryResource.
                    CallCentreEnquiry_TopMenuVehicle_Id_Locator));
                IWebElement getUserNameOption = base.
                    GetWebElementPropertiesByName(CallCentreEnquiryResource.
                    CallCentreEnquiry_TopMenuVehicle_Id_Locator);
                base.MouseOverByJavaScriptExecutor(getUserNameOption);

                // Click on logout option link
                string a = base.GetPageSource();
                bool a1 = base.IsElementPresent(By.XPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_TopMenuVehicleSearch_Xpath_Locator));
                base.WaitForElement(By.XPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_TopMenuVehicleSearch_Xpath_Locator));
                IWebElement getLogoutLink = base.GetWebElementPropertiesByXPath(CallCentreEnquiryResource.
                    CallCentreEnquiry_TopMenuVehicleSearch_Xpath_Locator);
                base.ClickByJavaScriptExecutor(getLogoutLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}