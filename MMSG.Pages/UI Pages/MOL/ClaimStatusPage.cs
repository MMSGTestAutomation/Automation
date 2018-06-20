using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL
{
    public class ClaimStatusPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ClaimStatusPage));

        /// <summary>
        /// Click on the Add New Claim Button in the Claim Status page
        /// </summary>
        /// <param name="buttonName">Button Name to be clicked</param>
        public void ClickOnAddNewClaimButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Add New Claim":
                        // Wait for the Add new button
                        WaitForElement(By.XPath(ClaimStatusResource.
                            ClaimStatusPage_AddClaimButton_Xpath_Locator));
                        //Clicking on the Add New benefit button
                        ClickButtonByXPath(ClaimStatusResource.
                            ClaimStatusPage_AddClaimButton_Xpath_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}