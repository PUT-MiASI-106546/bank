using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class FullReport : IReport
    {
        public string ReportString { get; private set; }

        public void Visit(Payment payment)
        {
            ReportString += "Payment: account number: " + payment.Account.AccountNumber + ", amount: " + payment.Amount + "\n";
        }

        public void Visit(Payout payout)
        {
            ReportString += "Payout: account number: " + payout.Account.AccountNumber + ", amount: " + payout.Amount + "\n";
        }

        public void Visit(Transfer transfer)
        {
            ReportString += "Transfer from " + transfer.FromAccount.AccountNumber + " to " + transfer.ToAccountNumber + ", amount: " + transfer.Amount + "\n";
        }

        public void Visit(IncomingTransfer transfer)
        {
        }
    }
}
