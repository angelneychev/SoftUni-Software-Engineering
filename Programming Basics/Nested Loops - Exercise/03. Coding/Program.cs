using System;

namespace _03._Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numInString = number.ToString();
            int count = numInString.Length;
            //Console.WriteLine(number);
            //Console.WriteLine(count);
            int b = 0;
            int c = 0;


            for (int i = 0; i < count; i++)
            {

                b = number / 10;
                c = number % 10;
                number = b;
                int e = c;
                int z = c + 33;
                if (e == 0)
                {
                    Console.Write("ZERO");
                }
                for (int w = 0; w < e; w++)
                {
                    Console.Write((char)z);

                }
                Console.WriteLine();
            }
        }
    }
}
