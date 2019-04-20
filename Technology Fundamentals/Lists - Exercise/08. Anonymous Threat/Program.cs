using System;
using System.Collections.Generic;
using System.Linq;
//Lists - Exercise
namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }

                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    string temp = String.Empty;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (startIndex > words.Count - 1 || endIndex < 0)
                    {
                        continue;
                    }

                    if (endIndex > words.Count - 1)
                    {
                        endIndex = words.Count - 1;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        temp += words[i];
                    }

                    words.RemoveRange(startIndex, endIndex - startIndex + 1);
                    words.Insert(startIndex, temp);
                }
                else if (command == "divide")
                {
                    List<string> newWords = new List<string>();
                    int indexOfWords = int.Parse(tokens[1]);
                    int parts = int.Parse(tokens[2]);

                    string element = words[indexOfWords];

                    int partLents = element.Length / parts;
                    int lastPartLent = partLents + element.Length % parts;

                    words.RemoveAt(indexOfWords);

                    for (int i = 0; i < parts; i++)
                    {
                        string newWord = element.Substring(i * partLents, partLents);
                        if (i == parts - 1)
                        {
                            newWord = element.Substring(i * partLents, lastPartLent);
                        }

                        newWords.Add(newWord);
                    }

                    words.InsertRange(indexOfWords, newWords);
                }
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}