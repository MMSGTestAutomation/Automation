using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class AmendmentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AmendmentPage));

        /// <summary>
        /// Verify the page landed on the Amendment Screen
        /// </summary>
        /// <returns>Status of the Page</returns>
        public bool VerifyThepageLandedOnAmendment()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool pageLandedOnAmendment = false;
            try
            {
                SwitchToPopup();
                // Wait untill window load and select window
                string pageTitle = GetCometDomain();
                WaitUntilWindowLoads(pageTitle);
                SelectWindow(pageTitle);
                // Wait for element and get text
                WaitForElement(By.XPath(AmendmentResource.AmendmentPage_Title_Value_Xpath_Locator));
                //geting the amendment Page heading

                string amendmentPage = GetElementInnerTextByXPath(AmendmentResource.
                    AmendmentPage_Title_Value_Xpath_Locator);
                if (amendmentPage == AmendmentResource.AmendmentPage_Title_Value)
                {
                    pageLandedOnAmendment = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return pageLandedOnAmendment;
        }

        /// <summary>
        /// Clicking on the button in Amendment screen
        /// </summary>
        /// <param name="optionName">option name which we need to be clicked </param>
        public void ClickOnOption(string optionName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load and select window
                string pageTitle = GetCometDomain();
                WaitUntilWindowLoads(pageTitle);
                SelectWindow(pageTitle);
                // Click based on the option
                switch (optionName)
                {
                    case "New":
                        WaitForElement(By.CssSelector(AmendmentResource.
                            AmendmentPage_NewButton_CsSelelctor_Locator), 10);
                        IWebElement newButtonProperty = GetWebElementProperties(
                            By.CssSelector(AmendmentResource.
                            AmendmentPage_NewButton_CsSelelctor_Locator));
                        ClickByJavaScriptExecutor(newButtonProperty);
                        break;

                    case "Cancel":
                        WaitForElement(By.CssSelector(AmendmentResource.
                            AmendmentPage_CancelButton_CssSelelctor_Locator), 20);
                        IWebElement newSaveProperty = GetWebElementProperties(By.
                            CssSelector(AmendmentResource.AmendmentPage_CancelButton_CssSelelctor_Locator));
                        ClickByJavaScriptExecutor(newSaveProperty);
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
        /// Checking the Benefit is been added
        /// </summary>
        /// <param name="benefitType">sending the benefit type to the method</param>
        /// <returns></returns>
        public bool BenefitIsAdded(Benefit.BenefitTypeEnum benefitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool benefitIsPresent = false;
            try
            {
                //geting the benefit from the memory
                Benefit benefit = Benefit.Get(benefitType);
                string benefitName = benefit.Benefit1.ToString();
                int numberOfBenefit = GetElementCountByXPath(AmendmentResource.
                    AmendmentPage_BenefitDetailsTableRow_Xpath_Locator);
                string textFromBenefit = GetInnerTextAttributeValueByXPath(AmendmentResource.
                    AmendmentPage_BenefitDetailsTableRow_Xpath_Locator + "[" + numberOfBenefit + "]/td[3]");
                if (benefitName == textFromBenefit)
                {
                    benefitIsPresent = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return benefitIsPresent;
        }
    }
}