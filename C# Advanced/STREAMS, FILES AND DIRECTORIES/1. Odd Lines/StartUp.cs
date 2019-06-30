using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _1._Odd_Lines
{
    public class StartUp
    {
        static void Main()
        {
            Dictionary<string, int> allMaterial = new Dictionary<string, int>();
            allMaterial.Add("Glass", 1);
            allMaterial.Add("Aluminium", 2);
            allMaterial.Add("Lithium", 1);
            allMaterial.Add("Carbon fiber", 0);
            int count = 0;
            foreach (var kvp in allMaterial.OrderBy(x => x.Key))
            {
                if (kvp.Value > 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
