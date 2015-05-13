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
            //OperationsReportsTest();
            ElixirTest();

            Console.ReadKey();
        }

        public static void OperationsReportsTest()
        {
            BankManager bank = new BankManager("1000");

            Owner owner1 = bank.CreateOwner("Jan", "Kowalski", "123456");
            Console.WriteLine("Owner {0} {1} with PESEL {2} created.", owner1.FirstName, owner1.LastName, owner1.PESEL);
            string owner1AccountNum = owner1.OpenAccount();
            Console.WriteLine("Account with number {0} created", owner1AccountNum);

            Owner owner2 = bank.CreateOwner("Anna", "Kowalska", "654321");
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
        }

        public static void ElixirTest()
        {
            BankManager bank1 = new BankManager("1000");
            BankManager bank2 = new BankManager("2000");

            Elixir elixir = new Elixir();
            elixir.Banks.Add(bank1.BankIdentifier, bank1);
            elixir.Banks.Add(bank2.BankIdentifier, bank2);

            Owner owner1 = bank1.CreateOwner("Jan", "Kowalski", "123456");
            Console.WriteLine("Owner {0} {1} with PESEL {2} created.", owner1.FirstName, owner1.LastName, owner1.PESEL);
            string owner1AccountNum = owner1.OpenAccount();
            Console.WriteLine("Account with number {0} created", owner1AccountNum);

            Owner owner2 = bank2.CreateOwner("Anna", "Kowalska", "654321");
            Console.WriteLine("\nOwner {0} {1} with PESEL {2} created.", owner2.FirstName, owner2.LastName, owner2.PESEL);
            string owner2AccountNum = owner2.OpenAccount();
            Console.WriteLine("Account with number {0} created", owner2AccountNum);

            bank1.CreatePayment(owner1AccountNum, 1000);
            Console.WriteLine("\nOwner1 payment, balance: {0}", bank1.GetAccount(owner1AccountNum).Balance);

            bank1.CreateTransfer(owner1AccountNum, owner2AccountNum, 500);
            bank1.CreateTransfer(owner1AccountNum, owner2AccountNum, 200);
            elixir.ExecuteTransfers();
            Console.WriteLine("Transfer 500 + 200 from o1 to o2: owner1's balance: {0}; owner2's balance: {1}", bank1.GetAccount(owner1AccountNum).Balance, bank2.GetAccount(owner2AccountNum).Balance);

            bank1.CreateTransfer(owner1AccountNum, owner2AccountNum, 100);
            bank2.CreateTransfer(owner2AccountNum, owner1AccountNum, 200);
            elixir.ExecuteTransfers();
            Console.WriteLine("Transfer 100 from o1 to o2, 200 from o2 to o1: owner1's balance: {0}; owner2's balance: {1}", bank1.GetAccount(owner1AccountNum).Balance, bank2.GetAccount(owner2AccountNum).Balance);

        }

    }
}
