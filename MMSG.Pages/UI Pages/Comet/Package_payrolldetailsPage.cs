using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Package_payrolldetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Package_payrolldetailsPage));

        /// <summary>
        /// Data to be filled in second step of Create package
        /// </summary>
        /// <param name="packageType">This is package type enum.</param>
        public void PackageCreationThirdStep()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate 6 digit random number
                Random r = new Random();
                int randNum = r.Next(1000000);
                string sixDigitNumber = randNum.ToString("D6");
                WaitUntilPopUpLoads(GetCometDomain());
                SelectWindow(GetCometDomain());
                // Enter payroll details
                WaitForElement(By.Id(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID));
                ClearTextById(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID);
                FillTextBoxById(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Payroll_Textbox_ID, sixDigitNumber);
                Thread.Sleep(1000);
                bool getDropdownOptionStatus = IsElementPresent(By.XPath(
                    Package_payrolldetailsResource.
                    Package_payrolldetailsPage_PayCycleTable_Textbox_Xpath), 10);
                if (getDropdownOptionStatus == false)
                {
                    WaitForElement(By.XPath(Package_payrolldetailsResource.
                        Package_payrolldetailsPage_PayCycle_Textbox_Xpath));
                    IWebElement getDropdown = GetWebElementPropertiesByXPath
                        (Package_payrolldetailsResource.
                        Package_payrolldetailsPage_PayCycle_Textbox_Xpath);
                    ClickByJavaScriptExecutor(getDropdown);

                    IWebElement getPayCycleOption = GetWebElementPropertiesByXPath(
                        Package_payrolldetailsResource.
                    Package_payrolldetailsPage_PayCycleTable_Textbox_Xpath);
                    ClickByJavaScriptExecutor(getPayCycleOption);
                }
                else
                {
                    IWebElement getPayCycleOption = GetWebElementPropertiesByXPath(
                        Package_payrolldetailsResource.
                    Package_payrolldetailsPage_PayCycleTable_Textbox_Xpath);
                    ClickByJavaScriptExecutor(getPayCycleOption);
                }
                WaitUntilPopUpLoads(GetCometDomain());
                SelectWindow(GetCometDomain());
                // Click Add button
                bool asd = IsElementPresent(By.XPath("//input[contains(@id, 'wucButtons_cmdAdd')]"), 10);
                WaitForElement(By.Id((Package_payrolldetailsResource.
                    Package_payrolldetailsPage__AddButton_ID)), 20);
                IWebElement getAddButton = base.GetWebElementProperties(By.Id
                    (Package_payrolldetailsResource.
                    Package_payrolldetailsPage__AddButton_ID));
                ClickByJavaScriptExecutor(getAddButton);

                WaitUntilPopUpLoads(GetCometDomain());
                SelectWindow(GetCometDomain());

                //Wait for the Result Grid
                WaitForElement(By.Id(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_ResultGrid_ID), 10);

                // Click Save Button
                SetPageLoadWaitTime(20);
                WaitForElement(By.Id(Package_payrolldetailsResource.
                  Package_payrolldetailsPage_Edit_SaveButton_ID), 20);
                IWebElement getSaveButton = base.GetWebElementProperties(By.Id
                    (Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Edit_SaveButton_ID));
                ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on he save button in Edit package in Package Enroll ment Details
        /// </summary>
        public void ClikingOnSaveInEdit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain();
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                WaitForDocumentLoadToComplete(20);
                // Wait for element and click on save button
                WaitForElement(By.Id(Package_payrolldetailsResource.
                    Package_payrolldetailsPage_Edit_SaveButton_ID));
                IWebElement getAddButton = base.GetWebElementProperties(By.Id
                   (Package_payrolldetailsResource.
                   Package_payrolldetailsPage_Edit_SaveButton_ID));
                ClickByJavaScriptExecutor(getAddButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}