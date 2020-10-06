using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    class RegistrationPage_POM
    {
        IWebDriver chrome;
        By _pageTitle = By.XPath("/html/body/div[1]/div[1]/div/div[1]/p");
        By _emailFieldPath = By.Name("login");
        By _nameFieldPath = By.Name("name");
        By _passwordFieldPath = By.Name("password");
        By _submitButton = By.Id("submit-button");
        By _submitButtonPath = By.CssSelector(".btn-graphite.btn-cell");
        By _facebookAutorizedBtnPath = By.CssSelector(".btn-cell.btn-icon.btn-facebook");
        By _googleAutorizedBtnPath = By.CssSelector(".btn-cell.btn-icon.btn-google");
        By _emailErrorMessage = By.XPath("/html/body/div[1]/div[1]/div/div[1]/form/div/div/div[1]/div[1]/div");
        By _nameErrorMessage = By.XPath("/html/body/div[1]/div[1]/div/div[1]/form/div/div/div[3]/div/div");
        By _passErrorMessage = By.XPath("/html/body/div[1]/div[1]/div/div[1]/form/div/div/div[4]/div/div");

        public RegistrationPage_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public string GetPageTitle()
        {
            string text = chrome.FindElement(_pageTitle).Text;
            return text;
        }

        public RegistrationPage_POM FillEmailFieldRnd()
        {
            string mail = GenerateMail();
            chrome.FindElement(_emailFieldPath).SendKeys(mail);
            return this;
        }

        public RegistrationPage_POM FillEmailField(string data)
        {
            if (data == "key")
            {
                data = GenerateMail();
            }
            chrome.FindElement(_emailFieldPath).SendKeys(data);
            return this;
        }

        public RegistrationPage_POM FillNameField(string key)
        {
            string name = "";
            if (key == "rdm" || key == "30" || key == "symb")
            {
                name = GenerateName(key);
            }
            else name = key;
            chrome.FindElement(_nameFieldPath).SendKeys(name);
            return this;
        }

        public RegistrationPage_POM FillPassField(string password)
        {
            chrome.FindElement(_passwordFieldPath).SendKeys(password);
            return this;
        }

        public RegistrationPage_POM ClickLoginButton()
        {
            chrome.FindElement(_submitButtonPath).Click();
            return this;
        }

        public string GetEmailErrorMessage()
        {
            string message = chrome.FindElement(_emailErrorMessage).Text;
            return message;
        }

        public string GetNameErrorMessage()
        {
            string message = chrome.FindElement(_nameErrorMessage).Text;
            return message;
        }

        public string GetPasswordErrorMessage()
        {
            string message = chrome.FindElement(_passErrorMessage).Text;
            return message;
        }

        public string GenerateMail()
        {
            string mail = "";
            Random rand = new Random();
            char[] letters = "abcdefghijklmnopqrstuvwxyzHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 1; i <= 10; i++)
            {
                int letter_num = rand.Next(0, 44);
                mail += letters[letter_num];
            }
            mail += rand.Next(100, 1000);
            mail += "@test.test";
            return mail;
        }

        public string GenerateName(string key)
        {
            string name = "";
            Random rand = new Random();
            int length = 16;
            if (key == "30") length = 29;
            char[] letters = "abcdefghijklmnopqrstuvwxyzабвгдежзыийклмнопрстуфхцщшьюя".ToCharArray();
            for (int i = 0; i <= length; i++)
            {
                int letter_num = rand.Next(0, 44);
                name += letters[letter_num];
                if (i == 10) name += ' ';
                if (key == "symb" && i == 7)
                {
                    name += "sym-b_l";
                    i += 7;
                }
            }
            return name;
        }

    }
}
