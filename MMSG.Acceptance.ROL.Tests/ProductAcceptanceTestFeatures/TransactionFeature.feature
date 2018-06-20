Feature: TransactionFeature
	This page conatins all the Tansaction related test cases

#Purpose:Checking the transaction by using the filter
#Testcase ID:103510
#Product:ROL
#UserStory:Display Wallet Transactions
Scenario: Display Wallet Transactions - User is able to view the card balance if he has SP Card Only
When I navigate to "Your Account" tab 
Then I should be displayed with "View Account:" dropdown and contains "RemServ Wallet" value
And I should be displayed with "From:" dropdown and contains "Living Expenses (RemServ Wallet)" value
And I should be displayed with Available Balance

#Purpose:Checking the transactionusing for 30 days,60 days and using advances filter
#Testcase ID:77009
#Product:ROL
#UserStory:ROL - Verify that the user is able to change the selection parameter on the "Transactions" screen from default 30 Days to either 7 Days or 60 Days or choose Transaction type and date range from Advanced Filter.
Scenario: Verify that the user is able to change the selection parameter in Transaction screen to 7 days,60,days and advances filter
When I navigate to "Your Account" tab
Then I should be on "Transactions" page of ROL
Then I should be on "30days" Tab
When I click on "7days" tab
Then I should be on "7days" Tab
When I click on "60days" tab
Then I should be on "60days" Tab
When I click on "Advances filter" tab
Then I should be on "Advances filter" Tab
When I click on "From" date picker and pick "2" month back transaction
And I click on "To" date picker and pick todays date
And I click on "Submit" Button in Tansaction page

 
