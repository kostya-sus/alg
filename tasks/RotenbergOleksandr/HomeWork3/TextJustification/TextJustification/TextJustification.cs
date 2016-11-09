using System;
using System.Linq;

namespace TextJustification
{
    internal class TextJustification
    {
        private static void Main(string[] args)
        {
            const string inputText = "Perform an HTTP (Ajax) request.";

            const int pageWidth = 10;

            string[] inputTextArray = inputText.Split(' ');
            

            ValidateString(inputTextArray,pageWidth);

            var badness = CountBadness(inputTextArray, pageWidth);
            TextJustify(inputTextArray, badness);
        }

        private static int[,] CountBadness(string[] inputTextArray, int pageWidth)
        {
            int[,] textWeigthArray = new int[inputTextArray.Length, inputTextArray.Length];

            for (int i = 0; i < inputTextArray.Length; i++)
            {
                for (int j = i; j < inputTextArray.Length; j++)
                {
                    var lineWidth = CountLineWidth(inputTextArray, i, j);

                    if (lineWidth < pageWidth)
                    {
                        textWeigthArray[i, j] = (int) Math.Pow(pageWidth - lineWidth + j - i, 3);
                    }
                    else
                    {
                        textWeigthArray[i, j] = Int32.MaxValue;
                    }
                }
            }

            return textWeigthArray;
        }

        private static int CountLineWidth(string[] inputTextArray, int startIndex, int endIndex)
        {
            var lineWidth = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                lineWidth += inputTextArray[i].Length;
            }
            return lineWidth;
        }

        private static void TextJustify(string[] inputTextArray, int[,] justifyArr)
        {
            int[] c = new int[inputTextArray.Length];
            int[] res = new int[inputTextArray.Length];

            for (int i = inputTextArray.Length - 1; i >= 0; i--)
            {
                c[i] = justifyArr[i, inputTextArray.Length - 1];
                res[i] = inputTextArray.Length;
                for (int j = inputTextArray.Length - 1; j > i; j--)
                {
                    if (justifyArr[i, j - 1] != Int32.MaxValue && (c[i] > c[j] + justifyArr[i, j - 1]))
                    {
                        c[i] = c[j] + justifyArr[i, j - 1];
                        res[i] = j;
                    }
                }
            }

            OutputText(res, inputTextArray);
        }

        private static void OutputText(int[] result, string[] words)
        {
            int i = 0;
            int j = 0;
            do
            {
                j = result[i];
                for (int k = i; k < j; k++)
                {
                    Console.Write(words[k] + " ");
                }
                Console.WriteLine();
                i = j;
            } while (j < words.Length);
        }

        private static void ValidateString(string[] inputTextArray, int pageWidth)
        {
            if (inputTextArray.Any(t => t.Length > pageWidth))
            {
                throw new ArgumentException("Word is longer than page width");
            }
        }
    }
}
