using JupiterToysAutomation.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Pages
{
    public class ShopPage:BasePage
    {
       
        public ShopPage(IWebDriver _driver)
        {
            this._driver = _driver;
        }

        public IWebElement FindProductConatiner(ItemDetails item)
        {
            string productname = $"//h4[text()=\"{item.ItemName}\"]/ancestor::li";
            return _driver.FindElement(By.XPath(productname));
        }       
        public void ClickBuyButton(ItemDetails item)
        {
            IWebElement productConatiner = FindProductConatiner(item);
            productConatiner.FindElement(By.XPath(".//a[text()=\"Buy\"]")).Click();

        }
        public double GetItemPrice(ItemDetails item)
        {
            IWebElement productConatiner = FindProductConatiner(item);
            string itemPrice = productConatiner.FindElement(By.XPath(".//span")).Text;
            itemPrice = itemPrice.Substring(1);
            double itemp = Convert.ToDouble(itemPrice);
            if (itemp < 11)
            {
                Console.WriteLine("Price of: " + item.ItemName + " is less the 11 dollars" + itemPrice);
            }
            else{
                Console.WriteLine("Price of: " + item.ItemName + " is more the 11 dollars" + itemPrice);
            }
            return itemp;
        }
       
      

    }
}
