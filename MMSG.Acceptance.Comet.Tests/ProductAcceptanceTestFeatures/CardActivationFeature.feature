Feature: CardActivationFeature
	This feature file conatins Card status changes Scenario

#Purpose:Change the Card Status from Order Pending to Order / Incative status
#Testcase ID:102195
#Product:Comet
#UserStory:  Card Activation
Scenario: Change order pending state of card to ordered			
When I click on "Card Screen" in "CCEnquiry" page
Then I should dispalay with Maxxia Wallet Page
And I should be display with Card status as "Order Pending"
When I run OrderCard Batch using Power Shell script
Then I should be display with Card status as "Inactive"
When I click on cancel button
Then I should be on the "CCEnquiry" page

#Purpose:Actiavte card from Incative/order to active by activating the card in Activation site
#Testcase ID:102195
#Product:MOL
#UserStory: Verify that the customer is able to activate his  both new SP-EML and MEVH card from through Remserv public site (through SMS validation).
Scenario: Activate the Card
Given I launch application URL as "MOLActivation"
Then I should be on page "Maxxia Online" 
When I should run Store Poc "Populate Profile" to insert Data to Respective Table
When I run the "Disable" Store proc to handel SMS validation
When I enter 'Date of Birth' and 'Card Activation Code' of "NewCOMETUser" in "MOL" application
And I click on Continue button
Then I should be on SMS Authenticate page
When I Enter the SMS and Submit the SMS Code
Then I should be on Benefit selection page
When I select the benefit from the page and activate
#Then I should be on success page
#And I should see congragulation Message
When I run the "Enable" Store proc to handel SMS validation