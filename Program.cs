using Payment_Project.Interfaces;
using Payment_Project.Models;
using Payment_Project.Models.BankClientInfo;
using Payment_Project.Models.PaymentMethods;

namespace Payment_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adress adress1 = new Adress("Minsk", "Lenina", 88, 16);
            Adress adress2 = new Adress("Soligorsk", "Stroiteley", 99, 15);

            User user1 = new User("Hanna", "Lemutova", "+375447854225");
            User user2 = new User("Ivan", "Tolkachev", "+375298764589");

            Product glasses = new Product("glasses", 500);
            Product IPhone = new Product("Iphone", 2000);
            Product table = new Product("table", 800);

            BankClient client1 = new BankClient(user1, adress1, new List<IPayment>{});
            var paymentMethod1 = new Cash("Cash", 300);
            var paymentMethod2 = new CashBackCard("4400 5588 5514", new Validity(2025, 5),558, 1.5M, 200);
            var paymentMethod3 = new DebetCard("4721 0525 5242", new Validity(2026, 8), 888, 1.0M, 1500);
            var paymentMethod4 = new CreditCard("4820 8245 4535", new Validity(2027, 1), 558, 2.5M, 5000);

            client1.AddPaymentMethod("Cash", paymentMethod1);
            client1.AddPaymentMethod("CashBack", paymentMethod2);
            client1.AddPaymentMethod("Debet Card", paymentMethod3);
            client1.AddPaymentMethod("Credit Card", paymentMethod4);

            client1.Pay(glasses.ProductPrice);
            client1.GetBalanceOfAllCards(client1.Payments);

            
            var paymentMethod5 = new Cash("Cash", 500);
            var paymentMethod6 = new CashBackCard("4400 5588 5514", new Validity(2025, 5), 558, 1.5M, 1800);
            var paymentMethod7 = new DebetCard("4721 0525 5242", new Validity(2026, 8), 888, 1.0M, 200);
            var paymentMethod8 = new CreditCard("4820 8245 4535", new Validity(2027, 1), 558, 2.5M, 5000);
            var paymentMethod9 = new BitCoin("BitCoin", 1,1000M);
            BankClient client2 = new BankClient(user2, adress2, new List<IPayment> {paymentMethod5,paymentMethod6,paymentMethod7,paymentMethod8,paymentMethod9});

            client2.Pay(IPhone.ProductPrice);
            client2.Pay(table.ProductPrice);
            client2.GetBalanceOfAllCards(client2.Payments);
        }
    }
}