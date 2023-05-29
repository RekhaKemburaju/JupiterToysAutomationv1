using JupiterToysAutomation.Data;
using JupiterToysAutomation.Pages;
using JupiterToysAutomation.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace JupiterToysAutomation
{
    public class LoginTests:BaseTest
    {
         
        
        [Test]
        public void LoginFromHomePageTest()
        {
            HomePage homepage = new HomePage(_driver);
            homepage.ClickLogin(); 
            LoginPopUp loginpage = new LoginPopUp(_driver);
            UserDetails user = new UserDetails("Rekha", "letmein");
            homepage = loginpage.Login(user);
            Assert.AreEqual("Rekha", homepage.GetLoggedInUser());
            //Assert.Pass();
        }
        [Test]
        public void IncorrectPasswordTest()
        {
            HomePage homepage = new HomePage(_driver);
            homepage.ClickLogin();
            LoginPopUp loginpage = new LoginPopUp(_driver);
            UserDetails user = new UserDetails("Rekha", "woringpassword");
            homepage = loginpage.Login(user);
            Assert.AreEqual("Your login details are incorrect", loginpage.GetLoginErrorMessage());
        }
        [Test]
        public void LoginFromShopPageTest()
        {           
            
            HomePage homepage = new HomePage(_driver);
            ShopPage shopepage  = homepage.ClickShop();
            shopepage.ClickLogin();
            LoginPopUp loginpage = new LoginPopUp(_driver);
            UserDetails user = new UserDetails("Rekha", "letmein");
            loginpage.Login(user);
            Assert.AreEqual("Rekha", shopepage.GetLoggedInUser());            
        }







    }
}