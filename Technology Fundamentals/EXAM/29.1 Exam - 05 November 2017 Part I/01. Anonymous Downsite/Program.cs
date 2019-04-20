using System;
using System.Linq;
using System.Numerics;

namespace _01._Anonymous_Downsite
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberSite = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            BigInteger securityToken = BigInteger.Pow(securityKey, numberSite);//Math.Pow(securityKey, Count)

            for (int i = 1; i <= numberSite; i++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split()
                    .ToArray();
                string site = inputLine[0];
                long siteVisits = long.Parse(inputLine[1]);
                decimal pricePerVisit = decimal.Parse(inputLine[2]);
                totalLoss = totalLoss + ((decimal)siteVisits * pricePerVisit);
                Console.WriteLine(site);
            }

            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {securityToken}");

        }
    }
}
