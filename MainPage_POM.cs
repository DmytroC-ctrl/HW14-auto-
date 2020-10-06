using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
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
    }
}

