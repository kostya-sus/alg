using System;

namespace MED
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------- Minimun Edit Distance! --------------");
            Console.WriteLine("\n(The minimum of editing operations sequence 1 to sequence 2)");
            Console.WriteLine("(Lines are interpreted as an array of characters!)\n");

            Console.Write("Enter the sequence 1: ");
            string sequence1 = Console.ReadLine();

            Console.Write("Enter the sequence 2: ");
            string sequence2 = Console.ReadLine();

            MinimumEditDistance.Ininitialization(sequence1, sequence2);

            Console.WriteLine("\n\n---------- Result ----------");
            Console.WriteLine("MED: {0}", MinimumEditDistance.GetMED);

            var pairsOfLetters = MinimumEditDistance.GetPairsOfLetters;
            Console.WriteLine("#nSequence alignment:");
            for (int i = pairsOfLetters.Count - 1; i >= 0; i--)
            {
                var pair = pairsOfLetters[i];
                Console.Write("{0} {1}\n", pair[0], pair[1]);
            }

            var operations = MinimumEditDistance.GetOperations;
            Console.WriteLine("\nOperations by sequence 1:");
            foreach (var operation in operations)
            {
                Console.WriteLine(operation);
            }

            Console.ReadLine();
        }
    }
}
