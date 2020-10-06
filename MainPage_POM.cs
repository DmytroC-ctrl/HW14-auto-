using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace HW14_auto_
{
    class MainPage_POM
    {
        IWebDriver chrome;

        By _logo = By.CssSelector(".header-logo.cell-4.cell-sm-6.cell-xs");
        By _location = By.ClassName("city-link");
        By _rusLanguage = By.XPath("/html/body/header/div[1]/div/div/div[1]/div/div[2]/div/div[2]/div/div/span[1]");
        By _ukrLanguage = By.XPath("/html/body/header/div[1]/div/div/div[1]/div/div[2]/div/div[2]/div/div/span[2]");
        By _autorizationLink = By.CssSelector("a[href='/login/']");
        By _cart = By.CssSelector(".pull-right.dropdown.dropdown-pull-right");
        By _productsListName = By.ClassName("uppercase");
        By _visitedProductsEmpty = By.CssSelector("#page-index > header > div.header > div > div > div.header-nav.cell-6 > div.pull-right.dropdown.dropdown-pull-right.active > div.dropdown-bd.active > div > ul > li:nth-child(3) > span");
        By _visitedProducts = By.CssSelector("body > header > div.header > div > div > div.header-nav.cell-6 > div.pull-right.dropdown.dropdown-pull-right.active > div.dropdown-bd.active > div > ul > li:nth-child(3) > a");
        By _wishesLink = By.CssSelector("body > header > div.header > div > div > div.header-nav.cell-6 > div:nth-child(2) > div.item-wishlist");
        By _wishesDropDown = By.CssSelector("div[data-dropdown-id='wishlist']");
        By _linkToWishListPage = By.CssSelector("a[href='/profile/guest/lists/bookmarks/']");
        By _hotProduct = By.XPath("/html/body/div[1]/div[1]/div/div/div/div[3]/div/div[1]/div/div[1]/div/a");
        By _autorizedUserName = By.XPath("/html/body/header/div[1]/div/div/div[2]/div[4]/div[1]/span[2]");

        By _fbLink = By.CssSelector("a[href='https://facebook.com/hotline.ua']");
        By _instLink = By.CssSelector("a[href='https://www.instagram.com/hotline_ua/']");
        By _youTubeLink = By.CssSelector("a[href='https://www.youtube.com/user/hotlinevideoua']");
        By _twitterLink = By.CssSelector("a[href='https://twitter.com/hotlineua']");
        By _searchInput = By.CssSelector("input[id='searchbox'][class='field'][placeholder='... найти товар']");



        public MainPage_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public MainPage_POM ClickOnLogo()
        {
            chrome.FindElement(_logo).Click();
            return this;
        }

        public MainPage_POM ChangeLocation()
        {
            chrome.FindElement(_location).Click();
            return this;
        }

        public MainPage_POM ChangeToRusLanguage()
        {
            chrome.FindElement(_rusLanguage).Click();
            return this;
        }

        public MainPage_POM ChangeToUkrLanguage()
        {
            chrome.FindElement(_ukrLanguage).Click();
            return this;
        }

        public MainPage_POM ShowWishList()
        {
            chrome.FindElement(_wishesLink).Click();
            return this;
        }

        public MainPage_POM GoToWishList()
        {
            chrome.FindElement(_linkToWishListPage).Click();
            return this;
        }

        public MainPage_POM ClickOnHotProd()
        {
            chrome.FindElement(_hotProduct).Click();
            return this;
        }

        public string GetHotProd()
        {
            string text = chrome.FindElement(_hotProduct).Text;
            return text;
        }

        public string ProductListText()
        {
            string text = chrome.FindElement(_productsListName).Text;
            return text;
        }

        public MainPage_POM NavigateToVisitedProducts()
        {
            chrome.FindElement(_visitedProducts).Click();
            return this;
        }

        public string GetUserName()
        {
            string name = chrome.FindElement(_autorizedUserName).Text;
            return name;
        }

        public MainPage_POM NavigateToAutorizationPage()
        {
            chrome.FindElement(_autorizationLink).Click();
            return this;
        }

        public MainPage_POM ClickOnSocialMedia(string key)
        {
            By link = By.CssSelector("a[href='https://facebook.com/hotline.ua']");
            switch (key)
            {
                case "fb":
                    link = _fbLink;
                    break;
                case "inst":
                    link = _instLink;
                    break;
                case "youTube":
                    link = _youTubeLink;
                    break;
                case "twitter":
                    link = _twitterLink;
                    break;
                default:
                    break;
            }
            chrome.FindElement(link).Click();
            return this;
        }

        public MainPage_POM SearchItemByEnter(string item)
        {
            chrome.FindElement(_searchInput).SendKeys(item);
            chrome.FindElement(_searchInput).SendKeys(Keys.Enter);
            return this;
        }

        public bool HasActiveClass(IWebElement element)
        {
            string classes = element.GetAttribute("class");
            string[] classArray = classes.Split(new char[] { ' ' });
            foreach (string item in classArray)
            {
                if (item == "current")
                {
                    return true;
                }
            }
            return false;
        }

        public string LanguageColor()
        {
            return chrome.FindElement(_ukrLanguage).GetCssValue("color");

        }
    }
}

