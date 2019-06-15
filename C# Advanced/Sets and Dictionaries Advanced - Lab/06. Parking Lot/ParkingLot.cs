using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
   public class ParkingLot
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            HashSet<string> parking = new HashSet<string>();
            while (input[0] !="END")
            {
                if (input[0] == "IN")
                {
                    parking.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    parking.Remove(input[1]);
                }
                

                input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            if (parking.Count >0)
            {
                foreach (var cars in parking)
                {
                    Console.WriteLine($"{cars}");
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
