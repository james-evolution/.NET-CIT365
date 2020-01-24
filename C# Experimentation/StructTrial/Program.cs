using System;

namespace StructTrial
{
    enum AccountState
    {
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    };

    struct Account
    {
        public AccountState State;
        public string Name;
        public string Address;
        public int AccountNumber;
        public int Balance;
        public int Overdraft;
    }
    class Program
    {
        public static void Main(string[] args)
        {
            const int MAX_CUST = 100;
            Account[] Bank = new Account[MAX_CUST];
            Bank[0].State = AccountState.Active;
            Bank[0].Name = "Selene";
            Bank[0].Address = "7331 Waterdeep Way";
            Bank[0].Balance = 1000000;
            Bank[0].Overdraft = 50000;

            /* 
             * This initially said "Account JamesAccount;" and compiled without error.
             * However, I wasn't able to pass it to PrintAccountDetails() as an argument until
             * adding "= new Account();" to the variable declaration. I assume it requires initialization
             * with some sort of invisible struct constructor method.
             * Try checking out VisualStudio's suggested simplification to the below code. 
             * Remember both approaches.
             */
            Account JamesAccount = new Account();
            JamesAccount.State = AccountState.Active;
            JamesAccount.Name = "Jeremy James";
            JamesAccount.Address = "1337 Athkatla Avenue";
            JamesAccount.Balance = 1000000;
            JamesAccount.Overdraft = 50000;

            Bank[1] = JamesAccount;

            PrintAccountDetails(Bank[0]);
            PrintAccountDetails(JamesAccount);
            PrintAccountDetails(Bank[1]);
        }

        public static void PrintAccountDetails(Account account)
        {
            Console.WriteLine("Account State: " + account.State);
            Console.WriteLine("Name: " + account.Name);
            Console.WriteLine("Address: " + account.Address);
            Console.WriteLine("Balance: " + account.Balance);
            Console.WriteLine("Overdraft: " + account.Overdraft + "\n");
        }
    }
}
