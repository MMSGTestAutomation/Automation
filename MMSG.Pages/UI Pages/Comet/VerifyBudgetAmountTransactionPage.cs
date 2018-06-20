using MMSG.Automation;
using MMSG.Automation.Database_Support.DBDataTransferObjects;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace MMSG.Pages.UI_Pages.Comet
{
    public class VerifyBudgetAmountTransactionPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(VerifyBudgetAmountTransactionPage));

        /// <summary>
        /// Click Employee Number
        /// </summary>
        public void ClickEmployeeNumber()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getEmployeeNum = GetWebElementPropertiesByXPath(
                    VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_EmployeeNum_XPath_Locator);
                PerformMouseClickAction(getEmployeeNum);
                ClickByJavaScriptExecutor(getEmployeeNum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch and Get the Page Title
        /// </summary>
        /// <returns>Title of the Pop up</returns>
        public string SwitchAndGetPageTitle(string pageTitle)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string popupTitle = null;
            try
            {
                SwitchToDefaultWindow();
                SwitchToLastOpenedWindow();
                popupTitle = GetPageTitle;
                WaitUntilPopUpLoads(pageTitle);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return popupTitle;
        }

        /// <summary>
        /// Select EAMS
        /// </summary>
        public void SelectEAMS()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for Eams option to appear and perform mourse click
                WaitForElement(By.Id(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_EAMS_Id_Locator));
                IWebElement getEAMSOption = GetWebElementPropertiesById(
                    VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_EAMS_Id_Locator);
                PerformMouseClickAction(getEAMSOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Username for the MOL is not null
        /// </summary>
        /// <returns>True if user name is no null</returns>
        public bool VerifyTheUserNameIsNotNull()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                MaximizeWindow();
                SwitchToIFrameByIndex(0);
                WaitForDocumentLoadToComplete(20);
                WaitForElement(By.XPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_MOLUserName_XPath_Locator));
                string userNameFromTextBox = GetValueAttributeByXPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_MOLUserName_XPath_Locator);
                if (userNameFromTextBox != "")
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
        /// Verify the treeview has appeared
        /// </summary>
        /// <returns></returns>
        public bool VerifytheTreeViewAppeare()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                bool isTreeViewPresent = IsElementPresent(By.Id(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_TreeView_Id_Locator));
                if (isTreeViewPresent)
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
        /// Verify balances with the VMS DB
        /// </summary>
        /// <returns>True if the VMS Balances are matched</returns>
        public bool CompareTheVMSAmountWithDB()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                string vmsBalanceWithName = GetElementInnerTextById(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_VMSBalance_ID_Locator);
                string hrefURL = GetHrefAttributeValueByXPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_VMSBalance_XPath_Locator);
                int index = hrefURL.IndexOf("PackageID");
                String PackageId = "";
                string EmployeID = "";
                if (index != -1)
                {
                    //DO YOUR LOGIC
                    string errorCode = hrefURL.Substring(index + 10);
                    PackageId = errorCode.Split('&').First();
                    int b = errorCode.IndexOf("&");
                    string errorCode1 = errorCode.Substring(b + 12);
                    EmployeID = errorCode1.Split('&').First();
                }
                String vmsBalnce = vmsBalanceWithName.Split('$').Last();
                //Removing the Decimal value
                string vmsBalnseRountOfffromScren = (vmsBalnce.Split('.').First()).Replace(",", "");
                vmsBalnseRountOfffromScren = vmsBalnseRountOfffromScren.Replace("-", "").Trim();
                string VMSBalanse = new DBUserQueries().GetTheVMSBalances(PackageId, EmployeID);
                //Removing the Decimal value
                string vmsBalnseRountOffFromDB = VMSBalanse.Split('.').First();
                vmsBalnseRountOffFromDB = vmsBalnseRountOffFromDB.Replace("-", "").Trim();
                // comapare the value with the DB
                if (vmsBalnseRountOfffromScren.Contains(vmsBalnseRountOffFromDB))
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
        /// Clicking on the link and delink in the EAMS profile
        /// </summary>
        public void ClickOnTheLinkAndDelinkButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // checking the Link delink display
                bool checkingTheLinkButton = IsElementPresent(By.XPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_LinkButon_Xpath_Locator), 20);
                // if link is present cli nk on it or click on the  delink
                if (checkingTheLinkButton)
                {
                    IWebElement linkButton = GetWebElementProperties(By.XPath(VerifyBudgetAmountTransactionResource.
                        VerifyBudgetAmountTransactionPage_LinkButon_Xpath_Locator));
                    ClickByJavaScriptExecutor(linkButton);
                }
                else
                {
                    IWebElement deLinkButton = GetWebElementProperties(By.XPath(VerifyBudgetAmountTransactionResource.
                        VerifyBudgetAmountTransactionPage_DeLinkButon_Xpath_Locator));
                    ClickByJavaScriptExecutor(deLinkButton);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Page Link button is present
        /// </summary>
        /// <returns>Returns true If link button is present</returns>
        public bool VerifyTheButtonLinkAndDelink()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                bool checkingTheLinkButton = IsElementPresent(By.XPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_LinkButon_Xpath_Locator), 20);
                // if link is present cli nk on it or click on the  delink
                if (checkingTheLinkButton)
                {
                    status = true;
                }
                // checking the delink Button
                else if (IsElementPresent(By.XPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_DeLinkButon_Xpath_Locator), 20))
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
        /// Verify the system name and Employee name
        /// </summary>
        /// <param name="userType">User Type role</param>
        /// <returns>True if the systen name and Employee name</returns>
        public bool VerifyTheSystemNameAndEmployeeName(User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                //Getting the data from XML
                string employeeNameFromXML = User.Get(userType).Name;
                // gettig the count of the system
                int getAccountCount = base.GetElementCountByXPath(VerifyBudgetAmountTransactionResource.
                    VerifyBudgetAmountTransactionPage_CountOfSysyem_Xpath_Locator);

                for (int i = 4; i <= getAccountCount; i++)
                {
                    string getSysName = base.GetInnerTextAttributeValueByXPath(String.Format(
                        VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_SystemName_XPath_Locator, i));
                    if (getSysName.Equals("VMS"))
                    {
                        string getGivenName = base.GetInnerTextAttributeValueByXPath(String.Format
                            (VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_GivenName_XPath_Locator, i));
                        if (employeeNameFromXML.Contains(getGivenName))
                        {
                            status = true;
                            break;
                        }
                        //Ms Rose Muir Dennison
                    }
                    else if (getSysName == "")
                    {
                        getSysName = base.GetInnerTextAttributeValueByXPath(String.Format(
                        VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_VMSAccuntIsPresent_XPath_Locator, i));
                        if (getSysName.Equals("VMS"))
                        {
                            string getGivenName = base.GetInnerTextAttributeValueByXPath(String.Format
                                (VerifyBudgetAmountTransactionResource.VerifyBudgetAmountTransactionPage_EmployeeName_XPath_Locator, i));
                            if (employeeNameFromXML.Contains(getGivenName))
                            {
                                status = true;
                                break;
                            }
                            //Ms Rose Muir Dennison
                        }
                    }
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