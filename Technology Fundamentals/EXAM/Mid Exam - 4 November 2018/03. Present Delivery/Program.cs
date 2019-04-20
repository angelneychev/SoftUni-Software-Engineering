using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> actionList = Console.ReadLine()
                .Split(", ")
                .ToList();
            string command;

            while ((command = Console.ReadLine()) != "Retire!")
            {
                List<string> newCommandList = command.Split(" - ")
                    .ToList();

                if (newCommandList[0] == "Start")
                {
                    if (!actionList.Contains(newCommandList[1]))
                    {
                        actionList.Add(newCommandList[1]);
                    }

                }
                else if (newCommandList[0] == "Complete")
                {
                    actionList.Remove(newCommandList[1]);
                }

                else if (newCommandList[0] == "Renew")
                {
                    if (actionList.Contains(newCommandList[1]))
                    {
                        actionList.Add(newCommandList[1]);
                        actionList.Remove(newCommandList[1]);
                    }
                }
                else
                {
                    List<string> action4 = newCommandList[1].Split(':')
                        .ToList();
                    string left = action4[0];
                    string right = action4[1];

                    if (actionList.Contains(left))
                    {
                        int index = actionList.IndexOf(left);
                        if (!actionList.Contains(right))
                        {
                            actionList.Insert(index + 1, right);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(", ", actionList));
        }
    }
}
