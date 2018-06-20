using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.ActivationSitePages
{
    public class ActivateLogin : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ActivateLogin));

        /// <summary>
        /// Verify the page landed on the Login page of the Actiavtion site
        /// </summary>
        /// <returns>This will return the page title.</returns>
        public string VeriFyThePageLandedOnActivationSite()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageTilte = "";
            try
            {
                pageTilte = GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return pageTilte;
        }

        /// <summary>
        /// Enter the login detils Date birth and the EAID
        /// </summary>
        /// <param name="role">User role</param>
        public void EnterTheLoginDetails(User.UserTypeEnum role)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                string product = string.Empty;
                //Enter thye DOB in Text box
                WaitForElement(By.XPath(ActivateLoginResources.
                    ActivationSite_LoginPage_DOB_Xpath_Loctator));

                FillTextBoxByXPath(ActivateLoginResources.
                    ActivationSite_LoginPage_DOB_Xpath_Loctator, "");

                // Enter the EAID in Text box
                WaitForElement(By.XPath(ActivateLoginResources.
                    ActivationSite_LoginPage_EAID_Xpath_Loctator));
                string EAIDNumber = string.Empty;
                EAIDNumber = new DBUserQueries().GetCardActivationCode(role, product);
                FillTextBoxByXPath(ActivateLoginResources.
                   ActivationSite_LoginPage_EAID_Xpath_Loctator, EAIDNumber);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the login button
        /// </summary>
        public void ClickOnLoginButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitForElement(By.XPath(ActivateLoginResources.
                    ActivationSite_LoginPage_ContinueButton_Xpath_Loctator));
                ClickButtonByXPath(ActivateLoginResources.
                    ActivationSite_LoginPage_ContinueButton_Xpath_Loctator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Runing the Disable Store poc to diable SMS Validation
        /// </summary>
        /// <param name="SMSStorPoc">Status of the SMS </param>
        public void SMSValidationControler(string SMSStorPoc)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                new DBUserQueries().SMSValidationStorePoc(SMSStorPoc);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Running the store poc to insert in to Employee profile table
        /// </summary>
        public void RunningStoreProcToInsertInTable(string storeProcName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                new DBUserQueries().RunStoreProcToPopulateProfile(storeProcName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}