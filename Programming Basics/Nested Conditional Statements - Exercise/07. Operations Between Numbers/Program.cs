using System;

namespace _07._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = double.Parse(Console.ReadLine());
            var num2 = double.Parse(Console.ReadLine());
            var oper = Console.ReadLine();
            string type = "";
            double sum = 0.00;

            if (num2 == 0 && (oper == "/" || oper == "%"))
            {
                Console.WriteLine($"Cannot divide {num1} by zero");
            }
            switch (oper)
            {
                case "+":
                    sum = num1 + num2;
                    break;
                case "-":
                    sum = num1 - num2;
                    break;
                case "*":
                    sum = num1 * num2;
                    break;
                case "/":
                    sum = num1 / num2;
                    break;
                case "%":
                    sum = num1 % num2;
                    break;
            }
            switch (sum % 2)
            {
                case 0:
                    type = "even";
                    break;
                default:
                    type = "odd";
                    break;
            }
            if (oper == "+" || oper == "-" || oper == "*")
            {
                Console.WriteLine($"{num1} {oper} {num2} = {sum} - {type}");
            }
            else if (oper == "/" && num2 != 0)
            {
                Console.WriteLine($"{num1} {oper} {num2} = {sum:F2}");
            }
            else if (oper == "%" && num2 != 0)
            {
                Console.WriteLine($"{num1} {oper} {num2} = {sum}");
            }
        }
    }
}
