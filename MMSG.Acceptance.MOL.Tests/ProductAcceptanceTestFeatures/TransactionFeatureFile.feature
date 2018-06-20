 Feature: TransactionFeatureFile
This feature file contains all the scenario related to MOL transaction

#Purpose:Checking the Wallet transaction of the MOl appliction
#Testcase ID:103510
#Product:Comet
#UserStory:Display Wallet Transactions
Scenario: Display Wallet Transactions - Verify that Transactions is displayed in the MOL My Account for SP Card Only
When I navigate to "Your Account" tab 
Then I should be displayed with "Select benefit:" dropdown
When I select "Maxxia Wallet" in the dropdown "Select benefit:"
Then I should be displayed with "From:" dropdown
When I select "Living Expense Wallet" in the dropdown "From:"
Then I should be displayed with Available Balance
Then I should see Transaction

