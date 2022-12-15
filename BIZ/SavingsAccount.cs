using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class SavingsAccount : Account
    {
        public int OverdraftLimit { get; set; }

        public SavingsAccount(string acc, int sc, int odl, float bl)
        {
            AccountType = acc;
            SortCode = sc;
            Balance = bl;
            OverdraftLimit = odl;
        }

    }
}
