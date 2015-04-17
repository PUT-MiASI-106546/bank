using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class AccountDecorator : IAccount
    {
        protected IAccount account;

        public double Balance
        {
            get { return account.Balance; }
        }

        public string AccountNumber
        {
            get { return account.AccountNumber; }
        }

        public List<IOperation> Operations
        {
            get { return account.Operations; }
        }

        public AccountDecorator(IAccount account)
        {
            this.account = account;
        }

        public virtual void Withdraw(double amount)
        {
             account.Withdraw(amount);
        }

        public virtual void Deposit(double amount)
        {
            account.Deposit(amount);
        }

        public virtual string GetReport(IReport report)
        {
            return account.GetReport(report);
        }
    }
}
