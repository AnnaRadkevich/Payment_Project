using Payment_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models.PaymentMethods
{
    internal abstract class PaymentCard : IPayment
    {
        private string _cardNumber;
        private Validity _cardExpiryDate;

        private int _cardCVV;

        public string CardNumber { get; }
        public Validity CardExpiryDate { get; }

        public int CardCVV { get; }
        public PaymentCard(string cardNumber, Validity cardExpiryDate, int cardCVV)
        {
            CardNumber = cardNumber;
            CardExpiryDate = cardExpiryDate;
            CardCVV = cardCVV;
        }
        public abstract bool MakePayment(decimal sum);
        public abstract void TopUp(decimal amount);
        public abstract decimal GetBalance();
        public override string ToString()
        {
            return $"Card Number: {CardNumber}, Card Expiry Date: {CardExpiryDate}, Card CVV: {CardCVV} ";
        }

    }
}
