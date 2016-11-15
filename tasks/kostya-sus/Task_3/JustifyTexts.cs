using System;

using System.Text;


namespace ALG_3_1
{
    class JustifyTexts
    {
        public string JustifyText(string[] str, int sizeOfLine)
        {
            foreach (var w in str)
            {
                if (w.Length < sizeOfLine)
                {
                    return "Error word bigger then line lenght";
                 
                }

            }

            var size = str.Length;
            int[,] wordsCost = new int[size, size];

            for (int i = 0; i < size; ++i)
            {
                wordsCost[i, i] = sizeOfLine - str[i].Length;
                for (int j = i + 1; j < size; ++j)
                {
                    wordsCost[i, j] = wordsCost[i, j - 1] - str[j].Length - 1;
                }
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = i; j < size; ++j)
                {
                    if (wordsCost[i, j] < 0)
                    {
                        wordsCost[i, j] = int.MaxValue;
                    }
                    else
                    {
                        wordsCost[i, j] = (int)Math.Pow(wordsCost[i, j], 2);
                    }
                }
            }

           
            int[] minWordsCost = new int[size];
            int[] result = new int[size];

            for (int i = size - 1; i >= 0; --i)
            {
                minWordsCost[i] = wordsCost[i, size - 1];
                result[i] = size;
                for (int j = size - 1; j > i; --j)
                {
                    if (wordsCost[i, j - 1] == int.MaxValue)
                    {
                        continue;
                    }
                    if (minWordsCost[i] > minWordsCost[j] + wordsCost[i, j - 1])
                    {
                        minWordsCost[i] = minWordsCost[j] + wordsCost[i, j - 1];
                        result[i] = j;
                    }
                }
            }

            int n = 0,
                m;
            var resText = new StringBuilder();
            do
            {
                m = result[n];
                for (int q = n; q < m; ++q)
                {
                    resText.Append(str[q] + " ");
                }
                resText.Append("\n");
                n = m;
            }
            while (m < size);

            return resText.ToString();



        }

    }
}
