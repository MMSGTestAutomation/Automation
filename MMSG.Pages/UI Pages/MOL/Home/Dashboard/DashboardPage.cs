using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MMSG.Pages.UI_Pages.MOL.Home.Dashboard
{
    public class DashboardPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(DashboardPage));

        /// <summary>
        /// Verifying the page landed on the Dashbord
        /// </summary>
        /// <param name="benefitName">Name Of the Benefit</param>
        /// <returns>True if the Benefit anme are present</returns>
        public bool VerifyTheBenefitIsPresent(string benefitName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                //Wait untill window load and select window
                WaitUntilWindowLoads(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_DashboardPageTitle_Title);
                SelectWindow(ApplicationLoginPageResource.
                    ApplicationLoginPage_MOL_DashboardPageTitle_Title);

                if (IsElementDisplayedByPartialLinkText(benefitName))
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
        /// Clicking on the link present in the dashbord
        /// </summary>
        /// <param name="linkName">This is link name.</param>
        public void ClickOnTheLink(string linkName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getDashboardLink = null;
                WaitUntilWindowLoads("Maxxia Online");

                // Wait untill the link in dashboard appear and click
                WaitForElement(By.PartialLinkText(linkName));
                getDashboardLink = GetWebElementProperties(By.PartialLinkText(linkName));
                PerformMouseClickAction(getDashboardLink);
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Saving the Benefits in Inmemory
        /// </summary>
        /// <param name="userBefits">Benfit type</param>
        public void SaveBenefitInMemory(Benefit.BenefitTypeEnum userBefits)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                int numberOfBenefits = GetElementCountByXPath(DashboardResource.
                    Dashboard_Benefitnumber_Xapth_locator);
                Benefit benefit = Benefit.Get(userBefits);
                for (int i = 3; i <= numberOfBenefits; i++)
                {
                    //Getting the Benefit name
                    string benefitName = GetElementInnerTextByXPath(string.Format(DashboardResource.
                        Dashboard_BenefitName_Xapth_locator, i));
                    if (benefitName.Contains("\r"))
                    {
                        benefitName = benefitName.Substring(0, benefitName.IndexOf("\r"));
                    }

                    switch (i)
                    {
                        case 3:
                            benefit.Benefit1 = benefitName;
                            break;

                        case 4:
                            benefit.Benefit2 = benefitName;
                            break;

                        case 5:
                            benefit.Benefit3 = benefitName;
                            break;

                        case 6:
                            benefit.Benefit4 = benefitName;
                            break;
                    }
                }
                //Saving in Inmemory
                benefit.UpdateBenefitInMemory(benefit);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Novated Lease Contain the Comma Sepepated Value
        /// </summary>
        /// <returns>True if Comma Separated Value are Present</returns>
        public bool VerifyNovatedLeaseConatainCommaSeperatedValue()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            bool status = false;
            try
            {
                int numberOfBenefits = GetElementCountByXPath(DashboardResource.
                   Dashboard_Benefitnumber_Xapth_locator);
                for (int i = 3; i <= numberOfBenefits; i++)
                {
                    //Verify the Wallet Benefit is present or not
                    if (!IsElementPresent(By.XPath(string.Format(DashboardResource.DashboardPage_WalletBenefit_Xpath_Locator, i)), 10))
                    {
                        //Getting the Benefit name
                        string benefitName = GetElementInnerTextByXPath(string.Format(DashboardResource.
                            Dashboard_BenefitName_Xapth_locator, i));
                        if (benefitName.Contains("Novated Lease") && benefitName.Contains(","))
                        {
                            status = true;
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

        /// <summary>
        /// Click option on dashboard page
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="pageName">This is page name.</param>
        public void ClickOption(string optionName, string pageName)
        {
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads and select window
                WaitUntilWindowLoads(pageName);
                SelectWindow(pageName);

                //Initialize Iwebelement
                IWebElement getButton = null;
                switch (optionName)
                {
                    case "Setting":
                        WaitForElement(By.XPath(DashboardResource.
                            DashboardPage_SettingIcon_Xpath_Locator));
                        getButton = GetWebElementPropertiesByXPath(DashboardResource.
                            DashboardPage_SettingIcon_Xpath_Locator);
                        ClickByJavaScriptExecutor(getButton);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}