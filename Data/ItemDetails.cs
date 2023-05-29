using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Data
{
    public class ItemDetails
    {
        public string ItemName { set; get; }
        public double ItemPrice { set; get; }
        public string ItemCurrency { set; get; }
        public  int ItemQuanity { set; get; }
        public double  ItemSubTotal { set; get; }       
        public ItemDetails(string ItemName)
        {
            this.ItemName = ItemName;            
        }        
        public ItemDetails(string itemName,double itemPrice,string itemCurrency,int itemQuanity,double itemSubTotal)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemCurrency = itemCurrency;
            ItemQuanity = itemQuanity;
            ItemSubTotal = itemSubTotal;           
        }
        
    }
}
