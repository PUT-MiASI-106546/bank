using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Unit
{
    [TestClass]
    public class AdvancedInterestTest
    {
        private AdvancedInterest interest;

        [TestInitialize]
        public void Initialize()
        {
            interest = new AdvancedInterest();
        }

        [TestMethod]
        public void ConutTest_Valid()
        {
            double counted = interest.Count(9999.99);
            Assert.AreEqual(2.7397, counted, 0.0001);

            counted = interest.Count(10000);
            Assert.AreEqual(1.3698, counted, 0.0001);

            counted = interest.Count(99999.99);
            Assert.AreEqual(13.6986, counted, 0.0001);

            counted = interest.Count(100000);
            Assert.AreEqual(5.4794, counted, 0.0001);
        }
    }
}
