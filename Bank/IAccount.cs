using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public interface IAccount
    {
        double Balance { get; }
        String AccountNumber { get; }
        List<IOperation> Operations { get; }

        void Withdraw(double amount);
        void Deposit(double amount);
        string GetReport(IReport report);
    }
}
