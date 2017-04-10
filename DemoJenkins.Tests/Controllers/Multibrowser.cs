using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Drawing;
using OpenQA.Selenium.Firefox;


namespace DemoJenkins.Tests.Controllers
{
    [TestClass]
    public class Multibrowser
    {
        private IWebDriver _firefox;
        private IWebDriver _chrome;
        private IWebDriver _iexplorer;
        private WebDriverWait wait;
        [TestMethod]
        public void TestFirefoxDriver()
        {
            _firefox = new FirefoxDriver();
            wait = new WebDriverWait(_firefox, TimeSpan.FromSeconds(30));
            _firefox.Navigate().GoToUrl("http://www.goalsystems.com/");
            wait.Until(ExpectedConditions.ElementExists(By.Id("contenedor-21")));
            var pageloaded = _firefox.FindElement(By.Id("contenedor-21")).Text.Contains("Horarios");

            Assert.IsTrue(pageloaded);

            _firefox.Quit();

        }

        [TestMethod]
        public void TestChromeDriver()
        {
            _chrome = new ChromeDriver();
            wait = new WebDriverWait(_chrome, TimeSpan.FromSeconds(30));
            _firefox.Navigate().GoToUrl("http://www.goalsystems.com/");
            wait.Until(ExpectedConditions.ElementExists(By.Id("contenedor-21")));
            var pageloaded = _chrome.FindElement(By.Id("contenedor-21")).Text.Contains("Horarios");

            Assert.IsTrue(pageloaded);

            _chrome.Quit();


        }


        [TestMethod]
        public void TestIEDriver()
        {
            _iexplorer = new InternetExplorerDriver();
            wait = new WebDriverWait(_iexplorer, TimeSpan.FromSeconds(30));
            _iexplorer.Navigate().GoToUrl("http://www.goalsystems.com/");
            wait.Until(ExpectedConditions.ElementExists(By.Id("contenedor-21")));
            var pageloaded = _iexplorer.FindElement(By.Id("contenedor-21")).Text.Contains("Horarios");

            Assert.IsTrue(pageloaded);

            _iexplorer.Quit();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_iexplorer != null)
                _iexplorer.Quit();
            if (_firefox != null)
                _firefox.Quit();
            if (_chrome != null)
                _chrome.Quit();
        }
    }
}
