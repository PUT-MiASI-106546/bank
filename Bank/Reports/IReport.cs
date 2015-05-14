using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public interface IReport
    {
        string ReportString { get; }

        void Visit(Payment payment);
        void Visit(Payout payout);
        void Visit(Transfer transfer);
        void Visit(IncomingTransfer incomingTransfer);
    }
}
