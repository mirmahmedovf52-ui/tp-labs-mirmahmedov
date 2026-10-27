
using Lab2.Models;

List<Product> products = new()
{
    new Electronics("Смартфон", 50000m, "Samsung", 12),
    new Electronics("Наушники", 8000m, "Sony", 6),
    new GroceryProduct("Молоко", 120m, DateTime.Today.AddDays(2)),
    new GroceryProduct("Чай", 350m, DateTime.Today.AddMonths(6)),
    new Clothing("Футболка", 1500m, "M", "Хлопок"),
    new Clothing("Куртка", 7000m, "L", "Полиэстер")
};

Console.WriteLine("=== ИНТЕРНЕТ-МАГАЗИН ===");
Console.WriteLine("\nВсе товары:");

foreach (Product product in products)
{
    Console.WriteLine(product);
    Console.WriteLine($"Цена со скидкой: {product.GetDiscountedPrice():F2} руб.");
}

Console.WriteLine("\n=== СОРТИРОВКА ПО ЦЕНЕ ===");

products.Sort();

foreach (Product product in products)
{
    Console.WriteLine($"{product.Name}: {product.Price:F2} руб.");
}

ShoppingCart cart = new();

foreach (Product product in products)
{
    cart.AddProduct(product);
}

Console.WriteLine("\n=== КОРЗИНА ===");
Console.WriteLine(cart);

Console.WriteLine($"\nИсходная стоимость: {cart.GetOriginalTotal():F2} руб.");
Console.WriteLine($"Сумма скидок: {cart.GetTotalDiscount():F2} руб.");
Console.WriteLine($"Итого к оплате: {cart.GetTotal():F2} руб.");

Console.WriteLine("\n=== УДАЛЕНИЕ ТОВАРА ===");

bool removed = cart.RemoveProduct("Чай");
Console.WriteLine(removed ? "Чай удалён из корзины." : "Товар не найден.");

Console.WriteLine($"Сумма после удаления: {cart.GetTotal():F2} руб.");

Console.WriteLine("\n=== ОЧИСТКА КОРЗИНЫ ===");

cart.Clear();
Console.WriteLine(cart.IsEmpty() ? "Корзина пуста." : "В корзине остались товары.");
