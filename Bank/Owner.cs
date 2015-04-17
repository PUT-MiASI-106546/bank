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

        public Owner(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            PESEL = pesel;

            Accounts = new Dictionary<string, IAccount>();
        }

        public string OpenAccount()
        {
            Account newAccount = new Account(PESEL);
            Accounts.Add(newAccount.AccountNumber, newAccount);

            return newAccount.AccountNumber;
        }

        public string OpenDebtAccount(double availableDebt)
        {
            Account newAccount = new Account(PESEL);
            Accounts.Add(newAccount.AccountNumber, new DebtAccount(newAccount, availableDebt));

            return newAccount.AccountNumber;
        }
    }
}
