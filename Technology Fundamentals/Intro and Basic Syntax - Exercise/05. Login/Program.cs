using System;
using System.Linq;
//Intro and Basic Syntax - Exercise
namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();

            string validePassord = string.Empty;

            for (var i = username.Length - 1; i >= 0; i--)
            {
                validePassord += username[i];

            }

            int countLogin = 0;
            while (true)
            {
                countLogin++;
                if (validePassord == password)
                {
                    countLogin = 0;
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else if (validePassord != password)
                {
                    if (countLogin > 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }

                    Console.WriteLine("Incorrect password. Try again.");
                }

                password = Console.ReadLine();
            }

        }
    }
}
