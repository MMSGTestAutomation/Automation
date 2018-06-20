using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages
{
    public class LogoutPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LogoutPage));

        /// <summary>
        /// Logout as user from application
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        public void LogoutAsUser(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for logout option t
                switch (userType)
                {
                    case User.UserTypeEnum.ROLUser:
                    case User.UserTypeEnum.ROLNonWalletTransactionUser:
                    case User.UserTypeEnum.ROLWalletTransactionUser:
                    case User.UserTypeEnum.ROLNoReimbursement:
                        //Wait untill window loads and select window
                        WaitandSelectROLWindow();
                        SwitchToDefaultWindow();
                        //Wait untill window load and select window
                        WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_PageTitle_Title);
                        SelectWindow(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_PageTitle_Title);
                        // Hover the mouse on the username option
                        WaitForElement(By.ClassName(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_loginuser_ClassName_Locator));
                        IWebElement getUserNameOption =
                            GetWebElementPropertiesByClassName("username");
                        PerformClickAndHoldAction(getUserNameOption);
                        WaitForElement(By.XPath(("//div[@class='popover bottom nav-popover']/div[2]/a")));
                        IWebElement getLogoutLink = GetWebElementPropertiesByXPath
                            ("//div[@class='popover bottom nav-popover']/div[2]/a");
                        ClickByJavaScriptExecutor(getLogoutLink);
                        Thread.Sleep(1000);
                        break;

                    case User.UserTypeEnum.MOLUser:
                    case User.UserTypeEnum.MOLActivation:
                    case User.UserTypeEnum.MOLNonWalletTransactionUser:
                    case User.UserTypeEnum.MOLWalletTransactionUser:
                    case User.UserTypeEnum.MOLNoReimbursement:
                    case User.UserTypeEnum.OnlyVMSUser:
                    case User.UserTypeEnum.MOLMultipleEmployeerEmployee:
                    case User.UserTypeEnum.MOLActiveTerminatedEmployeerEmployee:
                    case User.UserTypeEnum.MOLBenefitMergeWithEmployeer:
                    case User.UserTypeEnum.MOLNovetedLeaseBenefitSingleTitle:
                    case User.UserTypeEnum.MOLRandomUser:
                    case User.UserTypeEnum.MOLMultipleLeasePackaingWithTELSRA:
                        //Wait untill window loads and select window
                        WaitandSelectMOLWindow("Dashboard");

                        // Hover the mouse on the username option
                        WaitForElement(By.ClassName(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_loginuser_ClassName_Locator));
                        IWebElement getUserMOLNameOption =
                            GetWebElementPropertiesByClassName("username");
                        PerformMouseHoverAction(getUserMOLNameOption);
                        WaitForElement(By.XPath(("//div[@class='popover bottom nav-popover']/div[2]/a")));
                        IWebElement getMOLLogoutLink = GetWebElementPropertiesByXPath
                            ("//div[@class='popover bottom nav-popover']/div[2]/a");
                        ClickByJavaScriptExecutor(getMOLLogoutLink);
                        Thread.Sleep(1000);
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
        ///Wait untill window loads and select the window.
        /// </summary>
        protected void WaitandSelectROLWindow()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);

            try
            {
                // Wait untill window loads
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                // Select window
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
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
                        WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_LoginPageTitle_Title);
                        // Select window
                        SelectWindow(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_LoginPageTitle_Title);
                        break;

                    case "Dashboard":
                        // Wait until window loads
                        WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                        // Select window
                        SelectWindow(ApplicationLoginPageResource.
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
        /// Logout as Comet user
        /// </summary>
        public void LogoutAsCometUser()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Close browser
                CloseBrowserWindow();
                WebDriverCleanUp();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}