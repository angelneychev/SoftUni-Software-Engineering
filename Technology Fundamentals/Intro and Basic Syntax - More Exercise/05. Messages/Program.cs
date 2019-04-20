using System;
//Intro and Basic Syntax - More Exercise
namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {


            int numbersOfPush = int.Parse(Console.ReadLine());

            string message = String.Empty;

            for (int i = 0; i < numbersOfPush; i++)
            {
                string digits = Console.ReadLine();
                int digitLength = digits.Length;
                char oneDigit = digits[0];
                double mainDigit = char.GetNumericValue(oneDigit);
                int offset = ((int)mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset = ((int)mainDigit - 2) * 3 + 1;
                }
                int letterIndex = offset + digitLength - 1;
                int letterCode = letterIndex + 97;


                char letter = (char)letterCode;
                if (mainDigit == 0)
                {
                    letter = (char)(mainDigit + 32);
                }
                message += letter;


            }

            Console.WriteLine(message);
        }
    }
}
