Feature: CommonAcceptanceTestFeatures
As a User
I want to manage all the MOL User related usecases 
so that I would validate all the MOL scenarios are working fine.

#Purpose : User login as MOL user with valid user name and valid password
#Product : MOL
#Testuase ID :55016
Scenario: Login as MOL user with valid user name and valid password
Given I access application URL as "MOLUser"
When I login as "MOLUser" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose : User login as MOL user with valid user name and invalid password
#Product : MOL
#Testuase ID :55016
Scenario: Login as MOL user with valid user name and invalid password
Given I access application URL as "MOLUser"
When I login as "MOLUser" with "Valid username" and "Invalid password"
Then I should be on "Maxxia Online" page
And I should be displayed with "InvalidPasswordError" message

#Purpose : User login as MOL user with invalid user name and valid password
#Product : MOL
#Testuase ID :55016
Scenario: Login as MOL user with Invalid username and valid password
Given I access application URL as "MOLUser"
When I login as "MOLUser" with "Invalid username" and "Valid password"
Then I should be on "Maxxia Online" page
And I should be displayed with "InvalidUserNameError" message

#Purpose : User login as MOL user with invalid user name and invalid password
#Product : MOL
#Testuase ID :55016
Scenario:Login as MOL user with Invalid username and Invalid password
Given I access application URL as "MOLUser"
When I login as "MOLUser" with "Invalid username" and "Invalid password"
Then I should be on "Maxxia Online" page
And I should be displayed with "InvalidUserNameandPasswordError" message


#Purpose: User login as MOL wallet transaction user
#Product : MOL
Scenario: Login as MOL Wallet Transaction User
Given I access application URL as "MOLWalletTransactionUser"
When I login as "MOLWalletTransactionUser" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose : User login as MOL No Reimbursement
#Product : MOL
Scenario: Login as  MOL No Reimbursement
Given I access application URL as "MOLNoReimbursement"
When I login as "MOLNoReimbursement" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User logout as MOL user
#Product : MOL
Scenario: Logout as MOL User
When I click on Logout link as "MOLUser"
Then I should be on "Maxxia Online" page

#Purpose: MOL user access activation site url and activate comet user
#Product : MOL
Scenario: Access activation site URL and activate Comet user
Given I access application URL as "MOLActivation"
Then I should be on "Maxxia Online" page
When I run the "Disable" Store proc to handel SMS validation
When I enter 'Date of Birth' and 'Card Activation Code' of "NewCOMETUser"
And I click on Continue button

#Purpose: User Login as  VMSonly Employee
#Product : MOL
Scenario: Login as Only VMS user
Given I access application URL as "OnlyVMSUser"
When I login as "OnlyVMSUser" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User Login as  MOL Multiple Employeer Employee Login
#Product : MOL
Scenario:  Login As MOL Multiple Employeer Employee 
Given I access application URL as "MOLMultipleEmployeerEmployee"
When I login as "MOLMultipleEmployeerEmployee" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User Login as  MOL Active and Terminated Employeer Employee
#Product : MOL
Scenario: Login as MOL Active and Terminated Employeer Employee
Given I access application URL as "MOLActiveTerminatedEmployeerEmployee"
When I login as "MOLActiveTerminatedEmployeerEmployee" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User Login as  MOL Benefit  MergeWith Employeer
#Product : MOL
Scenario:  Login as MOL Benefit merge with Employeer
Given I access application URL as " MOLBenefitMergeWithEmployeer"
When I login as "MOLBenefitMergeWithEmployeer" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User Login as  MOL Noveted Lease Benefit SingleTitle
#Product : MOL
Scenario: Login as MOL Noveted Lease Benefit Single Title
Given I access application URL as "MOLNovetedLeaseBenefitSingleTitle"
When I login as "MOLNovetedLeaseBenefitSingleTitle" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User Login as  MOL Random User
#Product : MOL
Scenario:  Login as MOl Random Employee
Given I access application URL as "MOLRandomUser"
When I login as "MOLRandomUser" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page

#Purpose: User Login as  MOL Multiple Lease Packaing With TELSRA
#Product : MOL
Scenario: Login as MOL Multiple Lease Packaing With TELSRA
Given I access application URL as "MOLMultipleLeasePackaingWithTELSRA"
When I login as "MOLMultipleLeasePackaingWithTELSRA" with "Valid username" and "Valid password"
Then I should be on "Maxxia Online" page