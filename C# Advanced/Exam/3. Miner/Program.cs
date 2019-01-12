using System;
using System.Linq;

namespace _3._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            long fieldSize = long.Parse(Console.ReadLine());
            char[][] field = new char[fieldSize][];

            string[] commands = Console.ReadLine().Split();

            for(int i=0;i<fieldSize;i++)
            {
                char[] row = Console.ReadLine().Split().Select(char.Parse).ToArray();
                field[i] = row;
            }

            int sRow=0;
            int sCol=0;
            for(int row=0;row<fieldSize;row++)
            {
                for(int col=0;col<fieldSize;col++)
                {
                    if(field[row][col]=='s')
                    {
                        sRow = row;
                        sCol = col;
                        break;
                    }
                }
            }

            long coalsCollected = 0;
            long totalCoals = coalCounter(field, fieldSize);

            foreach(var command in commands)
            {
                if(isInside(command,sRow,sCol,field))
                {
                    switch(command)
                    {
                        case "up":
                            {
                                sRow -= 1;
                                break;
                            }
                        case "down":
                            {
                                sRow += 1;
                                break;
                            }
                        case "left":
                            {
                                sCol -= 1;
                                break;
                            }
                        case "right":
                            {
                                sCol += 1;
                                break;
                            }
                    }

                    switch(field[sRow][sCol])
                    {
                        case 'c':
                            {
                                coalsCollected++;
                                field[sRow][sCol] = '*';

                                if(coalsCollected==totalCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({sRow}, {sCol})");
                                    Console.ReadLine();

                                    return;
                                }
                                break;
                            }
                        case 'e':
                            {
                                Console.WriteLine($"Game over! ({sRow}, {sCol})");
                                Console.ReadLine();

                                return;
                            }
                        default:
                            {
                                continue;
                            }
                    }
                }
            }

            Console.WriteLine($"{totalCoals-coalsCollected} coals left. ({sRow}, {sCol})");
            Console.ReadLine();
        }

        public static bool isInside(string command, int row, int col, char[][] field)
        {
            switch(command)
            {
                case "up":
                    {
                        if (row - 1 < 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "down":
                    {
                        if (row + 1 >field.Length-1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "left":
                    {
                        if (col - 1 < 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "right":
                    {
                        if (col + 1 > field[0].Length-1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
            }
            return true;
        }

        public static long coalCounter(char[][] field,long fieldSize)
        {
            long coalCount = 0;
            for(int row=0;row<fieldSize;row++)
            {
                for(int col=0;col<fieldSize;col++)
                {
                    if(field[row][col]=='c')
                    {
                        coalCount++;
                    }
                }
            }

            return coalCount;
        }
    }
}
