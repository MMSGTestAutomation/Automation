Feature: Employee_personaldetailsFeature
This feature file contains scenario related to employee creation

#Purpose:Creating the employee 
#Testcase ID:86010
#Product:Comet
#UserStory: Create an employee 
Scenario: Create New Employee as commet user
When I click on "New" in "CCEnquiry" page
Then I should be on "Employee" page
When I enter new "NewCOMETUser" employee details
Then I should be on "Maxxia Account Snapin"
And I should be on the "CCEnquiry" page