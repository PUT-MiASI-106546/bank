using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Owner
    {  
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String PESEL { get; set; }

        public Dictionary<string, IAccount> Accounts { get; private set; }

        private string bankIdentifier;

        public Owner(string firstName, string lastName, string pesel, string bankIdentifier)
        {
            FirstName = firstName;
            LastName = lastName;
            PESEL = pesel;
            this.bankIdentifier = bankIdentifier;

            Accounts = new Dictionary<string, IAccount>();
        }

        public string OpenAccount()
        {
            Account newAccount = new Account(PESEL, bankIdentifier);
            Accounts.Add(newAccount.AccountNumber, newAccount);

            return newAccount.AccountNumber;
        }

        public string OpenDebtAccount(double availableDebt)
        {
            Account newAccount = new Account(PESEL, bankIdentifier);
            Accounts.Add(newAccount.AccountNumber, new DebtAccount(newAccount, availableDebt));

            return newAccount.AccountNumber;
        }
    }
}
