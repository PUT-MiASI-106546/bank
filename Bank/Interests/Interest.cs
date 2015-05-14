using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Interest
    {
        private IInterest currentInterest;

        public Interest(IInterest interest)
        {
            currentInterest = interest;
        }

        public void SetInterest(IInterest interest)
        {
            currentInterest = interest;
        }

        public double Count(double amount)
        {
            return currentInterest.Count(amount);
        }
    }
}
