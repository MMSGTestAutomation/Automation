using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Home
{
    public class ContactPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LoginPage));

        /// <summary>
        /// Verify the toggle functionality between employeer
        /// </summary>
        /// <returns>able id togle if togles and noable if togle is not present</returns>
        public string VerifyTheToggleBetweenEmployeer()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string toggleStatus = "";
            try
            {
                IWebElement employeerName = GetWebElementPropertiesByXPath(ContactResource.
                            ContactPage_EmployeerName_Xpath_Locator);
                PerformMouseClickAction(employeerName);
                int countEmployeer = 0;
                if (IsElementPresent(By.XPath(ContactResource.
                    ContactPage_EmployeerNameCount_Xpath_Locator), 20))
                {
                    countEmployeer = GetElementCountByXPath(ContactResource.
                                       ContactPage_EmployeerNameCount_Xpath_Locator);
                }
                if (countEmployeer > 1)
                {
                    for (int i = 1; i <= countEmployeer; i++)
                    {
                        IWebElement employeerNameToClick = GetWebElementPropertiesByXPath(ContactResource.
                            ContactPage_EmployeerName_Xpath_Locator);
                        PerformMouseClickAction(employeerNameToClick);
                        ClickLinkByXPath(string.Format(ContactResource.
                            ContactPage_EmployeerNameToClick_Xpath_Locator, i));
                        toggleStatus = "able";
                    }
                }
                else
                {
                    toggleStatus = "unable";
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return toggleStatus;
        }

        /// <summary>
        /// Select the drop down
        /// </summary>
        /// <param name="dropDownOption">option to be selected </param>
        /// <param name="dropDownName">Option to be selected in drop down name</param>
        public void SelectDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (dropDownName)
                {
                    case "I want to":
                        IWebElement dropDownButtonIwantTo = GetWebElementProperties(By.XPath(ContactResource.
                            ContactPage_IWantToDropDownButton_Id_Locator));
                        ClickByJavaScriptExecutor(dropDownButtonIwantTo);
                        ClickButtonByPartialLinkText(dropDownOption);
                        break;

                    case "Change":
                        IWebElement dropDownButtonChange = GetWebElementProperties(By.XPath(ContactResource.
                            ContactPage_ChangeButton_Xpath_Locator));
                        ClickByJavaScriptExecutor(dropDownButtonChange);
                        ClickButtonByPartialLinkText(dropDownOption);
                        break;

                    case "Remove Benefit":
                        IWebElement dropDownButtonRemoveBenefit = GetWebElementProperties(By.XPath(ContactResource.
                            ContactPage_RemoveBenefitButton_Xpath_Locator));
                        ClickByJavaScriptExecutor(dropDownButtonRemoveBenefit);
                        ClickButtonByPartialLinkText(dropDownOption);
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
        /// Clicking on the Pay date options
        /// </summary>
        /// <param name="optionName">Option Name to be selected</param>
        public void ClickOnPayDateForChange(string optionName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    case "Next pay date for change":
                        IWebElement radioButtonPayDateForChange = GetWebElementProperties(By.Id(ContactResource.
                            ContactPage_NextPayDateForChange_Id_Locator));
                        ClickByJavaScriptExecutor(radioButtonPayDateForChange);
                        break;

                    case "Select a pay date":
                        IWebElement radioButtonSelecDate = GetWebElementProperties(By.Id(ContactResource.
                            ContactPage_SelectAPayDate_Id_Locator));
                        ClickByJavaScriptExecutor(radioButtonSelecDate);
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
        /// Clicking on the Benefit in Remove benefit dropdown
        /// </summary>
        public void SelectBenefitFromRemoveBenefit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Clicking on the dropdown option
                WaitForElement(By.XPath(ContactResource.ContactPage_SelectBenefitButton_Xpath_Locator));
                ClickButtonByXPath(ContactResource.ContactPage_SelectBenefitButton_Xpath_Locator);
                //Selecting the option from dropdown
                WaitForElement(By.XPath(ContactResource.ContactPage_BenefitOption_Xpath_Locator));
                ClickButtonByXPath(ContactResource.ContactPage_BenefitOption_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Prefered Option for contact
        /// </summary>
        /// <param name="preferedOption">Option Name to be selected</param>
        public void SelectPreferredContact(string preferredOption)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (preferredOption)
                {
                    case "Phone":
                        WaitForElement(By.Id(ContactResource.
                            ContactPage_PhoneNumberRadioButton_Id_Locator));
                        ClickButtonById(ContactResource.
                            ContactPage_PhoneNumberRadioButton_Id_Locator);
                        break;

                    case "Email":
                        WaitForElement(By.Id(ContactResource.
                            ContactPage_EmailRadioButton_Id_Locator));
                        ClickButtonById(ContactResource.
                            ContactPage_EmailRadioButton_Id_Locator);
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
        /// Entering the value in Text box
        /// </summary>
        /// <param name="fieldsName">Field to be field</param>
        public void FillTheFields(string fieldsName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (fieldsName)
                {
                    case "Message":
                        WaitForElement(By.Id(ContactResource.
                            ContactPage_MessageText_Id_Locator));
                        FillTextBoxById(ContactResource.
                            ContactPage_MessageText_Id_Locator, ContactResource.ContactPage_MessageText_Text);
                        break;

                    case "Email":
                        WaitForElement(By.Id(ContactResource.
                            ContactPage_EmailText_Id_Locator));
                        FillTextBoxById(ContactResource.
                            ContactPage_EmailText_Id_Locator, ContactResource.ContactPage_EmailIdText_Text);
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
        /// Verify the Iqueue is created when Contact page are submitted
        /// </summary>
        /// <param name="userType">User type</param>
        /// <returns>True if Iqueue is created and Succes message is </returns>
        public bool VerifyIqueueCreatedWhenClickedOnSubmit(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                User user = User.Get(userType);
                string username = user.Name;
                //Verify the Number of Iqueue before submit
                string countOfIqueueBeforeSubmitInstring = new DBUserQueries().CountOfIqueueWithAwaitingForEmployeeUserName(username);
                int numberOfIqueueBeforeSubmit = Int32.Parse(countOfIqueueBeforeSubmitInstring);

                //clicking on the Submit button
                WaitForElement(By.Id(ContactResource.ContactPage_SubmitButton_Id_Locator));
                ClickButtonById(ContactResource.ContactPage_SubmitButton_Id_Locator);

                //Verify the Iqueue after submit
                string countOfIqueueAfterSubmitInstring = new DBUserQueries().CountOfIqueueWithAwaitingForEmployeeUserName(username);
                int numberOfIqueueAfterSubmit = Int32.Parse(countOfIqueueAfterSubmitInstring);

                //Getting the Success message
                string successMessaage = GetElementInnerTextByXPath(ContactResource.
                    ContactPage_Successmessage_Xpath_Locator);

                //Verifying the Iqueue is created and success Mesage validation
                if (numberOfIqueueAfterSubmit > numberOfIqueueBeforeSubmit && successMessaage == ContactResource.
                    ContactPage_Successmessage_Value)
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