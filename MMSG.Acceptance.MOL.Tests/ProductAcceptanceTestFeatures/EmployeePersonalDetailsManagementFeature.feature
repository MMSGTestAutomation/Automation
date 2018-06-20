Feature: EmployeePersonalDetailsManagementFeature
	This feature file contains all the scenarios related to employee personal details

#Purpose: Reset MOL user password
#Testcase ID: 62911
#Product:MOL
#UserStory:Forgotten password
Scenario: User Reset the password
Given I access application URL as "MOLWalletTransactionUser"
When I run the "Disable" Store proc to handel SMS validation
When I click on Button "Forgot your password"
Then I should be on "ForgotPassword" url of "Maxxia Online."Page
When I enter the "UserId" of "MOLWalletTransactionUser"
And I click on "Submit UserID"
Then I should view New password and Reenter	
When I enter New Password and Confirm password in text box as "MOLWalletTransactionUser"
And I click on "getCode"
When I enter the "SMSCode" of "MOLWalletTransactionUser"
And I click on "Submit"
Then I should be on "Maxxia Online" page
And I should be displayed with "Your password has been successfully changed" message for "MOLWalletTransactionUser"
When I run the "Enable" Store proc to handel SMS validation

#Purpose: Verify field validation in Personal details screen of 'Maxxia Secure Portal'
#Testcase ID: 55116
#Product:MOL
#UserStory:Employee Personal details validation
Scenario: Employee Personal details validation
When I click on "Setting" option in "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I enter "Empty" in "Personal Email address" textbox of "Maxxia Online" page
Then I should be displayed with "Empty" message in "Personal Email address" textbox of "Maxxia Online" page
When I enter "Invalid" in "Personal Email address" textbox of "Maxxia Online" page
Then I should be displayed with "Invalid" message in "Personal Email address" textbox of "Maxxia Online" page
When I enter "Valid" in "Personal Email address" textbox of "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I enter "Empty" in "Home phone" textbox of "Maxxia Online" page
Then I should be displayed with "Empty" message in "Home phone" textbox of "Maxxia Online" page
When I enter "Invalid" in "Home phone" textbox of "Maxxia Online" page
Then I should be displayed with "Invalid" message in "Home phone" textbox of "Maxxia Online" page
When I enter "Valid" in "Home phone" textbox of "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I enter "Empty" in "Mobile" textbox of "Maxxia Online" page
Then I should be displayed with "Empty" message in "Mobile" textbox of "Maxxia Online" page
When I enter "Invalid" in "Mobile" textbox of "Maxxia Online" page
Then I should be displayed with "Invalid" message in "Mobile" textbox of "Maxxia Online" page
When I enter "Valid" in "Mobile" textbox of "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I enter "Empty" in "Suburb" textbox of "Maxxia Online" page
Then I should be displayed with "Empty" message in "Suburb" textbox of "Maxxia Online" page
When I enter "Invalid" in "Suburb" textbox of "Maxxia Online" page
Then I should be displayed with "Invalid" message in "Suburb" textbox of "Maxxia Online" page
When I enter "Valid" in "Suburb" textbox of "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I enter "Empty" in "Post Code" textbox of "Maxxia Online" page
Then I should be displayed with "Empty" message in "Post Code" textbox of "Maxxia Online" page
When I enter "Invalid" in "Post Code" textbox of "Maxxia Online" page
Then I should be displayed with "Invalid" message in "Post Code" textbox of "Maxxia Online" page
When I enter "Valid" in "Post Code" textbox of "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I enter "Empty" in "Peninsula Health" textbox of "Maxxia Online" page
Then I should be displayed with "Empty" message in "Peninsula Health" textbox of "Maxxia Online" page
When I enter "Invalid" in "Peninsula Health" textbox of "Maxxia Online" page
Then I should be displayed with "Invalid" message in "Peninsula Health" textbox of "Maxxia Online" page
When I enter "Valid" in "Peninsula Health" textbox of "Maxxia Online" page

#Purpose: Verify the Communication preferences page check box are checked  
#Testcase ID: 
#Product:MOL
#UserStory:MOL - Change Request('Removal of Postal option in Communication Preferences page', against the User Story 130151) incorporation in existing Smoke Automation Suite
Scenario: Verify  Communication preferences conatins all the check box are been checked 
When I click on "Setting" option in "Maxxia Online" page
Then I should be on "Maxxia Online" page
When I click on the link "Communication preferences"
Then I should be on "communicationpreferences" url of "Maxxia Online"Page
Then I should view the "Please send me a reminder when I need to provide a receipt/documentation for a claim" check box checked
Then I should view the "Please send me an email confirmation when payments are made from my salary packaging account. " check box checked
Then I should view the "Please do not send me any marketing materials." check box checked

