using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using Xunit;

namespace AuroraTestAdrian
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
            throw new NotImplementedException();
        }

        [Fact]

        public void Test() 
        {

            driver.Navigate().GoToUrl("http://m4tth3wg-001-site1.btempurl.com/?fbclid=IwAR2PV55ynjc_7wAmG5TRNNePX4e8twtNvN9Fcrc2Mrm5eJr33EL8xYdOgdM");

            IWebElement signInButton = driver.FindElement(By.Id("login"));

            signInButton.Click();

            IWebElement InputForMail = driver.FindElement(By.Id("Input_Email"));
            IWebElement InputForPassword = driver.FindElement(By.Id("Input_Password"));

            InputForMail.SendKeys("anna.nowak@example.com");
            InputForPassword.SendKeys("haslo");

            IWebElement form = driver.FindElement(By.Id("account"));
            IWebElement submitBtn = form.FindElement(By.CssSelector("input[type='submit']"));

            submitBtn.Click();
        }

    }
}
