using System;
using System.Linq;

namespace _5._Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int columns = size[1];

            int[][] rubik = new int[rows][];

            FillRubik(rubik, columns);

            int n = int.Parse(Console.ReadLine());

            for(int i=0;i<n;i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                Shift(rubik, columns, command);
            }

            //Rearranging
            int counter = 1;

            for(int row=0;row<rubik.Length;row++)
            {
                for(int col=0;col<columns;col++)
                {
                    if(rubik[row][col]==counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        swap(rubik, row, col, counter);
                        counter++;
                    }
                }
            }
            Console.ReadLine();
        }

        private static void swap(int[][] rubik, int row, int col, int counter)
        {
            for(int targetRow=0;targetRow<rubik.Length;targetRow++)
            {
                for(int targetCol=0;targetCol<rubik[targetRow].Length;targetCol++)
                {
                    if(rubik[targetRow][targetCol]==counter)
                    {
                        rubik[targetRow][targetCol] = rubik[row][col];
                        rubik[row][col] = counter;
                        Console.WriteLine("Swap ("+row+", "+col+") with ("+targetRow+", "+targetCol+")");
                    }
                }
            }
        }

        private static void Shift(int[][] rubik, int columns, string[] command)
        {
            int selected = int.Parse(command[0]);
            int moves = int.Parse(command[2]);
            switch(command[1])
            {
                case "up":
                    {
                        moves = moves % rubik.Length;
                        for(int i=0;i<moves;i++)
                        {
                            int firstElement = rubik[0][selected];
                            for (int row=1;row<rubik.Length;row++)
                            {
                                rubik[row-1][selected] = rubik[row][selected];
                            }
                            rubik[rubik.Length - 1][selected] = firstElement;
                        }

                       // printRubik(rubik, columns);
                        break;
                    }
                case "down":
                    {
                        moves = moves % rubik.Length;
                        for (int i = 0; i < moves; i++)
                        {
                            int lastElement = rubik[rubik.Length-1][selected];
                            for (int row = rubik.Length-1; row >0; row--)
                            {
                                rubik[row][selected] = rubik[row-1][selected];
                            }
                            rubik[0][selected] = lastElement;
                        }

                       // printRubik(rubik, columns);
                        break;
                    }
                case "left":
                    {
                        moves = moves % rubik[selected].Length;
                        for (int i = 0; i < moves; i++)
                        {
                            int firstElement = rubik[selected][0];
                            for (int col = 0; col <columns-1; col++)
                            {
                                rubik[selected][col] = rubik[selected][col + 1];
                            }
                            rubik[selected][columns - 1] = firstElement;
                        }
                        //printRubik(rubik, columns);
                        break;
                    }
                case "right":
                    {
                        moves = moves % rubik[selected].Length;
                        for (int i = 0; i < moves; i++)
                        {
                            int lastElement = rubik[selected][columns - 1];
                            for (int col = columns - 1; col > 0; col--)
                            {
                                rubik[selected][col] = rubik[selected][col - 1];
                            }
                            rubik[selected][0] = lastElement;
                        }
                       // printRubik(rubik, columns);
                        break;
                    }
            }
        }

        private static void FillRubik(int[][] rubik, int columns)
        {
            for(int i=0;i<rubik.Length;i++)
            {
                rubik[i] = new int[columns];
            }

            int counter = 1;

            for(int row=0;row<rubik.Length;row++)
            {
                for(int col=0;col<columns;col++)
                {
                    rubik[row][col] = counter++;
                }
            }

           // printRubik(rubik, columns);
        }

        private static void printRubik(int[][] rubik,int columns)
        {
            for (int row = 0; row < rubik.Length; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(rubik[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
