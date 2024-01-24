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

        public static Dictionary<string, int> CorrectValuesToTestRRValueCalculatingMed = new()
        {
            { "MatPodst", 100},
            { "PolPodst", 100},
            { "FizPodst", 100},
            { "BioRoz", 50},
            { "ObcPodst", 100}
        };

        public static int CorrectValuesCalculatingMedExpectedValue = 360;


        public List<(Dictionary<string, int>, int, int)> correctValuesToTestRRValuesCalculating = new()
        {
            (CorrectValuesToTestRRValueCalculatingStandard, AiRID, CorrectValuesCalculatingStandardExpectedValue),
            (CorrectValuesToTestRRValueCalculatingArchitektura, ArchitekturaID, CorrectValuesCalculatingArchitekturaExpectedValue)
            //(CorrectValuesToTestRRValueCalculatingMed, LekarskiID, CorrectValuesCalculatingMedExpectedValue)

        };

        public AuroraViewsTest() 
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Thread.Sleep(15000);
            driver.Quit();
        }

        [Fact]

        public void Test()
        {

            //LogInAs("anna.nowak@example.com", "pracownik");

            foreach (var (values, fieldID, expValue) in correctValuesToTestRRValuesCalculating)
            {
                NavigateToCalculatingRRView(fieldID);
                TestRRValueCalculating(values);
                var result = FindRRValue();
                Assert.Equal(expValue, result);
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

        private void TestRRValueCalculating(Dictionary<string, int> InputValues)
        {
            if (InputValues is null) throw new ArgumentNullException(nameof(InputValues));

            foreach (var (key, value) in InputValues) {
                var input = driver.FindElement(By.Id(key));
                input.SendKeys(value.ToString());
            }

            Thread.Sleep(5000);

            var submitBtn = driver.FindElement(By.Id("wyliczWspolczynnikSubmitButton"));
            submitBtn?.Click();
            Thread.Sleep(5000);

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

    }
}
