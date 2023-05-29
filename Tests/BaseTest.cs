using JupiterToysAutomation.Framework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace JupiterToysAutomation.Tests
{
    public class BaseTest
    {
        public IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com/#/home");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }
        
        /*
        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Report.TakeScreenShot(_driver);
            }
            _driver.Close();
            _driver.Quit();

        }
        */
        
        
        

    }
}
