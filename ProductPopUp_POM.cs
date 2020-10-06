using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HW14_auto_
{    
    class ProductPopUp_POM
    {
        IWebDriver chrome;
        // Save to wish list page
        By _saveToWishListBtn = By.CssSelector("body > div.fade.active > div > div.lightbox-bd > form > div.text-right > div:nth-child(1) > button.btn-graphite");
        By _itemTitle = By.CssSelector("body > div.fade.active > div > div.lightbox-bd > div > p");

        // Asking about redirection page 
        By _goToWishListPageBtn = By.CssSelector("body > div.fade.active > div > div.lightbox-bd > form > div.text-right > div.hidden > button.btn-graphite");
        By _closePopUp = By.XPath("/html/body/div[5]/div/i");

        public ProductPopUp_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public ProductPopUp_POM SaveToWishList()
        {
            chrome.FindElement(_saveToWishListBtn).Click();
            return this;
        }

        public ProductPopUp_POM GoToWishList()
        {
            chrome.FindElement(_goToWishListPageBtn).Click();
            return this;
        }

        public string GetItemName()
        {
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(_itemTitle));
            return chrome.FindElement(_itemTitle).Text;
        }

        public ProductPopUp_POM ClosePopUp()
        {
            chrome.FindElement(_closePopUp).Click();
            return this;
        }
    }
}
