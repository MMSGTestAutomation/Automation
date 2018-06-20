using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Claims
{
    public class SubmitClaimPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SubmitClaimPage));

        /// <summary>
        /// Verify the page landed on the Submit page
        /// </summary>
        /// <param name="pageName">Page name</param>
        /// <returns>True if the page is loaded</returns>
        public bool VerifyThepageLandedOnTheSubmitClaimPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool result = false;
            try
            {
                //Verify the page landed on the selelvct bennefitpage
                if (GetElementInnerTextByXPath(SubmitClaimResource.SubmitClaimPage_Title_Xpath_Locator)
                    == pageName)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return result;
        }

        /// <summary>
        /// Clicking on th Check box
        /// </summary>
        /// <param name="checkBoxName">Chehck Box Name</param>
        public void ClickOnTheAcceptancesCheckBox(string checkBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Clicking on the Check box
                switch (checkBoxName)
                {
                    case "Accept Declaration":
                        WaitForElement(By.Id(SubmitClaimResource.SubmitClaimPage_AcceptDeclarationCheckBox_ID_Locator));
                        ClickButtonById(SubmitClaimResource.SubmitClaimPage_AcceptDeclarationCheckBox_ID_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on th submit button
        /// </summary>
        public void ClickOnTheSubmitButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // click on th submit button
                WaitForElement(By.Id(SubmitClaimResource.SubmitClaimPage_ProceedButton_ID_Locator));
                ClickButtonById(SubmitClaimResource.SubmitClaimPage_ProceedButton_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Success Meassage
        /// </summary>
        /// <returns> true if the message appeare</returns>
        public bool VerifyTheSuccessMessages()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool result = false;
            try
            {
                if (IsElementPresent(By.Id(SubmitClaimResource.SubmitClaimPage_DuplictaeModule_ID_Locator),10))
                {
                    ClickButtonById(SubmitClaimResource.SubmitClaimPage_PopUpProceedButton_Locator);
                }               
                //Verify Success message 
                string successXpath = GetElementInnerTextByXPath(SubmitClaimResource.
                    SubmitClaimPage_SuccessMessageStrong_Xpath_Locator);
                string value = SubmitClaimResource.SubmitClaimPage_SuccessMessage_Text;
                if (successXpath.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return result;
        }
    }
}