using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            GetRoom(n);

            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];

            GetSamPosition(samPosition);

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies();

                int[] enemyPosition = new int[2];

                GetEnemy(samPosition, enemyPosition);

                IsSamDead(samPosition, enemyPosition);

                room[samPosition[0]][samPosition[1]] = '.';

                MoveSamPos(moves, samPosition, i);

                room[samPosition[0]][samPosition[1]] = 'S';

                GetEnemy(samPosition, enemyPosition);

                IsNikoladzeDead(samPosition, enemyPosition);

            }
        }

        private static void IsNikoladzeDead(int[] samPosition, int[] enemyPosition)
        {
            if (room[enemyPosition[0]][enemyPosition[1]] == 'N' && samPosition[0] == enemyPosition[0])
            {
                room[enemyPosition[0]][enemyPosition[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private static void IsSamDead(int[] samPosition, int[] enemyPosition)
        {
            if (samPosition[1] < enemyPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'd'
                                && enemyPosition[0] == samPosition[0])
            {
                SamDies(samPosition);
            }
            else if (enemyPosition[1] < samPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'b' && enemyPosition[0] == samPosition[0])
            {
                SamDies(samPosition);
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void GetEnemy(int[] samPosition, int[] enemyPosition)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    enemyPosition[0] = samPosition[0];
                    enemyPosition[1] = j;
                }
            }
        }

        private static void MoveSamPos(char[] moves, int[] samPosition, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private static void SamDies(int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Environment.Exit(0);
        }

        private static void GetSamPosition(int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void GetRoom(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
