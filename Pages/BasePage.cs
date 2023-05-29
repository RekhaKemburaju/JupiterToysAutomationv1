using JupiterToysAutomation.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class BasePage
    {
        public IWebDriver _driver;
        private IWebElement logInLink => _driver.FindElement(By.LinkText("Login"));
        private IWebElement logOutLink => _driver.FindElement(By.LinkText("Logout"));
        private IWebElement contactLink => _driver.FindElement(By.CssSelector("#nav-contact a"));
        private IWebElement shopLink => _driver.FindElement(By.LinkText("Shop"));
        private IWebElement cartLink => _driver.FindElement(By.CssSelector("#nav-cart a"));
        private IWebElement loggedInUser => _driver.FindElement(By.ClassName("user"));
       
        public BasePage() { }
        public BasePage(IWebDriver _driver)
        {
            this._driver = _driver;
        }
        public void ClickLogin()
        {
            Report.LogStep("Clicking Login");
            logInLink.Click();
        }      
        public void ClickLogOut()
        {
            logOutLink.Click();
        }
        public ContactPage ClickConact()
        {
            contactLink.Click();
            return new ContactPage(_driver);
        }

        public ShopPage ClickShop() 
        {
            shopLink.Click();
            return new ShopPage(_driver);
        }

        public ShoppingCartPage ClickCart()
        {
            cartLink.Click();
            return new ShoppingCartPage(_driver);
        }
        public string GetLoggedInUser() => loggedInUser.Text;
        public int GetNumberOfItemsInShoppingCart()
        {
            String cartCount =_driver.FindElement(By.ClassName("cart-count")).Text;
            Console.WriteLine("The Number of Items in the cart : "+ cartCount);
            return Convert.ToInt32(cartCount);
        }
    }
}
