namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Statput
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = InitializeMatrix(dimestions);
            var ivo = new Ivo();
            var evil = new Evil();

            string command;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                UpdateCoordinates(command, ivo, evil);
                MoveEvil(evil, matrix);
                MoveIvo(ivo, matrix);
            }

            Console.WriteLine(ivo.Score);

        }

        private static void MoveIvo(Ivo ivo, int[,] matrix)
        {
            while (ivo.Row >= 0)
            {
                if (ivo.Row < matrix.GetLength(0) && ivo.Col >= 0 && ivo.Col < matrix.GetLength(1))
                {
                    ivo.CollectPoints(matrix[ivo.Row, ivo.Col]);
                }

                ivo.UdateCordinates(ivo.Row - 1, ivo.Col + 1);
            }
        }

        private static void MoveEvil(Evil evil, int[,] matrix)
        {
            while (evil.Row >= 0)
            {
                if (evil.Row < matrix.GetLength(0) && evil.Col >= 0 && evil.Col < matrix.GetLength(1))
                {
                    matrix[evil.Row, evil.Col] = 0;
                }

                evil.UpdateCoordinates(evil.Row - 1, evil.Col - 1);
            }
        }

        private static void UpdateCoordinates(string command, Ivo ivo, Evil evil)
        {
            var ivoCoordinates = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            ivo.UdateCordinates(ivoCoordinates[0], ivoCoordinates[1]);

            command = Console.ReadLine();

            var evilCoordinates = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            evil.UpdateCoordinates(evilCoordinates[0], evilCoordinates[1]);
        }

        private static int[,] InitializeMatrix(int[] dimestions)
        {
            int rowsCount = dimestions[0];
            int colsCount = dimestions[1];
            int count = 0;
            var matrix = new int[rowsCount, colsCount];

            for (short indexRow = 0; indexRow < rowsCount; indexRow++)
            {
                for (short indexCol = 0; indexCol < colsCount; indexCol++)
                {
                    matrix[indexRow, indexCol] = count++;
                }
            }

            return matrix;
        }
    }
}
