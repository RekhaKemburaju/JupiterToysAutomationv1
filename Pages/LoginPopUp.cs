using JupiterToysAutomation.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class LoginPopUp:BasePopUp
    {
        private IWebDriver _driver; 

        private  IWebElement txtUserName => popup.FindElement(By.Id("loginUserName"));
        private IWebElement txtUserPassword => popup.FindElement(By.Id("loginPassword"));
        private IWebElement btnLogin => popup.FindElement(By.ClassName("btn-primary"));
        private IWebElement btnCancel => popup.FindElement(By.ClassName("btn - cancel"));
        private IWebElement loginErrorMessage => popup.FindElement(By.CssSelector("div#login-error"));

        public LoginPopUp(IWebDriver _driver) : base(_driver) 
        {
            this._driver = _driver;
       }      
        
        public HomePage Login(UserDetails user)
        {
            txtUserName.SendKeys(user.UserName);
            txtUserPassword.SendKeys(user.Password);
            ClickLogin();
            return new HomePage(_driver);
        }    
        public void ClickLogin()
        {
            btnLogin.Click();
        }
        public void ClickCancel()
        {
            btnCancel.Click();
        }
        public string GetLoginErrorMessage()
        {
            
            return loginErrorMessage.Text;
        }
        
     


  
       




    }
}
