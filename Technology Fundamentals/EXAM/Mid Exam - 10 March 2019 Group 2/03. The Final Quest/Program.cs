using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine().Split().ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Stop")
            {
                //-	Delete {index} – removes the word after the given index if it is valid.
                if (command[0] == "Delete")
                {
                    int index = int.Parse(command[1]);
                    if (index>=-1 && index <=inputLine.Count-1)
                    {
                        inputLine.RemoveAt(index+1);
                    }
                }
                //-	Swap {word1} {word2} – find the given words in the collections if they exist and swap their places.
                else if (command[0] == "Swap")
                {
                    string word1 = command[1];
                    string word2 = command[2];
                    int left = inputLine.IndexOf(word1);
                    int right = inputLine.IndexOf(word2);
                    if (inputLine.Contains(word1) && inputLine.Contains(word2))
                    {//Congratulations! You have also through the last challenge!
                        inputLine[left] = word2;
                        inputLine[right] = word1;
                    }
                }
                //-	Put {word} {index} – add a word at the previous place {index} before the given one, if it exists.
                else if (command[0] == "Put")
                {
                    string word1 = command[1];
                    int indexWord = inputLine.IndexOf(word1);
                    int index = int.Parse(command[2]);
                    if ((index-1)>=0 && (index-1) <=inputLine.Count)
                    {
                        inputLine.Insert(index-1,word1);
                    }
                }
                //-	Sort – you must sort the words in descending order.
                else if (command[0] == "Sort")
                {
                    inputLine.Sort();
                    inputLine.Reverse();
                }
                //-	Replace {word1} {word2} – find the second word {word2} in the collection (if it exists) and replace it with the first word – {word1}.
                else if (command[0] == "Replace")
                {
                    string word1 = command[1];
                    string word2 = command[2];
                    int right = inputLine.IndexOf(word2);
                    if (inputLine.Contains(word2))
                    {
                        inputLine[right] = word1;
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", inputLine));
        }
    }
}
