using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary(@".\dict_en.txt", "abactorabashedsublativesubline");
            dictionary.LoadInArray();
            Console.WriteLine(dictionary.GetResult());
            Console.ReadKey();
        }
    }
}
