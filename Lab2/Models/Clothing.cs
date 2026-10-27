namespace Lab2.Models;

public class Clothing : Product
{
    private string _size;
    private string _material;

    public Clothing(
        string name,
        decimal price,
        string size,
        string material)
        : base(name, price)
    {
        if (string.IsNullOrWhiteSpace(size))
            throw new ArgumentException("Размер не может быть пустым.", nameof(size));

        if (string.IsNullOrWhiteSpace(material))
            throw new ArgumentException("Материал не может быть пустым.", nameof(material));

        _size = size;
        _material = material;
    }

    public string Size
    {
        get => _size;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Размер не может быть пустым.", nameof(value));

            _size = value;
        }
    }

    public string Material
    {
        get => _material;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Материал не может быть пустым.", nameof(value));

            _material = value;
        }
    }

    public override string GetCategory()
    {
        return "Одежда";
    }

    public override decimal GetDiscountedPrice()
    {
        return Price * 0.90m;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, размер: {Size}, материал: {Material}";
    }
}