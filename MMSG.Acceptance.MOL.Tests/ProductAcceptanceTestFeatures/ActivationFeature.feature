Feature: ActivationFeature
	This feature file conatins the all the Scenario related to Activaion site

#Purpose:Actiavte card from Incative/order to active by activating the card in Activation site
#Testcase ID:102195
#Product:MOL
#UserStory: Verify that the customer is able to activate his  both new SP-EML and MEVH card from through Remserv public site (through SMS validation).
Scenario: Activate the Card
Given I access application URL as "MOLActivation"
Then I should be on "Maxxia Online" page
When I should run Store Poc "Populate Profile" to insert Data to Respective Table
When I run the "Disable" Store proc to handel SMS validation
When I enter 'Date of Birth' and 'Card Activation Code' of "NewCOMETUser"
And I click on Continue button
Then I should be on SMS Authenticate page
When I Enter the SMS and Submit the SMS Code
Then I should be on Benefit selection page
When I select the benefit from the page and activate
When I run the "Enable" Store proc to handel SMS validation