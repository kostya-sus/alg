using System;

namespace LCS
{
    public static class LongestCommonSubsequence
    {
        public static string FindLcs(char[] arr1, char[] arr2)
        {
            int[,] dp = new int[arr1.Length + 1, arr2.Length + 1];

            for (int i = 1; i < arr1.Length + 1; i++)
            {
                for (int j = 1; j < arr2.Length + 1; j++)
                {
                    if (arr1[i - 1] == arr2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                    }
                }
            }

            return ReturnSubsequence(dp, arr1, arr2, arr1.Length, arr2.Length);
        }

        private static string ReturnSubsequence(int[,] dp, char[] arr1, char[] arr2, int length1,
            int length2)
        {
            string commonSubsequenence = "";

            if (length1 == 0 || length2 == 0)
            {
                return commonSubsequenence;
            }
            //move corner
            if (arr1[length1 - 1] == arr2[length2 - 1])
            {
                commonSubsequenence = ReturnSubsequence(dp, arr1, arr2, length1 - 1, length2 - 1);
                commonSubsequenence += arr1[length1 - 1];
                
                return commonSubsequenence;
            }
            //move up
            if (dp[length1 - 1, length2] >= dp[length1, length2 - 1])
            {
                return ReturnSubsequence(dp, arr1, arr2, length1 - 1, length2);
            }
            //move left
            if (dp[length1, length2 - 1] >= dp[length1 - 1, length2])
            {
                return ReturnSubsequence(dp, arr1, arr2, length1, length2 - 1);
            }
            return commonSubsequenence;
        }
    }
}