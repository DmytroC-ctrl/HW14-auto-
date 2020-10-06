using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    class AutorizePage_POM
    {
        IWebDriver chrome;
        By _loginFieldPath = By.Name("login");
        By _passwordFieldPath = By.Name("password");
        By __forgotPasswordPath = By.LinkText("Забыли пароль?");
        By _submitButtonPath = By.CssSelector(".btn-graphite.btn-cell");
        By _facebookAutorizedBtnPath = By.ClassName("btn-cell btn-icon btn-facebook");
        By _googleAutorizedBtnPath = By.ClassName("btn-cell btn-icon btn-google");
        By _registerLinkPath = By.LinkText("Зарегистрироваться");
        By _errorMessage = By.ClassName("errors");
        By _emailError = By.CssSelector("body > div.wrapper > div.content.row > div > div.viewbox > div.messagebox > div");
        By _passwordError = By.XPath("/html/body/div[1]/div[1]/div/div[1]/form/div/div/div[2]/div/div");
        By _errorForgetPassword = By.CssSelector("body > div.wrapper > div.content.row > div > div.viewbox > form > div > div > div:nth-child(2) > div > div > a");

        public AutorizePage_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public AutorizePage_POM FillLoginField(string login)
        {
            chrome.FindElement(_loginFieldPath).SendKeys(login);
            return this;
        }

        public AutorizePage_POM FillPassField(string password)
        {
            chrome.FindElement(_passwordFieldPath).SendKeys(password);
            return this;
        }

        public AutorizePage_POM ClickLoginButton()
        {
            chrome.FindElement(_submitButtonPath).Click();
            return this;
        }

        public AutorizePage_POM ClickForgetPassword()
        {
            chrome.FindElement(__forgotPasswordPath).Click();
            return this;
        }


        public AutorizePage_POM ClickErrorForgetPassword()
        {
            chrome.FindElement(_errorForgetPassword).Click();
            return this;
        }

        public AutorizePage_POM ClickRegisterLink()
        {
            chrome.FindElement(_registerLinkPath).Click();
            return this;
        }

        public bool ErrorMessageExistings()
        {
            bool exist = false;
            if (chrome.FindElement(_errorMessage).Enabled)
            {
                exist = true;
            }
            return exist;
        }

        public string GetLoginErrorMessage()
        {
            string message = chrome.FindElement(_emailError).Text;
            return message;
        }

        public string GetPasswordErrorMessage()
        {
            string message = chrome.FindElement(_passwordError).Text;
            return message;
        }
    }
}
