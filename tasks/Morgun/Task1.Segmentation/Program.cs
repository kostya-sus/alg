using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordDelimeter
{
    class Program
    {
        private const string DefaultDictPath = "dict_en.txt";
        //private const string DefaultCheckString = "iamace";
        //private const string DefaultCheckString = "helloworld";
        private const string DefaultCheckString = "catsanddog";
        //private const string DefaultCheckString = "goodluck";
        //private const string DefaultCheckString = "seesunweather";
        //private const string DefaultCheckString = "tellmethetruth";
        private static List<String> _sentences;

        static void Main(string[] args)
        {
            Stopwatch timeMeasure = new Stopwatch();

            Console.WriteLine("The input string is: ", DefaultCheckString);
  
            timeMeasure.Start();
            _sentences = BreakWords(DefaultCheckString, Dictionary.Load(DefaultDictPath), _sentences);
            timeMeasure.Stop();

            Console.WriteLine("Possible space positions are ({0} total count): \n", _sentences.Count);
            PrintSentences(_sentences);
            Console.WriteLine("\nWith {0} ms passed", timeMeasure.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static List<String> BreakWords(string input, HashSet<String> dictionary, List<String> sentences)
        {
            var wordList = new List<String>[input.Length + 1];
            wordList[0] = new List<String>();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j <= input.Length; j++)
                {
                    var prefix = input.Substring(i, j-i);
                    if (dictionary.Contains(prefix))
                    {
                        if (wordList[j] == null)
                        {
                            wordList[j] = new List<String>();
                        }
                        wordList[j].Add(prefix);
                    }
                }
            }

            sentences = new List<String>();
            CompleteSentences(wordList, sentences, new List<String>(), input.Length);

            return sentences;
        }

        static void CompleteSentences(List<String>[] wordList, List<String> sentences, List<String> temporary, int index)
        {
            if(index <= 0)
            {
                var sentenceBuild = temporary[temporary.Count - 1];
                for(int i=temporary.Count - 2; i>=0; i--)
                {
                    sentenceBuild += String.Format(" {0}", temporary[i]);
                }
                sentences.Add(sentenceBuild);
                return;
            }

            foreach(var word in wordList[index])
            {
                temporary.Add(word);
                CompleteSentences(wordList, sentences, temporary, index - word.Length);
                temporary.RemoveAt(temporary.Count - 1);
            }
        }

        static void PrintSentences(List<String> sentences)
        {
            foreach(var sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }

    }
}
