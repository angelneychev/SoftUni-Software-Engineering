using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _07._SoftUni_Party
{
   public class SoftUniParty
    {
        static void Main()
        {
            HashSet<string> guests = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "PARTY")
                {
                    break;
                }
                guests.Add(input);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }

                guests.Remove(input);
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
            
        }
    }
}
