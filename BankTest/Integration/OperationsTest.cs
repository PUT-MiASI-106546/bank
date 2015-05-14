using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Integration
{
    [TestClass]
    public class OperationsTest
    {
        private BankManager bank;
        private Owner owner1;
        private Owner owner2;
        private IAccount owner1Account;
        private IAccount owner2Account;

        [TestInitialize]
        public void Initialize()
        {
            bank = new BankManager("1000");
            owner1 = bank.CreateOwner("Jan", "Kowalski", "12345678910");
            owner2 = bank.CreateOwner("Anna", "Kowalski", "0987654321");

            string owner1AccountNum = owner1.OpenAccount();
            string owner2AccountNum = owner2.OpenAccount();
            owner1Account = bank.GetAccount(owner1AccountNum);
            owner2Account = bank.GetAccount(owner2AccountNum);
        }

        [TestMethod]
        public void PaymentTest_Valid()
        {
            bank.CreatePayment(owner1Account.AccountNumber, 1000);
            Assert.AreEqual(1000, owner1Account.Balance, 0.0001);
            Assert.AreEqual(1, owner1Account.Operations.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void PaymentTest_Error()
        {
            bank.CreatePayment(owner1Account.AccountNumber, -0.01);
        }

        [TestMethod]
        public void PayoutTest_Valid()
        {
            bank.CreatePayment(owner1Account.AccountNumber, 1000);
            bank.CreatePayout(owner1Account.AccountNumber, 500);
            Assert.AreEqual(500, owner1Account.Balance, 0.0001);
            Assert.AreEqual(2, owner1Account.Operations.Count);
        }

        [TestMethod]
        public void PayoutTest_Valid2()
        {
            bank.CreatePayment(owner1Account.AccountNumber, 1000);
            bank.CreatePayout(owner1Account.AccountNumber, 1000);
            Assert.AreEqual(0, owner1Account.Balance, 0.0001);
            Assert.AreEqual(2, owner1Account.Operations.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void PayoutTest_Error()
        {
            bank.CreatePayment(owner1Account.AccountNumber, 1000);
            bank.CreatePayout(owner1Account.AccountNumber, 1000.01);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void PayoutTest_Error2()
        {
            bank.CreatePayment(owner1Account.AccountNumber, 1000);
            bank.CreatePayout(owner1Account.AccountNumber, -0.01);
        }

        [TestMethod]
        public void TransferTest_Valid()
        {
            bank.CreatePayment(owner1Account.AccountNumber, 1000);

            bank.CreateTransfer(owner1Account.AccountNumber, owner2Account.AccountNumber, 500);
            bank.CreateTransfer(owner2Account.AccountNumber, owner1Account.AccountNumber, 100);
            Assert.AreEqual(600, owner1Account.Balance, 0.0001);
            Assert.AreEqual(400, owner2Account.Balance, 0.0001);
            Assert.AreEqual(3, owner1Account.Operations.Count);
            Assert.AreEqual(2, owner2Account.Operations.Count);
        }
    }
}
