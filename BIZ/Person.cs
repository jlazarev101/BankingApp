using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BIZ
{

    public class Person : DataEntry
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
       
 

        public Person(string fn, string sn, string em, string ph, string add1, string add2, string city, string cy)
        {
            FirstName = fn;
            SurName = sn;
            Email = em;
            Phone = ph;
            Address1 = add1;
            Address2 = add2;
            City = city;
            County = cy;
  
            

        }

    }
}
