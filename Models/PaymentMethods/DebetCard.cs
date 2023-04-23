using Payment_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.PaymentMethods
{
    internal class DebetCard : PaymentCard
    {
        private decimal _depositInterest;
        private decimal _amountOfFunds;

        public decimal DepositInterest { get; }
        public decimal AmountOfFunds { get; set; }

        public DebetCard(string cardNumber, Validity cardExpiryDate, int cardCVV, decimal depositInterest, decimal amountOfFunds)
            : base(cardNumber, cardExpiryDate, cardCVV)
        {
            DepositInterest = depositInterest;
            AmountOfFunds = amountOfFunds;
        }
        public override bool MakePayment(decimal sum)
        {
            if (IPayment.IsCanPay(sum, AmountOfFunds))
            {
                AmountOfFunds -= sum;
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void TopUp(decimal amount)
        {
            AmountOfFunds += amount + amount * DepositInterest / 100;
        }
        public override decimal GetBalance()
        {
            return AmountOfFunds;
        }
        public override string ToString()
        {
            return $"Debet Card Number: {CardNumber}, Card Expiry Date: {CardExpiryDate}, Card CVV: {CardCVV}." +
                $"\nDeposit of interest: {DepositInterest}%, the amount of funds in the account: {AmountOfFunds}.";
        }
    }

}
