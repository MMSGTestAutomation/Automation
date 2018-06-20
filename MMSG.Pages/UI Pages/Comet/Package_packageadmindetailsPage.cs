using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Package_packageadmindetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Package_packageadmindetailsPage));

        /// <summary>
        /// Data to be filled in second step of Create package
        /// </summary>
        /// <param name="packageType">This is package type enum.</param>
        public void PackageCreationSecondStep(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get page title
                string PageTitle = GetCometDomain();
                // Get package details
                Package package = Package.Get(packageType);
                string getEntertainmentCap = package.EntertainmentCap.ToString();
                string getLivingExpenseCap = package.LivingExpenseCap.ToString();

                // Wait untill window loads and select popup
                WaitUntilPopUpLoads(PageTitle);
                SelectWindow(PageTitle);
                // Fill Living Expense Cap textbox
                WaitForElement(By.Id(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_LivingExpenseCap_Textbox_ID));
                ClearTextById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_LivingExpenseCap_Textbox_ID);
                FillTextBoxById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_LivingExpenseCap_Textbox_ID,
                    getLivingExpenseCap);

                // Fill Living EntertainmentCap textbox
                WaitForElement(By.Id(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_EntertainmentCap_Textbox_ID));
                ClearTextById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_EntertainmentCap_Textbox_ID);
                FillTextBoxById(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_EntertainmentCap_Textbox_ID,
                    getEntertainmentCap);

                bool getOptionStatus = IsElementPresent(By.XPath(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_FinancialAdvisorTable_Textbox_Xpath), 10);
                if (getOptionStatus == false)
                {
                    // Clicking on the FinancialAdvisor Tex Box
                    WaitForElement(By.CssSelector(Package_packageadmindetailsResource.
                        Package_packageadmindetailsPage_NewPackage_FinancialAdvisorTable_Textbox_CssSelelctor));
                    IWebElement getFinancialAdvisor = GetWebElementPropertiesByCssSelector(
                        Package_packageadmindetailsResource.
                        Package_packageadmindetailsPage_NewPackage_FinancialAdvisorTable_Textbox_CssSelelctor);
                    ClickByJavaScriptExecutor(getFinancialAdvisor);

                    // Clicking on the DropDown of FinancialAdvisor
                    IWebElement getFinancialAdvisioOption = GetWebElementPropertiesByXPath
                        (Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_FinancialAdvisorTable_Textbox_Xpath);
                    ClickByJavaScriptExecutor(getFinancialAdvisioOption);
                }
                else
                {
                    // Clicking on the DropDown of FinancialAdvisor
                    IWebElement getFinancialAdvisioOption = GetWebElementPropertiesByXPath
                        (Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_FinancialAdvisorTable_Textbox_Xpath);
                    ClickByJavaScriptExecutor(getFinancialAdvisioOption);
                }
                // Wait untill window loads and select popup
                WaitUntilPopUpLoads(PageTitle);
                SelectWindow(PageTitle);

                // Click next button
                WaitForElement(By.XPath(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_NextButton_Textbox_Xpath), 20);
                IWebElement getNextButton = base.GetWebElementProperties(By.XPath(Package_packageadmindetailsResource.
                    Package_packageadmindetailsPage_NewPackage_NextButton_Textbox_Xpath));
                ClickByJavaScriptExecutor(getNextButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}