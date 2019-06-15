using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
   public class ProductShop
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var productShop = new Dictionary<string, Dictionary<string,double>>();

            while (input[0] != "Revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);
                if (!productShop.ContainsKey(shop))
                {
                    productShop.Add(shop, new Dictionary<string, double>());
                }

                productShop[shop].Add(product,price);

                input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            }
            //var orderedShops =
            //    productShop.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in productShop
                .OrderBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value))
            {
                var shop = kvp.Key;
                var products = kvp.Value;
                Console.WriteLine($"{shop}->");
                foreach (var productKvp in products)
                {
                    Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value}");
                }
            }


        }
    }
}
