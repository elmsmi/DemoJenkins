using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartTest
{
    [TestClass]
    public class StartTest
    {
        static IWebDriver _Firefox;
        static IWebDriver _Chrome;
        static IWebDriver _IExplorer;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            _Firefox = new FirefoxDriver();
            _Chrome = new ChromeDriver();
            _IExplorer = new InternetExplorerDriver();
        }

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
