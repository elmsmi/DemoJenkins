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

namespace StartTest
{
    [TestClass]
    public class StartTest
    {


        private readonly IWebDriver _Firefox = new FirefoxDriver();
        private readonly IWebDriver _Chrome = new ChromeDriver();
        private readonly IWebDriver _IExplorer = new InternetExplorerDriver();

        [TestMethod]
        public void TestFirefoxDriver()
        {
            _Firefox.Navigate().GoToUrl("http://www.google.com");
            _Firefox.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            _Firefox.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestChromeDriver()
        {
            _Chrome.Navigate().GoToUrl("http://www.google.com");
            _Chrome.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            _Chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }


        [TestMethod]
        public void TestIEDriver()
        {
            _IExplorer.Navigate().GoToUrl("http://www.google.com");
            _IExplorer.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            _IExplorer.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_Chrome != null)
                _Chrome.Quit();
            if (_Firefox != null)
                _Firefox.Quit();
            if (_IExplorer != null)
                _IExplorer.Quit();
        }
    }
}
