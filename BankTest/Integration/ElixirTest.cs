using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Integration
{
    [TestClass]
    public class ElixirTest
    {
        private Elixir elixir;
        private BankManager bank1;
        private BankManager bank2;
        private Owner owner1;
        private Owner owner2;
        private Owner owner3;
        private IAccount owner1Account;
        private IAccount owner2Account;
        private IAccount owner3Account;

        [TestInitialize]
        public void Initialize()
        {
            bank1 = new BankManager("1000");
            bank2 = new BankManager("2000");

            elixir = new Elixir();
            elixir.Banks.Add(bank1.BankIdentifier, bank1);
            elixir.Banks.Add(bank2.BankIdentifier, bank2);

            owner1 = bank1.CreateOwner("Jan", "Kowalski", "12345678910");
            owner2 = bank2.CreateOwner("Anna", "Kowalski", "0987654321");
            owner3 = bank2.CreateOwner("Maria", "Nowak", "64632184623");

            string owner1AccountNum = owner1.OpenAccount();
            string owner2AccountNum = owner2.OpenAccount();
            string owner3AccountNum = owner3.OpenAccount();
            owner1Account = bank1.GetAccount(owner1AccountNum);
            owner2Account = bank2.GetAccount(owner2AccountNum);
            owner3Account = bank2.GetAccount(owner3AccountNum);
        }

        [TestMethod]
        public void TransferTest()
        {
            bank1.CreatePayment(owner1Account.AccountNumber, 1000);
            bank1.CreateTransfer(owner1Account.AccountNumber, owner2Account.AccountNumber, 500);
            bank1.CreateTransfer(owner1Account.AccountNumber, owner2Account.AccountNumber, 200);
            bank1.CreateTransfer(owner1Account.AccountNumber, owner3Account.AccountNumber, 100);

            elixir.ExecuteTransfers();

            Assert.AreEqual(200, owner1Account.Balance, 0.0001);
            Assert.AreEqual(700, owner2Account.Balance, 0.0001);
            Assert.AreEqual(100, owner3Account.Balance, 0.0001);
            Assert.AreEqual(4, owner1Account.Operations.Count);
            Assert.AreEqual(2, owner2Account.Operations.Count);
            Assert.AreEqual(1, owner3Account.Operations.Count);
        }

        [TestMethod]
        public void TransferTest2()
        {
            bank1.CreatePayment(owner1Account.AccountNumber, 1000);
            bank2.CreatePayment(owner2Account.AccountNumber, 1000);
            bank2.CreatePayment(owner3Account.AccountNumber, 1000);

            bank1.CreateTransfer(owner1Account.AccountNumber, owner2Account.AccountNumber, 500);
            bank2.CreateTransfer(owner2Account.AccountNumber, owner1Account.AccountNumber, 100);
            bank2.CreateTransfer(owner3Account.AccountNumber, owner1Account.AccountNumber, 100);

            elixir.ExecuteTransfers();

            Assert.AreEqual(700, owner1Account.Balance, 0.0001);
            Assert.AreEqual(1400, owner2Account.Balance, 0.0001);
            Assert.AreEqual(900, owner3Account.Balance, 0.0001);
            Assert.AreEqual(4, owner1Account.Operations.Count);
            Assert.AreEqual(3, owner2Account.Operations.Count);
            Assert.AreEqual(2, owner3Account.Operations.Count);
        }
    }
}
