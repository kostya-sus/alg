using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    public static class LongestCommonSubsequence
    {
        private static string _sequence1;
        private static string _sequence2;
        private static string _lcs;

        private static int[,] _lengths;

        public static string GetLCS(string sequence1, string sequence2)
        {
            if (string.IsNullOrEmpty(sequence1) || string.IsNullOrEmpty(sequence2))
            {
                throw new ArgumentNullException();
            }

            _sequence1 = sequence1;
            _sequence2 = sequence2;

            FillMatrixLengths();
            GetLCS();

            return _lcs;
        }


        private static void FillMatrixLengths()
        {
            int n = _sequence1.Length;
            int m = _sequence2.Length;

            _lengths = new int[n + 1, m + 1];

            for (int i = 0; i <= m; i++)
            {
                _lengths[0, i] = 0;
            }

            for (int i = 0; i <= n; i++)
            {
                _lengths[i, 0] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (_sequence1[i - 1] == _sequence2[j - 1])
                    {
                        _lengths[i, j] = _lengths[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        _lengths[i, j] = Max(_lengths[i - 1, j], _lengths[i, j - 1]);
                    }
                }
            }
        }

        private static int Max(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        private static void GetLCS()
        {
            int n = _sequence1.Length;
            int m = _sequence2.Length;
            
            _lcs = "";

            for (int i = n; i > 0; i--)
            {
                for (int j = m; j > 0;)
                {
                    if (_lengths[i, j] == _lengths[i, j - 1])
                    {
                        j = --m;
                        continue;
                    }

                    if (_lengths[i, j] != _lengths[i - 1, j])
                    {
                        _lcs = _sequence1[i - 1] + _lcs;
                        --m;
                    }

                    break;
                }
            }
        }
    }
}
