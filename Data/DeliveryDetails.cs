using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Data
{
    public class DeliveryDetails
    {
        public string ForeName { set; get; }
        public string SurName { set; get; }
        public string Email { set; get; }
        public int Telephone { set; get; } 
        public string Address { set; get; }

        public DeliveryDetails(string foreName, string surName, string email, int telephone, string address)
        {
            ForeName = foreName;
            SurName = surName;
            Email = email;
            Telephone = telephone;
            Address = address;           
        }

    }
}
