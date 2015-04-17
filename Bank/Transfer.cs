using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public enum TransferType { Charge, Deposit }

    public class Transfer : IOperation
    {
        private BankManager bankManager;
        public Account FromAccount { get; private set; }
        public string ToAccountNumber { get; private set; }
        public double Amount { get; private set; }
        public TransferType TransferType { get; set; }

        public Transfer(BankManager bankManager,  Account account, string accountNumber, double amount)
        {
            this.bankManager = bankManager;
            FromAccount = account;
            ToAccountNumber = accountNumber;
            Amount = amount;
            TransferType = Bank.TransferType.Charge;
        }

        public void Execute()
        {
            Account targetAccount = bankManager.GetAccount(ToAccountNumber);

            if (targetAccount != null)
            {
                FromAccount.Withdraw(Amount);
                targetAccount.Deposit(Amount);

                Transfer targetOperationCopy = new Transfer(bankManager, FromAccount, ToAccountNumber, Amount);
                targetOperationCopy.TransferType = Bank.TransferType.Deposit;
                targetAccount.Operations.Add(targetOperationCopy);
            }
            else
            {
                FromAccount.Withdraw(Amount);
                bankManager.PutOutgoingTransfer(this);
            }

            FromAccount.Operations.Add(this);
        }

        public void Accept(IReport report)
        {
            report.Visit(this);
        }
    }
}
