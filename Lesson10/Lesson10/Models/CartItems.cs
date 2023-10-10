
namespace Lesson10.Models;

public class CartItems
{
    public int Id { get; set; }
    private int _quantity = default;

    public int Quantity
    {
        get => _quantity;

        set
        {
            if (_quantity != value)
            {
                _quantity = value;

                if (Products != null)
                {
                    TotalPrice = (decimal)(Products.Price * value);
                    TotalPriceDiscount = (decimal)(Products.PriceDiscount * value);
                }

            }
        }
    }

    public decimal? TotalPrice { get; set; }

    public decimal? TotalPriceDiscount { get; set; }

    public Product? Products { get; set; }



}
