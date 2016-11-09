using System;
using System.Collections.Generic;
using System.IO;

namespace SplitTheString
{
    internal class Program
    {
        private const string PathToFile = @"Dictionary/dict_en.txt";
        private const string inputString = "catsanddog";
        private const string Combinations = "There are {0} different combinations :";

        private static void Main(string[] args)
        {
            //HashSet<string> dictionary = new HashSet<string>(File.ReadAllLines(PathToFile));

            HashSet<string> dictionary = new HashSet<string>(){ "cat", "cats", "and", "sand", "dog" };

            FindAllVariants fb = new FindAllVariants();
            
            var allVariants = fb.FindSeparateWords(inputString, dictionary);

            Console.WriteLine(Combinations ,allVariants.Count);
            Console.WriteLine();
            foreach (var variant in allVariants)
            {
                Console.WriteLine(variant);
            }
        }


    }
}

