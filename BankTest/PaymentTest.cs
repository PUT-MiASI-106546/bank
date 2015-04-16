using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest
{
    [TestClass]
    public class PaymentTest
    {
        private Account account;

        [TestInitialize]
        public void Initialize()
        {
            account = new Account("123");
        }

        [TestMethod]
        public void ExecuteTest_CorrectAmount()
        {
            Payment payment = new Payment(account, 10.5);
            payment.Execute();

            Assert.AreEqual(10.5, account.Balance, 0.001);
        }
    }
}
