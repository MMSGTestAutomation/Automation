using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Claims
{
    public class SelectBenefitPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SelectBenefitPage));

        /// <summary>
        /// Verify the page landed on the selelct benefit page
        /// </summary>
        /// <param name="pageName">Page name to be validated</param>
        /// <returns>True if the page landed on the add benefit page</returns>
        public bool VerifyThePageLanded(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                // Waituntill window load and select window
                SwitchToDefaultWindow();
                WaitUntilWindowLoads(GetPageTitle);
                SelectWindow(GetPageTitle);

                //Verify the page landed on the selelvct bennefitpage
                WaitForElement(By.XPath(SelectBenefitResource.
                    SelelctBenefit_PageTitle_Xpath_Locator), 20);
                if (base.GetElementInnerTextByXPath(SelectBenefitResource.
                    SelelctBenefit_PageTitle_Xpath_Locator) == pageName)
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
        ///  Verify the No Reeienbusment message is been diaplayed
        /// </summary>
        /// <returns>Return true if it is sfound</returns>
        public string VerifyTheNoReiembusmentMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string status = "";
            try
            {
                SwitchToDefaultWindow();
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                //Verify the page landed on the selelvct bennefitpage               
                WaitForElement(By.XPath(SelectBenefitResource.
                    SelelctBenefit_NoReimbusmentMessge_Xpath_Locator), 30);
                status = base.GetElementInnerTextByXPath(SelectBenefitResource.
                    SelelctBenefit_NoReimbusmentMessge_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return status.Trim();
        }

        /// <summary>
        /// Select the benefit and start the reimbursement
        /// </summary>
        public void SelectTheBenefitAndStartReimbursement()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the bennefit from the from the page
                base.WaitForElement(By.Id(SelectBenefitResource.
                    SelelctBenefit_BenefitRadiobutton_ID_Locator));
                base.ClickButtonById(SelectBenefitResource.
                    SelelctBenefit_BenefitRadiobutton_ID_Locator);

                bool isExpenceDropdownDisplayed = IsElementPresent(By.XPath(
                    SelectBenefitResource.SelelctBenefit_PageTitle_ExpenceDropdownOption_List_Xpath), 10);
                if (isExpenceDropdownDisplayed == true)
                {
                    IWebElement getOption = GetWebElementPropertiesByXPath(SelectBenefitResource.
                        SelelctBenefit_PageTitle_ExpenceDropdownOption_List_Xpath);
                    ClickByJavaScriptExecutor(getOption);                   
                    bool isOptionPresent = IsElementPresent(By.XPath(
                      SelectBenefitResource. SelelctBenefit_PageTitle_ExpenceDropdownFirstOption_List_Xpath), 10);
                    getOption = GetWebElementPropertiesByXPath(SelectBenefitResource.
                        SelelctBenefit_PageTitle_ExpenceDropdownFirstOption_List_Xpath);
                    ClickByJavaScriptExecutor(getOption);
                }

                //click on the tsrat Start Reimbursement button
                base.WaitForElement(By.XPath(SelectBenefitResource.
                    SelelctBenefit_StartReimbursementButton_Xpath_Locator));
                base.ClickButtonByXPath(SelectBenefitResource.
                    SelelctBenefit_StartReimbursementButton_Xpath_Locator);

                //check if the process button if it present click on the process button
                if (base.IsElementPresent(By.Id(SelectBenefitResource.
                    SelelctBenefit_ProcessMenuButton_ID_Locator)))
                {
                    base.ClickButtonById(SelectBenefitResource.
                    SelelctBenefit_ProcessMenuButton_ID_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}