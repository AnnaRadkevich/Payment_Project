using Payment_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.PaymentMethods
{
    internal class CreditCard : PaymentCard
    {
        private decimal _interestOfLoan;
        private decimal _allowedCreditLimit;

        public decimal InterestOfLoan { get; }
        public decimal AllowedCreditLimit { get; set; }
        public CreditCard(string cardNumber, Validity cardExpiryDate, int cardCVV, decimal interestOfLoan, decimal allowedCreditLimit)
            : base(cardNumber, cardExpiryDate, cardCVV)
        {
            InterestOfLoan = interestOfLoan;
            AllowedCreditLimit = allowedCreditLimit;
        }
        public override bool MakePayment(decimal sum)
        {
            decimal sumWithPercentage = sum + sum * InterestOfLoan / 100M;
            if (IPayment.IsCanPay(sumWithPercentage, AllowedCreditLimit))
            {
                AllowedCreditLimit -= sumWithPercentage;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void TopUp(decimal amount)
        {
            AllowedCreditLimit += amount;
        }
        public override decimal GetBalance()
        {
            return AllowedCreditLimit;
        }
        public override string ToString()
        {
            return $"Credit Card Number: {CardNumber}, Card Expiry Date: {CardExpiryDate}, Card CVV: {CardCVV}," +
                $"\nInterest of a loan: {InterestOfLoan}%, allowed credit limit: {AllowedCreditLimit}";
        }
    }
}
