namespace Dinely.Domain.DinnerAggregate.ValueObjects;

public class Price
{
    public decimal Amount { get; }
    public string Currency { get; }

    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(decimal amount, string currency)
    {
        return new(amount, currency);
    }
}
