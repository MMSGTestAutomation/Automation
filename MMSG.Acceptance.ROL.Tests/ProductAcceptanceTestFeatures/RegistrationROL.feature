Feature: RegistrationROL
	This feature file is related to the Registarion page ROl

#Purpose: Verify the Error message in the registation Page
#Testcase ID:55031
#Product:ROL
#UserStory:Registration
Scenario: Validate the error handling functionality of ROL
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