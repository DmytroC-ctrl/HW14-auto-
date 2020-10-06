using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    class ShopProductList_POM
    {
        IWebDriver chrome;
        By _buyNow = By.CssSelector("body > div.wrapper > div.content.row > div.cell-fixed-indent.cell-md > div > div:nth-child(1) > div > div.offers-item-extended > div.offers-item.product-offer-12383623314s11054 > div.product-box > div > div:nth-child(2) > div > div.cell-7.cell-md > span");
        By _priceProduct = By.CssSelector("a[href='/go/price/12383623314/'][class='price-lg']");


        public ShopProductList_POM(IWebDriver chrome)
        {
            this.chrome = chrome;
        }

        public string PriceSearch()
        {
            string price = chrome.FindElement(_priceProduct).Text;
            return price;
        }
        public ShopProductList_POM ClickBuyNow()
        {
            chrome.FindElement(_buyNow).Click();
            return this;
        }
    }
}
