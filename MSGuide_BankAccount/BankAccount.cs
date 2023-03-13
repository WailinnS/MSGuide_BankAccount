using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSGuide_BankAccount
{
    public class BankAccount
    {
        //will give an account number for any bank account created.
        private static int accountNumberSeed = 00;

        private string accountNumber;

        private readonly decimal minimumBalance;
        public string AccountNumber
        {
            //use of expression bodied members
            get => accountNumber;
        }


        
        //auto Property;
        public string AccountOwner { get; set; }

        

        //Properties
        public Decimal Balance 
        {
            get
            {
                decimal currentBalance = 0;
                foreach (Transaction transaction in allTransactions)
                {
                    currentBalance += transaction.Amount;
                }
                return currentBalance;
            }
            
        }

        //constructor
        public BankAccount(string name, decimal initalBalance, decimal minimumBalance)
        {
            accountNumber = accountNumberSeed.ToString();
            accountNumberSeed++;
            AccountOwner = name;
            this.minimumBalance = minimumBalance;
            if (initalBalance > 0)
            {
                MakeDeposit(initalBalance, DateTime.Now, "Initial balance");
            }
        }

        public BankAccount(string name, decimal initalBalance) : this(name, initalBalance, 0) { }

       
        List<Transaction> allTransactions = new List<Transaction>();

        //TO DO: Handle deposit execption.
        
        //methods for bankAccount
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive\n");
            }
            Transaction deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawl must be positive.");
            }
            // ? -> method may return null
            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            Transaction? withdrawl = new(-amount,date,note);
            allTransactions.Add(withdrawl);
            
            if (overdraftTransaction != null)
            {
                allTransactions.Add(overdraftTransaction);
            }            
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("No sufficient funds for this withdrawl.");
            }

            return default;
            
        }

        public string GetAccountHistory()
        {
            StringBuilder transactionHistory = new StringBuilder();
            
            decimal balance = 0m;
            transactionHistory.AppendLine($"\t\t{AccountOwner} Account History");
            transactionHistory.AppendLine($"{"Date",-12}{"Amount",-15}{"Balance",14}\t{"Note:"}");

            foreach(Transaction transaction in allTransactions)
            {
                balance += transaction.Amount;
                transactionHistory.AppendLine($"{transaction.Date.ToShortDateString(),-12}{transaction.Amount,-15:C2}{balance,14:C2}\t{transaction.Notes}");
            }

            return transactionHistory.ToString();
        }


        //Virtual Method

        public virtual void PerformMonthEndTransactions() { }
        
    }
}
