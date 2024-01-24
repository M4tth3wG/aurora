using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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


            driver.Navigate().GoToUrl("http://m4tth3wg-001-site1.btempurl.com/OfertaKierunkow");

            IWebElement submitBtn = driver.FindElement(By.Id("calculateRRBtn"));

            submitBtn.Click();

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

            //IWebElement loginButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            //loginButton.Click();


        }

    }
}
