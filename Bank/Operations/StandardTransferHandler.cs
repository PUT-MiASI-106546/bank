using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class StandardTransferHandler : TransferHandler
    {
        public override void ProcessTransfer(Transfer transfer)
        {
            if (transfer.Amount <= 20000)
            {
                transfer.Execute();
            }
            else
            {
                if (Next != null)
                { 
                    Next.ProcessTransfer(transfer);
                }
            }
        }
    }
}
