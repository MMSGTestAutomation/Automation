using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class Amendment_BenefitPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(Amendment_BenefitPage));

        /// <summary>
        /// Verify the apge landedOn the Amendment Benefit page
        /// </summary>
        /// <returns>True is page is landed</returns>
        public bool VerifyPageLandedOnAmendmentBenefitPage(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool statusofPage = false;
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain();
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);
                // Wait for element and get title
                WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_PageTitle_ID_Locator));
                string AmendmentPageBenefitPage = GetInnerTextAttributeValueById(Amendment_BenefitResource.
                    Amendment_BenefitPage_PageTitle_ID_Locator);
                if (AmendmentPageBenefitPage == Amendment_BenefitResource.
                    Amendment_BenefitPage_PageTitle_Value_Value)
                {
                    statusofPage = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return statusofPage;
        }

        /// <summary>
        /// Select benifit from dropdown
        /// </summary>
        /// <param name="benifitType">This is Benefit type.</param>
        public void SelectTheBenefitDropDown(Benefit.BenefitTypeEnum benifitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string expectedPageTitle = GetCometDomain();
                WaitUntilWindowLoads(expectedPageTitle);
                SelectWindow(expectedPageTitle);

                // Get the benefit name from in memory
                Benefit benefit = Benefit.Get(benifitType);
                string benefitName = benefit.Benefit1.ToString();

                // Wait and select benefit type from dropdown
                WaitForElement(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_BenefitDropDown_ID_Locator));
                SelectDropDownValueThroughTextById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BenefitDropDown_ID_Locator, benefitName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select effective date
        /// </summary>
        public void EffectiveDate()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // geting the effective from the screen
                string getDateText = GetInnerTextAttributeValueByXPath(
                Employee_personaldetailsResource.EmployeepersonaldetailsPage__EffectiveDate_Xpath);
                string getDate = getDateText.Substring(17);
                string effectiveDateText = getDate.Replace(")", "").Trim();
                // waiting for the Element
                WaitForElement(By.Id(Amendment_BenefitResource.Amendment_BenefitPage_ActivationDateTextBox_ID_Locator));
                // clearing the text box
                ClearTextById(Amendment_BenefitResource.Amendment_BenefitPage_ActivationDateTextBox_ID_Locator);
                // entering the Effective date in text box
                FillTextBoxById(Amendment_BenefitResource.Amendment_BenefitPage_ActivationDateTextBox_ID_Locator, effectiveDateText);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the next Pay in the drop down
        /// </summary>
        public void NextPayDate()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // waiting for the Next date drop
                WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_NextPayDateDropDown_ID_Locator));
                SelectDropDownValueThroughIndexById(Amendment_BenefitResource.
                    Amendment_BenefitPage_NextPayDateDropDown_ID_Locator, 2);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Budget caluction menthod
        /// </summary>
        /// <param name="benefitType">This is benefit type enum.</param>
        public void BudgetCalculationMethod(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the BudgetCalculationMethod type from inmemory
                Benefit benefit = Benefit.Get(benefitType);
                string payDateType = benefit.BudgetCalculationMethod.ToString();
                WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetCalculationMenthodDropDown_ID_Locator));
                SelectDropDownValueThroughTextById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetCalculationMenthodDropDown_ID_Locator, payDateType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Entering the budget amount in the text box
        /// </summary>
        /// <param name="BudgetAmount">Budget Amount</param>
        public void BudgetAmount(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the BudgetAmount from inmemory
                Benefit benefit = Benefit.Get(benefitType);
                string BudgetAmount = benefit.BudgetAmount.ToString();
                // Clear Budget Amount text box an fill the Budget Amount
                ClearTextById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetAmountTextBox_ID_Locator);
                FillTextBoxById(Amendment_BenefitResource.
                    Amendment_BenefitPage_BudgetAmountTextBox_ID_Locator, BudgetAmount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the Save Button
        /// </summary>
        public void ClickOnSaveButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitForElement(By.Id(Amendment_BenefitResource.
                    Amendment_BenefitPage_SaveButton_ID_Locator));
                IWebElement saveButtonProperty = GetWebElementProperties(
                    By.Id(Amendment_BenefitResource.Amendment_BenefitPage_SaveButton_ID_Locator));
                ClickByJavaScriptExecutor(saveButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}