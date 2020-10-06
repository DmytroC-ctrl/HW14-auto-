using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    class Cart_POM
    {
        IWebDriver chrome;
        By _quantityAdd = By.ClassName("counter-plus");
        By _quantityMinus = By.CssSelector("span[class='counter-minus'][data-change-quantity='plus']");
        By _costOfOneValue = By.CssSelector("div.price-box span.price-format span.value");
        By _costOfOnePenny = By.CssSelector(" div.price-box span.price-format span.penny");
        By _fieldInputQuantity = By.CssSelector("body > div.wrapper > div.content.row > div > div:nth-child(4) > div.viewbox.viewbox-striped > div:nth-child(3) > div.info-box > div > div:nth-child(2)");
        By _totalPrice = By.CssSelector("span[class='price-lg'][data-total-sum]");
        By _removeProduct = By.CssSelector("span[class='delete'][data-getmdl=''][data-remove-order-item='273458168']");



        public Cart_POM(IWebDriver chrome)
        {
            this.chrome = chrome;
        }

        public string CartPriceSearch()
        {
            string price = chrome.FindElement(_costOfOneValue).Text;
            string price2 = chrome.FindElement(_costOfOnePenny).Text;
            return price + price2;
        }
        public string ShowFieldQuantity()
        {
            string quantity = chrome.FindElement(_fieldInputQuantity).Text;
            return quantity;
        }
        public Cart_POM ClicPlus()
        {
            chrome.FindElement(_quantityAdd).Click();
            return this;
        }

    }
}