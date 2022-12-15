using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BIZ
{
    public class Account : DataEntry
    {
        public string AccountType { get; set; }
        public int SortCode { get; set; }
        public float Balance { get; set; }
    }

}
