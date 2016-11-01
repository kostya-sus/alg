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
            Console.Write("Enter sequence 1: ");
            string sequence1 = Console.ReadLine();

            Console.Write("Enter sequence 2: ");
            string sequence2 = Console.ReadLine();

            string LCS = LongestCommonSubsequence.GetLCS(sequence1, sequence2);

            Console.WriteLine("LCS: {0}", LCS);
            Console.ReadLine();
        }
    }
}
