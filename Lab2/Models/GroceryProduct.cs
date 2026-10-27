namespace Lab2.Models;

public class GroceryProduct : Product
{
    private DateTime _expirationDate;

    public GroceryProduct(string name, decimal price, DateTime expirationDate)
        : base(name, price)
    {
        if (expirationDate.Date < DateTime.Today)
            throw new ArgumentOutOfRangeException(
                nameof(expirationDate),
                "Срок годности не может быть в прошлом.");

        _expirationDate = expirationDate;
    }

    public DateTime ExpirationDate
    {
        get => _expirationDate;
        set
        {
            if (value.Date < DateTime.Today)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Срок годности не может быть в прошлом.");

            _expirationDate = value;
        }
    }

    public override string GetCategory()
    {
        return "Продукты питания";
    }

    public override decimal GetDiscountedPrice()
    {
        if (ExpirationDate.Date <= DateTime.Today.AddDays(3))
            return Price * 0.80m;

        return Price;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, годен до: {ExpirationDate:dd.MM.yyyy}";
    }
}