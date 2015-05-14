using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Unit
{
    [TestClass]
    public class BankManagerTest
    {
        private BankManager bank;

        [TestInitialize]
        public void Initialize()
        {
            bank = new BankManager("1000");
        }

        [TestMethod]
        public void ConstructorValid()
        {
            Assert.AreEqual("1000", bank.BankIdentifier);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorError()
        {
            BankManager bank = new BankManager("123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorError2()
        {
            BankManager bank = new BankManager("12345");
        }

        [TestMethod]
        public void CreateOwnerTest()
        {
            Owner owner = bank.CreateOwner("Jan", "Kowalski", "12345678910");
            Owner owner2 = bank.CreateOwner("Anna", "Kowalski", "0987654321");
            Assert.AreEqual(owner, bank.GetOwner("12345678910"));
            Assert.AreEqual(owner2, bank.GetOwner("0987654321"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateOwnerError()
        {
            bank.CreateOwner("Jan", "Kowalski", "12345678910");
            bank.CreateOwner("Anna", "Kowalski", "12345678910");
        }

        [TestMethod]
        public void GetOwnerTest()
        {
            Owner owner = bank.CreateOwner("Jan", "Kowalski", "12345678910");
            Assert.AreEqual(null, bank.GetOwner("1234"));
        }
    }
}
