using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] sizes = IntArrayParserFromConsole();
            int x = sizes[0];
            int y = sizes[1];

            int[,] galaxy = new int[x, y];

            int value = 0;
            value = GetGalaxy(x, y, galaxy, value);

            string input = Console.ReadLine();
            long sum = 0;
            while (input != "Let the Force be with you")
            {
                int[] goodStarsStart = input
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilStarsStart = IntArrayParserFromConsole();

                int xEvil = evilStarsStart[0];
                int yEvil = evilStarsStart[1];

                DestroyStars(galaxy, ref xEvil, ref yEvil);

                int xGood = goodStarsStart[0];
                int yGood = goodStarsStart[1];

                SumIvoStars(galaxy, ref sum, ref xGood, ref yGood);

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }


        private static void SumIvoStars(int[,] galaxy, ref long sum, ref int xGood, ref int yGood)
        {
            while (xGood >= 0 && yGood < galaxy.GetLength(1))
            {
                if (xGood >= 0 && xGood < galaxy.GetLength(0) && yGood >= 0 && yGood < galaxy.GetLength(1))
                {
                    sum += galaxy[xGood, yGood];
                }

                yGood++;
                xGood--;
            }
        }

        private static void DestroyStars(int[,] galaxy, ref int xEvil, ref int yEvil)
        {
            while (xEvil >= 0 && yEvil >= 0)
            {
                if (xEvil >= 0 && xEvil < galaxy.GetLength(0) && yEvil >= 0 && yEvil < galaxy.GetLength(1))
                {
                    galaxy[xEvil, yEvil] = 0;
                }
                xEvil--;
                yEvil--;
            }
        }

        private static int GetGalaxy(int x, int y, int[,] galaxy, int value)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    galaxy[i, j] = value++;
                }
            }

            return value;
        }

        private static int[] IntArrayParserFromConsole()
        {
            return Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
