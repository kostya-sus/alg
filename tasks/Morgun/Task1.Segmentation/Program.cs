using System;
using System.Collections.Generic;
using System.Diagnostics;

//Dictionary file should be in executable directory with .txt format
//Input file should also be there with one string per line with no spaces or other delimeter characters

namespace WordDelimeter
{
    class Program
    {
        private const string DefaultDictPath = "dict_en.txt";
        private const string DefaultInputPath = "input.txt";
        private const string DefaultOutputName = "output";
        private const string DefaultOutputFormat = "txt";
        private const string DefaultCheckString = "catsanddog";

        static void Main()
        {
            var wordDelimeter = new WordDelimeter(new Dictionary(DefaultDictPath));
            var inputText = DataManager.ReadLinesFromFile(DefaultInputPath);
            var timeMeasure = new Stopwatch();
            var sentencesComplete = new List<string>();

            for (int i = 0; i < inputText.Count; i++)
            {
                Console.WriteLine("The input string is: {0}", inputText[i]);
                var outputPath = string.Format("{0}_{1}.{2}", DefaultOutputName, i, DefaultOutputFormat);

                timeMeasure.Start();
                sentencesComplete = wordDelimeter.GetSentences(inputText[i], outputPath);
                timeMeasure.Stop();
                Console.WriteLine("Total count of combinations: {0}. Time elapsed (ms): {1}.", wordDelimeter.CombinationCount, timeMeasure.ElapsedMilliseconds);
                Console.WriteLine("Output file is: {0}\n", outputPath);

                if(!wordDelimeter.OverSized)
                {
                    DataManager.WriteOutput(sentencesComplete, outputPath);
                }
                timeMeasure.Reset();

            }
            Console.WriteLine("It works!");
            Console.ReadLine();
        }

    }
}
