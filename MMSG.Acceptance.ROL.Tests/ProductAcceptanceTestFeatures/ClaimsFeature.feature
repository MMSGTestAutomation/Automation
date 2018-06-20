Feature: ClaimsFeature
	This page related to the Claims in MOl site

#Purpose: User no able to make a claim in ROL site is no reimbusment is present
#Testcase ID:62911
#Product:ROL
#UserStory: Forgotten password
Scenario: No Reibusment message to be displayed
Given I access application URL as "ROLNoReimbursement"
When I login as "ROLNoReimbursement" with "Valid username" and "Valid password"
Then I should be on "RemServ Online" page
When I Click on Claim button
Then I should display with Claim page
And I should see No Reimbusment Message
