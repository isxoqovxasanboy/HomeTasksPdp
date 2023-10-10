namespace Lesson10.Models
{
    public class Cart
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceDiscount { get; set; }

        //[JsonInclude]
        public readonly List<CartItems> _items;
        /// <summary>
        ///     Savatchani yaratish.
        /// </summary>
        public Cart()
        {
            _items = new List<CartItems>();
        }

        public void AddItem(Product product, int quantity)
        {
            ArgumentNullException.ThrowIfNull(product);

            foreach (var item in _items)
            {
                if (item.Products.Id == product.Id)
                {
                    item.Quantity += quantity;
                    return;
                }
            }

            _items.Add(new CartItems()
            {
                Products = product,
                Quantity = quantity,
            });
        }


    }
}
