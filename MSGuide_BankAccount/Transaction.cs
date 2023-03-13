using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGuide_BankAccount
{
    public class Transaction
    {
        public Decimal Amount { get; }
        public DateTime Date { get; }

        public string Notes { get; }

        public Transaction (Decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}
