using System;

namespace TestJustification
{
    class Program
    {
        static int TotalLength(int[] lengths, int i, int j)
        {
            int totalLength = -1;
            for (; i <= j; i++)
            {
                totalLength += lengths[i] + 1;
            }

            return totalLength;
        }

        static int Badness(int width, int totalLength)
        {
            return (int) Math.Pow(width - totalLength, 3);
        }

        static int[] CalculateLengths(int maxWidth, string[] lines)
        {
            int[] lengths = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                lengths[i] = lines[i].Length;
                if (lengths[i] > maxWidth)
                {
                    throw new Exception(string.Format("Word {0} is longer then {1} symbols.", lines[i], lengths[i]));
                }
            }

            return lengths;
        }

        static int[,] CalculateBadnessesMatrix(int maxWidth, int[] lengths)
        {
            int n = lengths.Length;
            int[,] badnesses = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = i; j < n; j++)
                {
                    int totalLength = TotalLength(lengths, i, j);
                    badnesses[i, j] = totalLength > maxWidth ? int.MaxValue : Badness(maxWidth, totalLength);
                }
            return badnesses;
        }

        static int[] FindBestJutification(int[,] badnesses)
        {
            int n = badnesses.GetLength(0);
            int[] resultBadnesses = new int[n + 1];
            resultBadnesses[n] = 0;
            int[] resultIndexes = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                int minJ = i;
                for (int j = i; j < n && badnesses[i, j] != int.MaxValue; j++)
                {
                    if (badnesses[i, j] + resultBadnesses[j + 1] < badnesses[i, minJ] + resultBadnesses[minJ + 1])
                    {
                        minJ = j;
                    }
                }
                resultBadnesses[i] = badnesses[i, minJ] + resultBadnesses[minJ + 1];
                resultIndexes[i] = minJ + 1;
            }

            Console.WriteLine("Minimum total badness: {0}", resultBadnesses[0]);

            return resultIndexes;
        }

        static void ViewResult(string[] lines, int[] indexes)
        {
            int i = 0;
            do
            {
                for (int j = i; j < indexes[i]; j++)
                {
                    Console.Write("{0} ", lines[j]);
                }

                Console.WriteLine();
            } while ((i = indexes[i]) < lines.Length);
        }

        static void Justificate(int maxWidth, string[] lines)
        {
            int[] lengths = CalculateLengths(maxWidth, lines);

            int[,] badnesses = CalculateBadnessesMatrix(maxWidth, lengths);

            int[] results = FindBestJutification(badnesses);
            
            Console.WriteLine("Results:");

            ViewResult(lines, results);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter maximum line width: ");
            int width;
            if (!int.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("You should enter numeric value here!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter text for justification(each word should be not longer then {0} symbols).", width);
            string text = Console.ReadLine();
            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Text couldn`t be empty!");
                Console.ReadKey();
                return;
            }

            string[] lines = text.Split(' ');

            Justificate(width, lines);

            Console.ReadKey();
        }
    }
}