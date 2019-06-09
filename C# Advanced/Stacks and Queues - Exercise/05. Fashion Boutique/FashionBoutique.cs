using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
   public class FashionBoutique
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();
            var clothes = new Stack<int>(input);

            int packCapacity = int.Parse(Console.ReadLine());
            int startCapacity = packCapacity;
            int totalPack = 1;
            while (clothes.Count > 0)
            {
                int countClothes = clothes.Pop();
                int nalCapacity = packCapacity - countClothes;

                if (nalCapacity > 0)
                {
                    packCapacity -= countClothes;
                }
                else if (nalCapacity == 0)
                {
                    packCapacity = startCapacity;
                    if (clothes.Count > 0)
                    {
                        totalPack++;
                    }
                }
                else if (nalCapacity < 0)
                {
                    totalPack++;
                    packCapacity = startCapacity;
                    packCapacity -= countClothes;
                }

            }

            Console.WriteLine(totalPack);
        }
    }
}
