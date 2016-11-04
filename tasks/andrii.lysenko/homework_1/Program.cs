using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace text_spacing
{
    class Program
    {
        static void Print(string text, ConsoleColor color)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = prevColor;
        }

        static void Print(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Console.Write(" |{0}| ", line);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[] dictionary = {"cat", "cats", "sand", "and", "dog"};
            string text = "catsanddog";
            string dictionaryPath = "../../../../../../dict_en.txt";

            ITextParser trieParser = new TrieTextParser();
            ITextParser backtraceParser = new BruteForceTextParser();

            Print("Testing TrieTextParser on small dictionary", ConsoleColor.Cyan);
            trieParser.SetDictionary(dictionary);
            Print(trieParser.SplitText(text));
            Print("Testing BruteForceTextParser on small dictionary", ConsoleColor.Cyan);
            trieParser.SetDictionary(dictionary);
            Print(trieParser.SplitText(text));

            var stopwatch = new Stopwatch();

            Print("Testing BruteForceTextParser on large dictionary", ConsoleColor.Cyan);
            stopwatch.Start();
            backtraceParser.ReadDictionary(dictionaryPath);
            stopwatch.Stop();
            Print(string.Format("Dictionary reading time: {0} ms.", stopwatch.Elapsed.TotalMilliseconds), ConsoleColor.White);
            stopwatch.Reset();
            stopwatch.Start();
            var backtraceResults = backtraceParser.SplitText(text);
            stopwatch.Stop();
            Print(string.Format("Text parsing time: {0} ms.", stopwatch.Elapsed.TotalMilliseconds), ConsoleColor.White);

            stopwatch.Reset();

            Print("Testing TrieTextParser on large dictionary", ConsoleColor.Cyan);
            stopwatch.Start();
            trieParser.ReadDictionary(dictionaryPath);
            stopwatch.Stop();
            Print(string.Format("Dictionary reading time: {0} ms.", stopwatch.Elapsed.TotalMilliseconds), ConsoleColor.White);
            stopwatch.Reset();
            stopwatch.Start();
            var trieResults = trieParser.SplitText(text);
            stopwatch.Stop();
            Print(string.Format("Text parsing time: {0} ms.", stopwatch.Elapsed.TotalMilliseconds), ConsoleColor.White);


            Console.WriteLine("Enter 'view' to view parsing results(their number can be too large).");
            var answer = Console.ReadLine();
            if (answer == "view")
            {
                var list = backtraceResults.ToList();
                Print(string.Format("Results for BruteForceTextParser({0} results): ", list.Count()), ConsoleColor.DarkCyan);
                Print(list);
                list = trieResults.ToList();
                Print(string.Format("Results for TrieTextParser({0} results): ", list.Count()), ConsoleColor.DarkCyan);
                Print(list);

                Console.ReadLine();
            }
        }
    }
}