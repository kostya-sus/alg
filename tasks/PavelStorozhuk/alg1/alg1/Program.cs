using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Threading;

namespace alg1
{
    class Program
    {
        static UInt32 getNumberOfDigits(UInt64 n)
        {
            
            UInt32 result = 1;
            for (; ; )
            {
                Console.WriteLine("step");
                if (n < 10)
                {
                    return result;
                }
                if (n < 100)
                {
                    return result + 1;
                }
                if (n < 1000)
                {
                    return result + 2;
                }
                if (n < 10000)
                {
                    return result + 3;
                }
                n /= 10000;
                result += 4;
              
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("3");
            stopwatch.Start();
            getNumberOfDigits(123);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.WriteLine("------------");
            Console.WriteLine("4");
            getNumberOfDigits(1234);
            Console.WriteLine("------------");
            Console.WriteLine("5");
            getNumberOfDigits(12345);
            Console.WriteLine("------------");
            Console.WriteLine("6");
            getNumberOfDigits(123456);
            Console.WriteLine("------------");
            Console.WriteLine("7");
            getNumberOfDigits(1234567);
            Console.WriteLine("------------");
            Console.WriteLine("8");
            getNumberOfDigits(12345678);
            Console.WriteLine("------------");
            Console.WriteLine("9");
            getNumberOfDigits(123456789);
            Console.WriteLine("------------");
            Console.WriteLine("10");
            getNumberOfDigits(1234567890);
            Console.WriteLine("------------");
            Console.ReadKey();
        }
    }
}
