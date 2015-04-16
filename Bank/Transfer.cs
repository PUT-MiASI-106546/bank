using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Transfer : IOperation
    {
        private BankManager bankManager;
        private Account account;
        private string accountNumber;
        private double amount;

        public Transfer(BankManager bankManager,  Account account, string accountNumber, double amount)
        {
            this.bankManager = bankManager;
            this.account = account;
            this.accountNumber = accountNumber;
            this.amount = amount;
        }

        public void Execute()
        {
            Account targetAccount = bankManager.GetAccount(accountNumber);

            if (targetAccount != null)
            {
                account.Withdraw(amount);
                targetAccount.Deposit(amount);
            }
            else
            {
                account.Withdraw(amount);
                bankManager.PutOutgoingTransfer(this);
            }

            account.Operations.Add(this);
        }
    }
}
