using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using System;
using System.Configuration;
using System.Diagnostics;

namespace MMSG.Pages.UI_Pages
{
    public class BrowseMMSGUserURL : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(BrowseMMSGUserURL));

        /// <summary>
        /// This is the login retry count.
        /// </summary>
        private static readonly int LoginAttemptRetryCount = Convert.ToInt32(ConfigurationManager.
            AppSettings[ApplicationLoginPageResource.Login_Page_AppSetting_RetryCount_Key]);

        /// <summary>
        /// Get Wait Limit Time From Config.
        /// </summary>
        private readonly int _getWaitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Initialize base MMSG login Url.
        /// </summary>
        private readonly string _baseLoginUrl = null;

        /// <summary>
        ///  Get Title of the Page.
        /// </summary>
        public new string GetPageTitle()
        {
            //Get Page Title
            { return base.GetPageTitle; }
        }

        // Property of URL
        public string GetURL
        {
            get { return this._baseLoginUrl; }
        }

        /// <summary>
        /// Gets the base login Url from configuration.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        public BrowseMMSGUserURL(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    // Get URL of ROL
                    case User.UserTypeEnum.ROLUser:
                    case User.UserTypeEnum.ROLWalletTransactionUser:
                    case User.UserTypeEnum.ROLNonWalletTransactionUser:
                    case User.UserTypeEnum.ROLNoReimbursement:
                        _baseLoginUrl = (AutomationConfigurationManager.ApplicationUrlRoot).ToString();
                        break;
                    // Get URL of COMET
                    case User.UserTypeEnum.COMETUser:
                    case User.UserTypeEnum.NewCOMETUser:
                        _baseLoginUrl = (AutomationConfigurationManager.ApplicationUrlRoot).ToString();
                        break;
                    // Get URL of MOL
                    case User.UserTypeEnum.MOLUser:
                    case User.UserTypeEnum.MOLWalletTransactionUser:
                    case User.UserTypeEnum.MOLNoReimbursement:
                    case User.UserTypeEnum.OnlyVMSUser:
                    case User.UserTypeEnum.MOLMultipleEmployeerEmployee:
                    case User.UserTypeEnum.MOLActiveTerminatedEmployeerEmployee:
                    case User.UserTypeEnum.MOLBenefitMergeWithEmployeer:
                    case User.UserTypeEnum.MOLNovetedLeaseBenefitSingleTitle:
                    case User.UserTypeEnum.MOLRandomUser:
                    case User.UserTypeEnum.MOLMultipleLeasePackaingWithTELSRA:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.ApplicationUrlRoot);
                        break;

                    case User.UserTypeEnum.MOLActivation:

                        if (ConfigurationManager.AppSettings["Product"] == "COMET")
                        {
                            string rootURL = (AutomationConfigurationManager.ApplicationUrlRoot).Replace("/Comet", ".securemaxxia.com.au");
                            string getEnvironment = rootURL.Substring(7, 6);
                            _baseLoginUrl = string.Format(rootURL.Replace(getEnvironment, "") + ApplicationLoginPageResource.Login_Page_MOL_Activation);
                        }
                        else
                        {
                            _baseLoginUrl = string.Format(
                                AutomationConfigurationManager.ApplicationUrlRoot
                                     + ApplicationLoginPageResource.Login_Page_MOL_Activation);
                        }
                        break;

                    case User.UserTypeEnum.ROLActivation:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.ApplicationUrlRoot
                                 + ApplicationLoginPageResource.Login_Page_MOL_Activation);
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
        ///  Navigates from base Url in browser through WebDriver.
        /// </summary>
        public void GoToLoginUrl()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    NavigateToBrowseUrl(this._baseLoginUrl);
                    string title = base.GetPageTitle;
                    if (title == "Certificate Error: Navigation Blocked")
                    {
                        NavigateToBrowseUrl("javascript:document.getElementById('overridelink').click()");
                    }
                }
                else
                {
                    throw new Exception("Browser cannot display the webpage");
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Navigates from base Url in browser through WebDriver.
        /// </summary>
        public void GoToCometLoginUrl()
        {
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    NavigateToBrowseUrl(this._baseLoginUrl);
                    SwitchToPopup();
                    MaximizeWindow();
                }
                else
                {
                    throw new Exception("Browser cannot display the webpage");
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Check thr Url Browsed Successfully.
        /// </summary>
        /// <returns>True if Url browsed successfully else false.</returns>
        /// <remarks>Slow web page loading or page not found then this
        /// method open the Url in the address bar and wait till specified time
        ///  to page get successfully browse.</remarks>
        public Boolean IsUrlBrowsedSuccessful()
        {
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Get Image Present On The Page
            String getCurrentPageTitle = base.GetPageTitle;
            if (getCurrentPageTitle.Equals(ApplicationLoginPageResource.ApplicationLoginPage_MOL_LoginButton_Click_XPath_Locator
                ) || getCurrentPageTitle.Equals
                (ApplicationLoginPageResource.Login_Page_404Error_Window_Title))
            {
                while (stopWatch.Elapsed.TotalSeconds < _getWaitTimeOut)
                {
                    //Navigate Base Url
                    NavigateToBrowseUrl(this._baseLoginUrl);
                    getCurrentPageTitle = base.GetPageTitle;
                    if (!getCurrentPageTitle.Equals(ApplicationLoginPageResource.
                        ApplicationLoginPage_MOL_LoginButton_Click_XPath_Locator) && !getCurrentPageTitle.Equals
                (ApplicationLoginPageResource.Login_Page_404Error_Window_Title))
                    {
                        stopWatch.Stop();
                        return true;
                    }
                }
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return true;
        }
    }
}