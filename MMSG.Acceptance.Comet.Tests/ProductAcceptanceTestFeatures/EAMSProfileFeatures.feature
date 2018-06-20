Feature: EAMSProfileFeatures
This feature file contains all the scenario related to EAMS profile
	
#Purpose: Verify the EAMS profile for the TELC Employee
#Testcase ID:86329,86329
#Product:Comet
#UserStory: EAMS Profile
Scenario: Verify the EAMS profile for the TELC Employee	
Then I should Save the "EmployeeName" in "TELCEmployee"
When I click on "Employee Number" in "CCEnquiry" page
Then I will land on "PROCESSES" page
When I click on "EAMS" option in Pop up
Then I will land on "Maxxia Account Snapin" page
And I should display with the MOL UserName not Empty
And I should be Display with systems name and Employee name which is been validated with VMS as "TELCEmployee"
When I click on "cancel" button in "Maxxia Account Snapin" popup
Then I should be on the "CCEnquiry" page

#Purpose:Verify the VMS balances is been verified with the DB
#Testcase ID:86333
#Product:Comet
#UserStory:  EAMS Profile
Scenario: Verify the page VMS balance is matching with the DB	
When I enter "Random" Employee number from "TELC" Employeer 
And I click on Search button
Then I should display Tree view structure
Then I Compare the the VMS value with the DB
	
#Purpose:Verify the Link and de link are working
#Testcase ID:86331
#Product:Comet
#UserStory: EAMS Profile
Scenario: Verify the Link and Delink working as expected	
Given  I access application URL as "COMETUser"
Then I should be displayed with Comet logo
And I should be on the "CCEnquiry" page
When I enter "Random" Employee number from "TELC" Employeer 
And I click on Search button
When I click on employee number	
When I Select EAMS option
Then I will land on EAMS screen
When I click on the Link or Delink	
Then I should display with Link or Delink Button
When I click on "cancel" button in "Maxxia Account Snapin" popup
Then I should be on the "CCEnquiry" page
		
#Purpose: Verify the EAMS Profile is been created for newly created Employee
#Testcase ID: 86329
#Product:Comet
#UserStory:  EAMS Profile
Scenario: Verify EAMS account generation for newly created employee
When I click on "Employee Number" in "CCEnquiry" page
Then I will land on "PROCESSES" page
When I click on "EAMS" option in Pop up
Then I will land on "Maxxia Account Snapin" page 
And I should be 'EAMS' ID for newly created employee "NewCOMETUser"
When I click on "cancel" button in "Maxxia Account Snapin" popup
Then I should be on the "CCEnquiry" page