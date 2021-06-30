using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Strategy
{
    public interface IPaymentMethod
    {
        void Pay(double amount);
    }

    public class DebitCardPayment : IPaymentMethod
    {
        public DebitCardPayment(string cardId, DateTimeOffset expiration)
        {
            CardId = cardId;
            Expiration = expiration;
        }

        public string CardId { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public void Pay(double amount)
        {
            Console.WriteLine($"Paying {amount} with debit card {CardId}");
        }
    }

    public class CashPayment : IPaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paying {amount} with cash");
        }
    }

    public class Cart
    {
        public List<string> Items { get; set; } = new();
        public double Price { get; set; } = new Random().NextDouble()*1000;
        public IPaymentMethod Payment { get; set; }

        public Cart(IPaymentMethod payment)
        {
            Payment = payment;
        }

        public void Pay()
        {
            Payment.Pay(Price);
        }
    }
}
