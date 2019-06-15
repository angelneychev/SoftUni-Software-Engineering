using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Record_Unique_Names
{
   public class RecordUniqueNames
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
                
            }

            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}
