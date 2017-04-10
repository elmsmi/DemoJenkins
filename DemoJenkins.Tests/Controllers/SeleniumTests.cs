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
    public class SeleniumTests
    {
        private readonly IWebDriver _firefox = new FirefoxDriver();
        private readonly IWebDriver _chrome = new ChromeDriver();
        private readonly IWebDriver _iexplorer = new InternetExplorerDriver();

        private string email = string.Join("", Guid.NewGuid().ToString().Take(6)) + "@gmail.com";
        private string password = "Ab*?" + string.Join("", Guid.NewGuid().ToString().Take(6));
        private string item = "Item_" + string.Join("", Guid.NewGuid().ToString().Take(6));

        [TestMethod]
        public void Can_Create_Account_And_Login()
        {
            CreateUser(_firefox, email, password);
            LogOutUser(_firefox);
            LoginUser(_firefox, email, password);
            LogOutUser(_firefox);
        }
        [TestMethod]
        public void Can_add_Item()
        {
            AddItem(_firefox, item);
        }

        [TestMethod]
        public void Can_Remove_Item()
        {
            RemoveItem(_firefox, item);
        }

        [TestMethod]
        public void Can_Edit_Item()
        {
            EditItem(_firefox, item);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_chrome != null)
                _chrome.Quit();
            if (_firefox != null)
                _firefox.Quit();
            if (_chrome != null)
                _chrome.Quit();
        }

        private void CreateUser(IWebDriver driver, string email, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://localhost/DemoJenkins/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("registerLink")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("loggedin")));
            var userWasCreated = driver.FindElement(By.Id("loggedin")).Text.Contains(email);

            Assert.IsTrue(userWasCreated);
        }

        private void LoginUser(IWebDriver driver, string email, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://localhost/DemoJenkins/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("loginLink")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("Email")));
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("loggedin")));
            var userWasCreated = driver.FindElement(By.Id("loggedin")).Text.Contains(email);
            Assert.IsTrue(userWasCreated);
        }

        private void LogOutUser(IWebDriver driver)
        {
            driver.FindElement(By.Id("logoutForm")).Submit();
        }

        private void AddItem(IWebDriver driver, string item)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://localhost/DemoJenkins/Items");
            driver.Manage().Window.Maximize();
            driver.Manage().Window.Size = new Size(480, 320);
            driver.FindElement(By.Id("Create")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("ItemName")));
            driver.FindElement(By.Id("ItemName")).SendKeys(item);
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("Create")));
            Assert.IsTrue(driver.FindElement(By.ClassName("table")).Text.C‌​ontains(item));
        }

        public void RemoveItem(IWebDriver driver, string item)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://localhost/DemoJenkins/Items");
            driver.FindElement(By.PartialLinkText("Delete")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".btn.btn-default")));
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("Create")));
            Assert.IsTrue(driver.FindElement(By.Id("Create")).Text.C‌​ontains("Add"));

        }

        public void EditItem(IWebDriver driver, string item)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            driver.Navigate().GoToUrl("http://localhost/DemoJenkins/Items");
            driver.FindElement(By.PartialLinkText("Edit")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("ItemName")));
            driver.FindElement(By.Id("ItemName")).Clear();
            driver.FindElement(By.Id("ItemName")).SendKeys(item+"_Edited");
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("Create")));
            Assert.IsTrue(driver.FindElement(By.Id("Create")).Text.C‌​ontains("Add"));
        }
    }
}
