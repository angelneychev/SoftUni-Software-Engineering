using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "end")
            {
                string messages = string.Empty;
                foreach (var decoder in input)
                {
                    int newChar = decoder - key;
                    messages += ((char)newChar);
                }
                // Console.WriteLine(messages);
                string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<type>|[A-Z]|)!";
                Regex regex = new Regex(pattern);

                if (regex.IsMatch(messages))
                {
                    string type = regex.Match(messages).Groups["type"].Value;
                    string name = regex.Match(messages).Groups["name"].Value;

                    if (type == "G")
                    {
                        Console.WriteLine($"{name}");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
