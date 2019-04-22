using System;

namespace _04._Fruit_or_Vegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();

            if (a == "banana" || a == "apple" || a == "kiwi" || a == "cherry" || a == "lemon" || a == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (a == "tomato" || a == "cucumber" || a == "pepper" || a == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
