using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14_auto_
{
    [TestFixture]
    class CartTests
    {
        IWebDriver chrome;
        Cart_POM c_POM;
        ShopProductList_POM spl_POM;

        [SetUp]
        public void OnSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=ru");
            chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32", options);
            c_POM = new Cart_POM(chrome);
            spl_POM = new ShopProductList_POM(chrome);
        }

        [Test]
        public void AddingItemsToCart()
        {
            chrome.Navigate().GoToUrl("https://hotline.ua/yp/11054/price/");
            string expectedResult = spl_POM.PriceSearch();
            spl_POM.ClickBuyNow();
            string actualResult = c_POM.CartPriceSearch();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TearDown]
        public void OnTearDown()
        {
            chrome.Quit();
        }
    }
}
