using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Claims
{
    public class ClaimDetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(ClaimDetailsPage));

        // Initialize the static variables
        private static string GSTAmount = string.Empty;

        private static string AmountIncludingGST = string.Empty;
        private static string DateOfTaxInvoice = string.Empty;

        /// <summary>
        /// Verify the Page landed on the Claim details page
        /// </summary>
        /// <param name="pageName">Page Name</param>
        /// <returns>True if page is loaded</returns>
        public bool VerifyPageLandedOnClaimDetails(String pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool result = false;
            try
            {
                //Verify the page landed on the selelvct bennefitpage
                if (GetElementInnerTextByXPath(ClaimDetailsResource.
                    ClaimDetailsPage_Title_Xpath_Locator) == pageName)
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
        /// Enter the value to the Text box
        /// </summary>
        /// <param name="textBoxName">Text box name which need to be filled</param>
        public void EnterValueToText(string textValue, string textBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (textBoxName)
                {
                    case "Amount Including GST":
                        AmountIncludingGST = ClaimDetailsResource.ClaimDetailsPage_AmountIncludingGST_Value;
                        WaitForElement(By.Id(ClaimDetailsResource.ClaimDetailsPage_Amount_ID_Locator));
                        FillTextBoxById(ClaimDetailsResource.ClaimDetailsPage_Amount_ID_Locator, AmountIncludingGST);
                        break;

                    case "GST":
                        if (IsElementPresent(By.Id(ClaimDetailsResource.ClaimDetailsPage_GSTAmount_ID_Locator), 10) == true)
                        {
                            GSTAmount = ClaimDetailsResource.ClaimDetailsPage_GST_Value;
                            WaitForElement(By.Id(ClaimDetailsResource.ClaimDetailsPage_GSTAmount_ID_Locator));
                            FillTextBoxById(ClaimDetailsResource.ClaimDetailsPage_GSTAmount_ID_Locator, GSTAmount);
                        }
                        break;

                    case "Date of Tax Invoice":
                        DateOfTaxInvoice = DateTime.Now.ToString("dd/MM/yyyy");
                        WaitForElement(By.Id(ClaimDetailsResource.ClaimDetailsPage_Date_ID_Locator));
                        FillTextBoxById(ClaimDetailsResource.ClaimDetailsPage_Date_ID_Locator,
                            DateOfTaxInvoice);
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
        /// Click on the processed button
        /// </summary>
        public void ClickOnTheProcessedButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitForElement(By.Id(ClaimDetailsResource.ClaimDetailsPage_ProceedButton_Locator));
                ClickButtonById(ClaimDetailsResource.ClaimDetailsPage_ProceedButton_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}