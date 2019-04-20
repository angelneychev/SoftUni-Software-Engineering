using System;
using System.Text.RegularExpressions;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
           // string pattern = @"^[A-Za-z0-9!@#$?]+(={1})[0-9]+(<{2})(.+)";
           string pattern = @"^(?<name>[\w\d!@#$?]+)=(?<length>[\d]+)<<(?<geodashCode>.+)$";
           Regex regex = new Regex(pattern);
           while (inputLine != "Last note")
           {
               var match = Regex.Match(inputLine, pattern);
               if (match.Success)
               {
                   string name = match.Groups["name"].Value;
                   int length = int.Parse(match.Groups["length"].Value);
                   string geodashCode = match.Groups["geodashCode"].Value;
                   string newName = String.Empty;
                   if (length == geodashCode.Length)
                   {
                       foreach (var items in name)
                       {
                           if (char.IsLetter(items))
                           {
                               newName += items;
                           }
                       }
                       Console.WriteLine($"Coordinates found! {newName}->{geodashCode}");
                   }

                   Console.WriteLine("Nothing found!");
               }
               else
               {
                   Console.WriteLine("Nothing found!");
                }
                inputLine = Console.ReadLine();
           }
        }
    }
}
