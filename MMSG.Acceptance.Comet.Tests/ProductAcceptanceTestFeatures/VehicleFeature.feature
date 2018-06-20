Feature: VehicleFeature
	This file contains all the test cases whcih are related to the Vechical lease.

#Purpose: Adding the the Vechical to the Employee
#Testcase ID:86109
#Product:Comet
#UserStory:PVT - Vehicle - Ensure user can create a new vehicle
Scenario: Ensure user can create a new vehicle
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "New Vehicle" option in Pop up
Then I should be on the "Motor Vehicle-Registrations" page
Then I should verify Elements are present in"Motor Vehicle-Registrations"
When I Enter all the Details in Motor Vehicle-Registrations page
Then I should be on the "Motor Vehicle-Base Details" page
Then I should verify Elements are present in"Motor Vehicle-Base Details"
When I enter all the details in Motor Vehicle-Base Details
Then I should be on the "Motor Vehicle-Accessories" page
Then I should verify Elements are present in"Motor Vehicle-Accessories"
When I enter all the details in Motor Vehicle-Accessories page
Then I should be on the "Motor Vehicle-Amounts" page
Then I should verify Elements are present in"Motor Vehicle-Amounts"
When I click on the Next button in Amount Page
Then I should be on the "Motor Vehicle-Fuel Cards" page
Then I should verify Elements are present in"Motor Vehicle-Fuel Card"
When I enter all the details of Fuel Card 
Then I should be on the "CCEnquiry" page

#Purpose: Edit the Existing car vehicle 
#Testcase ID:86110
#Product:Comet
#UserStory:PVT - Vehicle - Ensure user can edit and save an existing vehicle
Scenario: Ensure user can edit and save an existing vehicle
When I click on the Search in Vechicle menu
Then I should be on the "Motor Vehicle" page
When I Search Vehicle using "Registration Number" feild 
Then I will land on "PROCESSES" page
When I click on "Edit Vehicle" option in Pop up of Vehicle Search Page
Then I should be on the "Motor Vehicle-Registrations" page
Then I should verify Elements are present in"Motor Vehicle-Registrations"
When I click on next Button in "Motor Vehicle-Registrations" Page
Then I should be on the "Motor Vehicle-Base Details" page
Then I should verify Elements are present in"Motor Vehicle-Base Details"
When I Change "Colour" in "Motor Vehicle-Base Details" Page
When I click on next Button in "Motor Vehicle-Base Details" Page
Then I should be on the "Motor Vehicle-Accessories" page
Then I should verify Elements are present in"Motor Vehicle-Accessories"
When I click on next Button in "Motor Vehicle-Accessories" Page
Then I should be on the "Motor Vehicle-Amounts" page
Then I should verify Elements are present in"Motor Vehicle-Amounts"
When I click on next Button in "Motor Vehicle-Amounts" Page
Then I should be on the "Motor Vehicle-Fuel Cards" page
Then I should verify Elements are present in"Motor Vehicle-Fuel Cards"
When I click on next Button in "Motor Vehicle-Fuel Cards" Page
Then I should be on the "CCEnquiry" page
