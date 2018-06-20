using MMSG.Automation;
using MMSG.Pages.UI_Pages.MOL.Claims;
using MMSG.Pages.UIPages.Exceptions;
using OpenQA.Selenium;
using System;

namespace MMSG.Pages.UI_Pages.Comet.IQueuePages
{
    public class CreateRequestPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateRequestPage));

        /// <summary>
        /// Verify the Page landed on the Create page
        /// </summary>
        /// <returns> Page Title</returns>
        public string VerifyThePageLandedOnTheCreatePage()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            String pageHeader = "";
            try
            {
                // Switch to popup
                SwitchToPartialWindowTitle(CreateRequestResource.
                    CreateRequestPage_ParcialTitle_Text);
                WaitUntilPopUpLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                // Get the popup title
                String titleName = GetPageTitle;

                pageHeader = titleName.Substring(0, 6);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
            return pageHeader;
        }

        /// <summary>
        /// Filling the data to the tab
        /// </summary>
        /// <param name="dropdownName">Tab name</param>
        public void FillDataInTab(string dropdownName)
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait till popup load and select window
                WaitUntilPopUpLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                // Selelcting the dropdown option
                switch (dropdownName)
                {
                    case "General Tab":
                        GeneralTab();
                        break;

                    case "Attachment":
                        AttachmentTab();
                        break;

                    case "Note":
                        AddNoteTab();
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
        /// Filling the data to the General tab
        /// </summary>
        public void GeneralTab()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Clicking on the request ID
                WaitForElement(By.Id(CreateRequestResource.
                    CreateRequestPage_RequestTypeDropDown_Id_Locator));
                SelectDropDownValueThroughIndexById(CreateRequestResource.
                    CreateRequestPage_RequestTypeDropDown_Id_Locator, 5);

                // Fill the discription
                WaitForElement(By.Id(CreateRequestResource.
                    CreateRequestPage_Description_Id_Locator));
                FillTextBoxById(CreateRequestResource.
                    CreateRequestPage_Description_Id_Locator, CreateRequestResource.
                    CreateRequestPage_DescriptionTab_Text);

                // Cliking on the attachment tab
                WaitForElement(By.XPath(CreateRequestResource.
                    CreateRequestPage_AttachmentTab_Id_Locator));
                IWebElement attachmentTabElement = GetWebElementProperties(
                    By.XPath(CreateRequestResource.
                    CreateRequestPage_AttachmentTab_Id_Locator));
                PerformClickAction(attachmentTabElement);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the Attachment tab
        /// </summary>
        public void AttachmentTab()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                WaitUntilPopUpLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                //Get the File Path from test data folder
                string attachmentPath = new UploadReceiptPage().GetTestDataFilePath();
                // Switch to iFrame
                IWebElement elment = GetWebElementProperties(By.TagName(CreateRequestResource.
                    CreateRequestPage_IFrame_ID));
                SwitchToIFrameByWebElement(elment);
                // Upload the file
                UploadFile(attachmentPath, By.XPath(CreateRequestResource.
                    CreateRequestPage_AttachmentTextBox_Xpath_Locator));
                // Adding the attacment by cliking on add attchment button
                WaitForElement(By.XPath(CreateRequestResource.
                    CreateRequestPage_AttachmentAddButton_Id_Locator));
                IWebElement getAttachButton = GetWebElementPropertiesByXPath(
                    CreateRequestResource.CreateRequestPage_AttachmentAddButton_Id_Locator);
                ClickByJavaScriptExecutor(getAttachButton);
                // Switch to default page content
                SwitchToDefaultPageContent();
                WaitUntilPopUpLoads(GetPageTitle);
                SelectWindow(GetPageTitle);
                WaitForElement(By.XPath(CreateRequestResource.CreateRequestPage_AttachmentGrid_Xpath));
                SwitchToDefaultPageContent();
                IWebElement noteTabElement = GetWebElementProperties(By.XPath(
                    CreateRequestResource.
                    CreateRequestPage_AddNoteTab_Xpath_Locator));
                ClickByJavaScriptExecutor(noteTabElement);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Filling the Add note tab
        /// </summary>
        public void AddNoteTab()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // entering the note
                WaitForElement(By.Id(CreateRequestResource.
                    CreateRequestPage_AddNoteTextBox_Id_Locator));
                FillTextBoxById(CreateRequestResource.
                    CreateRequestPage_AddNoteTextBox_Id_Locator, CreateRequestResource.
                    CreateRequestPage_DescriptionTab_Text);

                // adding the note by cliking on the add note button
                WaitForElement(By.XPath(CreateRequestResource.
                    CreateRequestPage_AddNoteButton_Xpath_Locator));
                IWebElement addNoteButtonElelment = GetWebElementProperties(By.XPath(
                    CreateRequestResource.
                    CreateRequestPage_AddNoteButton_Xpath_Locator));
                PerformClickAction(addNoteButtonElelment);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicking the Submit button
        /// </summary>
        public void ClickOnSubmitButton()
        {
            Logger.LogMethodEntry(IsTakeScreenShotDuringEntryExit);
            try
            {
                // Submitting the IQueue
                WaitForElement(By.XPath(CreateRequestResource.
                    CreateRequestPage_SubmitButton_Xpath_Locator));
                IWebElement submitButtonElement = GetWebElementProperties(
                    By.XPath(CreateRequestResource.
                    CreateRequestPage_SubmitButton_Xpath_Locator));
                PerformClickAction(submitButtonElement);
                SwitchToLastOpenedWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit(IsTakeScreenShotDuringEntryExit);
        }
    }
}