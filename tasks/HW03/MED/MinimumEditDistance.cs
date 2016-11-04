using System;
using System.Collections.Generic;

namespace MED
{
    public static class MinimumEditDistance
    {
        private static string _sequence1;
        private static string _sequence2;

        private static int[,] _lengths;

        private static int _med;
        private static List<string> _operations;
        private static List<char[]> _pairs;


        public static int GetMED { get { return _med; } }

        public static List<char[]> GetPairsOfLetters { get { return _pairs; } }

        public static List<string> GetOperations { get { return _operations; } } 


        public static void Ininitialization(string sequence1, string sequence2)
        {
            Validation(sequence1, sequence2);

            _sequence1 = sequence1;
            _sequence2 = sequence2;

            FillMatrixLengths();

            _med = _lengths[_sequence1.Length, _sequence2.Length];

            ConstructionEditedLine();
        }
        
        private static void FillMatrixLengths()
        {
            int n = _sequence1.Length + 1;
            int m = _sequence2.Length + 1;

            _lengths = new int[n,m];

            for (int i = 0; i < n; i++)
            {
                _lengths[i, 0] = i;
            }

            for (int i = 0; i < m; i++)
            {
                _lengths[0, i] = i;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    if (_sequence1[i - 1] == _sequence2[j - 1])
                    {
                        _lengths[i, j] = _lengths[i - 1, j - 1];
                    }
                    else
                    {
                        _lengths[i, j] = 1 + MIN(_lengths[i - 1, j - 1], _lengths[i - 1, j], _lengths[i, j - 1]);
                    }
                }
            }
        }

        private static void ConstructionEditedLine()
        {
            _pairs = new List<char[]>();
            _operations = new List<string>();

            int i = _sequence1.Length;
            int j = _sequence2.Length;

            while (true)
            {
                char[] operation = new char[2];

                if (i == 0 && j == 0)
                {
                    break;
                }

                if (i != 0 && j != 0 && _sequence1[i - 1] == _sequence2[j - 1])
                {
                    operation[0] = operation[1] = _sequence2[j - 1];
                    _pairs.Add(operation);

                    i = i - 1;
                    j = j - 1;
                }
                else if (i != 0 && j != 0 && _lengths[i, j] == _lengths[i - 1, j - 1] + 1)
                {
                    _operations.Add(string.Format("{0} -> {1}", _sequence2[j - 1], _sequence1[i - 1]));

                    operation[0] = _sequence2[j - 1];
                    operation[1] = _sequence1[i - 1];
                    _pairs.Add(operation);

                    i = i - 1;
                    j = j - 1;
                }
                else if (i != 0 && _lengths[i, j] == _lengths[i - 1, j] + 1)
                {
                    _operations.Add(string.Format("{0} -> insert", _sequence1[i - 1]));

                    operation[0] = '-';
                    operation[1] = _sequence1[i - 1];
                    _pairs.Add(operation);

                    i = i - 1;
                }
                else if (j != 0 && _lengths[i, j] == _lengths[i, j - 1] + 1)
                {
                    _operations.Add(string.Format("{0} -> delete", _sequence2[j - 1]));

                    operation[0] = _sequence2[j - 1];
                    operation[1] = '-';
                    _pairs.Add(operation);

                    j = j - 1;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private static int MIN(int num1, int num2, int num3)
        {
            int min = Math.Min(num1, num2);
            return Math.Min(min, num3);
        }

        private static void Validation(string sequence1, string sequence2)
        {
            if (string.IsNullOrEmpty(sequence1) || string.IsNullOrEmpty(sequence2))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
