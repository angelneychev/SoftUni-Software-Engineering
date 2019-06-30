namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Startup
    {
        static void Main(string[] args)
        {
            CarFactory  carFactory = new CarFactory();
            EngineFactory engineFactory = new EngineFactory();
            CarSalesman carSalesman = new CarSalesman(carFactory, engineFactory);

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddEngine(parameters);
            }
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddCar(parameters);
            }

            foreach (var car in carSalesman.GeCars())
            {
                Console.WriteLine(car);
            }
        }
    }

}
