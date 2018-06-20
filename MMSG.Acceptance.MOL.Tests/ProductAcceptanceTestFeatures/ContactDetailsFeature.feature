Feature: ContactDetailsFeature
	This page contains scenario relted to conatct page 

#Purpose: verify the multiple employeer fuctionality
#Testcase ID:56840
#Product:Comet
#UserStory:Validate that the multiple Employer functionality is adopted for "Contact Us" screen.
Scenario: Verify the multiple employeer fuctionality in Contact Page
When I click on the link "Contact"
Then I should be on "Contact" url of "Maxxia Online"Page
And I should be "able" toggle betwwen Employee


#Purpose: Verify the Iqueue is created when user changes the personal details in Contact page
#Testcase ID:56840,59863
#Product:Comet
#UserStory:MOL-Validate when personal details are modified and saved, an “Ops Amendments – Web” iQueue request type must be lodged and closed to signify that changes have been made on an account.
Scenario: Verify the personal details are changed and saved with Iqueue need to be created 
When I click on the link "Contact"
Then I should be on "Contact" url of "Maxxia Online"Page
When I select "Make a change to your package" in the dropdown "I want to" in Contact Page
And I select "Remove a benefit in my package" in the dropdown "Change" in Contact Page
And I select benefit from Remove Benefit dropdown in Contact Page
And I should Select Pay date for Change as "Next pay date for change"
And I should select "Phone" as Preferred contact in Contact Page
And I should fill  "Message" in Contact Page
Then I should verify Iqueue is created when I Click on submit button as "MOLUser"
