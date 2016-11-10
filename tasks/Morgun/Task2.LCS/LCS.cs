using System;
using System.Collections.Generic;
using System.IO;

namespace LCS
{
    public class LCS
    {
        private const int MaxSequencesCount = 2;
        private const string QuadroSpace = "    ";

        private int[] _firstSequence;
        private int[] _secondSequence;
        private int[,] _tableLcs;
        private string _tableLcsPath;

        private static int[] _defaultFirstSequence = { 0, 1, 2, 1, 3, 0, 1 };
        private static int[] _defaultSecondSequence = { 1, 3, 2, 0, 1, 0 };

        public int[] FirstSequence
        {
            get { return _firstSequence; }
        }

        public int[] SecondSequence
        {
            get { return _secondSequence; }
        }

        public int MaxLCS
        {
            get { return _tableLcs[_firstSequence.Length, _secondSequence.Length]; }
        }

        public string OneOfLCS
        {
            get { return _tableLcsPath; }
        }

        public LCS(string path)
        {
            LoadInputSequences(path);
            _tableLcs = new int[_firstSequence.Length + 1, _secondSequence.Length + 1];
            FillTableLCS(_firstSequence, _secondSequence);
            FindLCSPath(_tableLcs, _firstSequence, _secondSequence, _firstSequence.Length, _secondSequence.Length);
        }

        public void PrintSequnce(int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write("{0} ", sequence[i]);
            }
            Console.WriteLine();
        }

        public void PrintTable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(QuadroSpace);
            PrintSequnce(_secondSequence);

            var currentCursorTop = Console.CursorTop;

            for (int i = 0; i < _firstSequence.Length; i++)
            {
                Console.SetCursorPosition(0, ++currentCursorTop);
                Console.Write("{0} ", _firstSequence[i]);
            }
            Console.ResetColor();

            var row = _tableLcs.GetLength(0);
            var col = _tableLcs.GetLength(1);
            //Return cursor to the correct position in order to print correct table
            Console.CursorTop -= _firstSequence.Length;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.SetCursorPosition(2 + j * 2, Console.CursorTop);
                    Console.Write("{0} ", _tableLcs[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void FillTableLCS(int[] X, int[] Y)
        {
            for (int i = 1; i <= X.Length; i++)
            {
                for (int j = 1; j <= Y.Length; j++)
                {
                    _tableLcs[i, j] = X[i - 1] == Y[j - 1] ? _tableLcs[i - 1, j - 1] + 1 : Math.Max(_tableLcs[i, j - 1], _tableLcs[i - 1, j]);
                }
            }
        }

        private void FindLCSPath(int[,] tableLCS, int[] X, int[] Y, int i, int j)
        {
            if (i <= 0 || j <= 0)
            {
                return;
            }
            else
            {
                if (X[i-1] == Y[j-1])
                {
                    _tableLcsPath = string.Format("{0} {1}",X[i-1], _tableLcsPath);
                    FindLCSPath(tableLCS, X, Y, --i, --j);
                }
                else
                {
                    if (tableLCS[i - 1, j] > tableLCS[i, j - 1])
                    {
                        FindLCSPath(tableLCS, X, Y, --i, j);
                    }
                    else
                    {
                        FindLCSPath(tableLCS, X, Y, i, --j);
                    }
                }
            }
            return;
        }

        private void LoadInputSequences(string path)
        {
            var sequences = new List<int[]>();

            if (!File.Exists(path))
            {
                _firstSequence = _defaultFirstSequence;
                _secondSequence = _defaultSecondSequence;
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    for (int i = 0; i < MaxSequencesCount; i++)
                    {
                        string[] sequence = streamReader.ReadLine().Trim().Split(' ', ',', '.');
                        var sequenceArray = new int[sequence.Length];

                        for (int j = 0; j < sequence.Length; j++)
                        {
                            sequenceArray[j] = int.Parse(sequence[j]);
                        }
                        sequences.Add(sequenceArray);
                    }
                }
            }
            _firstSequence = sequences[0];
            _secondSequence = sequences[1];
        }
    }
}
