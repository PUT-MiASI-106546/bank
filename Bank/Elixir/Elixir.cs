using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Elixir
    {
        public Dictionary<String, IElixirBank> Banks { get; private set; }
        private List<Transfer> transfers = new List<Transfer>();

        public Elixir()
        {
            Banks = new Dictionary<string, IElixirBank>();
        }

        //public void PutTransfers(List<Transfer> transfers)
        //{
        //    transfers.AddRange(transfers);
        //}

        public void ExecuteTransfers()
        {
            List<Transfer> transfers = FetchTransfers();
            Dictionary<IElixirBank, List<IncomingTransfer>> groupedTransfers = GroupTransfers(transfers);

            foreach (IElixirBank bank in groupedTransfers.Keys)
            {
                bank.ExecuteIncomingTransfers(groupedTransfers[bank]);
            }
        }

        private List<Transfer> FetchTransfers()
        {
            List<Transfer> transfers = new List<Transfer>();

            foreach (IElixirBank bank in Banks.Values)
            {
                transfers.AddRange(bank.GetOutgoingTransfers());
            }

            return transfers;
        }

        private Dictionary<IElixirBank, List<IncomingTransfer>> GroupTransfers(List<Transfer> transfers)
        {
            Dictionary<IElixirBank, List<IncomingTransfer>> groupedTransfers = new Dictionary<IElixirBank, List<IncomingTransfer>>();

            foreach (Transfer transfer in transfers)
            {
                string bankIdentifier = transfer.ToAccountNumber.Substring(0, 4);

                if (Banks.ContainsKey(bankIdentifier))
                {
                    IElixirBank bank = Banks[bankIdentifier];
                    if (!groupedTransfers.ContainsKey(bank))
                    {
                        groupedTransfers[bank] = new List<IncomingTransfer>();
                    }           

                    IncomingTransfer incomingTransfer = new IncomingTransfer((BankManager)bank, transfer.FromAccount.AccountNumber, transfer.ToAccountNumber, transfer.Amount);
                    groupedTransfers[bank].Add(incomingTransfer);
                }

                
            }

            return groupedTransfers;
        }
    }
}
