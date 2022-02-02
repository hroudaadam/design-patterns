namespace ConsoleApp.Behavioral.Strategy;

public static class StrategyExample
{
    public static void Run()
    {
        Cart cart = new(new CashPayment());
        cart.Pay();
        cart.Payment = new DebitCardPayment("4556-8554-2134-7546", DateTimeOffset.UtcNow.AddDays(365));
        cart.Pay();
    }
}

// abstract strategy
public interface IPaymentMethod
{
    void Pay(double amount);
}

// concrete strategy
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

// concrete strategy
public class CashPayment : IPaymentMethod
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paying {amount} with cash");
    }
}

// context
public class Cart
{
    public List<string> Items { get; set; } = new();
    public double Price { get; set; } = new Random().NextDouble() * 1000;
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
