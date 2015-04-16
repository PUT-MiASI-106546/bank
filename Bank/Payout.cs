using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Payout : IOperation
    {
        private Account account;
        private double amount;

        public Payout(Account account, double amount)
        {
            this.account = account;
            this.amount = amount;
        }

        public void Execute()
        {
            account.Withdraw(amount);
            account.Operations.Add(this);
        }
    }
}
