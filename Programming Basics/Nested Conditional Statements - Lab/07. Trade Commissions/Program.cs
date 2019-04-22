using System;

namespace _07._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine().ToLower();
            var salse = double.Parse(Console.ReadLine());
            double commission = -1;
            switch (town)
            {
                case "sofia":
                    if (salse >= 0 && salse <= 500)
                    {
                        commission = salse * 0.05;
                    }
                    else if (salse > 500 && salse <= 1000)
                    {
                        commission = salse * 0.07;
                    }
                    else if (salse > 1000 && salse <= 10000)
                    {
                        commission = salse * 0.08;
                    }
                    else if (salse > 10000)
                    {
                        commission = salse * 0.12;
                    }

                    break;
                case "varna":
                    if (salse >= 0 && salse <= 500)
                    {
                        commission = salse * 0.045;
                    }
                    else if (salse > 500 && salse <= 1000)
                    {
                        commission = salse * 0.075;
                    }
                    else if (salse > 1000 && salse <= 10000)
                    {
                        commission = salse * 0.10;
                    }
                    else if (salse > 10000)
                    {
                        commission = salse * 0.13;
                    }

                    break;
                case "plovdiv":
                    if (salse >= 0 && salse <= 500)
                    {
                        commission = salse * 0.055;
                    }
                    else if (salse > 500 && salse <= 1000)
                    {
                        commission = salse * 0.08;
                    }
                    else if (salse > 1000 && salse <= 10000)
                    {
                        commission = salse * 0.12;
                    }
                    else if (salse > 10000)
                    {
                        commission = salse * 0.145;
                    }

                    break;
            }

            if (commission >= 0)
            {
                Console.WriteLine($"{commission:F2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
