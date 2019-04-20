using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Memory_View
{
    class Program
    {
        static void Main(string[] args)
        {

            var totalList = new List<int>();
            var finallist = new List<string>();
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Visual Studio crash")
                {
                    break;
                }
                var listOfNums = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                totalList.AddRange(listOfNums);

            }
            while (true)
            {
                if (!totalList.Contains(32656))
                {
                    break;
                }
                int index = totalList.FindIndex(x => x == 32656);
                int lenghtofnameindex = index + 4;
                int startindexofname = index + 6;
                string newstring = string.Empty;
                for (int i = startindexofname; i <= startindexofname + totalList[lenghtofnameindex]; i++)
                {

                    newstring += (char)totalList[i];

                }
                finallist.Add(newstring);
                totalList.RemoveRange(0, startindexofname + totalList[lenghtofnameindex]);

            }
            Console.WriteLine(string.Join(Environment.NewLine, finallist));
        }
    }
}
