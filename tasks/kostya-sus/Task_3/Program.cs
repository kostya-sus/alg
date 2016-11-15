using System;

namespace ALG_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            JustifyTexts pro = new JustifyTexts();

            Console.WriteLine("Input some text...");
            string str = Console.ReadLine();
            
            Console.WriteLine("Input size of Line");
            int line = Int32.Parse(Console.ReadLine());
            string[] word =str.Split(' ');
            
            Console.WriteLine(pro.JustifyText(word, line));
            Console.ReadLine();
        }
       
    }
}
