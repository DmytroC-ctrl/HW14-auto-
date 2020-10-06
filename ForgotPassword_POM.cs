using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    class ForgotPassword_POM
    {
        IWebDriver chrome;
        By _dataFieldPath = By.Name("login");
        By _submitButtonPath = By.XPath("/html/body/div[1]/div[1]/div[1]/div/form/div/div/input");
        By _pageTitle = By.XPath("/html/body/div[1]/div[1]/div[1]/div/p");
        By _errorField = By.XPath("/html/body/div[1]/div[1]/div[1]/div/form/div/div/div[2]/div");
        By _sendAgainBtn = By.Id("send-code-again");

        public ForgotPassword_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public ForgotPassword_POM FillDataField(string key)
        {
            chrome.FindElement(_dataFieldPath).SendKeys(key);
            return this;
        }

        public ForgotPassword_POM ClickLoginButton()
        {
            chrome.FindElement(_submitButtonPath).Click();
            return this;
        }

        public string GetPageTitle()
        {
            string text = chrome.FindElement(_pageTitle).Text;
            return text;
        }

        public string GetErrorMessage()
        {
            string text = chrome.FindElement(_errorField).Text;
            return text;
        }

        public bool CheckPassReminder()
        {
            bool exist = false;
            if (chrome.FindElement(_sendAgainBtn).Enabled)
            {
                exist = true;
            }
            return exist;
        }
    }
}
