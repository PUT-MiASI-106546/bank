using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class DepositsReport : IReport
    {
        public string ReportString { get; private set; }

        public void Visit(Payment payment)
        {
            ReportString += "Payment: account number: " + payment.Account.AccountNumber + ", amount: " + payment.Amount + "\n";
        }

        public void Visit(Payout payout)
        {

        }

        public void Visit(Transfer transfer)
        {
            if (transfer.TransferType == TransferType.Deposit)
                ReportString += "Transfer from " + transfer.FromAccount.AccountNumber + " to " + transfer.ToAccountNumber + ", amount: " + transfer.Amount + "\n";
        }
    }
}
