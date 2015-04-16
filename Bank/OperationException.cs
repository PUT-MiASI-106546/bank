using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class OperationException: Exception
    {
        public OperationException(String message) : base(message)
        {

        }
    }
}
