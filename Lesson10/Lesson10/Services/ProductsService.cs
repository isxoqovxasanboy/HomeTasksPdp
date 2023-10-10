
using Lesson10.Models;

namespace Lesson10.Services;

/// <summary>
/// Bu product servis. 
/// </summary>
public class ProductsService
{
    private readonly Dictionary<int, Product> products;

    /// <summary>
    /// Buni vazifasi Productlar to'plamlarini yaratadi.
    /// </summary>
    public ProductsService()
    {
        products = new Dictionary<int, Product>();
        LoadProducts();
    }

    private void LoadProducts()
    {
        products.Add(1, new Product()
        {
            Id = 1,
            Name = "Coca-Cola",
            Description = "Coca-cola shakarsiz",
            Price = 5000,
            Discount = 500,
            PriceDiscount = 4500
        });
        products.Add(2, new Product()
        {
            Id = 2,
            Name = "Fanta",
            Description = "Fanta shakarlik",
            Price = 6000,
            Discount = 500,
            PriceDiscount = 5500
        });
    }

    public void ShowAllProducts()
    {
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Value}");
        }
    }

    public Product? GetProductById(int id)
    {
        if (products.TryGetValue(id, out var product))
            return product;

        return null;
    }
}
