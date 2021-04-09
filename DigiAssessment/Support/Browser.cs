using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace DigiAssessment.Pages
{
    [Binding]
    public class Browser
    {
        public static IWebDriver Current
        {
            get
            {
                var browserInUse = BrowserInUse;

                if (IsBrowserOpen) return (IWebDriver)ScenarioContext.Current["browser"];
                var selectedBrowser = browserInUse;
                SelectBrowser(selectedBrowser);
                return (IWebDriver)ScenarioContext.Current["browser"];
            }
        }

        private static string BrowserInUse
        {
            get
            {
                var testContext = ScenarioContext.Current.ScenarioContainer.Resolve<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>();
                string browserInUse = String.IsNullOrEmpty((testContext.Properties["browserInUse"] ?? "").ToString()) ? ConfigurationManager.AppSettings["browserInUse"] : testContext.Properties["browserInUse"].ToString();
                return browserInUse;
            }
        }

        private static void SelectBrowser(string selectedBrowser)
        {
            switch (selectedBrowser)
            {
                case "IE":
                    {
                        var options = new InternetExplorerOptions
                        {
                            IgnoreZoomLevel = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = false
                        };
                        ScenarioContext.Current["browser"] = new InternetExplorerDriver(options);
                    }
                    break;

                case "Firefox":
                    ScenarioContext.Current["browser"] = new FirefoxDriver();
                    break;
                case "Chrome":
                    {
                        var options = new ChromeOptions();
                        options.AddArguments("start-maximized");
                        options.AddArgument("disable-extensions");
                        ScenarioContext.Current["browser"] = new ChromeDriver(options);
                    }
                    break;

                default:
                    throw new NotSupportedException("Browser " + selectedBrowser + "not supported");
            }
            Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Browser.Current.Manage().Window.Maximize();
        }

        [AfterScenario]
        public static void CleanUpAfterFeature()
        {
            if (IsBrowserOpen)
                Current.Quit();
        }

        public static bool IsBrowserOpen => ScenarioContext.Current.ContainsKey("browser");

        //public static string ToPath(string s)
        //{
        //    var builder = new StringBuilder(s);
        //    foreach (var invalidChar in Path.GetInvalidFileNameChars())
        //    {
        //        builder.Replace(invalidChar.ToString(), "");
        //    }
        //    builder.Replace(' ', '_');
        //    return builder.ToString();
        //}
    }
}

