using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SpaceStationEstablishment
{
   public class PSpaceStationEstablishment
    {
        static char[][] galaxy;
        static int spaceshipRow;
        static int spaceshipCol;
        static int firstBlackholeRow = -1;
        static int firstBlackholeCol = -1;
        static int secondBlackholeRow;
        static int secondBlackholeCol;
        static int starsCount;
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            galaxy = new char[rows][];

            InitiliazeGalaxy();
            SpaceshipMove();

            if (starsCount >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {starsCount}");
                PrintGalaxy();
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {starsCount}");
                PrintGalaxy();
            }
        }

        private static void PrintGalaxy()
        {
            foreach (var row in galaxy)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void SpaceshipMove()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up" && IsInside(spaceshipRow - 1, spaceshipCol))
                {
                    spaceshipRow--;
                }
                else if (command == "down" && IsInside(spaceshipRow + 1, spaceshipCol))
                {
                    spaceshipRow++;
                }
                else if (command == "left" && IsInside(spaceshipCol - 1, spaceshipRow))
                {
                    spaceshipCol--;
                }
                else if (command == "right" && IsInside(spaceshipCol + 1, spaceshipRow))
                {
                    spaceshipCol++;
                }
                else
                {
                    break;
                }

                if (char.IsDigit(galaxy[spaceshipRow][spaceshipCol]))
                {
                    starsCount += galaxy[spaceshipRow][spaceshipCol] - '0';
                    galaxy[spaceshipRow][spaceshipCol] = '-';

                    if (starsCount >= 50)
                    {
                        galaxy[spaceshipRow][spaceshipCol] = 'S';
                        break;
                    }
                }
                else if (galaxy[spaceshipRow][spaceshipCol] == 'O')
                {
                    spaceshipRow = secondBlackholeRow;
                    spaceshipCol = secondBlackholeCol;

                    galaxy[firstBlackholeRow][firstBlackholeCol] = '-';
                    galaxy[secondBlackholeRow][secondBlackholeCol] = '-';
                }
            }
        }

        // How can I be so stupid not to set the initial blackholes dimensions ?!
        private static void InitiliazeGalaxy()
        {
            for (int row = 0; row < galaxy.Length; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();
                galaxy[row] = new char[values.Length];

                for (int col = 0; col < values.Length; col++)
                {
                    galaxy[row][col] = values[col];

                    if (galaxy[row][col] == 'S')
                    {
                        spaceshipRow = row;
                        spaceshipRow = col;
                        galaxy[row][col] = '-';
                    }
                    else if (galaxy[row][col] == 'O' && firstBlackholeRow == -1 && firstBlackholeCol == -1)
                    {
                        firstBlackholeRow = row;
                        firstBlackholeCol = col;
                    }
                    else if (galaxy[row][col] == 'O' && firstBlackholeRow != -1 && firstBlackholeCol != -1)
                    {
                        secondBlackholeRow = row;
                        secondBlackholeCol = col;
                    }
                }
            }
        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow >= 0 && desiredRow < galaxy.Length
                && desiredCol >= 0 && desiredCol < galaxy[desiredRow].Length;
        }
    }
}
