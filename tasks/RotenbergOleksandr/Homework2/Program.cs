using System;

namespace LCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var str1 = "fsdfsdgfhgd";
            var str2 = "dfsdfsdgsdf";
            var result = LongestCommonSubsequence.FindLcs(str1, str2);

            Console.WriteLine(result);
        }
    }
}
