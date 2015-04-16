using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Account
    {
        public const String bankIdentifier = "1000";
        private Interest interest = new Interest(new LineInterest());
        private static Random randomGenerator = new Random();

        public double Balance { get; set; }

        public String AccountNumber { get; set; }

        public List<IOperation> Operations { get; private set; }

        public Account(String PESEL, double balance = 0)
        {
            AccountNumber = bankIdentifier + randomGenerator.Next(10000, 99999).ToString();
            Balance = balance;
            Operations = new List<IOperation>();
        }

        public void Withdraw(double amount)
        {
            if (Balance - amount >= 0)
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
    }
}
