using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Configuration;
using System.Threading;

namespace DigiAssessment.Pages
{
    public class RegistrationPage : MainPage
    {
        private const string MainPageTitle = "Place your bets | - Betway";

        [FindsBy(How = How.Id, Using = "SignUp")]
        public IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.Id, Using = "MobileNumber_tmpl")]
        public IWebElement MobileNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Password_tmpl")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName_tmpl")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName_tmpl")]
        public IWebElement Surname { get; set; }

        [FindsBy(How = How.Id, Using = "Email_tmpl")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "nxtBtn")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.Id, Using = "IDType_tmpl")]
        public IWebElement IdType { get; set; }

        [FindsBy(How = How.Id, Using = "IDNumber_tmpl")]
        public IWebElement IdNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Template_TemplateFieldModels_13__Value_Day")]
        public IWebElement BirthDay { get; set; }

        [FindsBy(How = How.Id, Using = "Template_TemplateFieldModels_13__Value_Month")]
        public IWebElement BirthMonth { get; set; }

        [FindsBy(How = How.Id, Using = "Template_TemplateFieldModels_13__Value_Year")]
        public IWebElement BirthYear { get; set; }

        [FindsBy(How = How.Id, Using = "SourceOfFunds_tmpl")]
        public IWebElement SourceOfFunds { get; set; }

        [FindsBy(How = How.Id, Using = "BrandLanguageId_tmpl")]
        public IWebElement Language { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmAge_tmpl")]
        public IWebElement AgeConfirmation { get; set; }

        [FindsBy(How = How.Id, Using = "desktopReg")]
        public IWebElement RegistrationWindow { get; set; }

        [FindsBy(How = How.Id, Using = "SU-Close")]
        public IWebElement PopupWindow { get; set; }


        public void GoToBetwayHomePage()
        {
            var url = ConfigurationManager.AppSettings["Url"];
            GoToUrl(url);
        }

        public void ClickedTheSignUpButton()
        {
            WaitForPageToLoad();

            Thread.Sleep(30);
            SwitchToPopUpWindow();
            ClosePopUpWindow();
            //Browser.Current.SwitchTo().Window(Browser.Current.WindowHandles.Last()).Close();
            //SwitchBackToPrimaryWindow();
            SignUpButton.Click();
        }

        public void VerifyWindowDisplayed()
        {
            IsElementPresent(RegistrationWindow);

        }

        public void CaptureAValidCellphoneNumber( string phoneNumber)
        {
            SendTextToIWebElement(MobileNumber, phoneNumber);
        }

        public void EnterPassword(string password)
        {
            SendTextToIWebElement(Password, password);
        }

        public void EnterFirstName(string firstName)
        {
            SendTextToIWebElement(FirstName, firstName);
        }

        public void EnterSurname(string surname)
        {
            SendTextToIWebElement(Surname, surname);
        }

        public void EnterEmail(string email)
        {
            SendTextToIWebElement(Email, email);
        }

        public void ClickTheNextButton()
        {
            NextButton.Click();
        }

        public void VerifySecondRegistrationWindowDisplayed()
        {
            IsElementPresent(RegistrationWindow);
        }

        public void SelectIdType(string idType)
        {
            SelectElementFromSelectList(IdNumber.Text, idType);
        }

        public void EnterIdNumber(string id)
        {
            SendTextToIWebElement(IdNumber, id);
        }

        public void SelectBirthDay(int birthDay)
        {
            SelectElementFromSelectList(birthDay.ToString(), birthDay.ToString());
        }

        public void SelectBirthMonth(int birthMonth)
        {
            SelectElementFromSelectList(BirthMonth.Text, birthMonth.ToString());
        }

        public void SelectBirthYear(int birthYear)
        {
            SelectElementFromSelectList(BirthYear.Text, birthYear.ToString());
        }

        public void SelectSourceOfFunds(string source)
        {
            SelectElementFromSelectList(SourceOfFunds.Text, source);
        }

        public void SelectLanguage(string language)
        {
            SelectElementFromSelectList(Language.Text, language);
        }

        public void SelectTermsAndConditions()
        {
            AgeConfirmation.Click();
        }

        public void CloseBrowser()
        {
            Browser.Current.Quit();
        }
        public override void Verify()
        {
        }
    }
}
