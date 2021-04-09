using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiAssessment.Pages
{
    public class GoogleNewsPage : MainPage
    {
        private const string MainPageTitle = "Google News";

        public void GoToGoogleNewsWebsite()
        {
            var url = ConfigurationManager.AppSettings["GoogleUrl"];
            GoToUrl(url);
        }

        public void VerifyThatTheHeadlinesAreDisplayed()
        {
            WaitForTitle(MainPageTitle);
        }

        public void PrintOutAllTheHeadlinesDisplayed()
        {
            var result = FindElements(By.TagName("article")).ToList();

            var sb = new StringBuilder();
            foreach (var item in result)
            {
                sb.Append(item.Text);
            }
            // Folder location
            var directory = @"C://Textfile" + DateTime.Now.ToShortDateString();

            // If the folder doesn't exist, create it
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Creates a file copiedtext.txt with all the contents on the page.
            File.AppendAllText(Path.Combine(directory, "Copiedtext.txt"), sb.ToString());
        }
        public override void Verify()
        {
        }
    }
}
