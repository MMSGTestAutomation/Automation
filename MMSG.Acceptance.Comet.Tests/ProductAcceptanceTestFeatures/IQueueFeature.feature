Feature: IQueueFeature
	This Feature file conatins the all the senariso related to IQueue

#Purpose:User create the IQueu, takes the Action and close the Iqueue request
#Testcase ID:86386, 86405, 86399,86389,86396,86394,86395,86418
#Product:Comet
#UserStory: IQ Request List
Scenario: Add the IQueue and close it
When I click on "New Request" in "CCEnquiry" page
Then I should be display with "iQueue" Pop up
When I fill details in "General Tab"
And I fill details in "Attachment"
And I fill details in "Note"
And I Submit the IQueue
Then I should be on the "CCEnquiry" page
When I click on "Request History" in "CCEnquiry" page
Then I should be displayed "Search For Customer Requests "
When I click on the "Close" button