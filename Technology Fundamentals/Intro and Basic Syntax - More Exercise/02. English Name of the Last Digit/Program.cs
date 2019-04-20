using System;
//Intro and Basic Syntax - More Exercise
namespace _02._English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            //zero one two three four five six seven eight nine
            int numbers = int.Parse(Console.ReadLine());
            int num = numbers % 10;
            string name = String.Empty;

            switch (num)
            {
                case 0:
                    name = "zero";
                    break;
                case 1:
                    name = "one";
                    break;
                case 2:
                    name = "two";
                    break;
                case 3:
                    name = "three";
                    break;
                case 4:
                    name = "four";
                    break;
                case 5:
                    name = "five";
                    break;
                case 6:
                    name = "six";
                    break;
                case 7:
                    name = "seven";
                    break;
                case 8:
                    name = "eight";
                    break;
                case 9:
                    name = "nine";
                    break;
            }

            Console.WriteLine(name);

        }
    }
}
