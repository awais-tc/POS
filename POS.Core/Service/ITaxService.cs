using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Service
{
    public interface ITaxService
    {
        public double CalculateTax(double amount, double taxRate);

    }
}
