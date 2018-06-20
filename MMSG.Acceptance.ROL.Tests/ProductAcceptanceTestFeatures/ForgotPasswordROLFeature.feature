Feature: ForgotPasswordROLFeature
	This Feature file contains the Forgot password relateda Scenario

#Purpose: User able to Chage password in the in Forgot password screen
#Testcase ID:62911
#Product:ROL
#UserStory: Forgotten password
Scenario: User forgot the passsword and reset it
Given I access application URL as "ROLWalletTransactionUser"
When I run the "Disable" Store proc to handel SMS validation
When I click on Button "Forgot your password"
Then I should be on "forgotpassword" page of ROL	
When I enter "UserId" in text box as "ROLWalletTransactionUser"
And I click on "Submit UserID"
Then I should view New password and Reenter	
When I enter New Password and Confirm password in text box as "ROLWalletTransactionUser"
And I click on "getCode"
When I enter "SMSCode" in text box as "ROLWalletTransactionUser"
And I click on "Submit"
Then I should be on "RemServ Online" page
When I run the "Enable" Store proc to handel SMS validation

#Purpose: User validate the Error Message and Change the Password
#Testcase ID:76934
#Product:ROL
#UserStory:ROL - Verify change password validation
Scenario:  Verify change password validation and verify sucess message is displayed when customer changes password 
When I click on "Setting" in Dashboard
Then I should be on "PersonalDetails" page of ROL
When I click on "Change password" in Personal Details page
Then I should be on "changepassword" page of ROL
When I enter "Empty" Old Password,"Empty" New password, "Empty" re enter password in "RemServ Online" Page and click on save
Then I should see "Password Required" in Oldpassword, "Password Required" in new password and "Password Required" in Reenter password in "RemServ Online" 
When I enter "Empty" Old Password,"Invalid" New password, "Empty" re enter password in "RemServ Online" Page and click on save
Then I should see "Password Required" in Oldpassword, "Validation  Message" in new password and "Password Required" in Reenter password in "RemServ Online" 
When I enter "Valid" Old Password,"Invalid" New password, "Empty" re enter password in "RemServ Online" Page and click on save
Then I should see "No Message" in Oldpassword, "Validation  Message" in new password and "Password Required" in Reenter password in "RemServ Online" 
When I enter "Valid" Old Password,"Valid" New password, "Invalid" re enter password in "RemServ Online" Page and click on save
When I enter "Valid" Old Password,"Valid" New password, "Valid" re enter password in "RemServ Online" Page and click on save
Then I should be display with Success Message


#Purpose: User validate the Error Message and Change the Password
#Testcase ID:76552
#Product:ROL
#UserStory: ROL - Verify that "Password change successful message" is displayed when customer changes his password
Scenario: Verify the Success message when coustomer changes Password
When I click on "Setting" in Dashboard
Then I should be on "PersonalDetails" page of ROL
When I click on "Change password" in Personal Details page
Then I should be on "changepassword" page of ROL
When I enter "Valid" Old Password,"Valid" New password, "Invalid" re enter password in "RemServ Online" Page and click on save
When I enter "Valid" Old Password,"Valid" New password, "Valid" re enter password in "RemServ Online" Page and click on save
Then I should be display with Success Message

#Purpose: Verify The Account get susupenedwhen attempt login fails more then 3 times
#Testcase ID:76675
#Product:ROL
#UserStory: ROL - Verify that the customer account is locked out, when user enters incorrect password more than three consecutive times within the same session
Scenario:  Verify Account locked out when user enters incorrect password more then three consecutive times
Given I access application URL as "ROLUser"
When I reset Failed Login attempt to Zero for "ROLUser" 
When I login as "ROLUser" with "Valid username" and "Invalid password"
Then I should be on "RemServ Online" page
And I should be displayed with "InvalidPasswordError" message in LoginPage
When I login as "ROLUser" with "Valid username" and "Invalid password"
Then I should be on "RemServ Online" page
And I should be displayed with "InvalidPasswordError" message in LoginPage
When I login as "ROLUser" with "Valid username" and "Invalid password"
Then I should be on "RemServ Online" page
And I should be displayed with "InvalidPasswordError" message in LoginPage
When I login as "ROLUser" with "Valid username" and "Invalid password"
Then I should be on "RemServ Online" page
And I should be displayed with "AccountSuspenndedError" message in LoginPage
When I reset Failed Login attempt to Zero for "ROLUser" 
When I login as "ROLUser" with "Valid username" and "Valid password"
Then I should be on "RemServ Online" page