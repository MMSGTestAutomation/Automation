using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Profile
{
    public class CommunicationPreferencesPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CommunicationPreferencesPage));

        /// <summary>
        /// Verify the checkbox is been checked
        /// </summary>
        /// <param name="checkBoxName">check box name</param>
        /// <returns>True if Checkbox is checked</returns>
        public bool VerifyCheckBoxIsChecked(string checkBoxName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            string checkBoxvalue = "";
            try
            {
                switch (checkBoxName)
                {
                    case "Please send me a reminder when I need to provide a receipt/documentation for a claim":
                        checkBoxvalue = WebDriver.FindElement(By.Id(CommunicationPreferencesResource.CommunicationPreferencesPage_PleaseSendReminder_Id_loactor)).GetAttribute("checked");
                        if (checkBoxvalue == "true")
                        {
                            status = true;
                        }
                        break;

                    case "Please send me an email confirmation when payments are made from my salary packaging account. ":
                        checkBoxvalue = WebDriver.FindElement(By.Id(CommunicationPreferencesResource.CommunicationPreferencesPage_PleaseSendEmail_Id_loactor)).GetAttribute("checked");
                        if (checkBoxvalue == "true")
                        {
                            status = true;
                        }
                        break;

                    case "Please do not send me any marketing materials.":
                        checkBoxvalue = WebDriver.FindElement(By.Id(CommunicationPreferencesResource.CommunicationPreferencesPage_PleaseDoNotSend_Id_loactor)).GetAttribute("checked");
                        if (checkBoxvalue == "true")
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
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            return status;
        }
    }
}