using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Home.Dashboard
{
    public class PayrollDeductionsAndTransfersPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PayrollDeductionsAndTransfersPage));

        /// <summary>
        /// Verying the test landed on the Payroll Deductions And Transfers Page
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        /// <returns>Page existance status.</returns>
        public bool VerifyThepageLandedOnPayrollDeductionsAndTransfers(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                string payrollDeductionsAndTransfersXPath = PayrollDeductionsAndTransfersPageResource.
                    PayrollDeductionsAndTransfers_PayrollDeductionsAndTransfersTitle_Xpath_Locator;
                if (base.GetElementInnerTextByXPath(payrollDeductionsAndTransfersXPath) == pageName)
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

        /// <summary>
        /// Cliking on the tab tab present in the transaction page
        /// </summary>
        /// <param name="tabName">This is tab name.</param>
        public void ClickOnTheTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (tabName)
                {
                    case "Advanced Filter":
                        base.ClickButtonByXPath(PayrollDeductionsAndTransfersPageResource.
                            PayrollDeductionsAndTransfers_AdvanceFilterTab_Xpath_Locator);
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
        /// Verify the tab is in Active State
        /// </summary>
        /// <param name="tabName">Tab Name to be checked</param>
        /// <returns>True if the tab is in Active state</returns>
        public bool VerifyTheActiveTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                switch (tabName)
                {
                    case "30Days":
                        WaitForElement(By.XPath(PayrollDeductionsAndTransfersPageResource.
                            PayrollDeductionsAndTransfers_30DaysTransationTab_Xpath_Locator));
                        string classValue = GetClassAttributeValueByXPath(PayrollDeductionsAndTransfersPageResource.
                            PayrollDeductionsAndTransfers_30DaysTransationTab_Xpath_Locator);
                        if (classValue == PayrollDeductionsAndTransfersPageResource.
                            PayrollDeductionsAndTransfers_ActiveTabStatus_Text)
                        {
                            status = true;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return status;
        }
    }
}