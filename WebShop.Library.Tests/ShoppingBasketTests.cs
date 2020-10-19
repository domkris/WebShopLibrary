using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebShop.Library.Tests
{
    [TestFixture]
    public class ShoppingBasketTests
    {
        [Test]
        public void WhenEmptyBasket_ExpectedPrice_NoDiscounts() 
        {
            ShoppingBasket basket = new ShoppingBasket(new List<Item>());
            basket.CalculateTotalSumPrice();
            Assert.AreEqual(0.0, basket.TotalPrice);
        }

        [Test]
        public void WhenEmptyBasket_ExpectedPrice_WithDiscounts()
        {
            ShoppingBasket basket = new ShoppingBasket(new List<Item>());
            basket.CalculateTotalSumPrice();
            Assert.AreEqual(0.0, basket.TotalSumPrice);
        }

        [Test]
        public void WhenXButter_ExpectedPrice_NoDiscounts(
            [Values(1,3)] int butterQuantity)
        {
            Item item = new Item(butterQuantity, "Butter", 0.80);
            ShoppingBasket basket = new ShoppingBasket(new List<Item> {item});
            basket.CalculateTotalSumPrice();
            switch (butterQuantity)
            {
                case 1:
                    Assert.AreEqual(0.80, basket.TotalPrice);
                    break;
                case 3:
                    Assert.AreEqual(2.4, basket.TotalPrice);
                    break;

            }
        }

        [Test]
        public void WhenXButter_ExpectedPrice_WithDiscounts(
            [Values(1, 3)] int butterQuantity)
        {
            Item item = new Item(butterQuantity, "Butter", 0.80);
            ShoppingBasket basket = new ShoppingBasket(new List<Item> { item });
            basket.CalculateTotalSumPrice();
            switch (butterQuantity)
            {
                case 1:
                    Assert.AreEqual(0.80, basket.TotalSumPrice);
                    break;
                case 3:
                    Assert.AreEqual(2.4, basket.TotalSumPrice);
                    break;

            }
        }

        [Test]
        public void WhenXMilk_ExpectedPrice_NoDiscounts(
            [Values(1, 4, 9)] int milkQuantity)
        {
            Item item = new Item(milkQuantity, "Milk", 1.15);
            ShoppingBasket basket = new ShoppingBasket(new List<Item> { item });
            basket.CalculateTotalSumPrice();
            switch (milkQuantity)
            {
                case 1:
                    Assert.AreEqual(1.15, basket.TotalPrice);
                    break;
                case 4:
                    Assert.AreEqual(4.6, basket.TotalPrice);
                    break;
                case 9:
                    Assert.AreEqual(10.35, basket.TotalPrice);
                    break;

            }
        }

        [Test]
        public void WhenXMilk_ExpectedPrice_WithDiscounts(
            [Values(1, 4, 9)] int milkQuantity)
        {
            Item item = new Item(milkQuantity, "Milk", 1.15);
            ShoppingBasket basket = new ShoppingBasket(new List<Item> { item });
            basket.CalculateTotalSumPrice();
            switch (milkQuantity)
            {
                case 1:
                    Assert.AreEqual(1.15, basket.TotalSumPrice);
                    break;
                case 4:
                    Assert.AreEqual(3.45, basket.TotalSumPrice);
                    break;
                case 9:
                    Assert.AreEqual(8.05, basket.TotalSumPrice);
                    break;

            }
        }
        [Test]
        public void When2ButterXBread_ExpectedPrice_WithDiscounts(
            [Values(1, 4)] int breadQuantity)
        {
            List<Item> items = new List<Item> 
            {
                new Item(2, "Butter", 0.80),
                new Item(breadQuantity, "Bread", 1.00)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();
            switch (breadQuantity)
            {
                case 1:
                    Assert.AreEqual(2.1, basket.TotalSumPrice);
                    break;
                case 4:
                    Assert.AreEqual(5.1, basket.TotalSumPrice);
                    break;

            }
        }
        [Test]
        public void When13Butter6MilkXBread_ExpectedPrice_WithDiscount(
            [Values(3, 4, 7)] int breadQuantity)
        {
            List<Item> items = new List<Item>
            {
                new Item(13, "Butter", 0.80),
                new Item(6, "Milk", 1.15),
                new Item(breadQuantity, "Bread", 1.0)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();
            switch (breadQuantity)
            {
                case 3:
                    Assert.AreEqual(17.65, basket.TotalSumPrice);
                    break;
                case 4:
                    Assert.AreEqual(18.15, basket.TotalSumPrice);
                    break;
                case 7:
                    Assert.AreEqual(20.15, basket.TotalSumPrice);
                    break;
            }
        }
        [Test]
        public void When13ButterXMilk7Bread_ExpectedPrice_WithDiscount(
            [Values(3, 4, 9)] int milkQuantity)
        {
            List<Item> items = new List<Item>
            {
                new Item(13, "Butter", 0.80),
                new Item(milkQuantity, "Milk", 1.15),
                new Item(7, "Bread", 1.0)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            basket.CalculateTotalSumPrice();
            switch (milkQuantity)
            {
                case 3:
                    Assert.AreEqual(17.85, basket.TotalSumPrice);
                    break;
                case 4:
                    Assert.AreEqual(17.85, basket.TotalSumPrice);
                    break;
                case 9:
                    Assert.AreEqual(22.45, basket.TotalSumPrice);
                    break;
            }
        }

        [Test]
        public void When_Add1ButterToEmptyBasket_Expected1Butter() 
        {
            ShoppingBasket basket = new ShoppingBasket(new List<Item>());
            Item item = new Item(1, "Butter", 0.80);
            basket.AddItem(item);
            Assert.That(basket.Items.Any(item => item.Description == "Butter"));

        }

        [Test]
        public void When_Add1ButterToBasketWith7Butter_Expected8Butter()
        {
            List<Item> items = new List<Item>()
            {
                new Item(7, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Item item = new Item(1, "Butter", 0.80);
            basket.AddItem(item);
            Assert.That(basket.Items.Any(item => item.Quantity == 8 && item.Description == "Butter"));

        }

        [Test]
        public void When_Add1ButterToBasketWith7Butter_ExpectedPrice_WithDiscount()
        {
            List<Item> items = new List<Item>()
            {
                new Item(7, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Item item = new Item(1, "Butter", 0.80);
            basket.AddItem(item);
            basket.CalculateTotalSumPrice();
            Assert.AreEqual(6.4, basket.TotalSumPrice);

        }

        [Test]
        public void When_Remove1ButterFromEmptyBasket_ExpectedException()
        {
            string errorMessage = "No item exist to remove";
            ShoppingBasket basket = new ShoppingBasket(new List<Item>());
            Item item = new Item(1, "Butter", 0.80);
            Assert.Throws(typeof(Exception), () => basket.RemoveItem(item), errorMessage);

        }

        [Test]
        public void When_Remove1ButterFromBasketWith1Butter_ExpectedEmptyBasket()
        {
            List<Item> items = new List<Item>()
            {
                new Item(1, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Item item = new Item(1, "Butter", 0.80);
            basket.RemoveItem(item);
            Assert.That(basket.Items.Count == 0);

        }

        [Test]
        public void When_Remove1ButterFromBasketWith9Butter_Expected8Butter()
        {
            List<Item> items = new List<Item>()
            {
                new Item(9, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Item item = new Item(1, "Butter", 0.80);
            basket.RemoveItem(item);
            Assert.That(basket.Items.Any(item => item.Quantity == 8 && item.Description == "Butter"));

        }

        [Test]
        public void When_Remove1ButterFromBasketWith8Butter_ExpectedPrice_WithDiscount()
        {
            List<Item> items = new List<Item>()
            {
                new Item(8, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Item item = new Item(1, "Butter", 0.80);
            basket.RemoveItem(item);
            basket.CalculateTotalSumPrice();
            Assert.AreEqual(5.6, basket.TotalSumPrice);

        }

        [Test]
        public void When_Remove1ButterWithDifferentPrice_FromBasketWith1Butter_ExpectedException()
        {
            string errorMessage = "Wrong price listed in items to remove";
            List<Item> items = new List<Item>()
            {
                new Item(1, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Assert.Throws(typeof(Exception), () => basket.RemoveItem(new Item(1, "Butter", 0.85)), errorMessage);

        }

        [Test]
        public void When_Add1ButterWithDifferentPrice_ToBasketWith1Butter_ExpectedException()
        {
            string errorMessage = "Wrong price listed in items to add";
            List<Item> items = new List<Item>()
            {
                new Item(1, "Butter", 0.80)
            };
            ShoppingBasket basket = new ShoppingBasket(items);
            Assert.Throws(typeof(Exception), () => basket.AddItem(new Item(1, "Butter", 0.85)), errorMessage);

        }
    }
}
