using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Unit
{
    [TestClass]
    public class OwnerTest
    {
        private Owner owner;

        [TestInitialize]
        public void Initialize()
        {
            owner = new Owner("Jan", "Kowalski", "12345678910", "1000");
        }

        [TestMethod]
        public void OpenAccountTest()
        {
            owner.OpenAccount();
            Assert.AreEqual(1, owner.Accounts.Count);

            owner.OpenAccount();
            Assert.AreEqual(2, owner.Accounts.Count);
        }

        [TestMethod]
        public void OpenDebtAccountTest()
        {
            owner.OpenDebtAccount(10);
            Assert.AreEqual(1, owner.Accounts.Count);

            owner.OpenDebtAccount(100);
            Assert.AreEqual(2, owner.Accounts.Count);
        }
    }
}
