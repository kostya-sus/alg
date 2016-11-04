using System;

namespace TextJustification
{
    public static class TextJustification
    {
        private static string[] _words;
        private static int _width;

        private static int[,] _cost;
        private static int[] _minCost;
        private static int[] _justify;

        public static int GetMinCost { get { return _minCost.Length == 0 ? 0 : _minCost[0]; } }

        public static string Justify(string[] words, int width)
        {
            Validation(words, width);

            _words = words;
            _width = width;

            FillMatrixCost();
            FindMinCostAndResult();

            return ConstructionResultText();
        }

        private static void FillMatrixCost()
        {
            int n = _words.Length;

            _cost = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                _cost[i, i] = _width - _words[i].Length;

                for (int j = i + 1; j < n; j++)
                {
                    _cost[i, j] = _cost[i, j - 1] - _words[j].Length - 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    _cost[i, j] = _cost[i, j] < 0 ? int.MaxValue : (int) Math.Pow(_cost[i, j], 3);
                }
            }
        }

        private static void FindMinCostAndResult()
        {
            int n = _words.Length;

            _minCost = new int[n];
            _justify = new int[n];

            for (int i = n - 1; i >= 0; i--)
            {
                _minCost[i] = _cost[i, n - 1];
                _justify[i] = n;

                for (int j = n - 1; j > i; j--)
                {
                    if (_cost[i, j - 1] == int.MaxValue)
                    {
                        continue;
                    }

                    if (_minCost[i] > _minCost[j] + _cost[i, j - 1])
                    {
                        _minCost[i] =_minCost[j] + _cost[i, j - 1];
                        _justify[i] = j;
                    }
                }
            }
        }

        private static string ConstructionResultText()
        {
            string resText = string.Empty;

            int i = 0;
            int j;

            do
            {
                j = _justify[i];

                for (int k = i; k < j; k++)
                {
                    resText += _words[k] + " ";
                }

                resText += "\n";
                i = j;
            } while (j < _words.Length);

            return resText;
        }

        private static void Validation(string[] words, int width)
        {
            if (words.Length == 0)
            {
                throw new ArgumentException("Argument \"string[] words\" does not contain any values!");
            }

            if (width < 1)
            {
                throw new ArgumentException("Invalid value of the argument \"int width\"!\n" +
                                            "Argument can not be set to less than 1!");
            }

            foreach (var word in words)
            {
                if (width < word.Length)
                {
                    throw new ArgumentException("Invalid value of the argument \"int width\"!\n" +
                                                "Argument can not be set to less than the longest word!");
                }
            }
        }
    }
}
