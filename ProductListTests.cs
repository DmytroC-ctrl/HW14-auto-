using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace HW14_auto_
{
    [TestFixture]
    class ProductListTests
    {    
        IWebDriver chrome;
        ProductList_POM pl_POM;

        [SetUp]
        public void OnSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=ru");
            chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32", options);
            chrome.Navigate().GoToUrl("https://hotline.ua/sport/shtangi-grify-diski/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            pl_POM = new ProductList_POM(chrome);
        }

        [TearDown]
        public void OnTearDown()
        {
            chrome.Quit();
        }

        [Test]
        public void CheckPriceFilter()
        {
            string priceBeforeFilter = pl_POM.GetFirstItemPrice();
            int.TryParse(priceBeforeFilter, out int oldPrice);
            pl_POM.SetFilter(oldPrice).SendFilter();
            int.TryParse(pl_POM.GetFirstItemPrice(), out int newPrice);
            Assert.IsTrue(oldPrice < newPrice);

        }
    }
}

