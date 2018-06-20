using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMSG.Automation;
using MMSG.Pages.Exceptions;
using System;

namespace MMSG.Pages.UIPages.Exceptions
{
    public static class ExceptionHandler
    {
        /// <summary>
        /// Static logger instance of the class.
        /// </summary>
        private static readonly Logger ExceptionLogger =
            Logger.GetInstance(typeof(ExceptionHandler));

        /// <summary>
        /// This method handels and throws exceptions.and contnues on failure without closing browser
        /// </summary>
        /// <param name="ex">This is the exception.</param>
        public static void HandleException(Exception ex, bool ContinueOnFailure = false)
        {
            string customExceptionMessage = "";
            if (ex.InnerException != null)
                customExceptionMessage = GetCustomExceptionMessage(ex.InnerException);
            else
                customExceptionMessage = GetCustomExceptionMessage(ex);

            var genericPageException = new GenericPageException(ex.ToString(), ex);
            if (!string.IsNullOrWhiteSpace(customExceptionMessage))
            {
                ExceptionLogger.LogException("ExceptionHandler", "HandleException", ex, customExceptionMessage, true);
                new CustomReport().AddFailStatusToReport(ex, Logger.screenShotFilePath, customExceptionMessage);
            }
            else
            {
                ExceptionLogger.LogException("ExceptionHandler", "HandleException", ex, ex.Message, true);
                new CustomReport().AddFailStatusToReport(ex, Logger.screenShotFilePath, customExceptionMessage);
            }
            // close webdriver and browser instances
            if (!ContinueOnFailure)
            {
                WebDriverSingleton.GetInstance().Dispose();
            }
            throw genericPageException;
        }

        #region Map exceptions to user friendly messages

        public static string GetCustomExceptionMessage(Exception ex)
        {
            if (ex.GetType() == typeof(GenericPageException))
                return FaultErrorMessages.GenericPageException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.NoSuchWindowException))
                return FaultErrorMessages.NoSuchWindowException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.NoSuchElementException))
                return FaultErrorMessages.NoSuchElementException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.WebDriverException))
                return FaultErrorMessages.WebDriverException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.WebDriverTimeoutException))
                return FaultErrorMessages.WebDriverTimeoutException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.XPathLookupException))
                return FaultErrorMessages.XPathLookupException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.NotFoundException))
                return FaultErrorMessages.NotFoundException;
            else if (ex.GetType() == typeof(OpenQA.Selenium.ElementNotVisibleException))
                return FaultErrorMessages.ElementNotVisibleException;
            else if (ex.GetType() == typeof(InvalidOperationException))
                return FaultErrorMessages.InvalidOperationException;
            else if (ex.GetType() == typeof(InvalidCastException))
                return FaultErrorMessages.InvalidCastException;
            else if (ex.GetType() == typeof(NullReferenceException))
                return FaultErrorMessages.NullReferenceException;
            else if (ex.GetType() == typeof(TimeoutException))
                return FaultErrorMessages.TimeoutException;
            else if (ex.GetType() == typeof(NotSupportedException))
                return FaultErrorMessages.NotSupportedException;
            else if (ex.GetType() == typeof(AssertFailedException))
                return FaultErrorMessages.AssertFailedException;
            else
                return "";
        }

        #endregion Map exceptions to user friendly messages
    }
}