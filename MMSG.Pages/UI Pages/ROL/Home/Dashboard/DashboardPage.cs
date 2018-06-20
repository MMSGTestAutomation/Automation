using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.ROL.Home.Dashboard
{
    public class DashboardPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashboardPage));

        /// <summary>
        /// Navigate to tab
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        public void NavigateToTab(string applicationName, string tabName)
        {
            // Navigate to tab
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for window load and select the window
                WaitandSelectWindow(applicationName);
                Thread.Sleep(1000);
                WaitForElement(By.XPath("//ul[@id='lg-menu']/li"), 50);
                int getTabCount = GetElementCountByXPath("//ul[@id='lg-menu']/li");
                for (int i = 1; i <= getTabCount; i++)
                {
                    string applicationTabName = GetInnerTextAttributeValueByXPath(string.Format("//ul[@id='lg-menu']/li[{0}]/a/span[2]", i));
                    if (applicationTabName == tabName)
                    {
                        IWebElement getTab = GetWebElementPropertiesByXPath(string.Format("//ul[@id='lg-menu']/li[{0}]/a/span[2]", i));
                        ClickByJavaScriptExecutor(getTab);
                        break;
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
        /// Click tab name based on the title
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        private void ClickTabName(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            int getTabNameCount = Convert.ToInt32(0);
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                // Get the total number of tabs
                getTabNameCount = GetElementCountByXPath(DashboardResource.
                    DashboardPage_GetTabCount_Xpath_Locator);

                for (int i = Convert.ToInt32(1); i <= getTabNameCount; i++)
                {
                    // Get tab name
                    string getTabName = GetElementInnerTextByXPath(string.Format
                        (DashboardResource.
                        DashboardPage_GetTabName_Xpath_Locator, i));
                    if (getTabName.Equals(tabName))
                    {
                        // Click on the tab name based on the title comparision
                        IWebElement getTab = GetWebElementPropertiesByXPath
                            (string.Format(DashboardResource.
                        DashboardPage_GetTabName_Xpath_Locator, i));
                        PerformMouseClickAction(getTab);
                        break;
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
        /// Wait untill window loads and select the window.
        /// </summary>
        /// <param name="applicationName">Application to waited and selcted</param>
        private void WaitandSelectWindow(string applicationName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);

            try
            {
                //Wait for window load and select the window
                switch (applicationName)
                {
                    case "Maxxia Online":
                        WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                        SelectWindow(ApplicationLoginPageResource.
                            ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                        break;

                    case "RemServ Online":
                        SwitchToDefaultWindow();
                        WaitUntilWindowLoads(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_PageTitle_Title);
                        SelectWindow(ApplicationLoginPageResource.
                            ApplicationLoginPage_ROL_PageTitle_Title);
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
        /// Click on the button in Dashbord
        /// </summary>
        /// <param name="buttonName"></param>
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Setting":
                        WaitForElement(By.XPath(DashboardResource.DashboardPage_SettingIcon_Xpath_Locator));
                        IWebElement settingIconXpath = GetWebElementPropertiesByXPath(DashboardResource.DashboardPage_SettingIcon_Xpath_Locator);
                        PerformClickAction(settingIconXpath);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);

        }
    }
}