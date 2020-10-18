using System;
using System.Collections.Generic;
using WebShop.Library;

namespace WebShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // Scenario 1
            List<Item> items = new List<Item>
            {
                new Item(1, "Butter", 0.80),
                new Item(1, "Milk", 1.15),
                new Item(1, "Bread", 1.0)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();

            // Scenario 2
            items = new List<Item>
            {
                new Item(2, "Butter", 0.80),
                new Item(2, "Bread", 1.0)
            };
            basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();

            // Scenario 3
            items = new List<Item>
            {
                new Item(4, "Milk", 1.15)
            };
            basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();

            // Scenario 4
            items = new List<Item>
            {
                new Item(2, "Butter", 0.80),
                new Item(8, "Milk", 1.15),
                new Item(1, "Bread", 1.0)
            };
            basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();
        }
    }
}
