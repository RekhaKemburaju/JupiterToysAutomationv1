using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class CheckOutSuccessPage:BasePage
    {
        IWebElement sucessMessage => _driver.FindElement(By.ClassName("alert-success"));
        public CheckOutSuccessPage(IWebDriver _driver)
        {
            this._driver = _driver;
        }
        public string GetSuccessMessage()
        {
          
            string message =  sucessMessage.Text;
            message = message.Replace("\r\n", "").Trim();
            Console.WriteLine("Full Message : " + message);

            string startofOrderNumber = message.Substring(65,3);
            Console.WriteLine("StartOforderNumber : " + startofOrderNumber);

            String justOrderNumber = message.Substring(68);
            Console.WriteLine("JustOrderNumber : " + justOrderNumber);

            String orderNumber = message.Substring(65);
            Console.WriteLine("OrderNumber : " + orderNumber);     
            return message;
           
        }
        

    }
}
