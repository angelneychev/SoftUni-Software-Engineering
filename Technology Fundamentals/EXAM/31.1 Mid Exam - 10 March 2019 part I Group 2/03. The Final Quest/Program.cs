using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main()
        {
            List<string> inputLine = Console.ReadLine()
                .Split()
                .ToList();

            string[] command = Console.ReadLine().Split();

            /*
-	Delete {index} – removes the word after the given index if it is valid.
-	Swap {word1} {word2} – find the given words in the collections if they exist and swap their places.
-	Put {word} {index} – add a word at the previous place {index} before the 
given one, if it exists.
-	Sort – you must sort the words in descending order.
-	Replace {word1} {word2} – find the second word {word2} in the collection (if it exists) and replace it with the first word – {word1}.

             */
            while (command[0] != "Stop")
            {
                //Delete 2
                if (command[0] == "Delete")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < inputLine.Count - 1)
                    {
                        inputLine.RemoveAt(index + 1);
                    }
                }
                //Swap have last
                else if (command[0] == "Swap")
                {
                    string word1 = command[1];
                    string word2 = command[2];
                    int left = inputLine.IndexOf(word1);
                    int right = inputLine.IndexOf(word2);
                    if (inputLine.Contains(word1) && inputLine.Contains(word2))
                    {
                        inputLine[left] = word2;
                        inputLine[right] = word1;
                    }
                }
                //Put {word} {index}
                else if (command[0] == "Put")
                {
                    string word = command[1];
                    int index = int.Parse(command[2]);
                    if (index >= 1 && index < inputLine.Count + 1)
                    {
                        inputLine.Insert(index - 1, word);
                    }

                }
                else if (command[0] == "Sort")
                {
                    inputLine.Sort();
                    inputLine.Reverse();
                }
                else if (command[0] == "Replace")
                {
                    string word1 = command[1];
                    string word2 = command[2];
                    int left = inputLine.IndexOf(word2);
                    if (inputLine.Contains(word2))
                    {
                        inputLine[left] = word1;
                    }

                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", inputLine));

        }
    }
}
