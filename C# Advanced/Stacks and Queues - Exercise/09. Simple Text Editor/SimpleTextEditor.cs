using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    public class SimpleTextEditor
    {
        static void Main()
        {
            Stack<string> stackOfText = new Stack<string>();
            string text = string.Empty;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "1")
                {
                    stackOfText.Push(text);
                    text += input[1];
                }
                else if (input[0] == "2")
                {
                    int index = int.Parse(input[1]);
                    stackOfText.Push(text);
                    text = text.Substring(0, text.Length - index);
                }
                else if (input[0] == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (input[0] == "4")
                {
                    text = stackOfText.Pop();
                }
            }
        }
    }
}