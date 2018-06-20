Feature: CommonAcceptanceTestFeatures
	This file contains scenarios which are common across all the pages

#Purpose : User Launch ROL URL as ROLUser
Scenario: Login as ROL user
Given I access application URL as "ROLUser"
When I login as "ROLUser" with "Valid username" and "Valid password"
Then I should be on "RemServ Online" page

#Purpose : User Launch ROL URL as ROLWalletTransactionUser
Scenario: Login as ROL Wallet Transaction User
Given I access application URL as "ROLWalletTransactionUser"
When I login as "ROLWalletTransactionUser" with "Valid username" and "Valid password"
Then I should be on "RemServ Online" page

#Purpose : User Launch ROL URL as ROLNonWalletTransactionUser
Scenario: Login as ROL Non-Wallet Transaction User
Given I access application URL as "ROLNonWalletTransactionUser"
When I login as "ROLNonWalletTransactionUser" with "Valid username" and "Valid password"
Then I should be on "RemServ Online" page

#Purpose :User Logout ROL URL as ROLUser
Scenario: Logout as ROL User
When I click on Logout link as "ROLUser"
Then I should be on "RemServ Online" page

#Purpose: ROL user access activation site url and activate comet user
Scenario: Actiavte the Card Login
Given  I access application URL as "ROLActivation"
Then I should be on "RemServ Online" page
When I run the "Disable" Store proc to handel SMS validation
When I Enter the DOB and Card Activation Code 
And I click on Continue button

#Purpose : Launch ROl URL
Scenario: Launch ROL URL as ROLWalletTransactionUser
Given I access application URL as "ROLWalletTransactionUser"
Then I should be on "RemServ Online" page