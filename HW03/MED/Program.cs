using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("\nEditing:\n{0}\n{1}", sequence2, MinimumEditDistance.GetEditLine);

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
