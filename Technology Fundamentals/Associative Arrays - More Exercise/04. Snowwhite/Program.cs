using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfData = new Dictionary<string, Dictionary<string, int>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "Once upon a time")
            {
                string[] command = inputLine.Split(" <:> ");

                string dwarfName = command[0];
                string dwarfHatColor = command[1];
                int dwarfPhysics = int.Parse(command[2]);

                if (!dwarfData.ContainsKey(dwarfHatColor))
                {
                    dwarfData.Add(dwarfHatColor, new Dictionary<string, int>());
                    dwarfData[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                }
                else if (!dwarfData[dwarfHatColor].ContainsKey(dwarfName))
                {
                    dwarfData[dwarfHatColor].Add(dwarfName, dwarfPhysics);
                    //dict[dwarfHatColor]++;
                }

                if (dwarfData[dwarfHatColor][dwarfName] < dwarfPhysics)
                {
                    dwarfData[dwarfHatColor][dwarfName] = dwarfPhysics;
                }

                inputLine = Console.ReadLine();
            }

            foreach (var kvp in dwarfData)
                

            {

                //  Console.WriteLine($"{kvp.Key} {kvp.Value} - {kvp.Value}");
                var testNew = kvp.Value.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key.Length);

                foreach (var color in testNew)
                {
                    Console.WriteLine($"({kvp.Key}) {color.Key} <-> {color.Value}");
                }
            }
        }
    }
}
// (Blue) Pesho <-> 10000
//  (Blue) Gosho <-> 10000
//   (Red)  Pesho <-> 10000

