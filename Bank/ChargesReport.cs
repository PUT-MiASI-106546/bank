using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class ChargesReport : IReport
    {
        public string ReportString { get; private set; }

        public void Visit(Payment payment)
        {
            
        }

        public void Visit(Payout payout)
        {
            ReportString += "Payout: account number: " + payout.Account.AccountNumber + ", amount: " + payout.Amount + "\n";
        }

        public void Visit(Transfer transfer)
        {
            if (transfer.TransferType == TransferType.Charge)
                ReportString += "Transfer from " + transfer.FromAccount.AccountNumber + " to " + transfer.ToAccountNumber + ", amount: " + transfer.Amount + "\n";
        }

        public void Visit(IncomingTransfer incomingTransfer)
        {
        }
    }
}
