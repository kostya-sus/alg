using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommomSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "ABC",
            s2 = "BCA";
            LCS(s1, s2);
            Console.WriteLine(LCS(s1, s2));
        }

        public static string LCS(string _s1, string _s2)
        {

            int m = _s1.Length;
            int n = _s2.Length;

            string[,] dp = new string[m + 1, n + 1];

            for (int i = 0; i <= m; ++i)
            {
                for (int j = 0; j <= n; ++j)
                {
                    if (i == 0 || j == 0)
                        dp[i, j] = string.Empty;
                    else if (_s1[i - 1] == _s2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + _s1[i - 1];
                    else
                        dp[i, j] = (dp[i - 1, j].Length > dp[i, j - 1].Length) ? dp[i - 1, j] : dp[i, j - 1];
                }
            }
            return dp[m, n];
        }
    }
}
