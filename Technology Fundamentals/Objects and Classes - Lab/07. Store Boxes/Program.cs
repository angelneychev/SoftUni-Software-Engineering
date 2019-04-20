using System;
using System.Collections.Generic;
using System.Linq;
//Objects and Classes - Lab
namespace _07._Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double PriceBox { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<Box> listOfBox = new List<Box>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                string serialNumber = tokens[0];
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                double itemPrice = double.Parse(tokens[3]);

                double priceOfBox = itemQuantity * itemPrice;

                Item neItem = new Item()
                {
                    Name = itemName,
                    Price = itemPrice
                };
                Box oneBox = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = neItem,
                    Quantity = itemQuantity,
                    PriceBox = priceOfBox
                };
                listOfBox.Add(oneBox);

            }

            foreach (var oneBox in listOfBox.OrderByDescending(x => x.PriceBox))
            {
                Console.WriteLine(oneBox.SerialNumber);
                Console.WriteLine($"-- {oneBox.Item.Name} " +
                                  $"- ${oneBox.Item.Price:f2}:" +
                                  $" {oneBox.Quantity}");
                Console.WriteLine($"-- ${oneBox.PriceBox:f2}");

            }
        }
    }
}
