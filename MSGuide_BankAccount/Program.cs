namespace MSGuide_BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount checkingAccount = new BankAccount("Checking", 100);
            checkingAccount.MakeDeposit(1100, DateTime.Now, "Pay check");

            try
            {
                checkingAccount.MakeDeposit(-5000, DateTime.Now, "invalid deposit.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid deposit caught.\n");
                Console.WriteLine($"{ex.Message}\n");
            }


            try
            {
                checkingAccount.MakeWithdrawal(5000, DateTime.Now, "Withdraw amount too high");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"{ex.Message}\n");
                Console.WriteLine("You do not have enough funds for this withdrawl.\n");
            }

            checkingAccount.MakeDeposit(150, DateTime.Now, "Venmo, bills");
            DateTime later = new DateTime(2022, 3, 5, 12, 30, 34);
            checkingAccount.MakeWithdrawal(750, later, "rent");

            Console.WriteLine(checkingAccount.GetAccountHistory());


            //test for gift card and savings
            var giftCard = new GiftCardAccount("Wood Ranch BBQ", 100, 50);
            giftCard.MakeWithdrawal(25, DateTime.Now, "To go order of Ribs");
            giftCard.MakeWithdrawal(50, DateTime.Now, "Dine in for two");
            giftCard.PerformMonthEndTransactions();
            giftCard.MakeDeposit(25, DateTime.Now, "add to balance.");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}