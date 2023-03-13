using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGuide_BankAccount
{    
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initalBalance) :
            base(name, initalBalance){ }

        public override void PerformMonthEndTransactions()
        {
            if(Balance > 500m)
            {
                decimal intrest = Balance * 0.05m;
                MakeDeposit(intrest, DateTime.Now, "apply monthly interest");
            }
        }

    }
}
