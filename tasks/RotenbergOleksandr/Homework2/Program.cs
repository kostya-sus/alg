using System;

namespace LCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var str1 = "fsdfsdgfhgd";
            var str2 = "dfsdfsdgsdf";
            var result = LongestCommonSubsequence.FindLcs(str1.ToCharArray(), str2.ToCharArray());

            Console.WriteLine(result);
        }
    }
}
