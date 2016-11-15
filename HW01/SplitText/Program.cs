using System;
using System.Collections.Generic;

namespace SplitText
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filepath = "../../../dict_en.txt";

            StringSegmentation segmentation = new StringSegmentation();

            segmentation.SetDictionaryFromFile(filepath);

            Console.Write("Enter the text without backspace: ");
            string text = Console.ReadLine();

            List<string> partitions = segmentation.Segmentation(text);

            foreach (var option in partitions)
            {
                Console.WriteLine(option);
            }

            Console.ReadLine();
        }
    }
}
