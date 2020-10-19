using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebShop.Library
{
    /// <summary>
    /// Represents log file for shopping basket
    /// </summary>
    static class ShoppingBasketLog
    {
        // Length of every line in the log file
        private const int lengthOfLogLine = 40;

        // length of item's property values per line in the log
        private const int descriptionLogLength = 18;
        private const int quantityLogLength = 6;
        private const int priceLogLength = 8;

        private static readonly string ClassName = typeof(ShoppingBasketLog).Name;
        private static readonly string LogFileName = ClassName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
        private static readonly string LogFilePath = @"C:\Temp\" + ClassName + "\\" + LogFileName;

        private static ShoppingBasket basket;
        private static StreamWriter writer;

        /// <summary>
        /// Write the log file of all items in <c>ShoppingBasket</c>, all applicable discounts and a total sum price of basket
        /// </summary>
        public static void Log(ShoppingBasket shoppingBasket) 
        {
            basket = shoppingBasket;
            
            if (!Directory.Exists(@"C:\Temp\" + ClassName))
            {
                Directory.CreateDirectory(@"C:\Temp\" + ClassName);
            }

            using (StreamWriter logWriter = new StreamWriter(LogFilePath, true))
            {
                writer = logWriter;

                WriteFileHeader();
                foreach (Item item in basket.Items)
                {
                    WriteFileLogData(item);
                }
                WriteFileFotter();

                Console.WriteLine("SHOPPING LOG LOCATED AT: \n" + LogFilePath);
            }
        }

        /// <summary>
        /// Append total price and total discount of the shopping basket to the log file
        /// </summary>
        private static void WriteFileFotter()
        {
            writer.WriteLine(new string('-', lengthOfLogLine));
            if (basket.TotalDiscount != 0)
            {
                writer.WriteLine("Total Price" + new string(' ', lengthOfLogLine - 19) + basket.TotalPrice);
                writer.WriteLine("Total Discount" + new string(' ', lengthOfLogLine - 23) + "-" + basket.TotalDiscount);
                writer.WriteLine(new string('-', lengthOfLogLine));
            }
            writer.WriteLine("Total Sum Price" + new string(' ', lengthOfLogLine - 23) + basket.TotalSumPrice);
            writer.WriteLine(new string('-', lengthOfLogLine));
            writer.WriteLine("\n\n\n");
        }

        /// <summary>
        /// Append prices and discounts of items in the  shopping basket to the log file
        /// </summary>
        private static void WriteFileLogData(Item item)
        {
            double itemSumPrice = Math.Round(item.Quantity * item.Price, 2);
            writer.Write(item.Description + new string(' ', descriptionLogLength - item.Description.Length));
            writer.Write(item.Quantity + new string(' ', quantityLogLength - item.Quantity.ToString().Length));
            writer.Write(item.Price + new string(' ', priceLogLength - item.Price.ToString().Length));
            writer.Write(itemSumPrice + "\n");

            WriteFileItemDiscount(item);
        }

        private static void WriteFileItemDiscount(Item item)
        {
            if (item.Description == "Milk")
            {
                if (basket.TotalMilkDiscount != 0)
                {
                    writer.WriteLine(item.Description + " discount" + new string(' ', lengthOfLogLine - 18 - item.Description.Length) + "-" + basket.TotalMilkDiscount);
                }
            }
            if (item.Description == "Bread")
            {
                if (basket.TotalBreadDiscount != 0)
                {
                    writer.WriteLine(item.Description + " discount" + new string(' ', lengthOfLogLine - 18 - item.Description.Length) + "-" + basket.TotalBreadDiscount);
                }
            }
        }

        /// <summary>
        /// Append the info about the structure of the data to the log file
        /// </summary>
        private static void WriteFileHeader()
        {
            writer.WriteLine(new string('-', lengthOfLogLine));
            writer.Write("Product" + new string(' ', 11));
            writer.Write("Qnt" + new string(' ', 3));
            writer.Write("Price" + new string(' ', 3));
            writer.Write("SumPrice\n");
            writer.WriteLine(new string('-', lengthOfLogLine));
        }
    }

}
