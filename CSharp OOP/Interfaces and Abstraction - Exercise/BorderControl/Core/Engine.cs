using System.Collections.Generic;
using System.Linq;
using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl.Core
{
    using System;

    public class Engine
    {
        private List<IRegisterable> registerables;
        private Citizen citizen;
        private Robot robot;

        public Engine()
        {
            this.registerables = new List<IRegisterable>();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command !="End")
            {
                string[] tokens = command.Split().ToArray();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age =int.Parse(tokens[1]);
                    string id = tokens[2];
                    this.citizen = new Citizen(name,age,id);
                    registerables.Add(citizen);
                }
                else if (tokens.Length ==2)
                {
                    string name = tokens[0];
                    string id = tokens[1];
                    this.robot = new Robot(name,id);
                    registerables.Add(robot);
                }
                command = Console.ReadLine();
            }

            string controlNumber = Console.ReadLine();

            foreach (var item in registerables
                .Where(x => x.Id.EndsWith(controlNumber))
                .Select(x => x.Id)
                .ToList())
            {
                Console.WriteLine(item);
            }
        }
    }
}
