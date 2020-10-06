using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace HW14_auto_
{    
    [TestFixture]
    class MainPageTests
    {
        IWebDriver chrome;
        MainPage_POM mp_POM;

        [SetUp]
        public void OnSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=ru");
            chrome = new ChromeDriver(@"D:\Selenium\chromedriver_win32", options);
            chrome.Navigate().GoToUrl("https://hotline.ua/");
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            mp_POM = new MainPage_POM(chrome);
        }

        [TearDown]
        public void OnTearDown()
        {
            chrome.Quit();
        }

        [Test]
        public void ChangeLanguageToUkr()
        {
            string productText = mp_POM.ChangeToUkrLanguage().ProductListText();
            Assert.AreEqual("КАТАЛОГ ТОВАРІВ", productText);
        }

        [Test]
        public void ChangeLanguageToRus()
        {
            string productText = mp_POM.ChangeToUkrLanguage().ChangeToRusLanguage().ProductListText();
            Assert.AreEqual("КАТАЛОГ ТОВАРОВ", productText);
        }

        [Test]
        public void NavigateToAutorizePage()
        {
            AutorizePage_POM ap_POM = new AutorizePage_POM(chrome);
            mp_POM.NavigateToAutorizationPage();
            Assert.AreEqual("Вход", chrome.Title);
        }

        [TestCase("fb", "hotline.ua - Товары/услуги | Facebook ")]
        [TestCase("youTube", "hotline video - YouTube")]
        [TestCase("twitter", "hotline.ua (@hotlineua) / Твиттер")]
        [TestCase("inst", "Hotline (@hotline_ua) • Фото и видео в Instagram")]
        public void NavigateToSocialMediaPages(string socialMedia, string expectedTitle)
        {
            AutorizePage_POM ap_POM = new AutorizePage_POM(chrome);
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            mp_POM.ClickOnSocialMedia(socialMedia);
            string tabId = chrome.WindowHandles.Last();
            chrome.SwitchTo().Window(tabId);
            string actualTitle = chrome.Title;
            if (socialMedia == "fb")
            {
                actualTitle = actualTitle.Substring(0, 38);
            }
            Assert.AreEqual(expectedTitle, actualTitle);
        }


        [Test(Description = "Checking correctness of adding product to wish list")]
        public void CheckAddingToWishList()
        {
            ProductPage_POM pp_POM = new ProductPage_POM(chrome);
            ProductPopUp_POM pPopUp_POM = new ProductPopUp_POM(chrome);
            WishList_POM wl_POM = new WishList_POM(chrome);
            mp_POM.ClickOnHotProd();
            pp_POM.AddToWishList();
            string expectedElement = pPopUp_POM.GetItemName();
            pPopUp_POM.SaveToWishList().GoToWishList();
            string amount = wl_POM.GetAmountOfItems();
            string elementTitle = wl_POM.GetItemName();
            Assert.AreEqual("1", amount);
            Assert.AreEqual(expectedElement, elementTitle);
        }


        [Test]
        public void CheckColorOfLanguage()
        {
            string colorDisabled = mp_POM.LanguageColor();
            string colorEnabled = mp_POM.ChangeToUkrLanguage().LanguageColor();
            Assert.AreEqual("rgba(142, 180, 240, 1)", colorDisabled);
            Assert.AreEqual("rgba(255, 255, 255, 1)", colorEnabled);
        }
    }
}
