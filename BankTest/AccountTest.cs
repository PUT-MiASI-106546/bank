using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        private Account account;

        [TestInitialize]
        public void Initialize()
        {
            account = new Account("12345", 1000);
        }

        [TestMethod]
        public void WithdrawTest_Valid()
        {
            account.Withdraw(500.99);
            Assert.AreEqual(499.01, account.Balance, 0.0001);
        }
    }
}
