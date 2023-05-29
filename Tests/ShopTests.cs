using JupiterToysAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using JupiterToysAutomation.Data;

namespace JupiterToysAutomation.Tests
{
    class ShopTests:BaseTest
    {

        
        [Test]
        public void BuyItemTest()
        {
            HomePage homepage = new HomePage(_driver);            
            ShopPage shoppage = homepage.ClickShop();

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);  
            
            Assert.AreEqual(2, shoppage.GetNumberOfItemsInShoppingCart());       

        }
        
        
     
        [Test]
        public void VerifyItemsAddedToCartTest()
        {
            HomePage homepage = new HomePage(_driver);          

            ShopPage shoppage = homepage.ClickShop();           

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);

            ShoppingCartPage cart = shoppage.ClickCart(); 
            
            Assert.IsTrue(cart.IsItemInCart(item1));
            Assert.IsTrue(cart.IsItemInCart(item2));          

        }   
        
        
        [Test]
        public void VerifyItemRemovedFromCartTest()
        {
            HomePage homepage = new HomePage(_driver);        

            ShopPage shoppage = homepage.ClickShop();           

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");
            ItemDetails item3 = new ItemDetails("Handmade Doll");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);
            shoppage.ClickBuyButton(item3);

            ShoppingCartPage cart = shoppage.ClickCart(); 
            cart.RemoveItemFromCart(item3);

            Assert.IsTrue(cart.IsItemInCart(item1),"Unable to find Teddy Bear");
            Assert.IsTrue(cart.IsItemInCart(item2));
            Assert.IsFalse(cart.IsItemInCart(item3));        

        }
        
        
        [Test]
        public void PriceValidationOfItemsInCartTest()
        {
            HomePage homepage = new HomePage(_driver);            

            ShopPage shoppage = homepage.ClickShop();

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);     
                      
            ShoppingCartPage cart = shoppage.ClickCart();
            
            Assert.AreEqual("Teddy Bear", cart.FindItem(item1).ItemName);
            Assert.AreEqual(12.99, cart.FindItem(item1).ItemPrice);

            Assert.AreEqual("Stuffed Frog", cart.FindItem(item2).ItemName);             
            Assert.AreEqual(10.99, cart.FindItem(item2).ItemPrice);          

        }
        

        [Test]
        public void UpdateQuantityValidationTest()
        {
            HomePage homepage = new HomePage(_driver);
            ShopPage shoppage = homepage.ClickShop();

            ItemDetails item1 = new ItemDetails("Valentine Bear");
            item1.ItemQuanity = 11;
            ItemDetails item2 = new ItemDetails("Stuffed Frog");
            item2.ItemQuanity = 5;

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);
            

            ShoppingCartPage cart = shoppage.ClickCart();

            cart.UpdateQuanity(item1);
            cart.UpdateQuanity(item2);

            ItemDetails item1FromScreen = cart.FindItem(item1);
            ItemDetails item2FromScreen = cart.FindItem(item2);

         
            Assert.AreEqual("Valentine Bear", item1FromScreen.ItemName);           
            Assert.AreEqual(14.99, item1FromScreen.ItemPrice);          
            Assert.AreEqual(164.89, item1FromScreen.ItemSubTotal);

            Assert.AreEqual("Stuffed Frog", item2FromScreen.ItemName);
            Assert.AreEqual(10.99, item2FromScreen.ItemPrice);
            Assert.AreEqual(54.95, item2FromScreen.ItemSubTotal);
        }

        
        //Addtion Exercise 
        [Test]
        public void VerifyAllProductPricesInShopToBeMoreThen11DollarTest()
        {
            HomePage homepage = new HomePage(_driver);
            ShopPage shoppage = homepage.ClickShop();

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");
            ItemDetails item3 = new ItemDetails("Handmade Doll");
            ItemDetails item4 = new ItemDetails("Fluffy Bunny");
            ItemDetails item5 = new ItemDetails("Smiley Bear");
            ItemDetails item6 = new ItemDetails("Funny Cow");
            ItemDetails item7 = new ItemDetails("Valentine Bear");
            ItemDetails item8 = new ItemDetails("Smiley Face");

            double item1Price =  shoppage.GetItemPrice(item1);
            double item2Price = shoppage.GetItemPrice(item2);
            double item3Price = shoppage.GetItemPrice(item3);
            double item4Price = shoppage.GetItemPrice(item4);
            double item5Price = shoppage.GetItemPrice(item5);
            double item6Price = shoppage.GetItemPrice(item6);
            double item7Price = shoppage.GetItemPrice(item7);
            double item8Price = shoppage.GetItemPrice(item8);

            Assert.Greater(item1Price,11,"The Item "+ item1.ItemName +" price is not more then 11 dollars");
            Assert.Greater(item2Price, 11, "The Item " + item2.ItemName + " price is not more then 11 dollars");
            Assert.Greater(item3Price, 11, "The Item " + item3.ItemName + " price is not more then 11 dollars");
            Assert.Greater(item4Price, 11, "The Item " + item4.ItemName + " price is not more then 11 dollars");
            Assert.Greater(item5Price, 11, "The Item " + item5.ItemName + " price is not more then 11 dollars");
            Assert.Greater(item6Price, 11, "The Item " + item6.ItemName + " price is not more then 11 dollars");
            Assert.Greater(item7Price, 11, "The Item " + item7.ItemName + " price is not more then 11 dollars");
            Assert.Greater(item8Price, 11, "The Item " + item8.ItemName + " price is not more then 11 dollars");

        }
        
        [Test]
        public void EmptyCartTest()
        {
            HomePage homepage = new HomePage(_driver);

            ShopPage shoppage = homepage.ClickShop();

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");
            ItemDetails item3 = new ItemDetails("Handmade Doll");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);
            shoppage.ClickBuyButton(item3);

            ShoppingCartPage cart = shoppage.ClickCart();
            cart.ClickEmptyCart();

            if (cart.IsItemInCart(item1) & cart.IsItemInCart(item2) & cart.IsItemInCart(item3))
            {
                Assert.IsTrue(cart.IsCartEmpty(), "The Items are still in cart");
            }        


        }
        [Test]
        public void verifyItemInCartAfterClickNoForItemRemoveInCart()
        {
            HomePage homepage = new HomePage(_driver);

            ShopPage shoppage = homepage.ClickShop();

            ItemDetails item1 = new ItemDetails("Teddy Bear");
            ItemDetails item2 = new ItemDetails("Stuffed Frog");
            ItemDetails item3 = new ItemDetails("Handmade Doll");

            shoppage.ClickBuyButton(item1);
            shoppage.ClickBuyButton(item2);
            shoppage.ClickBuyButton(item3);

            ShoppingCartPage cart = shoppage.ClickCart();
            cart.ClickRemoveItem(item2);

            if (cart.IsItemInCart(item1) & cart.IsItemInCart(item2) & cart.IsItemInCart(item3))
            {
                Assert.Pass();
            }


        }






    }
}
