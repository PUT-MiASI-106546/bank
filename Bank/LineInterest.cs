using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class LineInterest : IInterest
    {
        public double Count(double amount)
        {
            return (0.05 * amount) / 365;
        }
    }
}
