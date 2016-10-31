using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    class Program
    {
        enum Direction
        {
            None = 0,
            Left,
            Top,
            Diagonal
        }

        static void FillZeros(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                a[i, 0] = 0;
            }
            for (int j = 0; j < a.GetLength(1); j++)
            {
                a[0, j] = 0;
            }
        }

        static void FindLargestCommonSubsequence(string x, string y, int[,] lcs, Direction[,] way)
        {
            for (int i = 1; i < lcs.GetLength(0); i++)
                for (int j = 1; j < lcs.GetLength(1); j++)
                {
                    if (x[i] == y[j])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                        way[i, j] = Direction.Diagonal;
                    }
                    else
                    {
                        if (lcs[i - 1, j] != 0 || lcs[i, j - 1] != 0)
                        {
                            if (lcs[i - 1, j] > lcs[i, j - 1])
                            {
                                lcs[i, j] = lcs[i - 1, j];
                                way[i, j] = Direction.Left;
                            }
                            else
                            {
                                lcs[i, j] = lcs[i, j - 1];
                                way[i, j] = Direction.Top;
                            }
                        }
                    }
                }
        }

        static void DisplayWay(Direction[,] way, string x)
        {
            var stack = new Stack<char>();
            int i = way.GetLength(0) - 1;
            int j = way.GetLength(1) - 1;

            while (way[i, j] != Direction.None)
            {
                switch (way[i, j])
                {
                    case Direction.Diagonal:
                        stack.Push(x[i]);
                        i -= 1;
                        j -= 1;
                        break;
                    case Direction.Left:
                        i -= 1;
                        break;
                    case Direction.Top:
                        j -= 1;
                        break;
                }
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter two sequences:");
            var x = ' ' + Console.ReadLine();
            var y = ' ' + Console.ReadLine();
            int m = x.Length;
            int n = y.Length;
            int[,] lcs = new int[m, n];
            Direction[,] way = new Direction[m, n];
            FillZeros(lcs);
            FindLargestCommonSubsequence(x, y, lcs, way);
            Console.WriteLine("Max subsequence length: {0}", lcs[m - 1, n - 1]);
            Console.WriteLine("Subsequence: ");
            DisplayWay(way, x);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}