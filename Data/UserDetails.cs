using System;
using System.Collections.Generic;
using System.Text;

namespace JupiterToysAutomation.Data
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserDetails(string userName,string password)
        {
            UserName = userName;
            Password = password;
        }

       


    }

}
