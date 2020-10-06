using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace HW14_auto_
{
    class WishList_POM
    {
        IWebDriver chrome;
        By _amountOfItems = By.CssSelector("body > div.wrapper > div.content.row > div.cell-9.cell-md > h1 > span");
        By _itemTitle = By.CssSelector("body > div.wrapper > div.content.row > div.cell-9.cell-md > div > div.viewbox-striped.border-t > ul > li > div > div.cell-9.cell-sm > p > a");

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

        public WishList_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public string GetAmountOfItems()
        {
            return chrome.FindElement(_amountOfItems).Text;
        }

        public string GetItemName()
        {
            return chrome.FindElement(_itemTitle).Text;
        }
    }
}

