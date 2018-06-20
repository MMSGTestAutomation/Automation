using MMSG.Automation;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.ROL.Your_Account
{
    public class TransactionsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TransactionsPage));

        /// <summary>
        /// Verify that the dropdown and values are present
        /// </summary>
        /// <param name="dropDownName"></param>
        /// <returns>Returns true if the element present</returns>
        public bool ValidateDropDownAndValue(string dropDownName, string dropDownValue)
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

                switch (dropDownName)
                {
                    case "View Account:":
                        status = IsElementPresent(By.XPath(TransactionResource.
                            TransactionsPage_ViewAccountLabel_Xpath_Locator))
                            && IsElementPresent(By.XPath(TransactionResource.
                            TransactionsPage_ViewAccountDropDown_Xpath_Locator));
                        break;

                    case "From:":
                        status = IsElementPresent(By.XPath(TransactionResource.
                            TransactionsPage_FromLabel_Xpath_Locator))
                            && IsElementPresent(By.XPath(TransactionResource.
                            TransactionsPage_FromDropDown_Xpath_Locator));
                        break;
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
        /// Method to verify available balance is not zero
        /// </summary>
        /// <returns>This is a return type.</returns>
        public bool ValidateAvailableBalance()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool getStatus = true;
            try
            {
                string valueOnWebPage = GetElementInnerTextByXPath(TransactionResource.
                    TransactionsPage_AvailableBalanceValue_Xpath_Locator);
                if (valueOnWebPage == "$9.52")
                {
                    getStatus = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return getStatus;
        }

        /// <summary>
        /// Verify the tab status in transaction page
        /// </summary>
        /// <param name="tabName">Tab Name</param>
        /// <returns>true if tab is active</returns>
        public bool ValidateTabStatus(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool returenStatus = false;
            try
            {
                switch (tabName)
                {
                    case "7days":
                        WaitForElement(By.XPath(TransactionResource.
                            TransactionsPage_7daysTab_Xpath_Locator));
                        string classValue7Days = GetClassAttributeValueByXPath(TransactionResource.
                            TransactionsPage_7daysTab_Xpath_Locator);
                        if (classValue7Days == "active")
                        {
                            returenStatus = true;
                        }
                        break;
                    case "30days":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_30daysTab_Xpath_Locator));
                        string classValue30Days = GetClassAttributeValueByXPath(TransactionResource.
                            TransactionsPage_30daysTab_Xpath_Locator);
                        if (classValue30Days == "active")
                        {
                            returenStatus = true;
                        }
                        break;
                    case "60days":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_60daysTab_Xpath_Locator));
                        string classValue60Days = GetClassAttributeValueByXPath(TransactionResource.TransactionsPage_60daysTab_Xpath_Locator);
                        if (classValue60Days == "active")
                        {
                            returenStatus = true;
                        }
                        break;
                    case "Advances filter":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_AdvancesFilterdaysTab_Xpath_Locator));
                        string classValueAdvance = GetClassAttributeValueByXPath(TransactionResource.
                            TransactionsPage_AdvancesFilterdaysTab_Xpath_Locator);
                        if (classValueAdvance == "active")
                        {
                            returenStatus = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return returenStatus;
        }

        /// <summary>
        /// Click on the tab in Transaction page
        /// </summary>
        /// <param name="tabName">tab name</param>       
        public void ClickOnTheTab(string tabName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);           
            try
            {
                switch (tabName)
                {
                    case "7days":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_7daysTab_Xpath_Locator));
                        ClickButtonByXPath(TransactionResource.TransactionsPage_7daysTab_Xpath_Locator);                  
                        break;                        
                    case "30days":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_30daysTab_Xpath_Locator));
                        ClickButtonByXPath(TransactionResource.TransactionsPage_30daysTab_Xpath_Locator);
                        break;
                    case "60days":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_60daysTab_Xpath_Locator));
                        ClickButtonByXPath(TransactionResource.TransactionsPage_60daysTab_Xpath_Locator);
                        break;
                    case "Advances filter":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_AdvancesFilterdaysTab_Xpath_Locator));
                        ClickButtonByXPath(TransactionResource.TransactionsPage_AdvancesFilterdaysTab_Xpath_Locator);
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);           
        }

        /// <summary>
        /// Add filter to the transaction in advances filter
        /// </summary>
        /// <param name="pickerType">date picker type</param>
        /// <param name="numberMonth">Number of monthsto set back</param>
        public void AddFilter(string pickerType, int numberMonth)
        {
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);            
            try
            {
                switch (pickerType)
                {
                    case "From":
                    ClickImageByXPath( TransactionResource.TransactionsPage_FromDatePickerImg_Xpath_Locator);
                        for (int i = 0; i < numberMonth; i++)
                        {
                            WaitForElement(By.XPath(TransactionResource.TransactionsPage_FromPrev_Xpath_Locator));
                            IWebElement preButton = GetWebElementPropertiesByXPath(TransactionResource.
                                TransactionsPage_FromPrev_Xpath_Locator);
                            PerformClickAction(preButton);                           
                        }
                        string toDate = DateTime.Now.ToString("dd");
                        string firstLetter = toDate[0].ToString();
                        if (firstLetter == "0")
                        {
                            string dateWithRemovedFirstCharecter = toDate.Remove(0, 1);
                            WaitForElement(By.XPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, dateWithRemovedFirstCharecter)));
                            ClickButtonByXPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, dateWithRemovedFirstCharecter, dateWithRemovedFirstCharecter));                          
                        }
                        else
                        {
                            WaitForElement(By.XPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator,  toDate)));
                            ClickButtonByXPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, toDate));
                        }
                        break;
                    case "To":
                        ClickImageByXPath(TransactionResource.TransactionsPage_ToDate_Xpath_Locator);
                        string toDateTO = DateTime.Now.ToString("dd");
                        string firstLetterTo = toDateTO[0].ToString();
                        if (firstLetterTo == "0")
                        {
                            string dateWithRemovedFirstCharecter = toDateTO.Remove(0, 1);                           
                            WaitForElement( By.XPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, dateWithRemovedFirstCharecter)));
                            ClickButtonByXPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, dateWithRemovedFirstCharecter));
                        }
                        else
                        {
                            WaitForElement(By.XPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, toDateTO )));
                            ClickButtonByXPath(string.Format(TransactionResource.TransactionsPage_FromDate_Xpath_Locator, toDateTO));
                        }
                        break;
            }              
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking on the button in transaction page 
        /// </summary>
        /// <param name="buttonName"></param>
        public void ClickonButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Submit":
                        WaitForElement(By.XPath(TransactionResource.TransactionsPage_SubmitButton_Xpath_Locator));
                        ClickButtonByXPath(TransactionResource.TransactionsPage_SubmitButton_Xpath_Locator);                            
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