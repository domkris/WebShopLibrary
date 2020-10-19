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
                new Item(2, "Butter", 0.80),
                new Item(1, "Milk", 1.15),
                new Item(1, "Bread", 1.0)
            };
            ShoppingBasket basket = new ShoppingBasket(items);

            // NOTE : Why do I have to write the price everytime ?
            // Maybe defining a struct/class or something else containing Inventory of the shop. 
            // this is simplier and with wrong price exception is thrown.
            basket.RemoveItem(new Item(1, "Butter", 0.80));
            basket.CalculateTotalSumPrice();

            // Scenario 2
            items = new List<Item>
            {
                new Item(2, "Butter", 0.80),
            };
            basket = new ShoppingBasket(items);
            basket.AddItem(new Item(2, "Bread", 1.0));
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
