using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class DebtAccount : AccountDecorator
    {
        private double debtLimit;
        public double AvailableDebt { get; set; }

        public DebtAccount(IAccount account, double availableDebt)
            : base(account)
        {
            this.AvailableDebt = debtLimit = availableDebt;
        }

        public override void Withdraw(double amount)
        {   
            double diff = Balance - amount;

            if (diff >= 0)
            {
                base.Withdraw(amount);
            }
            else
            {
                account.Withdraw(Balance);

                if (AvailableDebt + diff >= 0)
                {
                    AvailableDebt += diff;
                }
                else 
                {
                    throw new OperationException("Available debt is too low.");
                }
            }
        }

        public override void Deposit(double amount)
        {
            double addToAvailableDebt = debtLimit - AvailableDebt;
            double addToBalance = amount - addToAvailableDebt;

            if (addToBalance > 0)
            {
                AvailableDebt += addToAvailableDebt;
                base.Deposit(addToBalance);
            }
            else
            {
                AvailableDebt += amount;
            }
        }
    }
}
