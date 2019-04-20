using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopsAll = Console.ReadLine().Split().ToList();
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] tokkens = Console.ReadLine().Split();

                string command = tokkens[0];
                if (command == "Include")
                {
                    string shop = tokkens[1];
                    shopsAll.Add(shop);
                }
                else if (command == "Visit")
                {
                    string countShop = tokkens[1];
                    int countShop2 = int.Parse(tokkens[2]);
                    if (countShop2 <= shopsAll.Count)
                    {
                        if (countShop == "first")
                        {
                            shopsAll.RemoveRange(0, countShop2);
                        }
                        else if (countShop == "last")
                        {
                            shopsAll.RemoveAt(shopsAll.Count - 1);
                        }
                    }
                }
                else if (command == "Prefer")
                {
                    int shopIndex1 = int.Parse(tokkens[1]);
                    int shopIndex2 = int.Parse(tokkens[2]);

                    if ((shopIndex1 > -1 && shopIndex1 < shopsAll.Count) && 
                        (shopIndex2 > -1 && shopIndex2 < shopsAll.Count))
                    {
                        string word1 = shopsAll[shopIndex1];
                        string word2 = shopsAll[shopIndex2];

                        shopsAll[shopIndex1] = word2;
                        shopsAll[shopIndex2] = word1;
                    }
                    //ThriftShop ToyStore Groceries Armani PeakStore
                }
                else if (command == "Place")
                {
                    string shop = tokkens[1];
                    int index = int.Parse(tokkens[2]);
                    if (index >-1 && index < shopsAll.Count-1)
                    {
                        shopsAll.Insert(index+1,shop);
                    }
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ",shopsAll));
        }
    }
}
