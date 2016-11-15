using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG_LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lengths = Console.ReadLine().Split(' ');
            int m = Int32.Parse(lengths[0]);
            int n = Int32.Parse(lengths[1]);
            string[] sequence1 = Console.ReadLine().Split(' ');
            string[] sequence2 = Console.ReadLine().Split(' ');



            string[,] dp = new string[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = string.Empty;
                    }
                    else if (sequence1[i - 1] == sequence2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + sequence1[i - 1] + ' ';

                    }
                    else if ((dp[i - 1, j].Length > dp[i, j - 1].Length))
                    {
                        dp[i, j] = dp[i - 1, j] ;
                    }
                    else dp[i, j] = dp[i, j - 1];

                }
            }
            
            Console.WriteLine(dp[m, n]);
            Console.ReadLine();
        }
    }
}
