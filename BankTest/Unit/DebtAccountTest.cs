using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Unit
{
    [TestClass]
    public class DebtAccountTest
    {
        private DebtAccount account;

        [TestInitialize]
        public void Initialize()
        {
            Account account = new Account("12345", "1000", 100);
            this.account = new DebtAccount(account, 100);
        }

        [TestMethod]
        public void WithdrawTest_Valid()
        {
            account.Withdraw(50.99);
            Assert.AreEqual(49.01, account.Balance, 0.0001);
            Assert.AreEqual(100, account.AvailableDebt, 0.0001);
        }

        [TestMethod]
        public void WithdrawTest_Valid2()
        {
            account.Withdraw(150);
            Assert.AreEqual(0, account.Balance, 0.0001);
            Assert.AreEqual(50, account.AvailableDebt, 0.0001);
        }

        [TestMethod]
        public void WithdrawTest_Valid3()
        {
            account.Withdraw(200);
            Assert.AreEqual(0, account.Balance, 0.0001);
            Assert.AreEqual(0, account.AvailableDebt, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void WithdrawTest_Exception()
        {
            account.Withdraw(201);
        }

        [TestMethod]
        public void DepositTest_Valid()
        {
            account.Deposit(100);
            Assert.AreEqual(200, account.Balance, 0.0001);
            Assert.AreEqual(100, account.AvailableDebt, 0.0001);
        }

        [TestMethod]
        public void DepositTest_Valid2()
        {
            account.Withdraw(150);
            account.Deposit(20);
            Assert.AreEqual(0, account.Balance, 0.0001);
            Assert.AreEqual(70, account.AvailableDebt, 0.0001);
        }

        [TestMethod]
        public void DepositTest_Valid3()
        {
            account.Withdraw(150);
            account.Deposit(100);
            Assert.AreEqual(50, account.Balance, 0.0001);
            Assert.AreEqual(100, account.AvailableDebt, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void DepositTest_Exception()
        {
            account.Deposit(-10);
        }
    }
}
