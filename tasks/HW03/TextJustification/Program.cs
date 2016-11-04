using System;

namespace TextJustification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------- Text Justification! --------------");
            Console.WriteLine("\nIncoming text is interpreted as an array of words!\n");

            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            Console.Write("Enter the line width: ");
            string lineWidth = Console.ReadLine();

            string[] words = text.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int width;
            int.TryParse(lineWidth, out width);

            string justifiedText = TextJustification.Justify(words, width);
            
            Console.WriteLine("\nText:\n{0}", justifiedText);
            Console.ReadLine();
        }
    }
}
