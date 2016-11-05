using System;

namespace LCS
{
    class Program
    {
        //Sequences should be added one by one with spaces and one sequence per line
        //Only 2 sequences are allowed
        private const string DefaultInputPath = "input.txt";

        static void Main(string[] args)
        {
            var lcs = new LCS(DefaultInputPath);

            Console.WriteLine("DP LCS exapmple.");

            Console.WriteLine("First sequence: ");
            lcs.PrintSequnce(lcs.FirstSequence);
            Console.WriteLine("Second sequence: ");
            lcs.PrintSequnce(lcs.SecondSequence);

            Console.WriteLine("The result table: \n");
            lcs.PrintTable();

            Console.Write("The longest path is in [m,n] cell, ");
            Console.WriteLine("where m - length of first sequence, n - length of second");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LCS (max count) is {0}", lcs.MaxLCS);
            Console.ResetColor();

            Console.WriteLine("LCS is:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(lcs.OneOfLCS);
            Console.ResetColor();

            Console.ReadLine();
        }
    }

}
