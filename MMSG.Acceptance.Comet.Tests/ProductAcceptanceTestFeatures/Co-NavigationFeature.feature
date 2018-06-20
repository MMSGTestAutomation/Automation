Feature: Co-NavigationFeature	
 This feature file conatins all the Co navigation test cases

#Purpose:Conav Navigation
#Testcase ID:86634
#Product:Comet
#UserStory:Conav Navigation - Ensure user can Click the Co-Navigation link within EAMS and ensure it is working as expected
Scenario: Conav Navigation
When I click on "Employee Number" in "CCEnquiry" page
Then I will land on "PROCESSES" page
When I click on "EAMS" option in Pop up
Then I will land on "Maxxia Account Snapin" page
When I click on "MOL Co-Navigation" in "Maxxia Account Snapin" page
Then I will land on "Maxxia Online" window
#And I should display with Dashboard of the user