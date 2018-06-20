Feature: PaymentInstructionFeatures
		Payment instruction is be created to the Benifit by adding the Payee type 

#Purpose:Creating Payment Instruction
#Testcase ID:86086
#Product:Comet
#UserStory: Adding Payment Instruction to the benefit
Scenario: Create Payment Instruction to the benefit
When I click on "Benefit" in "CCEnquiry" page
Then I should be display with the Benefit Grid
When I click on the Benefit in benefit grid
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Edit Payment Instructions" option in Pop up
Then I should see "Edit Payment Instructions Benefit" as title in Payment Instruction Page 
When I should fill the all the details for payment type "Adhoc" and Payment Frequency "AdHoc"
Then I should be on the "CCEnquiry" page

#Purpose:View the payment intstruction
#Testcase ID:86086
#Product:Comet
#UserStory: Adding Payment Instruction to the benefit
Scenario: View the payment instruction and the Click on the cancel button
When I click on "Benefit" in "CCEnquiry" page
Then I should be display with the Benefit Grid
When I click on the Benefit in benefit grid
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "View Payment Instructions" option in Pop up
Then I should see "View Payment Instructions Benefit" as title in Payment Instruction Page 
When I click on the Cancel Button on the Edit Payment Instruction page
Then I should be on the "CCEnquiry" page