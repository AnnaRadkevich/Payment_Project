using Payment_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.PaymentMethods
{
    internal class CashBackCard : PaymentCard
    {
        private decimal _interest;
        private decimal _balance;

        public decimal Interest { get; }
        public decimal Balance { get; set; }

        public CashBackCard(string cardNumber, Validity cardExpiryDate, int cardCVV, decimal interest, decimal balance)
            : base(cardNumber, cardExpiryDate, cardCVV)
        {
            Interest = interest;
            Balance = balance;
        }

        public override bool MakePayment(decimal sum)
        {
            if (IPayment.IsCanPay(sum, Balance))
            {
                Balance -= sum + sum * Interest / 100M;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void TopUp(decimal amount)
        {
            Balance += amount;
        }
        public override decimal GetBalance()
        {
            return Balance;
        }

        public override string ToString()
        {
            return $"CashBack Card Number: {CardNumber}, Card Expiry Date: {CardExpiryDate}, Card CVV: {CardCVV}." +
                $"\nInterest: {Interest}%, Balance: {Balance}.";

        }
    }
}
