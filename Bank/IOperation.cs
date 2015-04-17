﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public interface IOperation
    {
        void Execute();
        void Accept(IReport report);
    }
}
