using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Traffic_Jam
{
   public class TrafficJam
    {
        static void Main()
        {
            int numberCar = int.Parse(Console.ReadLine());
            var typeCare = Console.ReadLine();

            var queueCar = new Queue<string>();
            var queueJam = new Queue<string>();

            while (typeCare != "end")
            {
                if (typeCare != "green")
                {
                    queueCar.Enqueue(typeCare);
                }
                else if (typeCare == "green")
                {
                    for (int i = 1; i <= numberCar; i++)
                    {
                       var print = queueCar.Peek();
                       Console.WriteLine($"{print} passed!");
                       queueJam.Enqueue(queueCar.Dequeue());
                       if (queueCar.Count < 1)
                       {
                          break;
                       }
                    }

                }
                typeCare = Console.ReadLine();
            }

            Console.WriteLine($"{queueJam.Count} cars passed the crossroads.");
        }
    }
}
