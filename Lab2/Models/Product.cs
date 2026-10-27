namespace Lab2.Models;

public abstract class Product : IComparable<Product>
{
    private string _name;
    private decimal _price;

    protected Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название товара не может быть пустым.", nameof(name));

        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной.");

        _name = name;
        _price = price;
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название товара не может быть пустым.", nameof(value));

            _name = value;
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Цена не может быть отрицательной.");

            _price = value;
        }
    }

    public abstract string GetCategory();

    public virtual decimal GetDiscountedPrice()
    {
        return Price;
    }

    public int CompareTo(Product? other)
    {
        if (other is null)
            return 1;

        return Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return $"{Name} — {Price:F2} руб. ({GetCategory()})";
    }
}