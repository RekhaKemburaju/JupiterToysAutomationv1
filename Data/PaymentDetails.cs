using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Data
{
    public class PaymentDetails
    {
        public string CardType { set; get; }
        public int CardNumber { set; get; }

        public PaymentDetails(string cardType,int cardNumber)
        {
            CardType = cardType;
            CardNumber = cardNumber;

        }
    }
}
