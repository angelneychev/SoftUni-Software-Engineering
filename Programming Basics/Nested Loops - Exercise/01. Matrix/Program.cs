using System;

namespace _01._Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int one = a; one <= b; one++)
            {
                for (int two = a; two <= b; two++)
                {
                    for (int three = c; three <= d; three++)
                    {
                        for (int four = c; four <= d; four++)
                        {
                            if (one != two && three != four)
                            {
                                if (one + four == two + three)
                                {
                                    Console.WriteLine($"{ one}{two}");
                                    Console.WriteLine($"{ three}{four}");
                                    Console.WriteLine();
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
