using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechTalk.SpecFlow;

namespace DigiAssessment.Pages
{
    public abstract class MainPage : IVerifiable
    {
        private WebDriverWait _wait;


        protected MainPage()
        {
            PageFactory.InitElements(Browser.Current, this);
        }
        public void WaitForTitle(string title, TimeSpan? timeout = null)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Current, timeout ?? TimeSpan.FromSeconds(30));
            wait.Until((d) => { return d.Title == title; });
        }

        public abstract void Verify();

        private const int TimeoutSeconds = 30;

        protected WebDriverWait Wait => _wait ?? (_wait = new WebDriverWait(Browser.Current, TimeSpan.FromSeconds(TimeoutSeconds))
        {
            PollingInterval = TimeSpan.FromMilliseconds(10000)
        });


        public static void GoToUrl(string url)
        {
            Browser.Current.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TimeoutSeconds);
            Browser.Current.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By by)
        {
            try
            {
                return Browser.Current.FindElement(@by);
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException($"Cannot Find Element {@by} on the Page");
            }
        }

        public IWebElement WaitForElement(By linkElementSelector)
        {
            var element = Wait.Until(x =>
            {
                try
                {
                    return x.FindElement(linkElementSelector);
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });

            return element;
        }

        public IWebElement WaitForElementToBeClickable(By locator)
        {
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            return Wait.Until(ElementIsClickable(locator));
        }

        public IWebElement WaitForElementToBeClickable(IWebElement element)
        {
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            return Wait.Until(ElementIsClickable(element));
        }

        //public IWebElement WaitForElementToBeEnabled(IWebElement element)
        //{
        //    return Wait.Until(ElementIsEnabled(element));
        //}

        private static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }

        private static Func<IWebDriver, IWebElement> ElementIsClickable(IWebElement element)
        {
            return driver => (element != null && element.Displayed && element.Enabled) ? element : null;
        }

        private static Func<IWebDriver, IWebElement> ElementIsEnabled(IWebElement element)
        {
            return driver => (element != null && element.Enabled) ? element : null;
        }

        public SelectElement WaitForSelectElement(By linkElementSelector)
        {
            var element = Wait.Until(d => new SelectElement(d.FindElement(linkElementSelector)));
            Wait.Until(d => element.Options.Count > 0);
            return element;
        }

        public MainPage WaitForElementToAppear(By selector, int? index = null)
        {
            try
            {
                Wait.Until(x =>
                index.HasValue
                    ? x.FindElements(selector)[index.Value].Displayed
                    : x.FindElement(selector).Displayed);
            }
            catch (Exception)
            {
                var exception = new Exception("Element did not appear");
            }

            return this;
        }

        public List<IWebElement> FindElements(By by)
        {
            return Browser.Current.FindElements(@by).ToList();
        }

        public string PageTitle()
        {
            return Browser.Current.Title;
        }

        public void SelectElementFromSelectList(string elementIdentifier, string itemToSelect)
        {
            WaitForElementToBeClickable(By.Id(elementIdentifier));
            WaitForElementToAppear(By.Id(elementIdentifier));
            var selectElement = WaitForSelectElement(By.Id(elementIdentifier));
            selectElement.SelectByText(itemToSelect);
        }

        public void SelectItemFromSelector(string elementIdentifier, string itemToSelect)
        {
            var selectElement = WaitForSelectElement(By.Id(elementIdentifier));
            selectElement.SelectByText(itemToSelect);
        }

        public void SendTextToIWebElement(IWebElement element, string textToSend)
        {
            WaitForElementToBeClickable(element).Click();
            element.Clear();
            element.SendKeys(textToSend);
        }

        public void SwitchToPopUpWindow()
        {
            Wait.Until(d => Browser.Current.WindowHandles.Count >= 1);
            var currentWindow = Browser.Current.CurrentWindowHandle;
            var windowHandles = Browser.Current.WindowHandles;
            var windows = new ReadOnlyCollection<string>(windowHandles);

            foreach (var window in windows)
            {
                if (window == currentWindow) continue;
                ScenarioContext.Current["secondWindow"] = window;
                Browser.Current.SwitchTo().Window(window);

                try
                {
                    Browser.Current.SwitchTo().Window(window).Manage().Window.Maximize();
                    break;
                }
                catch (UnhandledAlertException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void SwitchBackToPrimaryWindow()
        {
            Browser.Current.SwitchTo().Window(Browser.Current.WindowHandles.First());
        }

        public void ClosePopUpWindow()
        {
            Browser.Current.Quit();
        }

        public void WaitForPageToLoad()
        {
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
            Browser.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void RefreshPage()
        {
            Browser.Current.Navigate().Refresh();
        }

        public void CloseBrowser()
        {
            Browser.Current.Close();
        }

        public bool IsElementPresent(IWebElement by)
        {
            try
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
