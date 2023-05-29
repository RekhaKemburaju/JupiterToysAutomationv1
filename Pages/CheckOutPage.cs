using JupiterToysAutomation.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class CheckOutPage:BasePage
    {
        IWebElement foreNameTextBox => _driver.FindElement(By.Id("forename"));
        IWebElement surNameTextBox => _driver.FindElement(By.Id("surname"));
        IWebElement emailTextBox => _driver.FindElement(By.Id("email"));
        IWebElement telephoneTextBox => _driver.FindElement(By.Id("telephone"));
        IWebElement addressTextBox => _driver.FindElement(By.Id("address"));
        IWebElement cardTypeDropDownList => _driver.FindElement(By.Id("cardType"));
        IWebElement cardNumberTextBox => _driver.FindElement(By.Id("card"));
        IWebElement submitButton  => _driver.FindElement(By.Id("checkout-submit-btn"));
        IWebElement sucessCheckoutMessage => _driver.FindElement(By.ClassName("alert-success"));


        public CheckOutPage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        public void EnterDeliveryDetails(DeliveryDetails deliveryDetails )
        {
            foreNameTextBox.SendKeys(deliveryDetails.ForeName);
            surNameTextBox.SendKeys(deliveryDetails.SurName);
            emailTextBox.SendKeys(deliveryDetails.Email);
            telephoneTextBox.SendKeys(Convert.ToString(deliveryDetails.Telephone));
            addressTextBox.SendKeys(deliveryDetails.Address);
        }
        public void EnterPaymentDetails(PaymentDetails paymentDetails)
        {
            SelectElement select = new SelectElement(cardTypeDropDownList);
            select.SelectByText(paymentDetails.CardType);
            cardNumberTextBox.SendKeys(Convert.ToString(paymentDetails.CardNumber));

        } 
        public CheckOutSuccessPage ClickSubmit()
        {
            submitButton.Click();
            return new CheckOutSuccessPage(_driver);
        }

       

       
    }
}
