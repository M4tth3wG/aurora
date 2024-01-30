using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace Aurora.Test
{
    public class AuroraViewsTest : IDisposable
    {

        private IWebDriver driver;

        private static int ArchitekturaID = 1;
        private static int AiRID = 2;

        public static Dictionary<string, int> CorrectValuesToTestRRValueCalculatingStandard = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "FizPodst", 100},
            { "ObcPodst", 100}
        };

        public static int CorrectValuesCalculatingStandardExpectedValue = 220;


        public static Dictionary<string, int> CorrectValuesToTestRRValueCalculatingArchitektura = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "FizPodst", 100},
            { "ObcPodst", 100},
            { "EgzRys", 100}
        };

        public static int CorrectValuesCalculatingArchitekturaExpectedValue = 320;


        public List<(Dictionary<string, int>, int, int)> correctValuesToTestRRValuesCalculating = new()
        {
            (CorrectValuesToTestRRValueCalculatingStandard, AiRID, CorrectValuesCalculatingStandardExpectedValue),
            (CorrectValuesToTestRRValueCalculatingArchitektura, ArchitekturaID, CorrectValuesCalculatingArchitekturaExpectedValue)
        };


        public static Dictionary<string, int> IncompleteValuesToTestRRValueCalculatingStandard = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "ObcPodst", 100}
        };
        public static string IncompleteValuesCalculatingStandardExpectedMessage = "Brak podanego przynajmniej jednego wyniku dla przedmiotu (Fizyka).";

        public static Dictionary<string, int> IncompleteValuesToTestRRValueCalculatingArchitektura = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "FizPodst", 100},
            { "ObcPodst", 100}
        };

        public static string IncompleteValuesCalculatingArchitekturaExpectedMessage = "Brak podanego wyniku dla egzaminu z rysunku.";


        public List<(Dictionary<string, int>, int, string)> IncompleteValuesToTestRRValuesCalculating = new()
        {
            (IncompleteValuesToTestRRValueCalculatingStandard, AiRID, IncompleteValuesCalculatingStandardExpectedMessage),
            (IncompleteValuesToTestRRValueCalculatingArchitektura, ArchitekturaID, IncompleteValuesCalculatingArchitekturaExpectedMessage)
        };




        public static Dictionary<string, int> InvalidValuesToTestRRValueCalculatingStandardMoreThan100 = new()
        {
            { "MatPodst", 120},
            { "PolPodst", 100},
            { "ObcPodst", 100},
            { "FizPodst", 100}

        };
        public static string InvalidValueKeyStandardMoreThan100 = "MatPodst";

        public static Dictionary<string, int> InvalidValuesToTestRRValueCalculatingStandardLessThan0 = new()
        {
            { "MatPodst", -10},
            { "PolPodst", 100},
            { "ObcPodst", 100}
        };
        public static string InvalidValueKeyStandardLessThan0 = "MatPodst";


        public static Dictionary<string, int> InvalidValuesToTestRRValueCalculatingArchitekturaLessThan0 = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "FizPodst", 100},
            { "ObcPodst", 100},
            { "EgzRys", -240}
        }; 
        
        public static Dictionary<string, int> InvalidValuesToTestRRValueCalculatingArchitekturaMoreThan660 = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "FizPodst", 100},
            { "ObcPodst", 100},
            { "EgzRys", 1000}
        };
        public static string InvalidValueKeyArchitektura = "EgzRys";


        public static string InvalidValuesExpectedMessageMoreThan100 = "Wartość nie może być większa niż 100.";
        public static string InvalidValuesExpectedMessageMoreThan660 = "Wartość nie może być większa niż 660.";
        public static string InvalidValuesExpectedMessageLessThan0 = "Wartość nie może być mniejsza niż 0.";


        public List<(Dictionary<string, int>, int, string, string)> InvalidValuesToTestRRValuesCalculating = new()
        {
            (InvalidValuesToTestRRValueCalculatingStandardLessThan0, AiRID, InvalidValueKeyStandardLessThan0, InvalidValuesExpectedMessageLessThan0),
            (InvalidValuesToTestRRValueCalculatingStandardMoreThan100, AiRID, InvalidValueKeyStandardMoreThan100, InvalidValuesExpectedMessageMoreThan100), 
            (InvalidValuesToTestRRValueCalculatingArchitekturaLessThan0, ArchitekturaID, InvalidValueKeyArchitektura, InvalidValuesExpectedMessageLessThan0),
            (InvalidValuesToTestRRValueCalculatingArchitekturaMoreThan660, ArchitekturaID, InvalidValueKeyArchitektura, InvalidValuesExpectedMessageMoreThan660)
        };

        public AuroraViewsTest() 
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            //Thread.Sleep(10000);
            driver.Quit();
        }

        [Fact]
        public void CalculatingRRValue_EnteredValidAndRequiredValues_ReturnsPoints()
        {
            foreach (var (values, fieldID, expValue) in correctValuesToTestRRValuesCalculating)
            {
                NavigateToCalculatingRRView(fieldID);
                FillAndSubmitRRCalculating(values);
                var result = FindRRValue();
                Assert.Equal(expValue, result);
            }
        }   
        
        [Fact]
        public void CalculatingRRValue_NotEnteredRequiredValues_ReturnsErrorMessages()
        {
            foreach (var (values, fieldID, expMessage) in IncompleteValuesToTestRRValuesCalculating)
            {
                NavigateToCalculatingRRView(fieldID);
                FillAndSubmitRRCalculating(values);
                var popUpMessage = GetPopUpMessage();
                Assert.Equal(expMessage, popUpMessage);
            }
        } 
        
        [Fact]
        public void CalculatingRRValue_InvalidValues_ReturnsErrorMessages()
        {
            foreach (var (values, fieldID, key, expMessage) in InvalidValuesToTestRRValuesCalculating)
            {
                NavigateToCalculatingRRView(fieldID);
                var validityMessage = FillAndSubmitRRCalculatingWithJSExecutor(values, key);
                GetValidityMessage(key);
                Assert.Equal(expMessage, validityMessage);
            }
        }

        private void LogInAs(string mail, string password) 
        {
            driver.Navigate().GoToUrl("http://m4tth3wg-001-site1.btempurl.com/?fbclid=IwAR2PV55ynjc_7wAmG5TRNNePX4e8twtNvN9Fcrc2Mrm5eJr33EL8xYdOgdM");

            IWebElement signInButton = driver.FindElement(By.Id("login"));

            signInButton.Click();

            IWebElement InputForMail = driver.FindElement(By.Id("Input_Email"));
            IWebElement InputForPassword = driver.FindElement(By.Id("Input_Password"));

            InputForMail.SendKeys(mail);
            InputForPassword.SendKeys(password);

            IWebElement submitBtn = driver.FindElement(By.Id("submitLoginBtn"));

            submitBtn.Click();

        }

        private void NavigateToCalculatingRRView(int kierunekID)
        {
            driver.Navigate().GoToUrl("http://m4tth3wg-001-site1.btempurl.com/OfertaKierunkow");

            var submitBtns = driver.FindElements(By.Id("calculateRRBtn"));

            var targetSubmitBtn = submitBtns.FirstOrDefault(b => b.GetAttribute("data-index") == $"{kierunekID}");

            targetSubmitBtn?.Click();
        }

        private void FillAndSubmitRRCalculating(Dictionary<string, int> InputValues)
        {
            if (InputValues is null) throw new ArgumentNullException(nameof(InputValues));

            foreach (var (key, value) in InputValues) {
                var input = driver.FindElement(By.Id(key));
                input.SendKeys(value.ToString());
            }

            //Thread.Sleep(5000);

            var submitBtn = driver.FindElement(By.Id("wyliczWspolczynnikSubmitButton"));
            submitBtn?.Click();
            //Thread.Sleep(5000);

        }

        private string FillAndSubmitRRCalculatingWithJSExecutor(Dictionary<string, int> InputValues, string invalidValueKey)
        {
            if (InputValues is null) throw new ArgumentNullException(nameof(InputValues));

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string validityMessage = "";
            foreach (var (key, value) in InputValues)
            {
                var input = driver.FindElement(By.Id(key));
                input.SendKeys(value.ToString());

                if (invalidValueKey.Equals(key))
                {
                    validityMessage = (string)jsExecutor.ExecuteScript("return arguments[0].validationMessage;", input);
                }
            }

            //Thread.Sleep(5000);

            var submitBtn = driver.FindElement(By.Id("wyliczWspolczynnikSubmitButton"));
            submitBtn?.Click();
            //Thread.Sleep(5000);

            return validityMessage;
        }

        private int? FindRRValue() 
        {
            var RRValueTxt = driver.FindElement(By.Id("RRValueTxt"));
            if (RRValueTxt != null)
            {
                return Convert.ToInt32(RRValueTxt.Text.Split(" ")[2]);
            }
            return null;
        }

        private string GetPopUpMessage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By modalSelector = By.Id("myModal");
            IWebElement modal = wait.Until(ExpectedConditions.ElementIsVisible(modalSelector));
            IWebElement popUpMsgElement = modal.FindElement(By.Id("popUpMsgTxt"));
            Console.WriteLine(popUpMsgElement.Text);
            return popUpMsgElement.Text;
        }

        private string GetValidityMessage(string key)
        {
            IWebElement inputElement = driver.FindElement(By.Id(key));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].reportValidity();", inputElement);

            // czas na obsłużenie eventu invalid
            Thread.Sleep(1000);

            try
            {
                IWebElement errorElement = driver.FindElement(By.CssSelector(".error-class"));
                string errorMessage = errorElement.Text;

                Console.WriteLine("Error Message: " + errorMessage);
            }
            catch (NoSuchElementException)
            {
                //Console.WriteLine("Brak widocznego błędu po obsłudze eventu invalid.");
            }
            return "";
        }

    }
}
