using System;
using System.Collections.Generic;

namespace WordDelimeter
{
    public class WordDelimeter
    {
        private const int MaxSentenceCountInOneBuffer = 100000;

        private string _outputPath;

        private bool _isOverSized = false;
        
        private List<string> _sentences;
        private Dictionary _dictionary;

        public int CombinationCount
        {
            get { return _sentences.Count; }
        }

        public bool OverSized
        {
            get { return _isOverSized; }
        }

        public WordDelimeter(Dictionary dictionary, string outputPath = null)
        {
            _dictionary = dictionary;
            _outputPath = outputPath;
            _sentences = new List<string>();
        }

        public List<string> GetSentences(string inputText, string outputPath = null)
        {
            _outputPath = outputPath;
            _isOverSized = false;
            _sentences.Clear();

            if (_dictionary.Contains(inputText))
            {
                _sentences.Add(inputText);
                return _sentences;
            }

            BreakWords(inputText);

            if(_sentences.Count == 0)
            {
                throw new Exception("Can't break this string into separate words!");
            }

            return _sentences;
        }

        private void BreakWords(string inputText)
        {
            var Dp = new int[inputText.Length, inputText.Length + 1];

            for (int i = 0; i < inputText.Length; i++)
            {
                for (int j = i + 1; j <= inputText.Length; j++)
                {
                    var prefix = inputText.Substring(i, j - i);
                    Dp[i, j] = _dictionary.Contains(prefix) ? prefix.Length : 0;
                }
            }

            try
            {
                CompleteSentences(0, Dp, Dp.GetLength(0), Dp.GetLength(1), inputText, _sentences, "");
            }
            catch (OutOfMemoryException outOfMemory)
            {
                Console.WriteLine("{0}. In output not all combinations are present.", outOfMemory.Message);
            }
        }

        private void CompleteSentences(int currentRow, int[,] Dp, int row, int col, string input, List<string> sentences, string sentence)
        {
            for (int i = currentRow; i < row;)
            {
                for (int j = i + 1; j < col; j++)
                {
                    if (Dp[i, j] != 0)
                    {
                        var word = input.Substring(i, Dp[i, j]);
                        var length = (sentence + word).Replace(" ", string.Empty).Length;

                        if (input.Length <= length)
                        {
                            sentence += word;
                            sentences.Add(sentence);

                            //If maximum number reached, write to output and continue
                            if ((sentences.Count == MaxSentenceCountInOneBuffer) && (_outputPath != null))
                            {
                                DataManager.WriteOutputAppend(sentences, _outputPath);
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

    }
}
