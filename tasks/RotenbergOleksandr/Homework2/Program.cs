﻿using System;

namespace LCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var str1 =
                "16 27 89 79 60 76 24 88 55 94 57 42 56 74 24 95 55 33 69 29 14 7 94 41 8 71 12 15 43 3 23 49 84 78 73 63 5 46 98 26 40 76 41 89 24 20 68 14 88 26";
            var str2 =
                "27 76 88 0 55 99 94 70 34 42 31 47 56 74 69 46 93 88 89 7 94 41 68 37 8 71 57 15 43 89 43 3 23 35 49 38 84 98 47 89 73 24 20 14 88 75";
            var result = LongestCommonSubsequence.FindLcs(str1.Split(' '), str2.Split(' '));
            result = result.Remove(result.Length - 1); //remove last space in result

            Console.WriteLine(result);
        }
    }
}
