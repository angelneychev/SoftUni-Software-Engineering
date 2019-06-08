using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
   public class StackSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse);
            var numberStack = new Stack<int>();
            foreach (var item in numbers)
            {
                numberStack.Push(item);
            }
            
            while (true)
            {
                var command = Console.ReadLine().ToLower();
                if (command == "end")
                {
                    Console.WriteLine("Sum: " + numberStack.Sum());
                    break;
                }

                var tokkens = command.Split(' ');
                string operation = tokkens[0].ToLower();
                if (operation == "add")
                {
                    int furstNumber = int.Parse(tokkens[1]);
                    int secondNumber = int.Parse(tokkens[2]);

                    numberStack.Push(furstNumber);
                    numberStack.Push(secondNumber);
                }
                else if (operation == "remove")
                {
                    int removeCount = int.Parse(tokkens[1]);
                    if (numberStack.Count >= removeCount)
                    {
                        for (int i = 0; i < removeCount; i++)
                        {
                            numberStack.Pop();
                        }
                    }
                }
            }
        }
    }
}
