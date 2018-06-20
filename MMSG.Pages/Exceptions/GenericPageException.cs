﻿using MMSG.Automation;
using System;

namespace MMSG.Pages.UIPages.Exceptions
{
    public class GenericPageException : BaseAutomationException
    {
        public override Logger Logger
        {
            get
            {
                return ExceptionLogger;
            }
        }

        /// <summary>
        /// Static logger instance of the class.
        /// </summary>
        private static readonly Logger ExceptionLogger = Logger.GetInstance(typeof(GenericPageException));

        /// <summary>
        /// GenericPageException exception.
        /// </summary>
        public GenericPageException()
            : base()
        {
        }

        /// <summary>
        /// GenericPageException exception.
        /// </summary>
        /// <param name="message">Retrieves custom message for the exception.</param>
        public GenericPageException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// GenericPageException exception.
        /// </summary>
        /// <param name="message">Retrieves the message.</param>
        /// <param name="innerException">Retrieves the inner exception.</param>
        public GenericPageException(string message
            , Exception innerException)
            : base(message, innerException)
        {
        }
    }
}