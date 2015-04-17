using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankManager bank = new BankManager();

            bank.CreateOwner("Jan", "Kowalski", "123456");
            Owner owner1 = bank.GetOwner("123456");
            Console.WriteLine("Owner {0} {1} with PESEL {2} created.", owner1.FirstName, owner1.LastName, owner1.PESEL);
            string owner1AccountNum = owner1.OpenAccount();
            Console.WriteLine("Account with number {0} created", owner1AccountNum);

            bank.CreateOwner("Anna", "Kowalska", "654321");
            Owner owner2 = bank.GetOwner("654321");
            Console.WriteLine("\nOwner {0} {1} with PESEL {2} created.", owner2.FirstName, owner2.LastName, owner2.PESEL);
            string owner2AccountNum = owner2.OpenAccount();
            Console.WriteLine("Account with number {0} created", owner2AccountNum);

            bank.CreatePayment(owner1AccountNum, 1000);
            Console.WriteLine("\nOwner1 payment, balance: {0}", bank.GetAccount(owner1AccountNum).Balance);

            bank.CreatePayout(owner1AccountNum, 100);
            Console.WriteLine("Owner1 payout, balance: {0}", bank.GetAccount(owner1AccountNum).Balance);

            bank.CreateTransfer(owner1AccountNum, owner2AccountNum, 500);
            Console.WriteLine("Transfer: owner1's balance: {0}; owner2's balance: {1}", bank.GetAccount(owner1AccountNum).Balance, bank.GetAccount(owner2AccountNum).Balance);

            string owner1DebtAccountNum = owner1.OpenDebtAccount(200);
            Console.WriteLine("\nDebt account with number {0} and 200 debt created", owner1DebtAccountNum);

            bank.CreatePayment(owner1DebtAccountNum, 10);
            Console.WriteLine("Owner1 payment, balance: {0}", bank.GetAccount(owner1DebtAccountNum).Balance);

            bank.CreatePayout(owner1DebtAccountNum, 100);
            Console.WriteLine("Owner1 payout, balance: {0}, available debt: {1}", bank.GetAccount(owner1DebtAccountNum).Balance, ((DebtAccount)bank.GetAccount(owner1DebtAccountNum)).AvailableDebt);

            bank.CreatePayment(owner1DebtAccountNum, 100);
            Console.WriteLine("Owner1 payment, balance: {0}, available debt: {1}", bank.GetAccount(owner1DebtAccountNum).Balance, ((DebtAccount)bank.GetAccount(owner1DebtAccountNum)).AvailableDebt);

            Console.WriteLine("\nFull report:\n" + bank.CreateFullReport(owner1AccountNum));

            Console.WriteLine("\nCharges report:\n" + bank.CreateChargesReport(owner1AccountNum));

            Console.WriteLine("\nDeposits report:\n" + bank.CreateDepositsReport(owner1AccountNum));

            Console.ReadKey();
        }

    }
}
