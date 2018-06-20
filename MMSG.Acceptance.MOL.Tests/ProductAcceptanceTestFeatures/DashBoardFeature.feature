Feature: DashBoardFeature
This feature file contains scenarios related to MOL Dashboard

#Purpose:Verify the Benefit of of TELC Emoloyee
#Testcase ID:58036
#Product:Comet
#UserStory:Navigate the Dashboard
Scenario: MOL Non Wallet user verifies the Benefits are displayed
Then I should be display with the benefit "Novated Lease"

	
#Purpose:Adding the more benefit to the employee and see the checking the result in the MOL online is more benefit link is present
#Testcase ID:58036
#Product:Comet
#UserStory:Navigate the Dashboard
Scenario: MOL Wallet User see the "Show More Benefit" Message
Then I should be display with the benefit "Show me more benefits ..."

#Purpose:VMS Only customer's login should be successful and he should have a access to the new Maxxia Online solution
#Testcase ID:64146
#Product:Comet
#UserStory: Verify that VMS Only customers are provided a access to new Maxxia Online solution
Scenario:  Verify VMS Only customers are provided a access to new Maxxia Online solution
Then I should be display with the benefit "Novated Lease"


#Purpose:Verify Terminated employeer is not apearing for employee toggle for the Employee having both Active and terminated employeer
#Testcase ID:56115
#Product:Comet
#UserStory:MOL- Customers who have multiple salary packaging accounts, If one of the salary packaging accounts attains terminated status, 
		  #then system not enables them to select the terminated account (by Employer name) in MOL.
Scenario: Verify Employee with terminated Employeer not appeare in toggle drop down
Then I should be "unable" toggle betwwen Employee

#Purpose: Verify the Benefits are mergied in one Employeer
#Testcase ID:56829
#Product:Comet
#UserStory:MOL- Validate that the customers with' Salary Packaging', 'Meal Entertainment' and 'Venue Hire' products are merged into one Employer and no toggle functionality is provided.
Scenario: Verify Employee with Benefits are merged with One Employeer and Not fuctionality
When I should Save benefit from dashboard as "MOLBenefits"
When I click on the link "Your Account"
Then I should be "unable" toggle betwwen Employee
Then I should see Benefit in DropDown as "MOLBenefits"

#Purpose: Employee packaging two or more Novated leases ith same employyer are displaued with single title 
#Testcase ID:58163
#Product:Comet
#UserStory:MOL- Where a customer is packaging two (or more) Novated Leases(FMNL) with same employer, the system displays one 'Novated Lease' benefit tile and all relevant registrations displays within the single tile.
Scenario: : Verify system displays one 'Novated Lease' benefit tile and all relevant registrations displays within the single tile.
Then I should see Novated Lease comma separated values

#Purpose: Employee packaging two or more Novated leases ith same employyer are displaued with single title 
#Testcase ID:58163
#Product:Comet
#UserStory:MOL - Single Novated lease benefit tile with multiple Rego with comma separated is displayed in "Account summary" for employee who is packaging multiple leases with Employer TELSTRA.
Scenario: Single Novated lease benefit tile with multiple Rego with comma separated is displayed in Dashboard for employee who is packaging multiple leases with Employer TELSTRA
Then I should see Novated Lease comma separated values
