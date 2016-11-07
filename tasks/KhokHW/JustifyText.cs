using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustifyText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input some text...");
            string str = Console.ReadLine();
            List<string> words = new List<string>();

            ///Separation of words
            string temp = string.Empty;
            int size = str.Length;
            for(int i = 0; i < size; ++i)
            {
                if (str[i] != ' ')
                {
                    temp += str[i];
                }
                else if(temp != string.Empty)
                {
                    words.Add(temp);
                    temp = string.Empty;
                }
            }

            if (temp != string.Empty)
                words.Add(temp);

            Console.WriteLine();
            Console.WriteLine(JustifyText(words.ToArray(), 15));
        }

        public static string JustifyText(string[] str, int sizeOfLine)
        {
            int size = str.Length;
            int[,] costOfWords = new int[size, size];
            ///These steps are used to calculate the 
            ///costs of putting wors in one line
            for(int i = 0; i < size; ++i)
            {
                costOfWords[i, i] = sizeOfLine - str[i].Length;
                for(int j = i + 1; j < size; ++j)
                    costOfWords[i, j] = costOfWords[i,j-1] - str[j].Length - 1;
            }

            for(int i = 0; i < size; ++i)
            {
                for(int j = i; j < size; ++j)
                {
                    if (costOfWords[i, j] < 0)
                        costOfWords[i, j] = int.MaxValue;
                    else
                        costOfWords[i, j] = (int)Math.Pow(costOfWords[i, j], 2);
                }
            }
            ///Here we try to find the best words positions
            int[] minCostOfWords = new int[size];
            int[] result = new int[size];
            for(int i = size-1; i >= 0; --i)
            {
                minCostOfWords[i] = costOfWords[i, size - 1];
                result[i] = size;
                for(int j = size-1; j > i; --j)
                {
                    if (costOfWords[i, j-1] == int.MaxValue)
                        continue;

                    if (minCostOfWords[i] > minCostOfWords[j] + costOfWords[i,j - 1])
                    {
                        minCostOfWords[i] = minCostOfWords[j] + costOfWords[i,j - 1];
                        result[i] = j;
                    }
                }
            }

            return GetResultantString(result, str, size);
        }

        private static string GetResultantString(int[] result, string[] str, int size)
        {
            int i = 0, j;
            StringBuilder ResText = new StringBuilder();
            do
            {
                j = result[i];
                for (int q = i; q < j; ++q)
                    ResText.Append(str[q] + " ");

                ResText.Append("\n");
                i = j;
            }
            while (j < size);

            return ResText.ToString();
        }
    }
}
