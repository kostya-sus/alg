using System;


namespace ALG_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence1 = "fsdfsdgfhgdhik",
                   sequence2 = "dfsdfsdgsdfolti";

            Console.WriteLine(LongestCommonSubsequence(sequence1, sequence2));
            Console.ReadLine();
        }

        public static string LongestCommonSubsequence(string sequence1, string sequence2)
        {

            int m = sequence1.Length,
                n = sequence2.Length;

            string[,] dp = new string[m + 1, n + 1];

            for (int i = 0; i <= m; ++i)
            {
                for (int j = 0; j <= n; ++j)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = string.Empty;
                    }
                    else if (sequence1[i - 1] == sequence2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + sequence1[i - 1];
                    }
                    else if ((dp[i - 1, j].Length > dp[i, j - 1].Length))
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else dp[i, j] = dp[i, j - 1];

                }
            }
            return dp[m, n];
        }
    }
}
