using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Payment : IOperation
    {
        public Account Account { get; private set; }
        public double Amount { get; private set; }

        public Payment(Account account, double amount)
        {
            Account = account;
            Amount = amount;
        }

        public void Execute()
        {
            Account.Deposit(Amount);
            Account.Operations.Add(this);
        }

        public void Accept(IReport report)
        {
            report.Visit(this);
        }
    }
}
