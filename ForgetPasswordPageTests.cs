using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    [TestFixture]
    class ForgetPasswordPageTests
    {
        IWebDriver chrome;
        ForgotPassword_POM fp_POM;

        [SetUp]
        public void OnSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=ru");
            chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32", options);
            chrome.Navigate().GoToUrl("https://hotline.ua/reminder/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            fp_POM = new ForgotPassword_POM(chrome);
        }

        [TearDown]
        public void OnTearDown()
        {
            chrome.Quit();
        }

        [TestCase("fefefew4f", "Извините, номер телефона указан с ошибкой.",
            Description = "Checking  validation of Forget Password page throught text input")]
        [TestCase("380634400038", "Извините, пользователь с таким номером телефона не зарегистрирован.",
            Description = "Checking  validation of Forget Password page throught unregistred phone number")]
        [TestCase("vohony1@gmail.com", "Извините, пользователь с таким e-mail не зарегистрирован.",
            Description = "Checking  validation of Forget Password page throught unregistred phone number")]
        [TestCase("", "Извините, вы ничего не ввели.",
            Description = "Checking  validation of Forget Password page throught empty input field")]
        public void CheckingInvalidForgetPassword(string phoneNumber, string ExpectedMessage)
        {
            fp_POM.FillDataField(phoneNumber).ClickLoginButton();
            string errorMessage = fp_POM.GetErrorMessage();
            Assert.AreEqual(ExpectedMessage, errorMessage);
        }

        [TestCase("naboy94043@zuperholo.com", Description = "Reminding password for exicting email")]
        [TestCase("liudmiladeceducation@gmail.com", Description = "Reminding password from exicting phone number")]
        public void CheckingValidForgetPassword(string inputData)
        {
            fp_POM.FillDataField(inputData).ClickLoginButton();
            bool send = fp_POM.CheckPassReminder();
            Assert.IsTrue(send);
        }
    }
}
