using System;
//Intro and Basic Syntax - Exercise
namespace _01._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputAge = int.Parse(Console.ReadLine());
            string person = String.Empty;


            if (inputAge >= 0 && inputAge <= 2)
            {
                person = "baby";
            }
            else if (inputAge >= 3 && inputAge <= 13)
            {
                person = "child";
            }
            else if (inputAge >= 14 && inputAge <= 19)
            {
                person = "teenager";
            }
            else if (inputAge >= 20 && inputAge <= 65)
            {
                person = "adult";
            }
            else if (inputAge >= 66)
            {
                person = "elder";
            }

            Console.WriteLine(person);
        }
    }
}
