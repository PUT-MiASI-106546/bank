using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class AdvancedInterest : IInterest
    {
        public double Count(double amount)
        {
            if (amount < 10000)
            {
                return (amount * 0.1) / 365;
            }
            else if (amount < 100000)
            {
                return (amount * 0.05) / 365;
            }
            else
            {
                return (amount * 0.02) / 365;
            }
        }
    }
}
