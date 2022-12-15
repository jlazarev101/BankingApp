using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class CurrentAccount : Account
    {
        public int OverdraftLimit { get; set; }

        public CurrentAccount(string acc, int sc, float bl, int ol)
        {
            OverdraftLimit = ol;
            AccountType = acc;
            SortCode = sc;
            Balance = bl;
        }
    }
}
