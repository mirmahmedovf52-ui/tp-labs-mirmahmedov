using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2.Models;

public class ShoppingCart
{
    private readonly List<Product> _products = new();

    public IReadOnlyList<Product> Products => _products.AsReadOnly();

    public void AddProduct(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        _products.Add(product);
    }

    public bool RemoveProduct(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
            throw new ArgumentException("Название товара не может быть пустым.", nameof(productName));

        Product? product = _products.FirstOrDefault(
            p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

        if (product is null)
            return false;

        _products.Remove(product);
        return true;
    }

    public decimal GetTotal()
    {
        return _products.Sum(product => product.GetDiscountedPrice());
    }

    public decimal GetOriginalTotal()
    {
        return _products.Sum(product => product.Price);
    }

    public decimal GetTotalDiscount()
    {
        return GetOriginalTotal() - GetTotal();
    }

    public void Clear()
    {
        _products.Clear();
    }

    public bool IsEmpty()
    {
        return _products.Count == 0;
    }

    public override string ToString()
    {
        if (IsEmpty())
            return "Корзина пуста.";

        return string.Join(Environment.NewLine, _products.Select(
            (product, index) => $"{index + 1}. {product}"));
    }
}