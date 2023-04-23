using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Interfaces
{
    internal interface IPayment
    {
        public bool MakePayment(decimal amount);
        public void TopUp(decimal amount);
        public decimal GetBalance();
        public static bool IsCanPay(decimal amount, decimal availableFunds)
        {
            return availableFunds >= amount;
        }
    }
}
