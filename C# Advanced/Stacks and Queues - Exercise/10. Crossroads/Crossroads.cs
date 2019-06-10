using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    public class Crossroads
    {
        static void Main()
        {
            var secondsGreenlight = int.Parse(Console.ReadLine());
            var additionalSeconds = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var counter = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    var currentSecondsStart = secondsGreenlight;

                    while (currentSecondsStart > 0 && cars.Count > 0)
                    {
                        var currentCar = cars.Peek();

                        if (currentCar.Length <= currentSecondsStart)
                        {
                            cars.Dequeue();
                            counter++;
                        }
                        else if (currentCar.Length <= currentSecondsStart + additionalSeconds)
                        {
                            cars.Dequeue();
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine(
                                $"{cars.Peek()} was hit at {cars.Dequeue()[currentSecondsStart + additionalSeconds]}.");
                            return;
                        }

                        currentSecondsStart -= currentCar.Length;
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}