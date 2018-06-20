using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class PaymentInstructionPage : BasePage
    {      /// <summary>
           /// The static instance of the logger for the class.
           /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PaymentInstructionPage));

        /// <summary>
        /// Verify the page landed on the PaymentInstructionPage
        /// </summary>
        /// <returns>Returen sthe true if the the page landed on the Payment Instruction </returns>
        public bool VerifyThePagePageLandedOnPaymentInstruction(string pageType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                // switch to pop up
                SwitchToPopup();
                //Get page title and wait until page load
                string popupName = GetCometDomain() + " " + "Employee BenefitAirport Lounge Membership";
                WaitUntilPopUpLoads(popupName);
                SelectWindow(popupName);
                // Get header name
                string pageTitle = GetElementInnerTextByXPath
                    (PaymentInstructionResource.
                    PaymentInstruction_Title_Xapth_Locator);
                string pageName = pageTitle.Substring(0, 25);

                // checking the page landed on the Payment instruction page
                switch (pageType)
                {
                    case "View Payment Instructions Benefit":
                        if (pageName == "View Payment Instructions")
                        {
                            status = true;
                        }
                        break;

                    case "Edit Payment Instructions Benefit":
                        if (pageName == "Edit Payment Instructions")
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

        /// <summary>
        /// Fill the details required for the creation of the payment instruction
        /// </summary>
        /// <param name="paymentType">payment type</param>
        /// <param name="paymentFrequency">Payment frequency</param>
        public void FillThedetailsInPaymentInstructionPage(string paymentType,
            string paymentFrequency)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Maximize window
                MaximizeWindow();
                // Get page title
                string pageTitle = GetCometDomain() + " " + "Employee BenefitAirport Lounge Membership";
                // Wait untill window load and select window
                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                WaitForDocumentLoadToComplete(20);
                // Select payment type drop down
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PaymentTypeDropdown_Id_Locator));
                SelectDropDownValueThroughTextById(PaymentInstructionResource.
                    PaymentInstruction_PaymentTypeDropdown_Id_Locator, paymentType);

                //Fill Payment Description details
                Guid UserGUID = Guid.NewGuid();
                string randomValue = UserGUID.ToString().Split('-')[0];
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PaymentDiscriptionTextBox_Id_Locator));
                FillTextBoxById(PaymentInstructionResource.
                    PaymentInstruction_PaymentDiscriptionTextBox_Id_Locator,
                    "Auto-PaymentDescription" + randomValue);

                // Fill the Payment Reference
                FillTextBoxById(PaymentInstructionResource.
                    PaymentInstruction_PaymentReferencesTextBox_Id_Locator,
                    "Auto- PaymentReference" + randomValue);

                //Fill the payment Amount
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PaymentAmountTextBox_Id_Locator));
                ClearTextById(PaymentInstructionResource.
                    PaymentInstruction_PaymentAmountTextBox_Id_Locator);
                FillTextBoxById(PaymentInstructionResource.
                    PaymentInstruction_PaymentAmountTextBox_Id_Locator, PaymentInstructionResource.
                    PaymentInstruction_Amount_GSTInclusive_Value);

                //Selelct the Payment Frequency
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PaymentFrequencyDropdown_Id_Locator));
                SelectDropDownValueThroughTextById(PaymentInstructionResource.
                    PaymentInstruction_PaymentFrequencyDropdown_Id_Locator, paymentFrequency);

                //Enter the Due date
                string getDateText = GetInnerTextAttributeValueByXPath(
               Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);

                // Get the effective date from application
                string applicationEffectiveDateText = getDate.Replace(")", "").Trim().ToString();
                DateTime appEffectiveDate = DateTime.ParseExact(applicationEffectiveDateText, @"d/M/yyyy",
                System.Globalization.CultureInfo.InvariantCulture);

                // Incriment 31 days the effective date from application
                string incrimentedDate = Convert.ToDateTime(appEffectiveDate).AddDays(31).ToString("dd/MM/yyyy");
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PaymentDueDate_Id_Locator));
                FillTextBoxById(PaymentInstructionResource.
                    PaymentInstruction_PaymentDueDate_Id_Locator, incrimentedDate);

                // Incriment 1year to the effective date from application
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PaymentTerminationDate_Id_Locator));
                FillTextBoxById(PaymentInstructionResource.
                    PaymentInstruction_PaymentTerminationDate_Id_Locator, incrimentedDate);

                //Click on the Loopup Image
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PayeeLookUpImg_ID_Loacator));
                IWebElement lookUpProperties = GetWebElementProperties(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PayeeLookUpImg_ID_Loacator));
                PerformClickAction(lookUpProperties);

                // Add tyhe payee to from the pop up
                SelelctThePayeeFromPopUp();
                //Wait untill window load and select window
                pageTitle = GetCometDomain() + " " + PaymentInstructionResource.PaymentInstruction_PopupTitle_Text;
                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                Thread.Sleep(2000);
                // Click add button
                WaitForElement(By.Name(PaymentInstructionResource.
                    PaymentInstruction_AddButton_Name_Locator));
                IWebElement getAddButton = GetWebElementProperties(By.Id("CommandButtons_cmdAddEnabled"));
                PerformFocusOnElementAction(getAddButton);
                PerformMouseClickAction(getAddButton);
                bool getButtonStatus = IsElementPresent(By.Id("CommandButtons_cmdAddEnabled"), 10);
                if (getButtonStatus == true)
                {
                    ClickByJavaScriptExecutor(getAddButton);
                    ClickButtonById("CommandButtons_cmdAddEnabled");
                }
                getButtonStatus = IsElementPresent(By.Id("CommandButtons_cmdAddEnabled"), 10);
                bool getResultGridStatus = IsElementPresent(By.Id(PaymentInstructionResource.PaymentInstruction_SearchResultGrid_Id),10);
                SwitchToLastOpenedWindow();
                string title = GetPageTitle;
                if (GetPageTitle != "Confirm Dialogue?" && getButtonStatus == true)
                {
                    WaitUntilPopUpLoads(pageTitle);
                    SelectWindow(pageTitle);
                    // Click add button
                    WaitForElement(By.Name(PaymentInstructionResource.
                        PaymentInstruction_AddButton_Name_Locator));
                    getAddButton = GetWebElementProperties(By.Id("CommandButtons_cmdAddEnabled"));
                    PerformFocusOnElementAction(getAddButton);
                    PerformMouseClickAction(getAddButton);
                    ClickByJavaScriptExecutor(getAddButton);
                    ClickButtonById("CommandButtons_cmdAddEnabled");
                }
                else if (GetPageTitle == pageTitle && getButtonStatus == false && getResultGridStatus == true)
                {
                    // Click on the save button
                    WaitForElement(By.Id(PaymentInstructionResource.PaymentInstruction_SaveButton_Id_Locator));
                    IWebElement saveButton = GetWebElementProperties(By.Id(PaymentInstructionResource.
                        PaymentInstruction_SaveButton_Id_Locator));
                    ClickByJavaScriptExecutor(saveButton);
                    return;
                }
                SwitchToWindow("Confirm Dialogue?");
                WaitUntilPopUpLoads("Confirm Dialogue?");
                SelectWindow("Confirm Dialogue?");
                // Check if confirm dialog appears
                if (GetPageTitle.Contains("Confirm Dialogue"))
                {
                    IWebElement getYesButton = GetWebElementProperties(By.Id("cmdYes"));
                    ClickByJavaScriptExecutor(getYesButton);
                }
                SwitchToDefaultWindow();
                //Wait untill window load and select window
                WaitUntilPopUpLoads(pageTitle);
                SelectWindow(pageTitle);
                //Wait for the grit to appeare
                getResultGridStatus = IsElementPresent(By.Id(PaymentInstructionResource.PaymentInstruction_SearchResultGrid_Id));
                if (getResultGridStatus != true)
                {
                    // Click add button
                    WaitForElement(By.Name(PaymentInstructionResource.
                        PaymentInstruction_AddButton_Name_Locator));
                    getAddButton = GetWebElementProperties(By.Id("CommandButtons_cmdAddEnabled"));
                    PerformFocusOnElementAction(getAddButton);
                    PerformMouseClickAction(getAddButton);
                    ClickByJavaScriptExecutor(getAddButton);
                    ClickButtonById("CommandButtons_cmdAddEnabled");

                    SwitchToLastOpenedWindow();
                    title = GetPageTitle;
                    if (GetPageTitle != "Confirm Dialogue?")
                    {
                        WaitUntilPopUpLoads(pageTitle);
                        SelectWindow(pageTitle);
                        // Click add button
                        WaitForElement(By.Name(PaymentInstructionResource.
                            PaymentInstruction_AddButton_Name_Locator));
                        getAddButton = GetWebElementProperties(By.Id("CommandButtons_cmdAddEnabled"));
                        PerformFocusOnElementAction(getAddButton);
                        PerformMouseClickAction(getAddButton);
                        ClickByJavaScriptExecutor(getAddButton);
                        ClickButtonById("CommandButtons_cmdAddEnabled");
                    }
                    SwitchToWindow("Confirm Dialogue?");
                    WaitUntilPopUpLoads("Confirm Dialogue?");
                    SelectWindow("Confirm Dialogue?");
                    // Check if confirm dialog appears
                    if (GetPageTitle.Contains("Confirm Dialogue"))
                    {
                        IWebElement getYesButton = GetWebElementProperties(By.Id("cmdYes"));
                        ClickByJavaScriptExecutor(getYesButton);
                    }
                    SwitchToDefaultWindow();
                    //Wait untill window load and select window
                    WaitUntilPopUpLoads(pageTitle);
                    SelectWindow(pageTitle);
                }
                WaitForElement(By.Id(PaymentInstructionResource.PaymentInstruction_SearchResultGrid_Id));
                WaitForElement(By.XPath(PaymentInstructionResource.PaymentInstruction_Grid_Xapth_Locator), 20);

                // Click on the save button
                WaitForElement(By.Id(PaymentInstructionResource.PaymentInstruction_SaveButton_Id_Locator));
                IWebElement saveButtonProp = GetWebElementProperties(By.Id(PaymentInstructionResource.
                    PaymentInstruction_SaveButton_Id_Locator));
                ClickByJavaScriptExecutor(saveButtonProp);

                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to select the payeefrom popup
        /// </summary>
        public void SelelctThePayeeFromPopUp()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to pop up and swict to iframe
                SwitchToWindow(PaymentInstructionResource.
                    PaymentInstruction_SearchTitle_Text);
                WaitUntilPopUpLoads(PaymentInstructionResource.
                    PaymentInstruction_SearchTitle_Text);
                SelectWindow(PaymentInstructionResource.
                    PaymentInstruction_SearchTitle_Text);
                IWebElement iframeProp = GetWebElementProperties(By.TagName(PaymentInstructionResource.
                    PaymentInstruction_PayeePopUpIframe_Locator));
                SwitchToIFrameByWebElement(iframeProp);

                // fill the payee name in the text box
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PayeePopUpPayeeTextBox_Id_Locator));
                FillTextBoxById(PaymentInstructionResource.
                    PaymentInstruction_PayeePopUpPayeeTextBox_Id_Locator,
                    PaymentInstructionResource.PaymentInstruction_TextBoxPayee_Value);

                //Click On the search button
                WaitForElement(By.Id(PaymentInstructionResource.
                    PaymentInstruction_PayeePopUpPayeeSearchButton_Id_Locator));
                IWebElement getSearchButton = GetWebElementPropertiesById(PaymentInstructionResource.
                    PaymentInstruction_PayeePopUpPayeeSearchButton_Id_Locator);
                ClickByJavaScriptExecutor(getSearchButton);

                //Switch to pop up and swict to iframe
                WaitUntilPopUpLoads(PaymentInstructionResource.
                    PaymentInstruction_SearchTitle_Text);
                SelectWindow(PaymentInstructionResource.
                    PaymentInstruction_SearchTitle_Text);
                iframeProp = GetWebElementProperties(By.TagName(PaymentInstructionResource.
                    PaymentInstruction_PayeePopUpIframe_Locator));
                SwitchToIFrameByWebElement(iframeProp);
                // Wait for grid to appear
                WaitForElement(By.Id(PaymentInstructionResource.PaymentInstruction_SearchResultGrid_Id));
                WaitForElement(By.XPath(PaymentInstructionResource
                    .PaymentInstruction_PayeePopUpGrid_Xpath_Locator));
                ClickButtonByXPath(PaymentInstructionResource
                    .PaymentInstruction_PayeePopUpGrid_Xpath_Locator);

                //switch to default window
                SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// ClickOn the cancel button in edite page
        /// </summary>
        public void ClickOnEditePaymentInstructionCancelButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement propCancwelButton = GetWebElementProperties(By.Id(PaymentInstructionResource.
                    PaymentInstruction_CancelButton_ID_Locator));
                ClickByJavaScriptExecutor(propCancwelButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}