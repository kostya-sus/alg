using System;

namespace TextJustification
{
    class Program
    {
        const string DefaultInputTextPath = "input.txt";
        const int LatexPower = 3;
        const int DefaultPageWidth = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to console text justifier program!");
            Console.WriteLine("Please wait, while input text is loading...");

            var inputString = DataManager.ReadLinesFromFile(DefaultInputTextPath);
            var textJustifier = new TextJustifier(inputString);

            Console.WriteLine("Input string is: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(inputString);
            Console.ResetColor();

            Console.Write("Please, specify page width: ");
            var pageWidth = DefaultPageWidth;
            if(!int.TryParse(Console.ReadLine(), out pageWidth))
            {
                Console.WriteLine("Should be a number! The default {0} will be used.", pageWidth);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Processing...");
            Console.ResetColor();

            var sentences = textJustifier.DPSolution(pageWidth, LatexPower);
            Console.WriteLine("The result:\n");
            
            for(int i=0; i<sentences.Count; i++)
            {
                Console.WriteLine(sentences[i]);
            }

            Console.ReadLine();
        }
    }
}
