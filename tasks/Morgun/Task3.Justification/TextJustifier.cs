using System;
using System.Collections.Generic;

namespace TextJustification
{
    public class TextJustifier
    {
        private const int INF = int.MaxValue;
        private const int AddSpace = 1;
        private const int MinimumCost = 0;
        private const int WordIndex = 1;
        private const int ParameterCount = 2;

        private int _pageWidth;
        private int _power;
        private int[,] _costAndIndexTable;

        private int[,] _costTable;
        private List<string> _words;
        private List<string> _output;

        public TextJustifier(string inputText)
        {
            _words = new List<string>();
            SplitTextToWords(inputText, _words);

            _costTable = new int[_words.Count, _words.Count];
            _costAndIndexTable = new int[_words.Count, ParameterCount];
            _output = new List<string>();
        }

        public List<string> DPSolution(int pageWidth, int power)
        { 
            _pageWidth = pageWidth;

            for(int i=0; i<_words.Count; i++)
            {
                if(_words[i].Length > pageWidth)
                {
                    throw new ArgumentException("Can't be justified! Page width too small.");
                }
            }

            _power = power;

            InitCostTable(ref _costTable);
            FillCostTable();
            GetWordsPositions();

            return GetOutput();
        }

        public List<string> GetCostTable()
        {
            var row = _costTable.GetLength(0);
            var col = _costTable.GetLength(1);

            var fields = new List<string>();

            for(int i=0; i<row; i++)
            {
                var line = string.Empty;

                for(int j=0; j<col; j++)
                {
                    if(_costTable[i,j] == INF)
                    {
                        line += "INF\t";
                    }
                    else
                    {
                        line += string.Format("{0}\t", _costTable[i, j]);
                    }                    
                }
                fields.Add(line);
            }
            return fields;
        }

        private void SplitTextToWords(string text, List<string> words)
        {
            var splittedWords = text.Trim().Split(' ');
            foreach (var word in splittedWords)
            {
                words.Add(word);
            }
        }

        private void FillCostTable()
        {
            for (int i = 0; i < _words.Count; i++)
            {
                var totalWidth = 0;

                for (int j = i; j < _words.Count; j++)
                {
                    totalWidth += _words[j].Length;
                    totalWidth += totalWidth == _words[i].Length ? 0 : AddSpace;

                    _costTable[i, j] = totalWidth > _pageWidth ? INF : (int)Math.Pow(_pageWidth - totalWidth, _power);

                    if (_costTable[i, j] == INF)
                    {
                        break;
                    }
                }
            }
        }

        private void GetWordsPositions()
        {
            var n = _words.Count - 1;
            string[] sen = new string[_words.Count];

            for (int i = n; i >= 0; i--)
            {
                _costAndIndexTable[i, MinimumCost] = _costTable[i, n];
                _costAndIndexTable[i, WordIndex] = n + 1;

                for (int j = n; j > i; j--)
                {
                    if (_costTable[i, j - 1] == INF)
                    {
                        continue;
                    }

                    if (_costAndIndexTable[i, MinimumCost] > _costAndIndexTable[j, MinimumCost] + _costTable[i, j - 1])
                    {
                        _costAndIndexTable[i, MinimumCost] = _costAndIndexTable[j, MinimumCost] + _costTable[i, j - 1];
                        _costAndIndexTable[i, WordIndex] = j;
                    }
                }
            }
        }

        private List<string> GetOutput()
        {
            int i = 0;
            int j = 0;
            
            do
            {
                j = _costAndIndexTable[i, WordIndex];
                var line = "";
                for (int k = i; k < j; k++)
                {
                    line += _words[k] + " ";
                }
                _output.Add(line);
                i = j;
            } while (j < _words.Count);

            return _output;
        }

        private void InitCostTable(ref int[,] costTable)
        {
            var row = costTable.GetLength(0);
            var col = costTable.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    costTable[i, j] = INF;
                }
            }
        }

    }
}
