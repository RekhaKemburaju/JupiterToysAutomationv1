using JupiterToysAutomation.Data;
using JupiterToysAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace JupiterToysAutomation.Tests
{
    public class CheckOutTest:BaseTest
    {

        [Test]
        public void CheckOutProcessTest()
        {
            HomePage homepage = new HomePage(_driver);

            ShopPage shoppage = homepage.ClickShop();            

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);

            ShoppingCartPage cart = shoppage.ClickCart();
            CheckOutPage checkoutpage = cart.ClickCheckOut();

            DeliveryDetails deliveryDetails = new DeliveryDetails("Rekha","kembu", "rekha.kemburaju@gmail.com",1234567,"Manor lakes 199");
            PaymentDetails paymentDetails = new PaymentDetails("Mastercard",12345687);

            checkoutpage.EnterDeliveryDetails(deliveryDetails);
            checkoutpage.EnterPaymentDetails(paymentDetails);

            CheckOutSuccessPage checkOutSuccessPage = checkoutpage.ClickSubmit();

            //Implicit wait 
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Explicit  wait 
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));           
            wait.Until(e => e.FindElement(By.ClassName("alert-success")));

            string fullMesssage = checkOutSuccessPage.GetSuccessMessage();
            String orderNumber = fullMesssage.Substring(65);

            string sPattern = "JT\\d{13}";
            if (System.Text.RegularExpressions.Regex.IsMatch(orderNumber, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                Assert.AreEqual(fullMesssage, "Thanks " + deliveryDetails.ForeName + ", your order has been accepted. Your order nuumber is"+ orderNumber);
            }
            else
            {
                Assert.Fail("The message do not have the correct Ordernumber");
            }        


        }
    }
}
