using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Unit
{
    [TestClass]
    public class AccountTest
    {
        private Account account;

        [TestInitialize]
        public void Initialize()
        {
            account = new Account("12345", "1000", 1000);
        }

        [TestMethod]
        public void WithdrawTest_Valid()
        {
            account.Withdraw(500.99);
            Assert.AreEqual(499.01, account.Balance, 0.0001);
        }

        [TestMethod]
        public void WithdrawTest_Valid2()
        {
            account.Withdraw(1000);
            Assert.AreEqual(0, account.Balance, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void WithdrawTest_Exception()
        {
            account.Withdraw(1100);
        }

        [TestMethod]
        public void DepositTest_Valid()
        {
            account.Deposit(100);
            Assert.AreEqual(1100, account.Balance, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void DepositTest_Exception()
        {
            account.Deposit(-10);
        }
    }
}
