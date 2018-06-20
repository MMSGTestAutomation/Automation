using MMSG.Automation;
using MMSG.Automation.DataTransferObjects;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace MMSG.Pages.UI_Pages.Comet.Process_Menu
{
    public class AddBenefitPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(AddBenefitPage));

        /// <summary>
        /// Get Page Header
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        /// <returns>Return page title.</returns>
        public string GetPageHeader(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageHeader = "";
            try
            {
                // Switch to window
                SwitchToWindow(pageName);
                // Get page title
                pageHeader = GetPageTitle;
                return pageHeader;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return pageHeader;
        }

        /// <summary>
        /// Get browser Header
        /// </summary>
        /// <param name="pageName">This ia page name</param>
        /// <returns>Return page name.</returns>
        public string GetBrowserHeader(string pageName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            string pageHeader = "";
            try
            {
                Process[] browserProcesses = this.GetProcessInstance();
                foreach (Process browserProcess in browserProcesses)
                {
                    // Get the browser title based on the process
                    pageHeader = browserProcess.MainWindowTitle;
                    if (pageHeader.Contains(pageName))
                    {
                        return pageName;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return pageName;
        }

        /// <summary>
        /// Get the browser process instance
        /// </summary>
        /// <returns>Return the process instance.</returns>
        public Process[] GetProcessInstance()
        {
            Process[] processes = GetCommonProcess();
            processes.Union(Process.GetProcessesByName("IEDriverServer"));
            processes.Union(Process.GetProcessesByName("QTAgent32"));
            return processes;
        }

        /// <summary>
        /// Gets the the processes.
        /// </summary>
        /// <returns>Processes details.</returns>
        public static Process[] GetCommonProcess()
        {
            string browserName = ConfigurationManager.AppSettings["Browser"];
            Process[] processes = null;
            switch (browserName)
            {
                case BaseTestFixture.InternetExplorer: processes = Process.GetProcessesByName("iexplore"); break;
                case BaseTestFixture.FireFox: processes = Process.GetProcessesByName("firefox"); break;
                case BaseTestFixture.Safari: processes = Process.GetProcessesByName("safari"); break;
                case BaseTestFixture.Chrome: processes = Process.GetProcessesByName("chrome"); break;
            }

            if (processes != null)
            {
                processes.Union(Process.GetProcessesByName("IEDriverServer.exe"));
                processes.Union(Process.GetProcessesByName("chromedriver.exe"));
            }
            return processes;
        }

        /// <summary>
        /// Select the drop down
        /// </summary>
        /// <param name="dropDownOption"></param>
        /// <param name="dropDownName"></param>
        public void SelectDropDown(Benefit.BenefitTypeEnum benifitType, string dropDownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                string title = null;
                Benefit benefit = Benefit.Get(benifitType);
                string benefitName = benefit.Benefit2.ToString();
                string BudgetCalcutionMenthod = benefit.BudgetCalculationMethod.ToString();
                switch (dropDownName)
                {
                    case "Benefit":
                        // Get title and waituntil windowload
                        title = GetCometDomain() + " " + "Package Benefit";
                        WaitUntilPopUpLoads(title);
                        SelectWindow(title);
                        WaitForElement(By.Id(AddBenefitPageResource.AddBenefitPage_BenefitName_Id_Locator));
                        SelectDropDownValueThroughTextById(AddBenefitPageResource.AddBenefitPage_BenefitName_Id_Locator, benefitName);
                        break;

                    case "Budget Calculation Method":
                        // Get title and waituntil windowload
                        title = GetCometDomain() + " " + "Package Benefit - Benefit Details";
                        WaitUntilPopUpLoads(title);
                        SelectWindow(title);
                        WaitForElement(By.Id(AddBenefitPageResource.AddBenefitPage_BudgetCalculation_Id_Locator));
                        SelectDropDownValueThroughTextById(AddBenefitPageResource.AddBenefitPage_BudgetCalculation_Id_Locator, BudgetCalcutionMenthod);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save or Next button
        /// </summary>
        /// <param name="buttonName"></param>
        public void ClickOnButton(string buttonName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Next":
                        // Get title and waituntil windowload
                        string title = GetCometDomain() + " " + "Package Benefit";
                        WaitUntilPopUpLoads(title);
                        SelectWindow(title);
                        SetImplicitWaitTime(20);
                        WaitForElement(By.Id(AddBenefitPageResource.AddBenefitPage_NextButton_Id_Locator));
                        IWebElement nextButtonProperty = GetWebElementProperties(By.Id(AddBenefitPageResource
                            .AddBenefitPage_NextButton_Id_Locator));
                        PerformClickAction(nextButtonProperty);
                        break;

                    case "Save":
                        // Get title and waituntil windowload
                        title = GetCometDomain() + " " + "Package Benefit - Benefit Details";
                        WaitUntilPopUpLoads(title);
                        SelectWindow(title);
                        WaitForElement(By.Id(AddBenefitPageResource.AddBenefitPage_SaveButton_Id_Locator));
                        IWebElement saveButtonProperty = GetWebElementProperties(By.Id(AddBenefitPageResource.
                            AddBenefitPage_SaveButton_Id_Locator));
                        ClickByJavaScriptExecutor(saveButtonProperty);
                        // checking the the pop up appaered
                        bool enterNameOfTheCard = IsElementPresent(By.XPath(AddBenefitPageResource.
                            AddBenefitPage_CardNameOKButton_Xpath_Locator), 10);
                        if (enterNameOfTheCard)
                        {
                            IWebElement okButton = GetWebElementProperties((By.XPath(AddBenefitPageResource.
                                AddBenefitPage_CardNameOKButton_Xpath_Locator)));
                            ClickByJavaScriptExecutor(okButton);
                        }

                        bool noButtonOtherBenefitProcess = IsElementPresent(By.XPath(AddBenefitPageResource.
                            AddBenefitPage_NoButtonConfermation_Xpath_Locator), 10);
                        if (noButtonOtherBenefitProcess)
                        {
                            IWebElement noButtonPropertiesOfConfermation = GetWebElementProperties((By.XPath(AddBenefitPageResource.
                                AddBenefitPage_NoButtonConfermation_Xpath_Locator)));
                            ClickByJavaScriptExecutor(noButtonPropertiesOfConfermation);
                        }

                        break;

                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Budget Amount
        /// </summary>
        public void BudgetAmount(Benefit.BenefitTypeEnum benifitType)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            Benefit benefit = Benefit.Get(benifitType);
            string budgetAmount = benefit.BudgetAmount.ToString();
            try
            {
                ClearTextById(AddBenefitPageResource.AddBenefitPage_BudgetAmount_Id_Locator);
                FillTextBoxById(AddBenefitPageResource.AddBenefitPage_BudgetAmount_Id_Locator, budgetAmount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
        }
    }
}