using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet.IQueuePages
{
    public class ViewRequestPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ViewRequestPage));

        /// <summary>
        ///  Cliking on the button in View Screen
        /// </summary>
        /// <param name="buttonName">Button Name</param>
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Take Action":
                        ClickOnTakeAction();
                        break;

                    case "Close":
                        ClickOnCloseButton();
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
        /// Clicking on the Take action Button
        /// </summary>
        public void ClickOnTakeAction()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Clicking on the Take action Button
                WaitForElement(By.XPath(ViewRequestResource.
                    ViewRequestPage_TakeactionButton_Xpath_Locator));
                IWebElement elementProp = GetWebElementProperties(
                    By.XPath(ViewRequestResource.
                    ViewRequestPage_TakeactionButton_Xpath_Locator));
                PerformClickAction(elementProp);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Close button
        /// </summary>
        public void ClickOnCloseButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // clicking on the close button
                WaitForElement(By.XPath(ViewRequestResource.
                    ViewRequestPage_CloseButton_Xpath_Locator), 10);
                IWebElement elemenrpro = GetWebElementProperties(
                    By.XPath(ViewRequestResource.
                    ViewRequestPage_CloseButton_Xpath_Locator));
                PerformClickAction(elemenrpro);
                Thread.Sleep(Convert.ToInt32(ViewRequestResource.ViewRequestPage_WaitTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closing the PopUp
        /// </summary>
        public void ClosePopUp()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Clicking on the Close button on Close pop up window
                WaitForElement(By.XPath(ViewRequestResource.
                    ViewRequestPage_ClosepopUpCloseButton_Xpath_Locator));
                IWebElement closePro = GetWebElementProperties(By.XPath(ViewRequestResource.
                    ViewRequestPage_ClosepopUpCloseButton_Xpath_Locator));
                PerformClickAction(closePro);
                SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}