using Payment_Project.Interfaces;
using Payment_Project.Models.BankClientInfo;
using Payment_Project.Models.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Project.Models
{
    internal class BankClient
    {
        private User _user;
        private Adress _userAdress;
        private static List<string> _paymentMethodsTypes = new() { "Cash", "Debet Card", "Credit Card", "CashBack", "BitCoin" };
        public User User { get; }
        public Adress UserAdress { get; }
        public List<IPayment> Payments { get; set; }

        public BankClient(User user, Adress userAdress, List<IPayment> payments)
        {
            User = user;
            UserAdress = userAdress;
            Payments = payments;
        }

        public bool Pay(decimal amount)
        {
            bool IsPayd = false;
            foreach (IPayment payment in Payments)
            {
                switch (payment)
                {
                    case Cash cash:
                        if (cash.MakePayment(amount))
                        {
                            IsPayd = true;
                        }
                        break;
                    case CashBackCard cashBack:
                        if (cashBack.MakePayment(amount))
                        {
                            IsPayd = true;
                        }
                        break;
                    case DebetCard debet:
                        if (debet.MakePayment(amount))
                        {
                            IsPayd = true;
                        }
                        break;
                    case CreditCard credit:
                        if (credit.MakePayment(amount))
                        {
                            IsPayd = true;
                        }
                        break;
                    case BitCoin bitcoin:
                        if (bitcoin.MakePayment(amount))
                        {
                            IsPayd = true;
                        }
                        break;
                }
                if (IsPayd)
                {
                    break;
                }
            }
            return IsPayd;
        }
        public void AddPaymentMethod(string paymentMethod, IPayment payment)
        {
            if (!_paymentMethodsTypes.Contains(paymentMethod))
            {
                return;
            }
            Payments.Add(payment);
        }
        public void GetBalanceOfAllCards(List<IPayment> Payments)
        {
            Console.WriteLine($"Client: {User}, Adress: {UserAdress}");
            foreach (IPayment payment in Payments)
            {
                switch (payment)
                {
                    case Cash cash:
                        Console.WriteLine($"Cash: {cash.GetBalance()}");
                        break;
                    case CashBackCard cashBackCard:
                        Console.WriteLine($"CashBack Card: {cashBackCard.GetBalance()}");
                        break;
                    case DebetCard debetCard:
                        Console.WriteLine($"Debet Card: {debetCard.GetBalance()}");
                        break;
                    case CreditCard creditCard:
                        Console.WriteLine($"Credit Card: {creditCard.GetBalance()}");
                        break;
                    case BitCoin bitcoin:
                        Console.WriteLine($"BitCoin: {bitcoin.GetBalance()}");
                        break;
                }
            }
        }
    }
}
