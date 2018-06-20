Feature: CallCentreEnquiryFeature
This page contains all the scenarios of search the employee

#Purpose:Searching the employee using the DB
#Testcase ID:128496
#Product:Comet
#UserStory: 
Scenario: Commet user search using Employee Number from DB
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "DB"
And I click on Search button

#Purpose:Searching the employee using the XML
#Testcase ID:128496
#Product:Comet
#UserStory:
Scenario: Comment user search using Employee number from XML
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "XML"
And I click on Search button
Then I should be displayed with employee information of "NewCOMETUser"

#Purpose:Searching the employee using the InMemory
#Testcase ID:128496
#Product:Comet
#UserStory:
Scenario: Comment user search using Employee number from In Memory
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "InMemory"
And I click on Search button
Then I should be displayed with employee information of "NewCOMETUser"