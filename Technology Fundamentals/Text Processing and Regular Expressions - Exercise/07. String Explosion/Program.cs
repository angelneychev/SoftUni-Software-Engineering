using System;
using System.Text;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool bomb = false;

            int power = 0;

            int countMissedChars = 0;

            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current == '>')
                {
                    bomb = true;

                    power += int.Parse(input[i + 1].ToString());

                    sb.Append(current);

                    continue;
                }
                if (bomb == true && power > 0)
                {
                    power--;

                    if (power <= 0)
                    {
                        bomb = false;
                        power = 0;
                    }
                    continue;
                }
                if (bomb == false)
                {
                    sb.Append(current);
                }
            }
            Console.WriteLine(sb.ToString());

        }
    }
}
