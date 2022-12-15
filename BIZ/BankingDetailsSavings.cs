using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BIZ
{
    public class BankingDetailsSavings : DataEntry
    {
        public string AccType { get; set; }
        public float IniDep { get; set; }

        public BankingDetailsSavings(string acc, float dep)
        {
            AccType = acc;
            IniDep = dep;
        }

    

    }
}
