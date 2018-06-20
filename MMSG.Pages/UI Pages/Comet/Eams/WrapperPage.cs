using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet.Eams
{
    /// <summary>
    /// This clas contains all the methord of wrapper.asp page
    /// </summary>
    public class WrapperPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(WrapperPage));

        /// <summary>
        /// Get the status of Eams probile ID by comparing the application ID with the ID retrieved from DB
        /// </summary>
        /// <param name="userType">This is user type enum.</param>
        /// <returns>Return eams probile status</returns>
        public bool GetEamsProfileIDStatus(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            User user = User.Get(userType);
            bool eamsProfileStatus = false;
            try
            {
                // Maximize the window
                MaximizeWindow();
                // Get employee ID
                int employeeID = this.GetEmployeeID();
                string getEamsIDFromDB = (new DBUserQueries().GetEamsID(employeeID)).
                    ToString();
                //Store EAMSID to inMemory
                user.WriteUserInMemory(user, "EAMSID", getEamsIDFromDB);
                // Switch iframe by name
                SwitchToIFrameByName(CallCentreEnquiryResource.CallCentreEnquiry_Iframe_Id);
                // Get EamsID from application
                string getEamsIDFromApp = (GetValueAttributeByXPath(
                    WrapperResource.WrapperPage_GetEamsID_Value)).ToString();
                // Compare with the Eams ID reterived from application and from DB
                if (getEamsIDFromApp == getEamsIDFromDB)
                {
                    eamsProfileStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            // return Eams profile comparision status
            return eamsProfileStatus;
        }

        /// <summary>
        /// Getting the Employee ID using Employee ID
        /// </summary>
        /// <returns>Employee ID</returns>
        private int GetEmployeeID()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            int employeeID = 0;
            try
            {
                string url = GetCurrentUrl;
                //Getting the Index of the = and the Get the Employeee ID
                int first = url.IndexOf("=");
                int second = url.IndexOf("=", first + 1);
                int third = url.IndexOf("=", second + 1);
                string removeURL = url.Remove(0, third + 1);
                int getCharPosition = removeURL.IndexOf('&');
                string empID = (removeURL.Substring(0, getCharPosition));
                employeeID = Convert.ToInt32(empID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return employeeID;
        }

        /// <summary>
        /// Verify the page lnaded on the Co Nav Dashboard
        /// </summary>
        /// <returns></returns>
        public bool VerifyCoNavPageLandedOnDashboard()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                bool a = IsElementPresent(By.XPath(WrapperResource.
                    WrapperPage_GetDashboard_Xpath_Text));
                if (GetInnerTextAttributeValueByXPath(WrapperResource.
                    WrapperPage_GetDashboard_Xpath_Text) == "Dashboard")
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
    }
}