using System;
using System.Text.RegularExpressions;

namespace _03._Post_Office
{
    class Program
    {
        static void Main()
        {
            string[] inputLine = Console.ReadLine().Split("|");
            string firstPart = inputLine[0];
            string secondPart = inputLine[1];
            string thirdPart = inputLine[2];

            string firstPattern = @"([#$%*&])(?<capitals>[A-Z]+)(\1)";
            Match firstMatch = Regex.Match(firstPart, firstPattern);
            string capitals = firstMatch.Groups["capitals"].Value;

            for (int i = 0; i < capitals.Length; i++)
            {
                char startLetter = capitals[i];
                int acciiCode = startLetter;

                string secondPattern = $@"{acciiCode}:(?<length>[0-9][0-9])";
                Match secondMatch = Regex.Match(secondPart, secondPattern);
                int length = int.Parse(secondMatch.Groups["length"].Value);

                string thirdPattern = $@"(?<=\s|^){startLetter}[^\s]{{{length}}}(?=\s|$)";
                Match thirdMatch = Regex.Match(thirdPart, thirdPattern);
                string word = thirdMatch.ToString();

                Console.WriteLine(word);
            }
        }
    }
}
