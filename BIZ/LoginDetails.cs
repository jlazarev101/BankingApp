using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BIZ
{
    public class LoginDetails : DataEntry
    {

        public string Username { get; set; }
        public string Password  { get; set; }
        public string Firstname { get; set; }
       

        public LoginDetails(string username,  string password, string firstname)
        {
            Username = username;
            Password = password;
            Firstname = firstname;
         
        }

       


    }

}
