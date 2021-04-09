using DigiAssessment.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DigiAssessment.StepDefinitions
{
    [Binding]
    public sealed class GoogleNewsSteps : BaseSteps
    {
        [Given(@"I have navigated to the google news website")]
        public void GivenIHaveNavigatedToTheGoogleNewsWebsite()
        {
            On<GoogleNewsPage>().GoToGoogleNewsWebsite();
        }

        [Given(@"I verify that the headlines are displayed")]
        public void GivenIVerifyThatTheHeadlinesAreDisplayed()
        {
            On<GoogleNewsPage>().VerifyThatTheHeadlinesAreDisplayed();
        }

        [Then(@"I print out all the headlines displayed")]
        public void ThenIPrintOutAllTheHeadlinesDisplayed()
        {
            On<GoogleNewsPage>().PrintOutAllTheHeadlinesDisplayed();
        }

    }
}
