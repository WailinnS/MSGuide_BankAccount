using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGuide_BankAccount
{
    internal class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initalBalance, decimal creditLimit) : base(name, initalBalance, -creditLimit)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest change:
                decimal intrest = -Balance * 0.07m;

                MakeWithdrawal(intrest, DateTime.Now, "Charge monthly intereest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) => 
            isOverdrawn ? new Transaction(-20,DateTime.Now,"Apply overdraft fee") :default;
        
    }
}
