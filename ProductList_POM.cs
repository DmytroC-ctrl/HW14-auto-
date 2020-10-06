using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{    
    class ProductList_POM
    {
        IWebDriver chrome;

        By _firstItemPrice = By.CssSelector("#catalog-products > div > ul > li:nth-child(1) > div.item-price.stick-bottom > div:nth-child(1) > div.price-md > span");
        By _filterMinPrice = By.CssSelector("#page-catalog > div.wrapper > div.content.row > div.row-fixed > aside > div > div.filters-bd.tabs-content > div.filters-all.active > div.filters-item.opened.filters-price > div.item-bd > div > div.nowrap.m_b-lg > input:nth-child(1)");
        By _filterMaxPrice = By.CssSelector("#page-catalog > div.wrapper > div.content.row > div.row-fixed > aside > div > div.filters-bd.tabs-content > div.filters-all.active > div.filters-item.opened.filters-price > div.item-bd > div > div.nowrap.m_b-lg > input:nth-child(3)");
        By _priceFilterBtn = By.XPath("/html/body/div[1]/div[1]/div[2]/aside/div/div[3]/div[1]/div[7]/div[2]/div/div[1]/input[5]");

        public ProductList_POM(IWebDriver driver)
        {
            this.chrome = driver;
        }

        public string GetFirstItemPrice()
        {

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(_firstItemPrice));
            string text = chrome.FindElement(_firstItemPrice).Text;
            return text;
        }

        public ProductList_POM SetFilter(int firstPrice)
        {
            firstPrice = 300;
            chrome.FindElement(_filterMinPrice).SendKeys(Keys.Delete);
            chrome.FindElement(_filterMinPrice).SendKeys("30");
            return this;
        }


        public ProductList_POM SendFilter()
        {
            chrome.FindElement(_priceFilterBtn).Click();
            return this;
        }

    }
}
