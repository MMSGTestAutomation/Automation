Feature: ClaimsManagementFeature
This feature file contain all the scenarios related to making a claim in MOL website

#Purpose:Validate the workflow for 'Form Upload' type for uploading single receipt
#Testcase ID: 59295, 58929
#Product:MOL
#UserStory:Make a Claim - the existing features
Scenario: User make a claim in MOl website	
When I click on the link "Claims" 
Then I should be on "ClaimStatus" url of "Maxxia Online"Page
When I click on "Add New Claim" Button in Claim Status page
Then I should be display with page "Make a claim"
When I select the Benefit and Click on Start Reimbursement button
Then I should be display with "Upload tax invoices"
When I click on the "Individual tax invoice" button
And I upload the Claim invoices and Click on Processed button
Then I should be display with "Enter claim details" page
When I enter "AmountIncludingGST" in "Amount Including GST" textbox
And I enter "GSTAmount" in "GST" textbox
And I enter "DateOfTaxInvoice" in "Date of Tax Invoice" textbox
And I click on Proceed button
Then I should be display with "Review Your Claim" page name
When I click on "Accept Declaration" CheckBox
And I click on the Submit button
Then I should see success messages

#Purpose: To check the No reimbursement message in the screen of MOL
#Testcase ID:59521
#Product:MOL
#UserStory:Make a Claim - the existing features
Scenario: Validate system doesn't allow the user to submit an Online Claim if the Reimbursement details are not present
When I click on the link "Claims"
Then I should be on "ClaimStatus" url of "Maxxia Online"Page
When I click on "Add New Claim" Button in Claim Status page
Then I should be display with page "Make a claim"
And I should be display with "There is currently no reimbursement bank account listed on your Account." Message