using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Data
{
    public class ContactDetails
    {
             
        public string ForeName { set; get; }
        public string SurName { set; get; }
        public string Email { set; get; }
        public int Telephone { set; get; }
        public string Message { set; get; }                 
        public ContactDetails(string foreName, string surName, string email, int telephone, string message)
        {
            ForeName = foreName;
            SurName = surName;
            Email = email;
            Telephone = telephone;
            Message = message;
        }
      



    }
}
