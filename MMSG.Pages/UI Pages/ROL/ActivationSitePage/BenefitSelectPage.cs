using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.ActivationSitePage
{
    public class BenefitSelectPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(BenefitSelectPage));

        /// <summary>
        /// Verify the page Landed on the selelct Benefit page
        /// </summary>
        /// <returns>page title</returns>
        public bool PageLandedOnSelectBenefitPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                string currenrURL = base.GetCurrentUrl;
                int indexOf = GetCurrentUrl.LastIndexOf('/');
                string urlLastWord = currenrURL.Remove(0, indexOf + 1);

                //Getting the Page Title
                if (urlLastWord == "Terms")
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
        /// Selelct the Benefit by clicking on the checkbox
        /// </summary>
        public void SelectTheBenefit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //selelct the Benefit by clicking on the checkbox
                int num = GetElementCountByXPath(BenefitSelectResource.
                    BenefitSelectPage_BenefitList_Xpath_Text);
                for (int i = 1; i <= num; i++)
                {
                    ClickButtonByXPath(BenefitSelectResource.
                        BenefitSelectPage_BenefitList_Xpath_Text + "[" + i + "]");
                }

                //clicking on accept button
                WaitForElement(By.XPath(BenefitSelectResource.
                    BenefitSelectPage_TermsAndCondition_Xpath_Text));
                ClickButtonByXPath(BenefitSelectResource.
                    BenefitSelectPage_TermsAndCondition_Xpath_Text);

                //Clicking on Accept button
                WaitForElement(By.XPath(BenefitSelectResource.
                    BenefitSelectPage_ActivateButton_Xpath_Text));
                ClickButtonByXPath(BenefitSelectResource.
                    BenefitSelectPage_ActivateButton_Xpath_Text);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}