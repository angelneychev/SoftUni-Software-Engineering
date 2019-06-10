using System;
using System.Collections;
using  System.Collections.Generic;
using System.Linq;
namespace _06._Auto_Repair_and_Service
{
  public  class AutoRepairAndService
    {
        static void Main()
        {
            var carModel = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var queueOfCar = new Queue<string>(carModel);
            var servedCar = new Stack<string>();

            var input = Console.ReadLine()
                .Split("-").ToArray();

            while (input[0] !="End")
            {
                if (input[0] == "Service" && queueOfCar.Count >0)
                {
                    string currentCar = queueOfCar.Dequeue();
                    servedCar.Push(currentCar);
                    Console.WriteLine($"Vehicle {currentCar} got served.");
                }
                else if (input[0] == "CarInfo")
                {
                    string carName = input[1];
                    if (queueOfCar.Contains(carName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (input[0] == "History")
                {
                    Console.WriteLine(string.Join(", ",servedCar));
                }
                input = Console.ReadLine()
                    .Split("-").ToArray();
            }

            if (queueOfCar.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queueOfCar)}");
            }

            Console.WriteLine($"Served vehicles: {string.Join(", ", servedCar)}");
        }
    }
}
