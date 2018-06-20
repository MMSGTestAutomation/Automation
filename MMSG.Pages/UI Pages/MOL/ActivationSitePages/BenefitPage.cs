using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using System;

namespace MMSG.Pages.UI_Pages.MOL.ActivationSitePages
{
    public class BenefitPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(BenefitPage));

        /// <summary>
        /// Verify the page landed on the Benefit page
        /// </summary>
        public string VerifyThePageLandedOnBenefitPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageTilte = "";
            try
            {
                pageTilte = GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return pageTilte;
        }
    }
}