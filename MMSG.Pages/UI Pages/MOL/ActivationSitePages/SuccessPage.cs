using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.ActivationSitePages
{
    public class SuccessPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SuccessPage));

        /// <summary>
        /// Verify the page Landed on the selelct Benefit page
        /// </summary>
        /// <returns>page title</returns>
        public bool PageLandedOnSuccessPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageTilte = "";
            bool status = false;
            try
            {
                pageTilte = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return status;
        }

        /// <summary>
        /// Verify the Conragulation Message is been displayed
        /// </summary>
        /// <returns> true if is present</returns>
        public bool CongragulationMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                if (base.IsElementPresent(By.XPath(SuccessResource.
                    SuccessPage_Congratulation_XPath_Locator)))
                {
                    status = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return status;
        }
    }
}