Feature: ActivationFeature
	This  feature file conatins all the Card activation test cases

#Purpose: Activate the card in ROL activation site
#Testcase ID:102195
#Product:ROL
#UserStory:Verify that the customer is able to activate his  both new SP-EML and MEVH card from through Remserv public site (through SMS validation).
Scenario: Card Activation in activation site
Given  I access application URL as "ROLActivation"
Then I should be on "RemServ Online" page
When I run the "Disable" Store proc to handel SMS validation
When I Enter the DOB and Card Activation Code 
And I click on Continue button
When I Enter the SMS and Submit the SMS Code
Then I should be on Benefit selection page
When I select the benefit from the page and activate