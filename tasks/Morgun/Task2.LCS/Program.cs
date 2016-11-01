using System;
using System.Collections.Generic;

namespace LCS
{
    class Program
    {
        private const string QuadroSpace = "    ";

        //The original sequence is 0,1,2,1,3,0,1. 0 added in zero position
        //In order to start compare from 1st position
        private static int[] _firstSequence = {0, 0, 1, 2, 1, 3, 0, 1};
        //The same reason
        private static int[] _secondSequence = {0, 1, 3, 2, 0, 1, 0};
        private static int[,] _tableLCS;
        private static string _tableLCSPath;

        static void Main(string[] args)
        {
            Console.WriteLine("DP LCS exapmple.");
            Console.Write(" First sequence: ");
            PrintSequnce(_firstSequence);
            Console.Write("Second sequence: ");
            PrintSequnce(_secondSequence);

            _tableLCS = new int[_firstSequence.Length, _secondSequence.Length];

            _tableLCS = GetTableLCS(_tableLCS, _firstSequence, _secondSequence);
            Console.WriteLine("The result table: \n");
            PrintTableLCS(_tableLCS);

            Console.Write("The longest path is in [m,n] cell, ");
            Console.WriteLine("where m - length of first sequence, n - length of second");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("And the LCS is {0}", _tableLCS[_firstSequence.Length-1, _secondSequence.Length - 1]);
            Console.ResetColor();

            Console.Write("The LCS sequence: ");
            FindLCSPath(_tableLCS, _firstSequence, _secondSequence, _firstSequence.Length - 1, _secondSequence.Length - 1);
            PrintTableLCSPath(_tableLCSPath);
            Console.ReadLine();
        }

        static int[,] GetTableLCS(int[,] tableLCS, int[] X, int[] Y)
        {
            for (int i = 1; i < X.Length; i++)
            {
                for (int j = 1; j < Y.Length; j++)
                {
                    tableLCS[i, j] = X[i] == Y[j] ? tableLCS[i - 1, j - 1] + 1 : Math.Max(tableLCS[i, j - 1], tableLCS[i - 1, j]);
                }
            }
            return tableLCS;
        }

        static void FindLCSPath(int[,] tableLCS, int[] X, int[] Y, int i, int j)
        {
            if ((i == 0) || (j == 0))
            {
                return;
            }
            else
            {
                if (X[i] == Y[j])
                {
                    _tableLCSPath += X[i];
                    FindLCSPath(tableLCS, X, Y, --i, --j);
                }
                else
                {
                    if (tableLCS[i - 1, j] > tableLCS[i, j - 1])
                    {
                        FindLCSPath(tableLCS, X, Y, --i, j);
                    }
                    else
                    {
                        FindLCSPath(tableLCS, X, Y, i, --j);
                    }
                    return;
                }
            }
        }

        static void PrintTableLCSPath(string tableLCSPath)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for(int i=tableLCSPath.Length - 1; i>=0; i--)
            {
                Console.Write("{0} ", tableLCSPath[i]);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        static void PrintSequnce(int[] sequence)
        {
            for (int i = 1; i < sequence.Length; i++)
            {
                Console.Write("{0} ", sequence[i]);
            }
            Console.WriteLine();
        }

        static void PrintTableLCS(int[,] tableLCS)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(QuadroSpace);
            PrintSequnce(_secondSequence);

            var currentCursorTop = Console.CursorTop;

            for (int i = 1; i < _firstSequence.Length; i++)
            {
                Console.SetCursorPosition(0, ++currentCursorTop);
                Console.Write("{0} ", _firstSequence[i]);
            }
            Console.ResetColor();

            var row = tableLCS.GetLength(0);
            var col = tableLCS.GetLength(1);
            //Return cursor to the correct position in order to print correct table
            Console.CursorTop -= _firstSequence.Length - 1;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.SetCursorPosition(2 + j * 2, Console.CursorTop);
                    Console.Write("{0} ", tableLCS[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
