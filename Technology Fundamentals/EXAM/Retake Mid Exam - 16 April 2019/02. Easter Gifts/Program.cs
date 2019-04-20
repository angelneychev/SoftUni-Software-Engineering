using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> giftsAll = Console.ReadLine().Split().ToList();
            string inputLine = Console.ReadLine();
            

            while (inputLine != "No Money")
            {
                string[] tokkens = inputLine.Split();
                string command = tokkens[0];
                string gift = tokkens[1];
                //o	Find the gifts with this name in your collection,
                //if there are any, and change their values to "None".  
                if (command == "OutOfStock")
                {
                    for (int i = 0; i < giftsAll.Count; i++)
                    {
                        if (giftsAll[i].Contains(gift))
                        {
                            giftsAll[i] = "None";
                        }
                    }
                }
                else if (command == "Required")
                {
                    int index = int.Parse(tokkens[2]);

                    if (index > -1 && index < giftsAll.Count)
                    {
                        giftsAll[index] = gift;
                        //None StuffedAnimal Spoon Sweets EasterBunny None Clothes
                    }
                }
                else if (command == "JustInCase")
                {
                    giftsAll[giftsAll.Count - 1] = gift;
                }


                inputLine = Console.ReadLine();
            }

            for (int i = 0; i < giftsAll.Count; i++)
            {
                if (giftsAll[i] != "None")
                {
                    Console.Write(giftsAll[i] + " ");
                }
            }

        }
    }
}
