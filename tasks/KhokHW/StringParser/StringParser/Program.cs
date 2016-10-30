using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary d = new Dictionary();
            string[] dictionary = d.GetWords();
            Console.WriteLine("Enter string.");
            string str = Console.ReadLine();
            WordDivider w = new WordDivider(str, dictionary);
            w.WordsBrake();
        }
    }
}
