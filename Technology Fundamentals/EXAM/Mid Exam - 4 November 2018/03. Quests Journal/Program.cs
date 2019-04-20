using System;
using System.Collections.Generic;
using System.Linq;
//Programming Fundamentals - Mid Exam - 4 November 2018
namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine()
                .Split(", ")
                .ToList();
            string commandLine = Console.ReadLine();

            while (commandLine != "Retire!")
            {
                string[] command = commandLine.Split(" - ");

                if (command[0] == "Start")
                {
                    //•	"Start - {quest}" – Receiving this command,
                    //you should add the given quest in your journal.
                    //If the quest already exists, you should skip this line.
                    if ((!inputLine.Contains(command[1])))
                    {
                        inputLine.Add(command[1]);
                    }
                }
                else if (command[0] == "Complete")
                {
                    //•	"Complete - {quest}" – You should remove the quest
                    //from your journal, if it exists.
                    if (inputLine.Contains(command[1]))
                    {
                        inputLine.Remove(command[1]);
                    }
                }
                else if (command[0] == "Side Quest")
                {
                    //•	"Side Quest - {quest}:{sideQuest}" – You should check if the quest exists,
                    //if so, add the side quest after the quest.
                    //Note that you shouldn`t add the sideQuest if it already exists.
                    string temp = command[1];
                    string[] quest = temp.Split(":");
                    if (inputLine.Contains(quest[0]) && !inputLine.Contains(quest[1]))
                    {
                        int indexQuest = inputLine.IndexOf(quest[0]);
                        inputLine.Insert(indexQuest + 1, (quest[1]));
                    }
                }
                else if (command[0] == "Renew")
                {
                    //•	"Renew – {quest}" – If the given quest exists,
                    //you should change its position and put it last in your journal.
                    if (inputLine.Contains(command[1]))
                    {
                        inputLine.Add(command[1]);
                        inputLine.Remove(command[1]);
                    }
                }
                commandLine = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", inputLine));
            //After receiving "Retire!" print the quests in the journal,
            //separated by ", " (comma and space).
        }
    }
}
