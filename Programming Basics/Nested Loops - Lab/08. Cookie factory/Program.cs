using System;

namespace _08._Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int BrPartidi = int.Parse(Console.ReadLine());


            for (int i = 1; i <= BrPartidi; i++)
            {
                bool FlourYes = false;
                bool EggsYes = false;
                bool SugarYes = false;
                string Product = Console.ReadLine();
                while (true)
                {

                    if (Product == "flour")
                    {
                        FlourYes = true;
                    }
                    else if (Product == "eggs")
                    {
                        EggsYes = true;
                    }
                    else if (Product == "sugar")
                    {
                        SugarYes = true;
                    }
                    if (Product == "Bake!")
                    {
                        if (FlourYes && EggsYes && SugarYes)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        }
                    }
                    Product = Console.ReadLine();
                }
                Console.WriteLine($"Baking batch number {i}...");
            }
        }
    }
}
