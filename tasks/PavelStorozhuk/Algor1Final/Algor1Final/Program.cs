using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algor1Final
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary dictionary = new MyDictionary(354969,@".\dict_en.txt");
            dictionary.Load();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine(TextSegmintation.WordSegmintaion("abactorabashedsublativesubline",dictionary));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
