Feature: GoogleNews
	Print out all the headlines displayed on the webpage

@googlenews
Scenario: Print out headlines
	Given I have navigated to the google news website
	And I verify that the headlines are displayed
	Then I print out all the headlines displayed
	Then I close the browser