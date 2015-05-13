using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class IncomingTransfer : IOperation
    {
        private BankManager bankManager;
        public string FromAccountNumber { get; private set; }
        public string ToAccountNumber { get; private set; }
        public double Amount { get; private set; }

        public IncomingTransfer(BankManager bankManager, string fromAccountNumber, string toAccountNumber, double amount)
        {
            this.bankManager = bankManager;
            FromAccountNumber = fromAccountNumber;
            ToAccountNumber = toAccountNumber;
            Amount = amount;
        }

        public void Execute()
        {
            IAccount targetAccount = bankManager.GetAccount(ToAccountNumber);

            if (targetAccount != null)
            {
                targetAccount.Deposit(Amount);
                targetAccount.Operations.Add(this);
            }
        }


        public void Accept(IReport report)
        {
            report.Visit(this);
        }
    }
}
