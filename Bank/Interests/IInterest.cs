using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public interface IInterest
    {
        double Count(double amount);
    }
}
