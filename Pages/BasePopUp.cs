using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class BasePopUp
    {
        protected IWebElement popup;
        public BasePopUp(IWebDriver _driver)
        {
            popup = _driver.FindElement(By.ClassName("popup"));
        }
    }
}
