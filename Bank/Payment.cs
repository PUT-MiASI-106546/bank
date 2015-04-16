using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Payment : IOperation
    {
        private Account account;
        private double amount;

        public Payment(Account account, double amount)
        {
            this.account = account;
            this.amount = amount;
        }

        public void Execute()
        {
            account.Deposit(amount);
            account.Operations.Add(this);
        }
    }
}
