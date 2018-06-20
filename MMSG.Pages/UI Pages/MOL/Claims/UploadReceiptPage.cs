using MMSG.Automation;
using MMSG.Pages.UI_Pages.Comet.IQueuePages;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MMSG.Pages.UI_Pages.MOL.Claims
{
    public class UploadReceiptPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(UploadReceiptPage));

        /// <summary>
        /// Verify the page landed on the upload receipt page
        /// </summary>
        /// <param name="pageName">Page Name</param>
        /// <returns>Status of the Page</returns>
        public bool VerifyThepageLandedOnTheUploadpage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool result = false;
            try
            {
                //Verify the page landed on the selelvct bennefitpage
                if (GetElementInnerTextByXPath(UploadReceiptResource.
                    UploadReceiptPage_PageTitle_Xpath_Locator) == pageName)
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
        /// Clicking on the upload button
        /// </summary>
        /// <param name="uplaodType">Upload type</param>
        public void ClickingOnTheUploadButton(string uplaodType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Based on the condition upload the file
                switch (uplaodType)
                {
                    case "Individual tax invoice":
                        base.WaitForElement(By.XPath(UploadReceiptResource.
                            UploadReceiptPage_IndividualInvoicesUploadButton_Xpath_Locator), 20);
                        base.ClickButtonByXPath(UploadReceiptResource.
                            UploadReceiptPage_IndividualInvoicesUploadButton_Xpath_Locator);                       
                        Thread.Sleep(5000);
                        SendKeys.SendWait(GetTestDataFilePath());
                        Thread.Sleep(5000);
                        SendKeys.SendWait(@"{Enter}");                        
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
        /// Get the file path of Test data folder
        /// </summary>
        /// <returns>Testdata file path</returns>
        public String GetTestDataFilePath()
        {
            // get Image file path
            return Path.Combine(
                new string[] {
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                   UploadReceiptResource.TestData_FolderName,                   
                   UploadReceiptResource.Chrysanthemum_FileName + ".jpg" });
        }

        /// <summary>
        /// Upload the Claim Invoices
        /// </summary>
        public void UploadForm()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Upload
                Thread.Sleep(3000);
                WaitForElement(By.XPath(UploadReceiptResource.
                UploadReceiptPage_UploadSuccessIcon_Xpath_Locator));

                //Wait for Upload
                Thread.Sleep(3000);
                WaitForElement(By.XPath(UploadReceiptResource.
                    UploadReceiptPage_UploadSuccessIcon_Xpath_Locator));

                //Click on the Processed button
                WaitForElement(By.Id(UploadReceiptResource.
                    UploadReceiptPage_ProcessedButton_ID_Locator));
                ClickButtonById(UploadReceiptResource.
                    UploadReceiptPage_ProcessedButton_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}