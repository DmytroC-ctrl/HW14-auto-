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
    class AutorizePageTests
    {
        IWebDriver chrome;
        AutorizePage_POM ap_POM;

        [SetUp]
        public void OnSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=ru");
            chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32", options);
            chrome.Navigate().GoToUrl("https://hotline.ua/login/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void OnTearDown()
        {
            chrome.Quit();
        }


        [Test(Description = "Checking ability to login with valid credentials")]
        public void LogInWithValidCredentials()
        {
            ap_POM = new AutorizePage_POM(chrome);
            ap_POM.FillLoginField("naboy94043@zuperholo.com").FillPassField("123qwe").ClickLoginButton();
            Assert.IsTrue(true);
        }

        [Test(Description = "Checking ability to navigate to 'Forget Password' page ")]
        public void ForgetPasswordNavigation()
        {
            ap_POM = new AutorizePage_POM(chrome);
            ForgotPassword_POM fp_POM = new ForgotPassword_POM(chrome);
            ap_POM.ClickForgetPassword();
            string navigatedUrl = fp_POM.GetPageTitle();
            Assert.AreEqual("Изменение пароля", navigatedUrl);
        }

        [Test(Description = "Checking ability to navigate to 'Register page'")]
        public void NavigateToRegister()
        {
            ap_POM = new AutorizePage_POM(chrome);
            RegistrationPage_POM rp_POM = new RegistrationPage_POM(chrome);
            ap_POM.ClickRegisterLink();
            string navigatedUrl = rp_POM.GetPageTitle();
            Assert.AreEqual("Регистрация", navigatedUrl);
        }


        [TestCase("380634400038", "123qwe",
            "Извините, пользователь с указанным email не зарегистрирован, пожалуйста, убедитесь в правильности написания адреса",
            Description = "Log in with unregistred phone number")]
        [TestCase("0t1e2s3t4s@testing.com", "123456qwe",
            "Извините, пользователь с указанным email не зарегистрирован, пожалуйста, убедитесь в правильности написания адреса",
            Description = "Log in with unregistred email adress")]
        public void LogInWithInvalidLogins(string login, string pass, string errorMessage)
        {
            ap_POM = new AutorizePage_POM(chrome);
            ap_POM.FillLoginField(login).FillPassField(pass).ClickLoginButton();
            string actualError = ap_POM.GetLoginErrorMessage();
            Assert.AreEqual(errorMessage, actualError);
        }

        [TestCase("naboy94043@zuperholo.com", "Pass123",
            "Извините, вы ввели неправильный пароль. Если вы забыли свой пароль, вы можете его изменить",
            Description = "Log in with registred phone number and incorrect password")]
        [TestCase("Liudmiladeceducation@gmail.com", "Pass123",
            "Извините, вы ввели неправильный пароль. Если вы забыли свой пароль, вы можете его изменить",
            Description = "Log in with registred email adress and incorrect password")]
        public void LogInWithInvalidPass(string login, string pass, string errorMessage)
        {
            ap_POM = new AutorizePage_POM(chrome);
            ap_POM.FillLoginField(login).FillPassField(pass).ClickLoginButton();
            string actualError = ap_POM.GetLoginErrorMessage();
            Assert.AreEqual(errorMessage, actualError);
        }


        [Test(Description = "Checking ability to navigate to 'Forget Password' page ")]
        public void ForgetPasswordNavigationThroughtErrorMessage()
        {
            ap_POM = new AutorizePage_POM(chrome);
            ForgotPassword_POM fp_POM = new ForgotPassword_POM(chrome);
            ap_POM.FillLoginField("naboy94043@zuperholo.com").FillPassField("4f4f4f4f4f4").ClickLoginButton();
            ap_POM.ClickErrorForgetPassword();
            string navigatedUrl = fp_POM.GetPageTitle();
            Assert.AreEqual(navigatedUrl, "Изменение пароля");
        }

        [Test(Description = "Checking the correctness of work return to the previous page")]
        public void CheckBackRedirection()
        {
            AutorizePage_POM ap_POM = new AutorizePage_POM(chrome);
            string expextedTitle = chrome.Title;
            ap_POM.ClickRegisterLink();
            Assert.AreEqual("Вход", chrome.Title);
            chrome.Navigate().Back();
            Assert.AreEqual(expextedTitle, chrome.Title);
        }

        [Test(Description = "Checking the correctness of work return to the next page")]
        public void CheckForwardRedirection()
        {
            AutorizePage_POM ap_POM = new AutorizePage_POM(chrome);
            ap_POM.ClickRegisterLink();
            string expextedTitle = chrome.Title;
            chrome.Navigate().Back();
            Assert.AreNotEqual(expextedTitle, chrome.Title);
            chrome.Navigate().Forward();
            Assert.AreEqual(expextedTitle, chrome.Title);
        }
    }
}
