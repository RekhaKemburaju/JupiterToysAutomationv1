using JupiterToysAutomation.Data;
using JupiterToysAutomation.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class ShoppingCartPage : BasePage
    {
        IWebElement checkOutButton => _driver.FindElement(By.ClassName("btn-checkout"));
        IWebElement emptyCartButton => _driver.FindElement(By.XPath("//a[text()=\"Empty Cart\"]"));

        //IWebElement emptyCartMessage => _driver.FindElement(By.XPath("//div[@class=\"alert\"]//strong"));
        IWebElement emptyCartMessage => _driver.FindElement(By.XPath("//div[@class=\"alert\"]"));

        public ShoppingCartPage(IWebDriver _driver)
        {
            this._driver = _driver;
        }
        public CheckOutPage ClickCheckOut()
        {
            checkOutButton.Click();
            return new CheckOutPage(_driver);
        }
        public IWebElement GetItemRow(ItemDetails item)
        {
            return _driver.FindElement(By.XPath($"//td[normalize-space(text())=\"{item.ItemName}\"]/parent::tr"));

        }
        public ItemDetails FindItem(ItemDetails item) //etItemDetails
        {
            IWebElement itemRow = GetItemRow(item);

            string itemName = itemRow.FindElement(By.XPath($"./td[normalize-space(text())=\"{item.ItemName}\"]")).Text; ;
            string itemPrice = itemRow.FindElement(By.XPath(".//td[2]")).Text;
            string currency = itemPrice.Substring(0, 1).Trim();
            itemPrice = itemPrice.Substring(1);

            string itemQuanity = itemRow.FindElement(By.Name("quantity")).GetAttribute("value");

            string itemSubTotal = itemRow.FindElement(By.XPath(".//td[4]")).Text;
            itemSubTotal = itemSubTotal.Substring(1);

            Console.WriteLine("ItemName : " + itemName);
            Console.WriteLine("ItemPrice : " + itemPrice);
            Console.WriteLine("ItemCurrency : " + currency);
            Console.WriteLine("ItemQuantity : " + itemQuanity);
            Console.WriteLine("ItemSubTotal : " + itemSubTotal);

            return new ItemDetails(itemName, Convert.ToDouble(itemPrice), currency, Convert.ToInt32(itemQuanity), Convert.ToDouble(itemSubTotal));
        }
        public Boolean IsItemInCart(ItemDetails item)
        {          
            Boolean verify = false;
            try
            {
                ItemDetails x = FindItem(item);
                verify = true;


            }
            catch (Exception e)
            {
                Console.WriteLine("Item " + item.ItemName + " is not found in the cart");
                Console.WriteLine("{0} Exception caught.", e);
            }
            return verify;

        }
        public void RemoveItemFromCart(ItemDetails item)
        {

            IWebElement itemRow = GetItemRow(item);
            itemRow.FindElement(By.XPath(".//td/ng-confirm[@title=\"Remove Item\"]")).Click();
            RemoveItemPopUp removeItemPopup = new RemoveItemPopUp(_driver);
            removeItemPopup.ClickYes();

        }
        public void UpdateQuanity(ItemDetails item)
        {
            IWebElement itemRow = GetItemRow(item);
            itemRow.FindElement(By.Name("quantity")).Clear();
            itemRow.FindElement(By.Name("quantity")).SendKeys(Convert.ToString(item.ItemQuanity));

        }
        public void ClickEmptyCart()
        {
            emptyCartButton.Click();
            EmptyCartPopUp emptyCartPopup = new EmptyCartPopUp(_driver);
            emptyCartPopup.ClickYes();
        }
        public Boolean IsCartEmpty()
        {
            Boolean verify = false;
            string message = emptyCartMessage.Text;
            Console.WriteLine(message);
            message = message.Replace("\r\n", "").Trim();
            Console.WriteLine(message);
            string x  = "×Your cart is empty - there's nothing to see here.";
            Console.WriteLine(x);
            if (message == x)
            {
                verify = true;
            }
            return verify;
        }
        public void ClickRemoveItem(ItemDetails item)
        {
            IWebElement itemRow = GetItemRow(item);
            IWebElement redbutton = itemRow.FindElement(By.XPath(".//td[5]//a"));
            redbutton.Click();
            RemoveItemPopUp removeItemPopUp = new RemoveItemPopUp(_driver);
            removeItemPopUp.ClickNo();
        }
    }
}
