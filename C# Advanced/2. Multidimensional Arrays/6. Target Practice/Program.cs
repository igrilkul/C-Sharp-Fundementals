using System;
using System.Linq;

namespace _6._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] shot = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[][] matrix = new char[size[0]][];

            for(int i=0;i<size[0];i++)
            {
                matrix[i] = new char[size[1]];
            }

            fillMatrix(matrix, size[1], snake);

            shoot(matrix, shot);
        }

        private static void shoot(char[][] matrix, int[] shot)
        {
            int impactRow = shot[0];
            int impactCol = shot[1];
            int radius = shot[2];

            for(int row=0;row<matrix.Length;row++)
            {
                for(int col=0;col<matrix[row].Length;col++)
                {
                    if(Math.Pow((row-impactRow),2)+Math.Pow((col-impactCol),2)<=Math.Pow(radius,2))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            trickle(matrix);
            Console.ReadLine();
        }

        private static void trickle(char[][] matrix)
        {
            bool trickling = true;
            while (trickling == true)
            {
                trickling = false;
                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row + 1][col] == ' ' && matrix[row][col]!=' ')
                        {
                            int trickleRow = row + 1;
                            for (; trickleRow < matrix.Length && matrix[trickleRow][col] == ' '; trickleRow++) { }
                            matrix[trickleRow - 1][col] = matrix[row][col];
                            matrix[row][col] = ' ';
                            trickling = true;
                        }
                    }
                }
            }
            printMatrix(matrix);
        }

        private static void fillMatrix(char[][] matrix, int cols, string snake)
        {
            int counter = 0;
            int col = cols-1;
            for(int row=matrix.GetLength(0)-1;row>=0;row--)
            {
                if (col == 0)
                {
                    for (col = 0; col < matrix[row].GetLength(0); col++)
                    {
                        matrix[row][col] = snake[counter % snake.Length];
                        counter++;
                    }
                    col = 1;
                }
                else
                {
                    for (col = cols-1; col >=0; col--)
                    {
                        matrix[row][col] = snake[counter % snake.Length];
                        counter++; 
                    }
                    col = 0;
                }
                
            }

           
        }



        private static void printMatrix(char[][] matrix)
        {

            for(int row=0;row<matrix.GetLength(0);row++)
            {
               for(int col=0;col<matrix[row].GetLength(0);col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();

            }
        }
    }
}
