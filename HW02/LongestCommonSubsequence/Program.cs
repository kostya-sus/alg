using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- Find Longest Common Subsequence! ----------");
            Console.WriteLine("\nLines are interpreted as an array of characters!\n");

            Console.Write("Enter sequence 1: ");
            string sequence1 = Console.ReadLine();

            Console.Write("Enter sequence 2: ");
            string sequence2 = Console.ReadLine();

            string LCS = LongestCommonSubsequence.GetLCS(sequence1, sequence2);

            Console.WriteLine("\nLongest Common Subsequence (LCS): {0}", LCS);
            Console.ReadLine();
        }
    }
}
