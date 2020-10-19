using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Library
{
    /// <summary>
    /// The main <c>WebShop.Library</c> class.
    /// Contains all methods for performing web shop functions.
    /// </summary>
    public class ShoppingBasket
    {
        /// <summary>
        /// Total price of all items in <c>ShoppingBasket</c> not including discounts
        /// </summary>
        public double TotalPrice { get; private set; }

        /// <summary>
        /// Total price of all items in <c>ShoppingBasket</c> including discounts
        /// </summary>
        public double TotalSumPrice { get; private set; }

        /// <summary>
        /// Total discount of all items in <c>ShoppingBasket</c>
        /// </summary>
        public double TotalDiscount { get; private set; }

        /// <summary>
        /// Total discount of all 'Milk' items in <c>ShoppingBasket</c>
        /// </summary>
        public double TotalMilkDiscount { get; private set; }

        /// <summary>
        /// Total discount of all 'Bread' items in <c>ShoppingBasket</c>
        /// </summary>
        public double TotalBreadDiscount { get; private set; }

        /// <summary>
        /// List of all Items in <c>ShoppingBasket</c>
        /// </summary>
        public List<Item> Items { get; private set; }


        public ShoppingBasket(List<Item> itemsInBasket) 
        {
            Items = itemsInBasket;
        }
        private double SetTotalPrice() 
        {
            double sum = 0.0;

            foreach (Item item in Items) 
            {
                sum += (item.Price * item.Quantity);
            }
            var x = Math.Round(sum,2);
            return Math.Round(sum,2);
        }
        private double SetTotalSumPrice()
        {
            double sum = 0.0;

            foreach (Item item in Items)
            {
                sum += (item.Price * item.Quantity);
            }
            sum -= TotalDiscount;
            return Math.Round(sum, 2);
        }

        private double SetTotalMilkDiscount() 
        {
            double discount = 0.0;
            var milk = Items.FirstOrDefault(item => item.Description == "Milk");
            int milkQuantity = milk != null ? milk.Quantity : 0;
            double milkPrice = milk != null ? milk.Price : 0.0;
            discount = (milkQuantity / 4) * milkPrice;
            return Math.Round(discount, 2);
        }

        private double SetTotalBreadDiscount() 
        {
            double discount = 0.0;
            var butter = Items.FirstOrDefault(item => item.Description == "Butter");
            int butterQuantity = butter != null ? butter.Quantity : 0;

            var bread = Items.FirstOrDefault(item => item.Description == "Bread");
            int breadQuantity = bread != null ? bread.Quantity : 0;
            double breadPrice = bread != null ? bread.Price : 0;
            double breadPriceHalf = breadPrice / 2;

            if (breadQuantity >= butterQuantity / 2)
            {
                discount = butterQuantity / 2 * breadPriceHalf;
            }
            else
            {
                discount = breadQuantity * breadPriceHalf;
            }
            return Math.Round(discount, 2);
        }
        /// <summary>
        /// Set all parameters after all Items have been added to the <c>ShoppingBasket</c>
        /// and generate the log in C:\\temp\ShoppingBasketLog 
        /// </summary>
        public void CalculateTotalSumPrice() 
        {
            TotalMilkDiscount = SetTotalMilkDiscount();
            TotalBreadDiscount = SetTotalBreadDiscount();
            TotalDiscount = TotalMilkDiscount + TotalBreadDiscount;
            TotalPrice = SetTotalPrice();
            TotalSumPrice = SetTotalSumPrice();
            GenerateLog();
        }

        /// <summary>
        /// Generate TXT file in C:\\temp\ShoppingBasketLog 
        /// that contains all items in <c>ShoppingBasket</c>, all applicable discounts and a total sum price of basket
        /// </summary>
        private void GenerateLog() 
        {
            ShoppingBasketLog.Log(this);
        }
        /// <summary>
        /// Add additional Quantity to specified Item in ShoppingBasket
        /// </summary>
        public void AddItem(Item item)
        {
            Item itemToChange = Items.Find(i => i.Description == item.Description);
            if (itemToChange == null)
            {
                Items.Add(item);
            }
            else 
            {
                if (itemToChange.Price != item.Price) 
                {
                    throw new Exception("Wrong price listed in items to add");
                }
                itemToChange.Quantity += item.Quantity;
            }
        }
        /// <summary>
        /// Remove additional Quantity from specified Item in ShoppingBasket
        /// </summary>
        public void RemoveItem(Item item)
        {
            if (Items.Count == 0) 
            {
                throw new Exception("No item exist to remove");
            }
            Item itemToChange = Items.Find(i => i.Description == item.Description);
            if (itemToChange.Price != item.Price) 
            {
                throw new Exception("Wrong price listed in items to remove");
            }
            itemToChange.Quantity -= item.Quantity;
            if (itemToChange.Quantity == 0) 
            {
                Items.Remove(itemToChange);
            }
        }
    }
}
