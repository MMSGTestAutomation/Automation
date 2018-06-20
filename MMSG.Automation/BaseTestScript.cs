﻿using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MMSG.Automation
{
    /// <summary>
    /// This is the base test script
    /// </summary>
    [Binding]
    public class BaseTestScript
    {
        /// <summary>
        /// Instance of the web driver.
        /// </summary>
        private readonly IWebDriver _webDriver = WebDriverSingleton.GetInstance().WebDriver;

        /// <summary>
        /// Returns an instance of web driver.
        /// </summary>
        protected IWebDriver WebDriver
        {
            get { return _webDriver; }
        }

        /// <summary>
        /// This is the browser.
        /// </summary>
        private readonly String _browser = WebDriverSingleton.GetInstance().Browser;

        /// <summary>
        /// This is the browser.
        /// </summary>
        public String Browser
        {
            get { return _browser; }
        }

        /// <summary>
        /// Reset the Webdriver Singleton.
        ///  </summary>
        public void ResetWebdriver()
        {
            WebDriverSingleton.GetInstance().ResetSingleton();
        }

        public void ResetDesiredBrowser(string browser)
        {
            WebDriverSingleton.GetInstance().ResetNewBrowserSingleton(browser);
        }

        /// <summary>
        /// Clean the WebDriver.
        /// </summary>
        public void WebDriverCleanUp()
        {
            WebDriverSingleton.GetInstance().Cleanup();
        }

        /// <summary>
        /// This is the name of the user who is logged in.
        /// </summary>
        public static string UserName = "";

        /// <summary>
        /// This is the login space
        /// </summary>
        public static string LoginSpace = "";

        /// <summary>
        /// This is the password.
        /// </summary>
        public static string Password = "";

        /// <summary>
        /// This is the type of the user.
        /// </summary>
        public static string UserType = "";

        /// <summary>
        /// This is the name of the course in which user is present.
        /// </summary>
        public static string CourseName = "";

        /// <summary>
        /// This is the calculate transaction timings when executing activities.
        /// </summary>
        public static string TransactionTimings = "";

        /// <summary>
        /// This is name of the browser.
        /// </summary>
        public static string CurrentBrowserName = "";
    }
}