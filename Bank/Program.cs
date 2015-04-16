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
            Console.WriteLine("Owner {0} {1} with PESEL {2} created.", owner2.FirstName, owner2.LastName, owner2.PESEL);
            string owner2AccountNum = owner2.OpenAccount();
            Console.WriteLine("Account with number {0} created", owner2AccountNum);

            bank.CreatePayment(owner1AccountNum, 1000);
            Console.WriteLine("Owner1 payment, balance: {0}", bank.GetAccount(owner1AccountNum).Balance);

            bank.CreatePayout(owner1AccountNum, 100);
            Console.WriteLine("Owner1 payout, balance: {0}", bank.GetAccount(owner1AccountNum).Balance);

            bank.CreateTransfer(owner1AccountNum, owner2AccountNum, 500);
            Console.WriteLine("Transfer: owner1's balance: {0}; owner2's balance: {1}", bank.GetAccount(owner1AccountNum).Balance, bank.GetAccount(owner2AccountNum).Balance);


            Console.ReadKey();
        }

    }
}
