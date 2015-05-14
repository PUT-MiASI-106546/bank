using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class HighTransferHandler : TransferHandler
    {
        public override void ProcessTransfer(Transfer transfer)
        {
            if (transfer.Amount > 20000)
            {
                NotifyTaxOffice();
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

        private void NotifyTaxOffice()
        {
            Console.WriteLine("Notifying tax office: transfer above 20 000.");
        }
    }
}
