using Payment_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.PaymentMethods
{
    internal class Cash : IPayment

    {
        private string _name;
        private decimal _balance;

        public string Name { get; }
        public decimal Balance { get; set; }

        public Cash(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }
        public bool MakePayment(decimal amount)
        {

            if (IPayment.IsCanPay(amount, Balance))
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void TopUp(decimal amount)
        {
            Balance += amount;
        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
