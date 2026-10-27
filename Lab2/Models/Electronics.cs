namespace Lab2.Models;

public class Electronics : Product
{
    private int _warrantyMonths;
    private string _brand;

    public Electronics(
        string name,
        decimal price,
        string brand,
        int warrantyMonths)
        : base(name, price)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Название бренда не может быть пустым.", nameof(brand));

        if (warrantyMonths < 0)
            throw new ArgumentOutOfRangeException(nameof(warrantyMonths), "Гарантия не может быть отрицательной.");

        _brand = brand;
        _warrantyMonths = warrantyMonths;
    }

    public string Brand
    {
        get => _brand;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Название бренда не может быть пустым.", nameof(value));

            _brand = value;
        }
    }

    public int WarrantyMonths
    {
        get => _warrantyMonths;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Гарантия не может быть отрицательной.");

            _warrantyMonths = value;
        }
    }

    public override string GetCategory()
    {
        return "Электроника";
    }

    public override decimal GetDiscountedPrice()
    {
        return Price * 0.95m;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, бренд: {Brand}, гарантия: {WarrantyMonths} мес.";
    }
}