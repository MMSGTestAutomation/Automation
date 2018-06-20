using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using System;

namespace MMSG.Pages.UI_Pages.ROL.Claims
{
    public class MakeAClaimPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MakeAClaimPage));

        /// <summary>
        /// Verify the page landed on the Make a claim screen
        /// </summary>
        /// <returns></returns>
        public bool VerifyPageLandedOnMakeAClaimPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);

                if (GetElementInnerTextByXPath(MakeAClaimResource.
                    MakeAClaim_PageTitle_Xpath_Locator) == MakeAClaimResource.
                    MakeAClaim_PageTitle_Xpath_Value)
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
        /// Verify the No Reibusment Message
        /// </summary>
        /// <returns></returns>
        public bool VerifyTheNoReimbusmentMessage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_ROL_PageTitle_Title);

                if (GetInnerTextAttributeValueByXPath(MakeAClaimResource.
                    MakeAClaim_NoReibusment_Xpath_Locator) ==
                    MakeAClaimResource.MakeAClaim_NoReibusment_Text_Value)
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
    }
}