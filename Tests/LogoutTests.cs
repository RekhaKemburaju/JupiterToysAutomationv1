using System;
using System.Collections.Generic;
using System.Text;
using JupiterToysAutomation.Data;
using JupiterToysAutomation.Pages;
using JupiterToysAutomation.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace JupiterToysAutomation.Tests
{
    public class LogoutTests:BaseTest
    {
        [Test]        
        public void LogOutFromHomePageTest()
        {

            HomePage homepage = new HomePage(_driver);
            homepage.ClickLogin();
            LoginPopUp loginpage = new LoginPopUp(_driver);
            UserDetails user = new UserDetails("Rekha", "letmein");
            homepage = loginpage.Login(user);
            homepage.ClickLogOut();
            LogoutPopUp logoutpopup = new LogoutPopUp(_driver);
            homepage = logoutpopup.Logout();
            Assert.AreEqual("", homepage.GetLoggedInUser());

        }
        [Test]      
        public void LogOutFromShopePageTest()
        {

            HomePage homepage = new HomePage(_driver);
            homepage.ClickLogin();
            LoginPopUp loginpage = new LoginPopUp(_driver);
            UserDetails user = new UserDetails("Rekha", "letmein");
            homepage = loginpage.Login(user);            
            ShopPage shoppage = homepage.ClickShop();
            shoppage.ClickLogOut();
            LogoutPopUp logoutpopup = new LogoutPopUp(_driver);
            homepage = logoutpopup.Logout();
            Assert.AreEqual("", homepage.GetLoggedInUser());

        }
    }
}
