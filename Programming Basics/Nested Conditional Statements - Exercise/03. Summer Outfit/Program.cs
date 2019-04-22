    using System;

namespace _03._Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            var degrees = int.Parse(Console.ReadLine());
            string day = Console.ReadLine().ToLower();
            string outfit = "";
            string shoes = "";

            if (degrees <= 18)
            {
                if (day == "morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (day == "afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (true)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                if (day == "morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (day == "afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (true)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (degrees >= 25)
            {
                if (day == "morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (day == "afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (true)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");

        }
    }
}
