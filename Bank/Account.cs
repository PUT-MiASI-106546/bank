using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Account : IAccount
    {
        private Interest interest = new Interest(new LineInterest());
        private static Random randomGenerator = new Random();

        public double Balance { get; private set; }

        public String AccountNumber { get; private set; }

        public List<IOperation> Operations { get; private set; }

        public Account(String PESEL, string bankIdentifier, double balance = 0)
        {
            AccountNumber = bankIdentifier + randomGenerator.Next(10000, 99999).ToString();
            Balance = balance;
            Operations = new List<IOperation>();
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
                Balance -= amount;
            else
                throw new OperationException("Account balance is too low.");
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new OperationException("Invalid amount.");
            else
                Balance += amount;
        }

        public string GetReport(IReport report)
        {
            foreach (IOperation operation in Operations)
            {
                operation.Accept(report);
            }

            return report.ReportString;
        }
    }
}
