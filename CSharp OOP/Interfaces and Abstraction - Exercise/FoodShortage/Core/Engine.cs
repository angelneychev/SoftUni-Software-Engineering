namespace FoodShortage.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using FoodShortage.Contracts;
    using FoodShortage.Models;

    public class Engine
    {
        private List<IBuyer> buyers;
        private Citizen citizen;
        private Rebel rebel;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthday = tokens[3];
                    citizen = new Citizen(name,age,id,birthday);
                    buyers.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                    string group = tokens[2];
                    rebel = new Rebel(name,age,group);
                    buyers.Add(rebel);
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                var buyer = buyers.SingleOrDefault(x=>x.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}
