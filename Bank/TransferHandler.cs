using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class TransferHandler
    {
        public TransferHandler Next { get; set; }

        public abstract void ProcessTransfer(Transfer transfer);
    }
}
