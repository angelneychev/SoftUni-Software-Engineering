using System;

namespace _08._Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberFish = int.Parse(Console.ReadLine());
            int countFish = 0;
            double costMoney = 0;
            double incomeMoney = 0;
            for (int i = 1; i <= numberFish; i++)
            {
                string typeFish = Console.ReadLine();
                if (typeFish == "Stop")
                {
                    break;
                }
                double fishKG = double.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    double currentIncome = 0;
                    for (int w = 0; w < typeFish.Length; w++)
                    {
                        char fish = typeFish[w];
                        currentIncome += fish;
                    }
                    incomeMoney += currentIncome / fishKG;
                }
                else
                {
                    double currentCost = 0;
                    for (int w = 0; w < typeFish.Length; w++)
                    {
                        char fish = typeFish[w];
                        currentCost += fish;
                    }
                    costMoney += currentCost / fishKG;
                }
                if (i == numberFish)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                }
                countFish++;
            }
            double diff = incomeMoney - costMoney;

            if (incomeMoney > costMoney)
            {
                Console.WriteLine($"Lyubo's profit from {countFish} fishes is {diff:F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(diff):F2} leva today.");
            }
        }
    }
}
