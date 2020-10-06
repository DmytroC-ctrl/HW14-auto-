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
    class RegistrationPageTests
    {
        IWebDriver chrome;
        RegistrationPage_POM rp_POM;

        [SetUp]
        public void OnSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=ru");
            chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32", options);
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            chrome.Navigate().GoToUrl("https://hotline.ua/register/");
        }

        [TearDown]
        public void OnTearDown()
        {
            chrome.Quit();
        }

        // Wouldn't checking registration with phone number, becouse hard to find unique one        
        [TestCase("rdm", Description = "Checking registration using uniq email")]
        [TestCase("30", Description = "Checking registration using max length of name")]
        [TestCase("symb", Description = "Checking registration using symbols in name")]
        public void RegistrationWithValidData(string nameKey)
        {
            rp_POM = new RegistrationPage_POM(chrome);
            string pass = "123qwe";
            rp_POM.FillEmailFieldRnd().FillNameField(nameKey).FillPassField(pass).ClickLoginButton();
            string ExpectedMessage = "Завершение регистрации";
            Assert.AreEqual(ExpectedMessage, chrome.Title);
            chrome.Quit();
        }

        [TestCase("naboy94043@zuperholo.com", "rdm", "123qwe", "Извините, но такой email или номер телефона уже занят",
             Description = "Usage of existing email")]
        [TestCase("38063440003", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of phone number that has length one sign less than required")]
        [TestCase("3806344000388", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of phone number that has length one sign more than required")]
        [TestCase("000634400038", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of phone number in invalid format, but valid length")]
        [TestCase("@gmail.com", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of email adress with empty email name")]
        [TestCase("email@", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of email adress with empty domain main")]
        [TestCase("n0boy94043040@gmailcom", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of email adress without '.' symbol after '@' sign")]
        [TestCase("n0boy94043040gmail.com", "rdm", "123qwe", "Введите email или номер телефона",
             Description = "Usage of email adress without '@' sign")]
        [TestCase("почта@gmail.com", "rdm", "123qwe", "Поле не соответствует формату",
             Description = "Usage of email adress with cyrylic signs")]
        [TestCase(" ", "rdm", "123qwe", "Заполните это поле",
             Description = "Usage of empty email/phone field")]
        public void RegistrainoWithInvalidEmail(string data, string name, string pass, string expectedErrorMessage)
        {
            rp_POM = new RegistrationPage_POM(chrome);
            rp_POM.FillEmailField(data).FillNameField(name).FillPassField(pass).ClickLoginButton();
            string actualErrorMessage = rp_POM.GetEmailErrorMessage();
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestCase("key", "#Test U$еr^Nаmе", "123qwe", "Поле не соответствует формату",
             Description = "Usage of name with special symbols")]
        [TestCase("key", "TestUser01", "123qwe", "Данный ник уже занят.",
             Description = "Usage of name that already exist")]
        [TestCase("key", " ", "123qwe", "Заполните это поле",
             Description = "Usage of empty name field")]
        public void RegistrainoWithInvalidName(string data, string name, string pass, string expectedErrorMessage)
        {
            rp_POM = new RegistrationPage_POM(chrome);
            rp_POM.FillEmailField(data).FillNameField(name).FillPassField(pass).ClickLoginButton();
            string actualErrorMessage = rp_POM.GetNameErrorMessage();
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }

        [TestCase("key", "rdm", "12e", "Длина поля не может быть меньше 4 и больше 16 символов",
            Description = "Usage of password that has length one sign less than required")]
        [TestCase("key", "rdm", "", "Заполните это поле",
             Description = "Usage of empty password")]
        public void RegistrainoWithInvalidPass(string data, string name, string pass, string expectedErrorMessage)
        {
            rp_POM = new RegistrationPage_POM(chrome);
            rp_POM.FillEmailField(data).FillNameField(name).FillPassField(pass).ClickLoginButton();
            string actualErrorMessage = rp_POM.GetPasswordErrorMessage();
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
    }
}
