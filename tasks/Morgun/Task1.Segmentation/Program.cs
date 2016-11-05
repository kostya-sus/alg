using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

        private const int MaxSentenceCountInOneBuffer = 100000;

        private static int _currentInputString = 0;
        private static bool _isOverSized = false;
        private static string _outputPath;

        static void Main()
        {
            var inputDictionary = LoadDictionary(DefaultDictPath);
            var inputText = LoadInputText(DefaultInputPath);
            var timeMeasure = new Stopwatch();

            if(inputDictionary.Count == 0)
            {
                Console.WriteLine("Dictionary has no words. Fill it with one word per line and try again.\n(File: {0})", DefaultDictPath);
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < inputText.Count; i++)
            {
                Console.WriteLine("The input string is: {0}", inputText[i]);

                _currentInputString = i;
                _isOverSized = false;
                _outputPath = string.Format("{0}_{1}.{2}", DefaultOutputName, _currentInputString, DefaultOutputFormat);

                if(File.Exists(_outputPath))
                {
                    File.Delete(_outputPath);
                }

                if (inputDictionary.Contains(inputText[i]))
                {
                    Console.WriteLine("output string is: {0}", inputText[i]);
                    continue;
                }

                var sentences = new List<string>();

                timeMeasure.Reset();
                timeMeasure.Start();
                BreakWords(inputText[i], inputDictionary, sentences);
                timeMeasure.Stop();

                if (sentences.Count != 0)
                { 

                    Console.WriteLine("Possible space positions are ({0} total count):", sentences.Count);
                    Console.WriteLine("See output_{0}.txt for found combinations", _currentInputString);

                    if(!_isOverSized)
                    {
                        WriteOutput(sentences, _outputPath);
                    }

                    Console.WriteLine("Used time: {0} ms \n", timeMeasure.ElapsedMilliseconds);
                }
                else
                {
                    Console.WriteLine("Input string can't be broken.\n");
                }
            }
            Console.ReadLine();
        }

        static void BreakWords(string input, HashSet<String> dictionary, List<String> sentences)
        {
            var Dp = new int[input.Length, input.Length+1];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j <= input.Length; j++)
                {
                    var prefix = input.Substring(i, j-i);
                    Dp[i, j] = dictionary.Contains(prefix) ? prefix.Length : 0;
                }
            }

            try
            {
                CompleteSentences(0, Dp, Dp.GetLength(0), Dp.GetLength(1), input, sentences, "");
            }
            catch(OutOfMemoryException outOfMemory)
            {
                Console.WriteLine("{0}. In output not all combinations are present.", outOfMemory.Message);
            }
        }

        static void CompleteSentences(int currentRow, int[,] Dp, int row, int col, string input, List<string> sentences, string sentence)
        {
            for (int i = currentRow; i < row; )
            {
                for(int j = i + 1; j < col; j++)
                {
                    if(Dp[i,j] != 0)
                    {
                        var word = input.Substring(i, Dp[i, j]);
                        var length = (sentence + word).Replace(" ", string.Empty).Length;

                        if (input.Length <= length)
                        {
                            sentence += word;
                            sentences.Add(sentence);

                            //If maximum number reached, write to output and continue
                            if(sentences.Count == MaxSentenceCountInOneBuffer)
                            {
                                WriteOutputAppend(sentences, _outputPath);
                                _isOverSized = true;
                                sentences.Clear();
                            }
                            return;
                        }
                        else
                        {
                            CompleteSentences(length, Dp, row, col, input, sentences, sentence + word + " ");
                        }
                    }
                }
                return;
            }
        }

        static List<string> LoadInputText(string path)
        {
            var inputText = new List<string>();

            if (!File.Exists(path))
            {
                inputText.Add(DefaultCheckString);
                return inputText;
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    
                    string readLine = streamReader.ReadLine();

                    while (readLine != null)
                    {   
                        inputText.Add(readLine);
                        readLine = streamReader.ReadLine();
                    } 
                }
            }
            return inputText;
        }

        static void WriteOutput(List<string> sentence, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    for(int i=0; i<sentence.Count; i++)
                    {
                        try
                        {
                            streamWriter.WriteLine(sentence[i]);
                        }
                        catch (OutOfMemoryException)
                        {
                            break;
                        }
                    }
                }
            }
        }

        static void WriteOutputAppend(List<string> sentence, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    for (int i = 0; i < sentence.Count; i++)
                    {
                        try
                        {
                            streamWriter.WriteLine(sentence[i]);
                        }
                        catch (OutOfMemoryException)
                        {
                            break;
                        }
                    }
                }
            }
        }

        static HashSet<string> LoadDictionary(string fullPath)
        {
            var dictionary = new HashSet<string>();

            using (FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string word = sr.ReadLine();
                    while (word != null)
                    {
                        dictionary.Add(word);
                        word = sr.ReadLine();
                    }
                }
            }
            return dictionary;
        }

    }
}
