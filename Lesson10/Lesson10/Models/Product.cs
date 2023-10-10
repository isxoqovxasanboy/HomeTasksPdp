
namespace Lesson10.Models;
/// <summary>
/// Bu product bo'limi
/// </summary>
public class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? PriceDiscount { get; set; }

    public override string ToString()
    {
        return $"Id {Id}, Name {Name}, Price {Price}, Discount {Discount}";
    }
}
