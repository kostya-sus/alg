using System;


namespace HW1_ALG
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary d = new Dictionary();
            string[] dictionary = d.ParseDictionary();

            Console.WriteLine("Enter statement");
            string input = Console.ReadLine();

            WordDivider w = new WordDivider(input, dictionary);
            w.WordsEmpty();
            Console.ReadLine();
        }
    }
}
