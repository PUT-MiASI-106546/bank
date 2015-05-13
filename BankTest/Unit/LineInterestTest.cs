using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest.Unit
{
    [TestClass]
    public class LineInterestTest
    {
        private LineInterest interest;

        [TestInitialize]
        public void Initialize()
        {
            interest = new LineInterest();
        }

        [TestMethod]
        public void CountTest_Valid()
        {
            double counted = interest.Count(100);
            Assert.AreEqual(0.0136, counted, 0.0001);
        }
    }
}
