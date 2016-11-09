using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoLCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string lcs = LCS("abcbdab", "bdcaba");
            Console.WriteLine(lcs);
            Console.ReadLine();
        }

        static string LCS(string x, string y)
        {

            string[,] sequences = new string[x.Length + 1, y.Length + 1];
            sequences = EmptyFirstRowAndColumn(sequences, x.Length + 1, y.Length + 1);
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < y.Length; j++)
                {
                    if (x[i] == y[j])
                    {
                        sequences[i + 1, j + 1] = sequences[i, j] + x[i];
                    } else
                    {
                        sequences[i + 1, j + 1] = (sequences[i, j + 1].Length > sequences[i + 1, j].Length)
                            ? sequences[i, j + 1]
                            : sequences[i + 1, j];

                    }
                }
            }
            return sequences[x.Length, y.Length];
        }

        static string[,] EmptyFirstRowAndColumn(string[,] A, int rowNum, int colNum)
        {
            int minLength = Math.Min(rowNum, colNum);
            for (int i = 0; i < minLength; i++)
            {
                A[i, 0] = "";
                A[0, i] = "";
            }
            for (int i = minLength; i < rowNum; i++)
            {
                A[i, 0] = "";
            }
            for (int i = minLength; i < colNum; i++)
            {
                A[0, i] = "";
            }
            return A;
        }

    }
}
