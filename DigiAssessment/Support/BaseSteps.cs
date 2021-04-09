using TechTalk.SpecFlow;

namespace DigiAssessment.Pages
{
    public class BaseSteps : Steps
    {
        protected static T On<T>() where T : IVerifiable, new()
        {
            var page = new T();
            page.Verify();
            return page;
        }
    }
}
