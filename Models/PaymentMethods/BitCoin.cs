using Payment_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.PaymentMethods
{
    public class BitCoin : IPayment
    {
        private string _name;
        private decimal _balance;
        private decimal _exchangeRate;

        public string Name { get; }
        public decimal Balance { get; set; }
        public decimal ExchangeRate { get; }

        public BitCoin(string name, decimal balance, decimal exchangeRate)
        {
            Name = name;
            Balance = balance;
            ExchangeRate = exchangeRate;
        }
        public bool MakePayment(decimal amount)
        {
            decimal bitCoinAmount = amount / ExchangeRate;

            if (IPayment.IsCanPay(bitCoinAmount, Balance))
            {
                Balance -= bitCoinAmount;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void TopUp(decimal amount)
        {
            Balance += amount / ExchangeRate;
        }
        public decimal GetBalance()
        {
            return Balance;
        }
    }
}
