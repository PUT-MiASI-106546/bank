﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class BankManager
    {
        private Dictionary<string, Owner> owners = new Dictionary<string, Owner>();
        private List<Transfer> outgoingTransfers = new List<Transfer>();

        public void CreateOwner(string firstName, string lastName, string pesel)
        {
            Owner owner = new Owner(firstName, lastName, pesel);
            owners.Add(pesel, owner);
        }

        public Owner GetOwner(string pesel)
        {
            if (owners.ContainsKey(pesel))
                return owners[pesel];
            else
                return null;
        }

        /// <summary>
        /// Zwraca obiekt typu Account identyfikujacy sie zadanym parametrem accountNumber.
        /// Jesli Account nie istnieje, zwraca null.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public Account GetAccount(string accountNumber)
        {
            foreach(Owner owner in owners.Values)
            {
                if (owner.Accounts.ContainsKey(accountNumber))
                    return owner.Accounts[accountNumber];
            }

            return null;
        }

        public void PutOutgoingTransfer(Transfer transfer)
        {
            outgoingTransfers.Add(transfer);
        }

        public void CreatePayment(string accountNumber, double amount)
        {
            Account account = GetAccount(accountNumber);
            Payment payment = new Payment(account, amount);
            payment.Execute();
        }

        public void CreatePayout(string accountNumber, double amount)
        {
            Account account = GetAccount(accountNumber);
            Payout payout = new Payout(account, amount);
            payout.Execute();
        }

        public void CreateTransfer(string fromAccountNumber, string toAccountNumber, double amount)
        {
            Account account = GetAccount(fromAccountNumber);
            Transfer transfer = new Transfer(this, account, toAccountNumber, amount);
            transfer.Execute();
        }
    }
}
