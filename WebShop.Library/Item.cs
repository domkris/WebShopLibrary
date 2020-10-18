using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Library
{
    /// <summary>
    /// Represents item in shopping basket
    /// </summary>
    public class Item
    {
        public Item(int quantity, string description, double price)
        {
            Quantity = quantity;
            Description = description;
            Price = price;

            if (Quantity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            if (Price <= 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }
        }

        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
