using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HW14_auto_
{
    class ProductPage_POM
    {        
        IWebDriver chrome;
        By _wishListIcon = By.CssSelector(".icon.icon-wishlist");

        public ProductPage_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public ProductPage_POM AddToWishList()
        {
            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(_wishListIcon));
            chrome.FindElement(_wishListIcon).Click();
            return this;
        }
    }
}