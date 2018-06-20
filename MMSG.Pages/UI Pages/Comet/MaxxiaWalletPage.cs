using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class MaxxiaWalletPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(MaxxiaWalletPage));

        /// <summary>
        /// Verify the page landed on the Maxxia Wallet
        /// </summary>
        /// <returns>Returns true if page landed</returns>
        public bool VerifyThePageLandedOnMaxxiaWalletPage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                WaitUntilPopUpLoads(GetCometDomain());
                SelectWindow(GetCometDomain());
                string pageTitleFromPage = GetInnerTextAttributeValueByXPath(MaxxiaWalletResource.
                    MaxxiaWalletPage_Title_Xpath_Lacator);
                if (pageTitleFromPage == MaxxiaWalletResource.MaxxiaWalletPage_MaxxiaWallet_Title)
                {
                    status = true;
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
        /// Get the status of card from application
        /// </summary>
        /// <returns>stsuts of the card</returns>
        public string GetTheStatusOfCard()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string cardStatusString = "";
            try
            {
                RefreshTheCurrentPage();
                cardStatusString = GetInnerTextAttributeValueByXPath(MaxxiaWalletResource.
                    MaxxiaWalletPage_CardStatus_Xpath_Lacator);
                string user = User.Get(User.UserTypeEnum.NewCOMETUser).EmployeeNumber.ToString();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return cardStatusString;
        }

        /// <summary>
        /// Click cancel button
        /// </summary>
        public void ClickCancelButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait untill cancel button load and click
                WaitForElement(By.Id(MaxxiaWalletResource.
                    MaxxiaWalletPage_CancelButton_ID_Lacator), 10);
                IWebElement getCancelButton = GetWebElementProperties(By.Id(MaxxiaWalletResource.
                    MaxxiaWalletPage_CancelButton_ID_Lacator));
                PerformMouseClickAction(getCancelButton);
                ClickByJavaScriptExecutor(getCancelButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}