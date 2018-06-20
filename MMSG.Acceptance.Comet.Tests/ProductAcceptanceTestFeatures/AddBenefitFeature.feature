Feature: AddBenefitFeature	
This feature file contains all the scenarios related to adding benefit to package

#Purpose:Add a benefit - Process Menu
#Testcase ID:86083
#Product:Comet
#UserStory:Add a benefit - Process Menu
Scenario: Add a benefit - Process Menu	
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "New Benefit" option in Pop up
Then I should be on the "Package Benefit" page	
When I select "PHCNBenefit" in  "Benefit" dropdown 
And I click on "Next" Button
Then I should be on the "Package Benefit - Benefit Details" page
When I select "PHCNBenefit" in  "Budget Calculation Method" dropdown 	
And I Enter Budget Amount for "PHCNBenefit"
And I click on "Save" Button
Then I should be on "FWA Popup" popup
When I Confirm the General PAC information
Then I should be on the "CCEnquiry" page