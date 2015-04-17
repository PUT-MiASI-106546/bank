using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Payout : IOperation
    {
        public IAccount Account { get; private set; }
        public double Amount { get; private set; }

        public Payout(IAccount account, double amount)
        {
            Account = account;
            Amount = amount;
        }

        public void Execute()
        {
            Account.Withdraw(Amount);
            Account.Operations.Add(this);
        }

        public void Accept(IReport report)
        {
            report.Visit(this);
        }
    }
}
