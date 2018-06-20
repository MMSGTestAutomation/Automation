using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Package_basedetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Package_basedetailsPage));

        /// <summary>
        /// Create a new package
        /// </summary>
        /// <param name="packageType">This is a package type enum.</param>
        public void FillNewPackageDetails(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // First set in new package creation
                this.PackageCreationFirstStep(packageType);

                // Data to be filled in second step
                new Package_packageadmindetailsPage().PackageCreationSecondStep(packageType);

                // Data to be filled in third step
                new Package_payrolldetailsPage().PackageCreationThirdStep();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// First step in package creation
        /// </summary>
        /// <param name="packageType">This is a package type enum.</param>
        private void PackageCreationFirstStep(Package.PackageTypeEnum packageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                Package package = Package.Get(packageType);
                string getEmail = package.BusinessEmail.ToString();
                string getPhone = package.BusinessPhone.ToString();
                string setUpReason = package.SetUpReason.ToString();
                string getEmployerCode = package.EmployerCode.ToString();
                string getOffering = package.Offering.ToString();
                string empNumber = User.Get(User.UserTypeEnum.NewCOMETUser).EmployeeNumber;
                SwitchToLastOpenedWindow();

                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain();
                string getPackageURL = GetCurrentUrl;
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);

                // Fill Business Email text box
                WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID), 50);
                IWebElement getTextBox = GetWebElementPropertiesById(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID);
                PerformFocusOnElementAction(getTextBox);
                ClearTextById(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID);
                FillTextBoxById(Package_basedetailsResource.
                    Package_basedetailsPage_BusinesEmail_ID, getEmail);

                // Fill Business Telephone textbox
                WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID), 10);
                getTextBox = GetWebElementPropertiesById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID);
                PerformFocusOnElementAction(getTextBox);
                ClearTextById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID);
                FillTextBoxById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_BusinessTelephone_ID, getPhone);

                // Select Setup Reason from dropdown
                WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SetupReason_Dropdown_ID), 10);
                SelectDropDownValueThroughIndexById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SetupReason_Dropdown_ID, 1);

                // Click on Employer lookup icon
                WaitForElement(By.Id(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID), 10);
                IWebElement getEmployeeIcon = GetWebElementPropertiesById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);
                PerformMouseClickAction(getEmployeeIcon);
                ClickImageById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);
                ClickImageById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);

                // Search employer record
                this.SearchEmployerRecords(getEmployerCode);
                Thread.Sleep(2000);
                // Wait untill wondow load and select window
                SwitchToDefaultWindow();
                WaitUntilWindowLoads(GetCometDomain());
                SelectWindow(GetCometDomain());
                // Fill Offering textbox
                bool getDropdownOptionStatus = IsElementPresent(By.XPath(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_OffreingTable_Dropdown_XPath), 5);
                if (getDropdownOptionStatus == false)
                {
                    FocusOnElementById("ddmEmployerOfferingID_tdDisplay");
                    IWebElement getDropdown = base.GetWebElementProperties(By.Id("ddmEmployerOfferingID_tdDisplay"));
                    ClickByJavaScriptExecutor(getDropdown);

                    IWebElement clickTheDropDownOption = GetWebElementPropertiesByXPath(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_OffreingTable_Dropdown_XPath);
                    ClickByJavaScriptExecutor(clickTheDropDownOption);
                }
                else
                {
                    IWebElement clickOnTheDropDownOption = GetWebElementPropertiesByXPath(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_OffreingTable_Dropdown_XPath);
                    ClickByJavaScriptExecutor(clickOnTheDropDownOption);
                }

                // Click next button
                WaitForElement(By.XPath(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_NextButton_Xpath));
                IWebElement getNextButton = GetWebElementPropertiesByXPath(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_NextButton_Xpath);
                ClickByJavaScriptExecutor(getNextButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search employer records based on the employer code
        /// </summary>
        /// <param name="getEmployerCode">This is Employer code.</param>
        private void SearchEmployerRecords(string getEmployerCode)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Switch to Default window
                SwitchToDefaultWindow();
                SwitchToWindow(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                WaitUntilPopUpLoads(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                SelectWindow(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                // Retry mechanism
                if (GetPageTitle != Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title)
                {
                    // Click on Employer lookup icon
                    WaitForElement(By.Id(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID), 10);
                    IWebElement getEmployeeIcon = GetWebElementPropertiesById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);
                    PerformMouseClickAction(getEmployeeIcon);
                    ClickImageById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);
                    ClickImageById(Package_basedetailsResource.Package_basedetailsPage_NewPackage_EmployerLookup_ID);
                }
                // Switch to iframe
                SwitchToIFrameByIndex(0);

                // Fill employer code in search employer textbox
                WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Textbox_ID));
                ClearTextById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Textbox_ID);
                FillTextBoxById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Textbox_ID, getEmployerCode);

                // Switch to Default window
                SwitchToDefaultWindow();
                SwitchToWindow(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                WaitUntilPopUpLoads(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                SelectWindow(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);

                // Switch to iframe
                SwitchToIFrameByIndex(0);

                //Click Search button
                WaitForElement(By.Id(Package_basedetailsResource.
                Package_basedetailsPage_NewPackage_SearchEmployer_SearchButton_ID));
                ClickImageById(Package_basedetailsResource.
                Package_basedetailsPage_NewPackage_SearchEmployer_SearchButton_ID);

                WaitUntilPopUpLoads(Package_basedetailsResource.
                 Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                SelectWindow(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_Title);

                // Switch to iframe
                SwitchToIFrameByIndex(0);
                // Wait for Search Results grid to appear
                bool getSearchGridStatus = IsElementPresent(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_ResultGrid_ID), 10);
                if (getSearchGridStatus == true)
                {
                    WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_ResultGrid_ID), 20);
                    //ClickIng on the Employeer Link
                    WaitForElement(By.XPath(Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_EmployeerLink_Xpath));
                    IWebElement getEmployerLink = GetWebElementPropertiesByXPath((Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_EmployeerLink_Xpath));
                    ClickByJavaScriptExecutor(getEmployerLink);
                    SwitchToDefaultWindow();
                }
                else
                {
                    // Switch to Default window
                    SwitchToDefaultWindow();
                    SwitchToWindow(Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                    WaitUntilPopUpLoads(Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_Title);
                    SelectWindow(Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_Title);

                    // Switch to iframe
                    SwitchToIFrameByIndex(0);

                    //Click Search button
                    WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_SearchButton_ID));
                    ClickImageById(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_SearchEmployer_SearchButton_ID);

                    WaitForElement(By.Id(Package_basedetailsResource.
                    Package_basedetailsPage_NewPackage_ResultGrid_ID), 20);
                    //ClickIng on the Employeer Link
                    WaitForElement(By.XPath(Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_EmployeerLink_Xpath));
                    IWebElement getEmployerLink = GetWebElementPropertiesByXPath((Package_basedetailsResource.
                        Package_basedetailsPage_NewPackage_SearchEmployer_EmployeerLink_Xpath));
                    ClickByJavaScriptExecutor(getEmployerLink);
                    SwitchToDefaultWindow();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifythe page landed in the Edit page
        /// </summary>
        /// <param name="pageName">Page name</param>
        /// <returns>Status of the Page tru if page lannded </returns>
        public bool VerifyPageLandedOnEditPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool pagestatusFromScreen = false;
            string pagenamefromScreen = string.Empty;
            try
            {
                SwitchToDefaultWindow();
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain();
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                switch (pageName)
                {
                    case "Edit Package":
                        WaitForElement(By.XPath(Package_basedetailsResource.
                            Package_basedetailsPage_EditPackage_PageHeading_Xpath));
                        pagenamefromScreen = GetInnerTextAttributeValueByXPath(Package_basedetailsResource.
                            Package_basedetailsPage_EditPackage_PageHeading_Xpath);
                        break;

                    case "Package Admin Details":
                        WaitForElement(By.XPath(Package_basedetailsResource.
                             Package_basedetailsPage_EditPackage_PackageAdminDetails_Xpath));
                        pagenamefromScreen = GetInnerTextAttributeValueByXPath(Package_basedetailsResource.
                            Package_basedetailsPage_EditPackage_PackageAdminDetails_Xpath);
                        break;

                    case "Payroll Details":
                        WaitForElement(By.XPath(Package_basedetailsResource.
                        Package_basedetailsPage_EditPackage_PayrollDetails_Xpath));
                        pagenamefromScreen = GetInnerTextAttributeValueByXPath(Package_basedetailsResource.
                            Package_basedetailsPage_EditPackage_PayrollDetails_Xpath);
                        break;
                }
                // Page title validation
                if (pagenamefromScreen == pageName)
                {
                    pagestatusFromScreen = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return pagestatusFromScreen;
        }

        /// <summary>
        /// changeing the value in edit package page
        /// </summary>
        /// <param name="changeType">change in the type</param>
        /// <param name="changeValue">change value</param>
        public void ChangetheOption(string changeType, string changeValue)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain();
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                switch (changeType)
                {
                    case "Email":
                        WaitForElement(By.Id(Package_basedetailsResource.
                            Package_basedetailsPage_BusinesEmail_ID));
                        ClearTextById(Package_basedetailsResource.
                            Package_basedetailsPage_BusinesEmail_ID);
                        FillTextBoxById(Package_basedetailsResource.
                            Package_basedetailsPage_BusinesEmail_ID, changeValue);
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
        /// Clicking on the next button
        /// </summary>
        public void ClickOnNext()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for element
                WaitForDocumentLoadToComplete(20);
                WaitForElement(By.Id(Package_basedetailsResource.Package_basedetailsPage_EditPackage_NextButton_Id));
                IWebElement nextButton = GetWebElementProperties(By.Id(
                    Package_basedetailsResource.Package_basedetailsPage_EditPackage_NextButton_Id));
                ClickByJavaScriptExecutor(nextButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}