Feature: RegistrationMOL
This feature file contain all the scenarios related to mol user regestration

#Purpose: To check the Error message in the Registation page 
#Testcase ID: 55031
#Product:MOL
#UserStory: Validate the error handling functionality in Registration page.
Scenario: Validate the error handling functionality in Registration page
Given I access application URL as "MOLUser"	
When I click on Button "Register now"
When I enter "Invalid" email
And I click on Button "Submit" in Register page
Then I should be dispalyed with "Invalid"
When I enter "Empty Email" email
And I click on Button "Submit" in Register page
Then I should be dispalyed with "Empty Email"
When I enter "Unregistered" email
And I click on Button "Submit" in Register page
Then I should be dispalyed with "Unregistered"