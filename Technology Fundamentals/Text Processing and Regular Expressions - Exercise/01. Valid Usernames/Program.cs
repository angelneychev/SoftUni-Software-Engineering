using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(", ")
                .ToArray();

            List<string> validUsername = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool isvalid = false;
                if (word.Length >= 3 && word.Length <= 16)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        char currentCharacter = word[j];
                        if (char.IsLetterOrDigit(currentCharacter) 
                            || currentCharacter == '-' 
                            || currentCharacter == '_')
                        {
                            isvalid = true;
                        }
                        else
                        {
                            isvalid = false;
                            break;
                        }

                    }

                    if (isvalid)
                    {
                        Console.WriteLine(word);
                    }
                }

            }
        }
    }
}
