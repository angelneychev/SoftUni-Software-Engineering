using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listName = Console.ReadLine().Split("&").ToList();
            string[] inputLine = Console.ReadLine().Split();

            while (inputLine[0] != "Finished!")
            {
                string command = inputLine[0];
                string name = inputLine[1];
                //•	Bad {kidName} - adds a kid at the start of the list.  If the kid already exists skip this line.
                if (command == "Bad")
                {
                    if (!listName.Contains(name))
                    {
                        listName.Insert(0,name);
                    }
                    
                }
                else if (command == "Good")
                {
                    if (listName.Contains(name))
                    {
                        listName.Remove(name);
                    }
                }
                else if (command == "Rename")
                {
                    string newName = inputLine[2];
                    if (listName.Contains(name))
                    {
                        int left = listName.IndexOf(name);
                        listName[left] = newName;
                    }
                }
                else if (command == "Rearrange")
                {
                    if (listName.Contains(name))
                    {
                        listName.Remove(name);
                        listName.Add(name);
                    }
                }
                inputLine = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ",listName));
        }
    }
}
