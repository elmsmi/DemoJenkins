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

        [TestMethod]
        public void TestFirefoxDriver()
        {
            _firefox = new FirefoxDriver();
            _firefox.Navigate().GoToUrl("http://www.google.com");
            _firefox.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            _firefox.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            _firefox.Quit();

        }

        [TestMethod]
        public void TestChromeDriver()
        {
            _chrome = new ChromeDriver();
            _chrome.Navigate().GoToUrl("http://www.google.com");
            _chrome.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            _chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            _chrome.Quit();

        }


        [TestMethod]
        public void TestIEDriver()
        {
            _iexplorer = new InternetExplorerDriver();
            _iexplorer.Navigate().GoToUrl("http://www.google.com");
            _iexplorer.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            _iexplorer.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
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
