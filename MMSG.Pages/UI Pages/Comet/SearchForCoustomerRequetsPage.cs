using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class SearchForCoustomerRequetsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SearchForCoustomerRequetsPage));

        /// <summary>
        /// Verify the page landed on the Maxxia Wallet
        /// </summary>
        /// <returns>Returns true if page landed</returns>
        public string VerifyThePageLandedOnMaxxiaWalletPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string status = "";
            try
            {
                // Wait untill window load and get title
                string pageTitle = GetCometDomain() + " " + "Search For Customer Requests";
                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                SetPageLoadWaitTime(20);
                WaitForElement(By.XPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_Title_Xpath_Locator));
                status = GetInnerTextAttributeValueByXPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_Title_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return status;
        }

        /// <summary>
        /// Clicking on the Cancel Button
        /// </summary>
        /// <param name="buttonName">Button Name which need to be clicked</param>
        public void ClickOnTheCancelButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain() + " " + "Search For Customer Requests";
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                //Clicking in the cancel button
                SetPageLoadWaitTime(20);
                WaitForElement(By.XPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_CancelButton_Xpath_Locator), 20);
                IWebElement cancelButtonProperties = GetWebElementProperties(By.XPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_CancelButton_Xpath_Locator));
                ClickByJavaScriptExecutor(cancelButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Iqueue Status
        /// </summary>
        /// <returns>Stuts of the Iqueue</returns>
        public string IQueueStatus()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string status = "";
            try
            {
                status = GetInnerTextAttributeValueByXPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_GetIQStatus_Xpath_Locator);
                //if (pageTitleFromPage == "Search For Customer Requests")
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return status;
        }

        /// <summary>
        /// Clicking on the Request ID
        /// </summary>
        public void ClickOnTheRequestId()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitForElement(By.XPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_ResultGrid_Xpath_Locator));
                ClickButtonByXPath(SearchForCoustomerRequeustResources.
                    SearchForCoustomerRequeustPage_ResultGrid_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}