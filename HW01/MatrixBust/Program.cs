using System;
using System.Diagnostics;

namespace MatrixBust
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 0;
            int cols = 0;
            int[,] matrix = {};

            Console.WriteLine("Enter the size of matrix!");
            Console.Write("   Rows: ");
            string rowsStr = Console.ReadLine();

            Console.Write("Columns: ");
            string colsStr = Console.ReadLine();

            if (!string.IsNullOrEmpty(rowsStr) && !string.IsNullOrEmpty(colsStr))
            {
                int.TryParse(rowsStr, out rows);
                int.TryParse(colsStr, out cols);
            }

            if (rows > 0 && cols > 0)
                matrix = new int[rows, cols];

            TimeSpan time1 = MatrixBustMethod1(matrix, rows, cols);
            TimeSpan time2 = MatrixBustMethod2(matrix, rows, cols);

            Console.WriteLine("Runtime pass by rows: {0:00}:{1:00}:{2:00}.{3:00}", 
                                                     time1.Hours, 
                                                     time1.Minutes,
                                                     time1.Seconds, 
                                                     time1.Milliseconds);
            Console.WriteLine("Runtime pass by cols: {0:00}:{1:00}:{2:00}.{3:00}",
                                                     time2.Hours,
                                                     time2.Minutes,
                                                     time2.Seconds,
                                                     time2.Milliseconds);

            Console.ReadLine();
        }

        public static int[,] FillMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows,cols];

            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(0, 100);
                }
            }

            return matrix;
        }

        public static TimeSpan MatrixBustMethod1(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Bypassing the rows!");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0:00} ", matrix[i, j]);
                }

                Console.WriteLine();
            }

            stopWatch.Stop();

            Console.WriteLine();
            return stopWatch.Elapsed;
        }

        public static TimeSpan MatrixBustMethod2(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Bypassing the columns!");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write("{0:00} ", matrix[j, i]);
                }

                Console.WriteLine();
            }

            stopWatch.Stop();

            Console.WriteLine();
            return stopWatch.Elapsed;
        }

    }
}
