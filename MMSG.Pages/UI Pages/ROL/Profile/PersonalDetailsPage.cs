using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSG.Pages.UI_Pages.ROL.Profile
{
  public  class PersonalDetailsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PersonalDetailsPage));

        /// <summary>
        /// Click on the element in page 
        /// </summary>
        /// <param name="elementName">Element to ne click</param>
        public void ClickOnWebElement(string elementName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (elementName)
                {
                    case "Change password":                       
                        WaitForElement(By.PartialLinkText("Change password"), 10);
                        IWebElement changeProperty = GetWebElementPropertiesByPartialLinkText("Change password");
                        PerformClickAction(changeProperty);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);

        }
    }
}
