using System;
using System.Collections.Generic;

namespace LineBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Wikipedia is a free online encyclopedia that, by default, allows its users to edit any article Wikipedia is the largest and most popular general reference work on the Internet and is ranked among the ten most popular websites.";
            int lineLength = 42;

            PrintText(text, lineLength);
            Console.WriteLine();

            lineLength = 35;
            PrintText(text, lineLength);
            Console.WriteLine();

            lineLength = 30;
            PrintText(text, lineLength);

            Console.ReadLine();
        }
        static void PrintText(string text, int lineLength)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Line length is {0}", lineLength);
            Console.ResetColor();

            int[] breakPlaces = GetBreakPlaces(text);
            int[] breaks = GetPrefferedBreakPositions(breakPlaces, lineLength);

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                if (breaks[j] == i)
                {
                    Console.WriteLine();
                    j++;
                }
            }
        }

        static int[] GetBreakPlaces(string text)
        {
            List<int> breakPlaces = new List<int>();
            breakPlaces.Add(0);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    breakPlaces.Add(i);
                }
            }
            breakPlaces.Add(text.Length - 1);
            return breakPlaces.ToArray();
        }
        static int[] GetPrefferedBreakPositions(int[] breakPlaces, int lineLength)
        {
            int[] badnessAtBreak = new int[breakPlaces.Length];
            int[] preferedBreaks = new int[breakPlaces.Length];
            for (int i = 1; i < breakPlaces.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    int wordsLength = breakPlaces[i] - breakPlaces[j];
                    if (wordsLength > lineLength)
                    {
                        if (j == i - 1)
                            throw new ArgumentException("Word is longer than line");
                        break;
                    }
                    int badness = Badness(lineLength, wordsLength);
                    if ((badness < badnessAtBreak[i]) || (j == i - 1))
                    {
                        badnessAtBreak[i] = badness;
                        preferedBreaks[i] = j;
                    }
                }
            }
            List<int> breakPositions = new List<int>();
            int k = preferedBreaks.Length - 1;
            while (k > 0)
            {
                breakPositions.Add(breakPlaces[k]);
                k = preferedBreaks[k];
            }
            breakPositions.Reverse();
            return breakPositions.ToArray();
        }
        static int Badness(int lineLength, int wordsLength)
        {
            return (int)Math.Pow((lineLength - wordsLength), 3);
        }
        

    }
}
