using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebShop.Library
{
    /// <summary>
    /// Represents log for shopping basket
    /// </summary>
    static class ShoppingBasketLog
    {
        private static readonly string ClassName = typeof(ShoppingBasketLog).Name;
        private static readonly string LogFileName = ClassName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
        private static readonly string LogFilePath = @"C:\Temp\" + ClassName + "\\" + LogFileName;

        /// <summary>
        /// Show details about all items in <c>ShoppingBasket</c>, all applicable discounts and a total sum price of basket
        /// </summary>
        public static void Log(ShoppingBasket basket) 
        {
            int lengthOfLogLine = 40;
            int itemLogLength = 18;
            int quantityLogLength = 6;
            int priceLogLength = 8;

            if (!Directory.Exists(@"C:\Temp\" + ClassName))
            {
                Directory.CreateDirectory(@"C:\Temp\" + ClassName);
            }

            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine(new string('-', lengthOfLogLine));
                writer.Write("Product" + new string(' ', 11));
                writer.Write("Qnt" + new string(' ', 3));
                writer.Write("Price" + new string(' ', 3));
                writer.Write("SumPrice\n");
                writer.WriteLine(new string('-', lengthOfLogLine));
                foreach (Item item in basket.Items)
                {
                    double itemSumPrice = Math.Round(item.Quantity * item.Price, 2);
                    writer.Write(item.Description + new string(' ', itemLogLength - item.Description.Length));
                    writer.Write(item.Quantity + new string(' ', quantityLogLength - item.Quantity.ToString().Length));
                    writer.Write(item.Price + new string(' ', priceLogLength - item.Price.ToString().Length));
                    writer.Write(itemSumPrice + "\n");

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
                writer.Close();

                Console.WriteLine("SHOPPING LOG LOCATED AT: \n" + LogFilePath);
            }
        }
    }

}
