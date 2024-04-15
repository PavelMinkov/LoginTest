using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LoginTest
{
    [TestFixture]
    public class LoginAutomationTest
    {

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var chromeDriverPath = "path of driver";
            driver = new ChromeDriver(chromeDriverPath);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://qa.sorted.com/nextrack");
        }

        [Test]
        public void LoginTest()
        {

            driver.FindElement(By.Id("email")).SendKeys("johnsmith@sorted.com");
            driver.FindElement(By.Id("password")).SendKeys("Pa55w0rd!");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url.Contains("loginsuccess"));

            var expectedURL = "http://qa.sorted.com/nextrack/loginsuccess";
            var actualUrl = driver.Url;
            Assert.That(expectedURL, Is.EqualTo(actualUrl));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}