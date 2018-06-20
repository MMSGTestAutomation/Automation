using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.MOL.Your_Account
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
        public bool ValidateDropDownIsPresent(string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                switch (dropDownName)
                {
                    case "Select benefit:":
                        status = IsElementPresent(By.XPath(TransactionResource.
                            TransactionsPage_SelectBenefitLabel_Xpath_Locator));
                        break;

                    case "From:":
                        status = IsElementPresent(By.XPath(TransactionResource.
                            TransactionsPage_FromLabel_Xpath_Locator));
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
        /// <returns>True idf the element Exist</returns>
        public bool ValidateAvailableBalance()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                string valueOnWebPage = GetElementInnerTextByXPath(TransactionResource.
                    TransactionsPage_AvailableBalanceValue_Xpath_Locator);
                if (valueOnWebPage != "$0.00")
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
        /// Verify the tracsction are displayed
        /// </summary>
        /// <returns>True if the Transction are displayed</returns>
        public bool VerifyTheTransactionIsDisplayed()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                if (IsElementPresent(By.XPath(TransactionResource.
                    TransactionsPage_TransactionTable_Xpath_Locator)))
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
        /// Click on the dropdown  button present on the Transaction page
        /// </summary>
        /// <param name="dropDownOption">Drop down Option</param>
        /// <param name="dropDownName">Drop down Name</param>
        public void ClickOnDropDown(string dropDownOption, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                SwitchToDefaultWindow();
                WaitUntilWindowLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                switch (dropDownName)
                {
                    case "Select benefit:":
                        IWebElement getDropdownSelectBenefit = GetWebElementProperties(By.XPath(TransactionResource.
                            TransactionPage_SelectBenefitButton_Xpath_Locator));
                        ClickByJavaScriptExecutor(getDropdownSelectBenefit);
                        SelectTheDropDown(dropDownOption);
                        break;

                    case "From:":
                        IWebElement getDropdownFrom = GetWebElementProperties(By.XPath(TransactionResource.
                         TransactionPage_FromButton_Xpath_Locator));
                        ClickByJavaScriptExecutor(getDropdownFrom);
                        SelectTheDropDown(dropDownOption);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the drop down option in the dropdown button
        /// </summary>
        /// <param name="dropDownOption">DropDown Option to be selelcted </param>
        public void SelectTheDropDown(string dropDownOption)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                ClickLinkByPartialLinkText(dropDownOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifify Benefit name
        /// </summary>
        public bool VerifiyBenefitName(Benefit.BenefitTypeEnum userBenfitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                IWebElement dropdownButton = GetWebElementProperties(By.XPath(TransactionResource.
                    TransactionsPage_ViewAccountDropDownonButton_Xpath_Locator));
                ClickByJavaScriptExecutor(dropdownButton);
                int benefitCount = GetElementCountByXPath(TransactionResource.TransactionsPage_GetCountOfBenefitfromDropdown_Xpath_Locator);
                Benefit benfit = Benefit.Get(userBenfitType);
                //Compare the benefit
                for (int i = 2; i <= benefitCount; i++)
                {
                    string benefit = GetElementInnerTextByXPath(string.Format(TransactionResource.
                              TransactionsPage_GetBenefitName_Xpath_Locator, i));
                    if (benefit.Contains(benfit.Benefit1) ||
                        benefit.Contains(benfit.Benefit2) ||
                        benefit.Contains(benfit.Benefit3))

                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                        break;
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