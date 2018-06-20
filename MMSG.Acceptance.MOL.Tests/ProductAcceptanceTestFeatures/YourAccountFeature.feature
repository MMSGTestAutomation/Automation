Feature: YourAccountFeature	
This feature file contains all the scenario related to your account page

#Purpose:Checking the transaction of Non Wallet user
#Testcase ID:64692
#Product:MOL
#UserStory:	MOL -Correct transactions displayed in "PD&T" screen for employee who is packaging multiple leases with Employer TELC.
Scenario: MOL User  with No Wallet View the transaction
When I click on the link "View payroll deductions & transfers"
Then I should be display with page name "Payroll Deductions & Transfers"
When I click on the tab "Advanced Filter"
Then  I should see Transaction

#Purpose: Navigate to the Payroll Deductions & Transfers under Your accounts tab
#Testcase ID:56762
#Product:MOL
#UserStory:	MOL- The customer able to navigates to their income/payroll deduction and benefit funds transfer details from the Account Summary dashboard by selecting the sub menu "Payroll deductions & transfers" under "My Account" menu.
Scenario: MOL Navigate to Payroll Deductions & Transfers tab under Accounts Tab
When I click on the link "Your Account"
Then I should be on "Transactions" url of "Maxxia Online"Page
When I click on the link "Payroll Deductions & Transfers"
Then I should be on "PayrollDeductionsAndTransfers" url of "Maxxia Online"Page
And I should see  default "30Days" tab active