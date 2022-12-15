using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BIZ
{
    public class TransactionsCurrent : DataEntry
    {
        public string transType { get; set; }
        public float Amount { get; set; }

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public TransactionsCurrent(string transtype, float amount, string sender, string receiver)
        {
            transType = transtype;
            Amount = amount;
            Sender = sender;
            Receiver = receiver;
        }

   

    }
}
