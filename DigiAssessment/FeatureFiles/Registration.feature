Feature: Registration
	As an end user, I want to navigate to the betway website and register as a new user.

Background: Pre-Condition
 Given I have navigated to the betway website

@registration
Scenario: Complete registration form
	Given I clicked the Sign Up button
	And The Register An Account window is displayed
	And I capture a valid cellphone number "606988511"
	And I enter password "Testuser566123"
	And I enter First Name "Sharon Amy"
	And I enter surname "Madihlaba"
	And I enter email "sharonm@test.com"
	And I click the Next button
	Then The Register  An Account page 2 should be displayed

	Then I select "South African ID" in the ID type list
	And I enter a valid SA Id number "7701014800086"
	And I select "01" in the Date of Birth Day select list
	And I select "01" in the Date of Birth Month select list
	And I select "1977" in the Date of Birth Year select list
	And I select "Self Employed" in the Source of funds select list
	And I select "Sotho" in the Language select list
	And I select the Terms and Conditions checkbox

	Then I close the browser

