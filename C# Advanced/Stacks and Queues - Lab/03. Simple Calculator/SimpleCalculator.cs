using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._Simple_Calculator
{
    public class SimpleCalculator
    {
        static void Main()
        {
            var command = Console.ReadLine().Split(' ').Reverse();
            var numStack = new  Stack<string>();
            int total = 0;
            foreach (var item in command)
            {
                numStack.Push(item);
            }

            while (numStack.Count > 0)
            {

                string tokkens = numStack.Peek(); //виждам елемента какъв е

                switch (tokkens)
                {
                    case "+":
                        numStack.Pop(); //премахвам
                        total += int.Parse(numStack.Peek()); //събирам/изваждам
                        numStack.Pop(); // премахвам
                        break;
                    case "-":
                        numStack.Pop();
                        total -= int.Parse(numStack.Peek());
                        numStack.Pop();
                        break;
                    default:
                        total += int.Parse(numStack.Peek());
                        numStack.Pop();
                        break;
                }
            }

            Console.WriteLine(total);
        }
    }
}
