using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class LogoutPopUp : BasePopUp
    {

        private IWebDriver _driver;
        private IWebElement btnLogout => popup.FindElement(By.ClassName("btn-success"));
        private IWebElement btnCancel => popup.FindElement(By.ClassName("btn-cancel"));
        public LogoutPopUp(IWebDriver _driver) : base(_driver)
        {
            this._driver = _driver;
        }
        public HomePage Logout()
        {
            ClickLogout();
            return new HomePage(_driver);
        }
        public void ClickLogout()
        {
            btnLogout.Click();
        }
        public void ClickCancel()
        {
            btnCancel.Click();
        }

    }
}
