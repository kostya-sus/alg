using System;

namespace LCS
{
    public static class LongestCommonSubsequence
    {
        public static string FindLcs(string[] str1, string[] str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 1; i < str1.Length + 1; i++)
            {
                for (int j = 1; j < str2.Length + 1; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            return ReturnSubsequence(dp, str1, str2, str1.Length, str2.Length);
        }

        private static string ReturnSubsequence(int[,] dp, string[] str1, string[] str2, int length1,
            int length2)
        {
            string commonSubsequenence = "";

            if (length1 == 0 || length2 == 0)
            {
                return commonSubsequenence;
            }
            //move corner
            if (str1[length1 - 1] == str2[length2 - 1])
            {
                commonSubsequenence = ReturnSubsequence(dp, str1, str2, length1 - 1, length2 - 1);
                commonSubsequenence += str1[length1 - 1]+ " ";
                
                return commonSubsequenence;
            }
            //move up
            if (dp[length1 - 1, length2] >= dp[length1, length2 - 1])
            {
                return ReturnSubsequence(dp, str1, str2, length1 - 1, length2);
            }
            //move left
            if (dp[length1, length2 - 1] >= dp[length1 - 1, length2])
            {
                return ReturnSubsequence(dp, str1, str2, length1, length2 - 1);
            }

            return commonSubsequenence;
        }
    }
}