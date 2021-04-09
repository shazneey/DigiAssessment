using DigiAssessment.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DigiAssessment.StepDefinitions
{
    [Binding]
    public sealed class RegistrationSteps : BaseSteps
    {
        [Given(@"I have navigated to the betway website")]
        public void GivenIHaveNavigatedToTheBetwayWebsite()
        {
            On<RegistrationPage>().GoToBetwayHomePage();
        }

        [Given(@"I clicked the Sign Up button")]
        public void GivenIClickedTheSignUpButton()
        {
            On<RegistrationPage>().ClickedTheSignUpButton();
        }

        [Given(@"The Register An Account window is displayed")]
        public void GivenTheRegisterAnAccountWindowIsDisplayed()
        {
            On<RegistrationPage>().VerifyWindowDisplayed();
        }

        [Given(@"I capture a valid cellphone number ""(.*)""")]
        public void GivenICaptureAValidCellphoneNumber(string phonenumber)
        {
            On<RegistrationPage>().CaptureAValidCellphoneNumber(phonenumber);
        }

        [Given(@"I enter password ""(.*)""")]
        public void GivenIEnterPassword(string password)
        {
            On<RegistrationPage>().EnterPassword(password);
        }

        [Given(@"I enter First Name ""(.*)""")]
        public void GivenIEnterFirstName(string firstName)
        {
            On<RegistrationPage>().EnterFirstName(firstName);
        }

        [Given(@"I enter surname ""(.*)""")]
        public void GivenIEnterSurname(string surname)
        {
            On<RegistrationPage>().EnterSurname(surname);
        }

        [Given(@"I enter email ""(.*)""")]
        public void GivenIEnterEmail(string email)
        {
            On<RegistrationPage>().EnterEmail(email);
        }

        [Given(@"I click the Next button")]
        public void GivenIClickTheNextButton()
        {
            On<RegistrationPage>().ClickTheNextButton();
        }

        [Then(@"The Register  An Account page (.*) should be displayed")]
        public void ThenTheRegisterAnAccountPageShouldBeDisplayed(int p0)
        {
            On<RegistrationPage>().VerifySecondRegistrationWindowDisplayed();
        }

        [Then(@"I select ""(.*)"" in the ID type list")]
        public void ThenISelectInTheIDTypeList(string idType)
        {
            On<RegistrationPage>().SelectIdType(idType);
        }

        [Then(@"I enter a valid SA Id number ""(.*)""")]
        public void ThenIEnterAValidSAIdNumber(string idNumber)
        {
            On<RegistrationPage>().EnterIdNumber(idNumber);
        }

        [Then(@"I select ""(.*)"" in the Date of Birth Day select list")]
        public void ThenISelectInTheDateOfBirthDaySelectList(int birthDay)
        {
            On<RegistrationPage>().SelectBirthDay(birthDay);
        }

        [Then(@"I select ""(.*)"" in the Date of Birth Month select list")]
        public void ThenISelectInTheDateOfBirthMonthSelectList(int birthMonth)
        {
            On<RegistrationPage>().SelectBirthMonth(birthMonth);
        }

        [Then(@"I select ""(.*)"" in the Date of Birth Year select list")]
        public void ThenISelectInTheDateOfBirthYearSelectList(int birthYear)
        {
            On<RegistrationPage>().SelectBirthYear(birthYear);
        }

        [Then(@"I select ""(.*)"" in the Source of funds select list")]
        public void ThenISelectInTheSourceOfFundsSelectList(string source)
        {
            On<RegistrationPage>().SelectSourceOfFunds(source);
        }

        [Then(@"I select ""(.*)"" in the Language select list")]
        public void ThenISelectInTheLanguageSelectList(string language)
        {
            On<RegistrationPage>().SelectLanguage(language);
        }

        [Then(@"I select the Terms and Conditions checkbox")]
        public void ThenISelectTheTermsAndConditionsCheckbox()
        {
            On<RegistrationPage>().SelectTermsAndConditions();
        }

        [Then(@"I close the browser")]
        public void ThenICloseTheBrowser()
        {
            On<RegistrationPage>().CloseBrowser();
        }

    }
}
