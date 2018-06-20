using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.MOL.ActivationSitePages
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
        public bool PageLandedOnSelelctBenefitPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageTilte = "";
            bool status = false;
            try
            {
                //Waituntill window load and select window
                Thread.Sleep(2000);
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title, 20);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);

                pageTilte = GetInnerTextAttributeValueByXPath(BenefitSelectResource.
                    BenefitSelectPage_Title_Xpath_Location);
                if (pageTilte == BenefitSelectResource.BenefitSelectPage_Title_Xpath_Text)
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
        /// Selelct the Benefit from the page
        /// </summary>
        public void SelelctTheBenefit()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Waituntill window load and select window
                WaitUntilPopUpLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_LoginPageTitle_Title);

                //selelct the Benefit by clicking on the checkbox
                int num = GetElementCountByXPath(BenefitSelectResource.
                    BenefitSelectPage_BenefitsList_Xpath_Text);
                for (int i = 1; i <= num; i++)
                {
                    ClickButtonByXPath(BenefitSelectResource.
                        BenefitSelectPage_BenefitsList_Xpath_Text + "[" + i + "]");
                }

                //clicking on accept button
                WaitForElement(By.XPath(BenefitSelectResource.
                    BenefitSelectPage_TearmsAndCondition_Xpath_Text));
                ClickButtonByXPath(BenefitSelectResource.
                    BenefitSelectPage_TearmsAndCondition_Xpath_Text);

                //Clicking on Activate button
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