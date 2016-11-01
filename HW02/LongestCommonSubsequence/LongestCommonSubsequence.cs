using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    public static class LongestCommonSubsequence
    {
        public static string GetLCS(string sequence1, string sequence2)
        {
            int n = sequence1.Length;
            int m = sequence2.Length;
            string subSequence = "";

            int[,] matrixLengths = MatrixLengths(sequence1, sequence2);

            for (int i = n; i >= 1; i--)
            {
                for (int j = m; j >= 1;)
                {
                    if (sequence1[i - 1] == sequence2[j - 1])
                    {
                        subSequence = sequence1[i - 1] + subSequence;
                        m--;
                    }
                    else if(matrixLengths[i, j - 1] > matrixLengths[i - 1, j])
                    {
                        j = --m;
                        continue;
                    }

                    break;
                }
            }

            return subSequence;
        }


        private static int[,] MatrixLengths(string sequence1, string sequence2)
        {
            int n = sequence1.Length;
            int m = sequence2.Length;

            int[,] matrix = new int[n + 1, m + 1];

            for (int i = 0; i <= m; i++)
            {
                matrix[0, i] = 0;
            }

            for (int i = 0; i <= n; i++)
            {
                matrix[i, 0] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (sequence1[i - 1] == sequence2[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            return matrix;
        }

        private static int Max(int int1, int int2)
        {
            return int1 > int2 ? int1 : int2;
        }
    }
}
