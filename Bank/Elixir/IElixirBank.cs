using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public interface IElixirBank
    {
        string BankIdentifier { get; }
        void ExecuteIncomingTransfers(List<IncomingTransfer> transfers);
        List<Transfer> GetOutgoingTransfers();
    }
}
